using System.Runtime.InteropServices;
using System.Transactions;
using LfSync.Data.LCModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Configuration;

namespace LfSync.Data.Db;

public partial class LibLCMDbContext : DbContext
{
    public DbSet<LfLexExampleSentence> ExampleSentences { get; set; }
    public DbSet<LfLexSense> Senses { get; set; }
    public DbSet<LfLexEntry> Entries { get; set; }
    public DbSet<LfPossibilityList> PossibilityLists { get; set; }
    public DbSet<LfPossibility> Possibilities { get; set; }
    public DbSet<LfPerson> Persons { get; set; }
    public DbSet<LfLexRefType> LexRefType { get; set; }
    public DbSet<LfLocation> Locations { get; set; }

    protected readonly IConfiguration Configuration;

    public LibLCMDbContext()
    {
        /*var configuration = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json");
        Configuration = configuration.Build();*/
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Host=localhost; Database=liblcm; Username=postgres; Password=postgres; Include Error Detail=true")
            .EnableSensitiveDataLogging();
            //.UseCustomNamingConvention(name => name.Replace("Lf", ""));
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new GuidForeignKeyConvention());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Ignore<LfObject>();
        modelBuilder.Ignore<LfTsString>();
        modelBuilder.Entity<LfFsFeatureSpecification>()
            .HasOne(f => f.Feature)
            .WithMany();
        modelBuilder.Entity<LfTranslation>()
            .Property<Guid>("LexExampleSentence_Translations_Guid");
        modelBuilder.Entity<LfPossibility>()
            .Property<Guid>("PossibilityList_Possibilities_Guid");
        //.HasForeignKey($"{nameof(LfFsFeatureSpecification.Feature)}{nameof(Guid)}");
        // modelBuilder.Entity<LfPossibilityList>()
        //     .HasMany(l => l.Possibilities)
        //     .WithOne()
        //     .HasForeignKey($"PossibilityList{nameof(Guid)}");
        modelBuilder.Entity<LfPossibility>()
            .HasMany(l => l.SubPossibilities)
            .WithOne();
            //.HasForeignKey($"ParentPossibility{nameof(Guid)}");
        modelBuilder.Entity<LfPossibility>()
            .HasMany(l => l.Restrictions)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfPossibility)}_{nameof(LfPossibility.Restrictions)}"));
        modelBuilder.Entity<LfPossibility>()
            .HasOne(l => l.Confidence)
            .WithMany()
            .HasForeignKey($"{nameof(LfPossibility.Confidence)}{nameof(Guid)}");
        modelBuilder.Entity<LfPossibility>()
            .HasOne(l => l.Status)
            .WithMany();
            //.HasForeignKey($"{nameof(LfPossibility.Status)}{nameof(Guid)}");
        modelBuilder.Entity<LfPossibility>()
            .HasMany(l => l.Researchers)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfPossibility)}_{nameof(LfPossibility.Researchers)}"));

        modelBuilder.Entity<LfPerson>()
            .HasOne(l => l.PlaceOfBirth)
            .WithMany();
        //     .HasForeignKey($"{nameof(LfPerson.PlaceOfBirth)}{nameof(Guid)}");
        modelBuilder.Entity<LfPerson>()
            .HasMany(l => l.PlacesOfResidence)
            .WithMany();
        //.UsingEntity(j => j.ToTable($"{nameof(LfCmPerson)}_{nameof(LfCmPerson.PlacesOfResidence)}"));
        modelBuilder.Entity<LfPerson>()
            .HasOne(l => l.Education)
            .WithMany();
        //     .HasForeignKey($"{nameof(LfPerson.Education)}{nameof(Guid)}");
        modelBuilder.Entity<LfPerson>()
            .HasMany(l => l.Positions)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfPerson)}_{nameof(LfPerson.Positions)}"));

        modelBuilder.Entity<LfLexExampleSentence>()
            .HasMany(e => e.DoNotPublishIn)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfLexExampleSentence)}_{nameof(LfLexExampleSentence.DoNotPublishIn)}"));

    }

    partial void ConfigureManyToMany();

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        List<Action> secondCommitChanges = new();
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is LfSemanticDomain sd)
            {
                var relatedDomains = sd.RelatedDomains;
                sd.RelatedDomains = null;
                secondCommitChanges.Add(() => sd.RelatedDomains = relatedDomains);
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

public class GuidForeignKeyConvention : IForeignKeyAddedConvention
{
    public void ProcessForeignKeyAdded(
        IConventionForeignKeyBuilder foreignKeyBuilder,
        IConventionContext<IConventionForeignKeyBuilder> context)
    {
        foreignKeyBuilder.HasForeignKey(...)
    }
}