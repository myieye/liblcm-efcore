using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using extract;
using LfSync.Data.Db;
using LfSync.Data.LCModel;
using LfSync.LcmModelGenerator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.IdentityModel.Tokens;
using SIL.Extensions;
using SIL.LCModel;
using SIL.WritingSystems;
using static transform.Playground;

namespace transform;

public partial class Program
{
    static partial void HelloFrom(string name);

    public static void Main(string[] args)
    {
        GenerateModels();

        var loadData = Stopwatch.StartNew();
        var project = args.Length > 0 ? args[0] : "Sena 3";
        var extractor = new LcmExtractor(project);
        var cache = extractor.ExtractProject();
        var langProj = cache.LangProject;
        var wsManager = langProj.Services.WritingSystemManager;
        loadData.Stop();
        Utils.Print($"Load data: {loadData.ElapsedMilliseconds}ms");
        var initMapper = Stopwatch.StartNew();
        var mapper = AutoMapperConfig.InitMapper(langProj.Services, wsManager);
        initMapper.Stop();
        Utils.Print($"Init mapper: {initMapper.ElapsedMilliseconds}ms");

        Migrate(cache, mapper);

        ReadAndCompare(cache);

        QueryLexicon(cache);
    }

    private static void GenerateModels()
    {
        var xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MasterLCModel.xml");
        var serializer = new XmlSerializer(typeof(EntireModel));
        using var reader = XmlReader.Create(xmlPath);
        var lcm = (EntireModel)serializer.Deserialize(reader)!;

        var classModels = new Dictionary<string, ClassModel>
        {
            // Properties not in XML
            { nameof(LcmModelConstants.LfObject), LcmModelConstants.LfObject },
            // Not in XML at all, but referenced in XML
            { nameof(LcmModelConstants.LfAnalysis), LcmModelConstants.LfAnalysis },
        };
        var postProcessing = new List<Action>();
        foreach (var clazz in lcm.CellarModule.SelectMany(m => m.@class ?? Array.Empty<@class>()))
        {
            var className = LcmUtils.LcmNameToLf(clazz.id);
            if (classModels.ContainsKey(className))
            {
                continue;
            }
            var baseClassName = clazz.@base == null ? null : LcmUtils.LcmNameToLf(clazz.@base);
            ClassModel? baseClass = baseClassName == null ? null : classModels.GetValueOrDefault(baseClassName);
            var tableName = PickTableName(className, baseClass);

            if (baseClassName != null && baseClass == null)
            {
                postProcessing.Add(() =>
                {
                    var _baseClass = classModels.GetValueOrDefault(baseClassName);
                    var _tableName = PickTableName(className, baseClass);
                    classModels[className].BaseClass = _baseClass;
                    classModels[className].TableName = _tableName;
                });
            }

            classModels.Add(className, new ClassModel
            {
                Name = className,
                Abstract = clazz.@abstract,
                BaseClass = baseClass,
                TableName = tableName,
                Properties = clazz.props.Items?.Select(prop => prop switch
                {
                    basic p => new PropertyModel
                    {
                        Name = p.id,
                        Type = MapValueType(p.sig, out bool isComplexValueType),
                        Order = int.Parse(p.num),
                        Cardinality = Cardinality.One,
                        IsOwner = true,
                        ValueType = isComplexValueType ? ValueType.Jsonb : ValueType.Literal,
                        Docs = GetDocs(p.comment, p.notes),
                    },
                    owning p => new PropertyModel
                    {
                        Name = p.id,
                        Type = LcmUtils.LcmNameToLf(p.sig),
                        Order = int.Parse(p.num),
                        Cardinality = p.card == cardType.atomic ? Cardinality.One : Cardinality.Many,
                        IsOwner = true,
                        ValueType = ValueType.Relation,
                        Docs = GetDocs(p.comment, p.notes),
                    },
                    rel p => new PropertyModel
                    {
                        Name = p.id,
                        Type = LcmUtils.LcmNameToLf(p.sig),
                        Order = int.Parse(p.num),
                        Cardinality = p.card == cardType.atomic ? Cardinality.One : Cardinality.Many,
                        IsOwner = false,
                        ValueType = ValueType.Relation,
                        Docs = GetDocs(p.comment, p.notes),
                    },
                    _ => throw new NotImplementedException(),
                }).ToList() ?? new List<PropertyModel>(),
            });
        }

        foreach (var action in postProcessing)
        {
            action();
        }

        var output = new StringBuilder();
        output.AppendLine("""
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LfSync.Data.LCModel;    

""");

        foreach (var clazzPair in classModels)
        {
            var clazz = clazzPair.Value;
            // CmObject gets its own table or else we can't define a FK-constraint for relations to CmObjects
            //  we stil can't figure out what the object actually is without reading the object type
            // CmMajorObject doesn't get its own table
            // all other sub-hierarchies are grouped into individual tables

            if (!string.IsNullOrWhiteSpace(clazz.TableName))
            {
                output.AppendLine($"""
[Table("{clazz.TableName}")]
""");
            }

            var _abstract = clazz.Abstract ? " abstract" : "";
            var _base = clazz.BaseClass != null ? $" : {clazz.BaseClass.Name}" : "";
            output.AppendLine($$"""
public{{_abstract}} class {{clazz.Name}}{{_base}}
{
""");
            foreach (var prop in clazz.Properties)
            {
                if (prop.Docs != null)
                {
                    foreach (var line in prop.Docs)
                    {
                        output.AppendLine($"""
    /// {line}
""");
                    }
                }

                if (prop.ValueType == ValueType.Jsonb)
                {
                    output.AppendLine("""
    [Column(TypeName = "jsonb")]
""");
                }
                else if (prop.ValueType == ValueType.Relation)
                {
                    if (prop.Cardinality == Cardinality.Many && !prop.IsOwner)
                    {
                        output.AppendLine("""
    // M:N
""");
                    }
                    else
                    {
                        string _fk;
                        if (prop.Cardinality == Cardinality.One)
                        {
                            _fk = $"{prop.Name}{nameof(Guid)}";
                            output.AppendLine($$"""
    public Guid {{_fk}} { get; set; }
""");
                        }
                        else
                        {
                            _fk = $"{clazz.TableName}_{prop.Name}_{nameof(Guid)}";
                            output.AppendLine($"""
    [ForeignKey("{_fk}")]
""");
                        }
                    }
                }

                if (prop.IsPrimaryKey)
                {
                    output.AppendLine($"""
    [Key]
""");
                }

                var _type = prop.Cardinality == Cardinality.One ? prop.Type : $"List<{prop.Type}>";
                output.AppendLine($$"""
    public {{_type}} {{prop.Name}} { get; set; }

""");
            }
            output.AppendLine("""
}

""");
        }

        AnalyzeRelations(classModels);

        /** Output:
        M:N: Owner:[False:False] -- LfPossibility.Restrictions <-> LfPerson.Researchers Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfPossibility.Restrictions <-> LfLocation.PlacesOfResidence Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfPossibility.Restrictions <-> LfPossibility.Positions Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfPossibility.Restrictions <-> LfAnthroItem.OcmRefs Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfPossibility.Restrictions <-> LfSemanticDomain.RelatedDomains Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfPossibility.Researchers <-> LfPossibility.Restrictions Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfRnGenericRec.SeeAlso <-> LfRnGenericRec.CounterEvidence Tables:[RnGenericRec:RnGenericRec]
        M:N: Owner:[False:False] -- LfRnGenericRec.SeeAlso <-> LfRnGenericRec.SupersededBy Tables:[RnGenericRec:RnGenericRec]
        M:N: Owner:[False:False] -- LfRnGenericRec.SeeAlso <-> LfRnGenericRec.SupportingEvidence Tables:[RnGenericRec:RnGenericRec]
        M:N: Owner:[False:False] -- LfRnGenericRec.CounterEvidence <-> LfRnGenericRec.SeeAlso Tables:[RnGenericRec:RnGenericRec]
        1:M: Owner:[False:True] -- LfPossibility.Confidence <-> LfPossibility.SubPossibilities Tables:[Possibility:Possibility]
        1:M: Owner:[False:True] -- LfPossibility.Status <-> LfPossibility.SubPossibilities Tables:[Possibility:Possibility]
        1:M: Owner:[False:True] -- LfPerson.PlaceOfBirth <-> LfPossibility.SubPossibilities Tables:[Possibility:Possibility]
        1:M: Owner:[False:True] -- LfPerson.Education <-> LfPossibility.SubPossibilities Tables:[Possibility:Possibility]
        1:M: Owner:[False:True] -- LfMoGlossItem.Target <-> LfMoGlossItem.GlossItems Tables:[MoGlossItem:MoGlossItem]

        */

        File.WriteAllText(@"D:\code\lf-sync\LfSync.Data\LCModel\LibLCM.Generated.cs", output.ToString());

        // basic = no FK annotation
        // owning + atomic = FK in curr class    - [ForeignKey("BlogForeignKey")] probably always a Guid
        //                                          e.g. in Scripture "<owning num="25" id="NoteCategories" card="atomic" sig="CmPossibilityList">"
        // owning + seq/col = FK in other class  - [ForeignKey("BlogForeignKey")] "the specified name will be used to create a shadow foreign key [if necessary]"
        // rel  + atomic = FK in curr class      - [ForeignKey("BlogForeignKey")] probably always a Guid
        // rel  + seq/col = Many to many         - Need to generate a class as a join table or configure with fluent API

        // Print bidirectional 1:1's
        //    - is one side always called "default"?
        //    - Is there also an m property?
    }

