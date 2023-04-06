using Microsoft.EntityFrameworkCore;
using SIL.LCModel.EFCore.Model;

namespace SIL.LCModel.EFCore;

public partial class LcmDbContext : DbContext
{
    public DbSet<LfObjectId> ObjectIds { get; set; }
    public DbSet<CustomFieldConfig> CustomFieldConfigs { get; set; }
    public DbSet<CustomFieldValue> CustomFieldValues { get; set; }
    public DbSet<WritingSystem> WritingSystems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Host=localhost; Database=liblcm; Username=postgres; Password=postgres; Include Error Detail=true")
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name });
    }

    partial void OnModelCreating_Generated(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        OnModelCreating_Generated(builder);
        builder.Entity<GenDateCustomFieldValue>();
        builder.Entity<WsTsStringCustomFieldValue>();
        builder.Entity<StTextCustomFieldValue>();
        builder.Entity<IntCustomFieldValue>();
        builder.Entity<StringCustomFieldValue>();
        builder.Entity<PossibilityCustomFieldValue>();
        builder.Entity<PossibilityListCustomFieldValue>()
            .HasMany(p => p.Value)
            .WithMany()
            .UsingEntity(j => j.ToTable($"PossibilityListCustomFieldValue_Value_Possibility"));
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        List<Action> secondCommitChanges = new();
        foreach (var entry in ChangeTracker.Entries())
        {
            // Circular dependencies
            if (entry.Entity is LfSemanticDomain sd)
            {
                var relatedDomains = sd.RelatedDomains;
                sd.RelatedDomains = null;
                secondCommitChanges.Add(() => sd.RelatedDomains = relatedDomains);
            }
            if (entry.Entity is LfLexEntry lexEntry)
            {
                var form = lexEntry.LexemeForm;
                lexEntry.LexemeForm = null;
                secondCommitChanges.Add(() => lexEntry.LexemeForm = form);
            }
        }

        if (!secondCommitChanges.Any())
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        using var transation = Database.BeginTransaction();
        var num = base.SaveChanges(acceptAllChangesOnSuccess);
        secondCommitChanges.ForEach(a => a());
        num += base.SaveChanges(acceptAllChangesOnSuccess);
        transation.Commit();
        return num;
    }
}
