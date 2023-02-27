using System.Runtime.InteropServices;
using LfSync.Data.LCModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LfSync.Data.Db;

public class LibLCMDbContext : DbContext
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
            .EnableSensitiveDataLogging()
            .UseCustomNamingConvention(name => name.Replace("Lf", ""));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<LfObject>();
        modelBuilder.Ignore<LfTsString>();
        //modelBuilder.Entity<LfFsFeatDefn>()
        //.HasMany()
        //    .HasOne(f => f.DefaultOA)
        //    .WithMany();
        modelBuilder.Entity<LfFsFeatureSpecification>()
            .HasOne(f => f.FeatureRA)
            .WithMany()
            .HasForeignKey($"{nameof(LfFsFeatureSpecification.FeatureRA)}{nameof(Guid)}");
        modelBuilder.Entity<LfPossibilityList>()
            .HasMany(l => l.PossibilitiesOS)
            .WithOne()
            .HasForeignKey($"PossibilityList{nameof(Guid)}");
        modelBuilder.Entity<LfPossibility>()
            .HasMany(l => l.SubPossibilitiesOS)
            .WithOne()
            .HasForeignKey($"ParentPossibility{nameof(Guid)}");
        modelBuilder.Entity<LfPossibility>()
            .HasMany(l => l.RestrictionsRC)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfPossibility)}_{nameof(LfPossibility.RestrictionsRC)}"));
        modelBuilder.Entity<LfPossibility>()
            .HasOne(l => l.ConfidenceRA)
            .WithMany()
            .HasForeignKey($"{nameof(LfPossibility.ConfidenceRA)}{nameof(Guid)}");
        modelBuilder.Entity<LfPossibility>()
            .HasOne(l => l.StatusRA)
            .WithMany()
            .HasForeignKey($"{nameof(LfPossibility.StatusRA)}{nameof(Guid)}");
        modelBuilder.Entity<LfPossibility>()
            .HasMany(l => l.ResearchersRC)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfPossibility)}_{nameof(LfPossibility.ResearchersRC)}"));

        modelBuilder.Entity<LfPerson>()
            .HasOne(l => l.PlaceOfBirthRA)
            .WithMany()
            .HasForeignKey($"{nameof(LfPerson.PlaceOfBirthRA)}{nameof(Guid)}");
        modelBuilder.Entity<LfPerson>()
            .HasMany(l => l.PlacesOfResidenceRC)
            .WithMany();
        //.UsingEntity(j => j.ToTable($"{nameof(LfCmPerson)}_{nameof(LfCmPerson.PlacesOfResidenceRC)}"));
        modelBuilder.Entity<LfPerson>()
            .HasOne(l => l.EducationRA)
            .WithMany()
            .HasForeignKey($"{nameof(LfPerson.EducationRA)}{nameof(Guid)}");
        modelBuilder.Entity<LfPerson>()
            .HasMany(l => l.PositionsRC)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfPerson)}_{nameof(LfPerson.PositionsRC)}"));

        modelBuilder.Entity<LfLexExampleSentence>()
            .HasMany(e => e.DoNotPublishInRC)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfLexExampleSentence)}_{nameof(LfLexExampleSentence.DoNotPublishInRC)}"));

    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        List<Action> secondCommitChanges = new();
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.Entity is LfSemanticDomain sd)
            {
                var relatedDomains = sd.RelatedDomainsRC;
                sd.RelatedDomainsRC = null;
                secondCommitChanges.Add(() => sd.RelatedDomainsRC = relatedDomains);
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