    private static string MapValueType(string type, out bool isComplexValueType)
    {
        isComplexValueType = false;
        switch (type)
        {
            case "Time":
                return "DateTime";
            case "Integer":
                return "int";
            case "Unicode":
                return "string";
            case "Binary":
                return "byte[]";
            case "TextPropBinary":
                isComplexValueType = true;
                return "List<TextProperty>";
            case "MultiString":
            case "MultiUnicode":
                isComplexValueType = true;
                return "List<LfWsTsString>";
            case "GenDate":
                isComplexValueType = true;
                return type;
            default:
                return type;
        }
    }

    private static void AnalyzeRelations(Dictionary<string, ClassModel> classModels)
    {
        var manyToManyRelations = new List<Relation>();
        var manyToOneRelations = new List<Relation>();
        var oneToOneRelations = new List<Relation>();
        var oneToManyRelations = new List<Relation>();
        foreach (var clazz in classModels.Values)
        {
            foreach (var prop in clazz.Properties)
            {
                if (prop.ValueType == ValueType.Relation)
                {
                    var relation = new Relation
                    {
                        Left = clazz,
                        LeftProp = prop,
                        Right = classModels[prop.Type],
                    };
                    if (prop.Cardinality == Cardinality.Many)
                    {
                        if (prop.IsOwner)
                        {
                            manyToOneRelations.Add(relation);
                        }
                        else
                        {
                            manyToManyRelations.Add(relation);
                        }
                    }
                    else
                    {
                        if (prop.Cardinality == Cardinality.One)
                        {
                            if (prop.IsOwner)
                            {
                                oneToOneRelations.Add(relation);
                            }
                            else
                            {
                                oneToManyRelations.Add(relation);
                            }
                        }
                    }
                }
            }
        }

        FindBidirectionalRelations(manyToManyRelations, manyToManyRelations, "M:N", classModels);
        FindBidirectionalRelations(oneToManyRelations, manyToOneRelations, "1:M", classModels);
        FindBidirectionalRelations(oneToOneRelations, oneToOneRelations, "1:1", classModels);
    }

