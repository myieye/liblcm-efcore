using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using SIL.LCModel;

namespace LfSync.LcmModelGenerator
{

    [Generator]
    public class LcmDbSourceGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext generatorContext)
        {
            var xmlPath = generatorContext.AdditionalFiles.First().Path;
            var classModels = LibLcmModelReader.ReadLibLcmModel(xmlPath);
            LcmAnalyzer.LogPotentialBidirectionalNavigationProperties(classModels);
            LcmAnalyzer.LogRelationInfo(classModels);

            var models = new StringBuilder();
            var context = new StringBuilder();
            models.AppendLine(
@"using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SIL.LCModel;
using SIL.LCModel.Core.Cellar;

namespace SIL.LCModel.EFCore.Model;
");
            context.AppendLine(
@"using Microsoft.EntityFrameworkCore;
using SIL.LCModel.EFCore.Model;

namespace SIL.LCModel.EFCore;

public partial class LcmDbContext : DbContext
{");

            foreach (var clazz in classModels.Values)
            {
                if (!clazz.ConvertToInterface && !clazz.Name.Equals(nameof(LcmModelConstants.LfObject)))
                {
                    context.AppendLine(
$@"    public DbSet<{clazz.Name}> {clazz.FriendlyName}s {{ get; set; }}
");
                }
            }

            context.AppendLine(
@"    partial void OnModelCreating_Generated(ModelBuilder builder)
    {");
            foreach (var clazz in classModels)
            {
                var clazzName = clazz.Key;
                if (clazzName.Equals(nameof(LcmModelConstants.LfObject)))
                {
                    context.AppendLine(
$@"        builder.Ignore<{clazzName}>();");
                }
                else if (!clazz.Value.ConvertToInterface)
                {
                    context.AppendLine(
$@"        builder.Entity<{clazzName}>();");
                }
            }

            foreach (var clazz in classModels.Values)
            {
                if (clazz.Docs != null)
                {
                    foreach (var line in clazz.Docs)
                    {
                        models.AppendLine(
$@"/// {line}");
                    }
                }
                var _abstract = clazz.Abstract ? " abstract" : "";
                var _base = clazz.BaseClass?.Name;
                var _interface = clazz.Interface?.Name;
                string _extends = _base == null && _interface == null ? ""
                    : _base != null && _interface != null ? $" : {_base}, {_interface}"
                    : $" : {_base ?? _interface}";
                var _symbolType = clazz.ConvertToInterface ? "interface" : "class";
                models.AppendLine(
$@"public{_abstract} partial {_symbolType} {clazz.Name}{_extends}
{{");
                foreach (var prop in clazz.Properties)
                {
                    var lfTypeName = prop.Type == nameof(LcmModelConstants.LfObject) ? "LfObjectId" : prop.Type;

                    if (prop.Docs != null)
                    {
                        foreach (var line in prop.Docs)
                        {
                            models.AppendLine(
$@"    /// {line}");
                        }
                    }

                    if (!clazz.ConvertToInterface)
                    {
                        if (prop.ValueType == ValueType.Jsonb)
                        {
                            models.AppendLine(
@"    [Column(TypeName = ""jsonb"")]");
                        }
                        else if (prop.ValueType == ValueType.Relation)
                        {
                            var ownerHint = prop.IsOwner ? "Owner" : "Not owner";
                            models.AppendLine(
$@"    /// {ownerHint}");
                            if (prop.Cardinality == Cardinality.One)
                            {
                                string foreignKey = $"{prop.Name}Guid";
                                models.AppendLine(
$@"    public Guid? {foreignKey} {{ get; set; }}");
                                if (prop.IsOwner)
                                {
                                    context.AppendLine(
$@"        builder.Entity<{clazz.Name}>()
        .HasOne(e => e.{prop.Name})
        .WithOne()
        .HasForeignKey<{clazz.Name}>(e => e.{foreignKey})
        .OnDelete(DeleteBehavior.Cascade);");
                                }
                                else
                                {
                                    context.AppendLine(
$@"        builder.Entity<{clazz.Name}>()
        .HasOne(e => e.{prop.Name})
        .WithMany()
        .HasForeignKey(e => e.{foreignKey});");
                                }
                            }
                            else
                            {
                                if (prop.IsOwner)
                                {
                                    string foreignKey = $"{clazz.DbAbbrev ?? clazz.TableName}_{prop.Name}Guid";
                                    context.AppendLine(
$@"        builder.Entity<{clazz.Name}>()
        .HasMany(e => e.{prop.Name})
        .WithOne()
        .HasForeignKey(""{foreignKey}"")
        .OnDelete(DeleteBehavior.Cascade);");
                                }
                                else
                                {
                                    models.AppendLine(
@"    /// M:N");
                                    context.AppendLine(
$@"        builder.Entity<{clazz.Name}>()
        .HasMany(e => e.{prop.Name})
        .WithMany()
        .UsingEntity(j => j.ToTable($""{clazz.FriendlyName}_{prop.Name}_{classModels[prop.Type].TableName}""));");
                                }
                            }
                        }

                        if (prop.IsPrimaryKey)
                        {
                            models.AppendLine(
$@"    [Key]");
                        }
                    }

                    var _type = prop.Cardinality == Cardinality.One ? lfTypeName : $"List<{lfTypeName}>";
                    models.AppendLine(
$@"    public {_type} {prop.Name} {{ get; set; }}
");
                }
                models.AppendLine(
@"}
");
            }

            context.AppendLine(
@"    }
}");

            generatorContext.AddSource($"LcmDbModels.Generated.cs", models.ToString());
            generatorContext.AddSource($"LcmDbContext.Generated.cs", context.ToString());
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // No initialization required for this one
        }
    }
}