    private static void FindBidirectionalRelations(List<Relation> _relations, List<Relation> _inverseRelations, string tag, Dictionary<string, ClassModel> classModels)
    {
        var relations = new List<Relation>(_relations);
        var inverseRelations = new List<Relation>(_inverseRelations);
        while (relations.Any())
        {
            var from = relations[0];
            relations.RemoveAt(0);
            foreach (var inverse in inverseRelations.Where(to =>
                    to != from
                    && to.Left.TableName == from.Right.TableName
                    && to.Right.TableName == from.Left.TableName).ToList())
            {
                if (_relations == _inverseRelations)
                {
                    inverseRelations.Remove(inverse);
                }
                var ownerInfo = $"Owner:[{from.LeftProp.IsOwner}:{inverse.LeftProp.IsOwner}]";
                Console.WriteLine($"{tag}: {ownerInfo} -- {from.Left.Name}.{from.LeftProp.Name} <-> {inverse.LeftProp.Type}.{inverse.LeftProp.Name} Tables:[{from.Left.TableName}:{inverse.Left.TableName}]");
            }
        }
    }

    private static string? PickTableName(string className, ClassModel? baseClass)
    {
        var lonelyAbstractTypeWithNoTable = "LfMajorObject";
        if (className.Equals(lonelyAbstractTypeWithNoTable))
        {
            return null;
        }
        var currName = className;
        if (baseClass != null)
        {
            var currClass = baseClass;
            while (currClass != null
                && !currClass.Name.Equals(nameof(LcmModelConstants.LfObject))
                && !currClass.Name.Equals(lonelyAbstractTypeWithNoTable))
            {
                currName = currClass.Name;
                currClass = currClass.BaseClass;
            }
        }
        return currName[2..]; // Remove Lf prefix
    }

    private static List<string>? GetDocs(string[]? comment, notes? notes)
    {
        if ((comment == null || comment.Length <= 0) && string.IsNullOrEmpty(notes?.para))
        {
            return null;
        }
        var docs = new List<string>();
        var summary = comment.IsNullOrEmpty() ? new string[] { notes!.para } : comment!;
        var remarks = comment.IsNullOrEmpty() ? null : notes?.para;
        docs.Add("<summary>");
        foreach (var line in summary)
        {
            docs.Add(line);
        }
        docs.Add("</summary>");
        if (!string.IsNullOrEmpty(remarks))
        {
            docs.Add("<remarks>");
            docs.Add(remarks);
            docs.Add("</remarks>");
        }
        return docs;
    }

    private static void ReadAndCompare(LcmCache cache)
    {
        using var context = new LibLCMDbContext();
        //context.PossibilityLists
    }

    private static void QueryLexicon(LcmCache cache)
    {
        using var context = new LibLCMDbContext();
        var search = "zungunuk";
        var entriesCm = cache.LanguageProject.LexDbOA.Entries.Where(entry => LexemeContains(entry, "zungunuk")).First();
        var entriesC = context.Entries
            .Where(e => EF.Functions.JsonContains(e.LexemeForm.Form, new List<LfWsTsString>() { new LfWsTsString { Text = search } }));//$$"""[{"{{nameof(LfWsTsString.Text)}}": "{{search}}"}]"""));

        var s = entriesC.ToQueryString();
        //.Include(entry => entry.LexemeFormOA)

        var c = entriesC.ToList();
    }

    private static readonly List<Type> SavedTypes = new();
    public static void Migrate(LcmCache cache, IMapper mapper)
    {
        /*SaveAll<IFsFeatureSpecification>(cache, mapper);
        SaveAll<IFsFeatDefn>(cache, mapper);
        SaveAll<IFsFeatStrucType>(cache, mapper);
        SaveAll<IFsFeatStruc>(cache, mapper);
        SaveAll<ICmDomainQ>(cache, mapper);
        SaveAll<ICmPossibilityList>(cache, mapper);
        SavedTypes.Add(typeof(LfPossibility));*/
        SaveAll<ILexEntry>(cache, mapper);
    }

    public static void SaveAll<TSrc>(LcmCache cache, IMapper mapper) where TSrc : class, ICmObject
    {
        var lfType = AutoMapperConfig.GetLfType(typeof(TSrc));
        var repo = cache.ServiceLocator.GetInstance<IRepository<TSrc>>();
        var entities = repo.AllInstances();
        using var context = new LibLCMDbContext();
        var destListType = typeof(List<>).MakeGenericType(lfType);
        var lfEntities = (IEnumerable<object>)mapper.Map(entities, entities.GetType(), typeof(List<LfObject>));
        context.AddRange(lfEntities);

        // Potentially change existing entities to EntityState.Modified
        //var existingEntities = ((IEnumerable<LfObject>)context.Set((lfType, lfEntities.ToArray()))
        //    .Select(e => e.Guid).ToList();

        foreach (var e in context.ChangeTracker.Entries())
        {
            if (SavedTypes.Any(t => t.IsAssignableFrom(e.Entity.GetType())))
            {
                e.State = EntityState.Unchanged;
            }
        }
        context.SaveChanges();
        SavedTypes.Add(lfType);
    }

    public static void SaveAll(object entities, IMapper mapper)
    {
        var lfEntities = mapper.Map(entities, typeof(List<ICmObject>), typeof(List<LfObject>));
        using var context = new LibLCMDbContext();
        context.AddRange((IEnumerable<object>)lfEntities);
        context.SaveChanges();
    }

    public static List<object> GetAll<T>(LcmCache cache) where T : class, ICmObject
    {
        var repo = cache.ServiceLocator.GetInstance<IRepository<T>>();
        return repo.AllInstances().ToList<object>();
    }
}
