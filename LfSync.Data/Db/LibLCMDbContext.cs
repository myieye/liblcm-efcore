using LfSync.Data.LCModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace LfSync.Data.Db;

public class LibLCMDbContext : DbContext
{
    public DbSet<LfLexExampleSentence> ExampleSentences { get; set; }
    public DbSet<LfCmPossibility> Possibilities { get; set; }
    public DbSet<LfCmPerson> Persons { get; set; }
    public DbSet<LfCmLocation> Locations { get; set; }

    protected readonly IConfiguration Configuration;

    public LibLCMDbContext()
    {
        /*var configuration = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json");
        Configuration = configuration.Build();*/
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql("Host=localhost; Database=liblcm; Username=postgres; Password=postgres; Include Error Detail=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LfCmPossibility>()
                .Property(x => x.Guid)
                .ValueGeneratedNever();
        modelBuilder.Entity<LfCmPossibility>()
            .HasMany(l => l.SubPossibilitiesOS)
            .WithOne()
            .HasForeignKey($"ParentPossibility{nameof(Guid)}");
        modelBuilder.Entity<LfCmPossibility>()
            .HasMany(l => l.RestrictionsRC)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfCmPossibility)}_{nameof(LfCmPossibility.RestrictionsRC)}"));
        modelBuilder.Entity<LfCmPossibility>()
            .HasOne(l => l.ConfidenceRA)
            .WithMany()
            .HasForeignKey($"{nameof(LfCmPossibility.ConfidenceRA)}{nameof(Guid)}");
        modelBuilder.Entity<LfCmPossibility>()
            .HasOne(l => l.StatusRA)
            .WithMany()
            .HasForeignKey($"{nameof(LfCmPossibility.StatusRA)}{nameof(Guid)}");
        modelBuilder.Entity<LfCmPossibility>()
            .HasMany(l => l.ResearchersRC)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfCmPossibility)}_{nameof(LfCmPossibility.ResearchersRC)}"));

        modelBuilder.Entity<LfCmPerson>()
            .HasOne(l => l.PlaceOfBirthRA)
            .WithMany()
            .HasForeignKey($"{nameof(LfCmPerson.PlaceOfBirthRA)}{nameof(Guid)}");
        modelBuilder.Entity<LfCmPerson>()
            .HasMany(l => l.PlacesOfResidenceRC)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfCmPerson)}_{nameof(LfCmPerson.PlacesOfResidenceRC)}"));
        modelBuilder.Entity<LfCmPerson>()
            .HasOne(l => l.EducationRA)
            .WithMany()
            .HasForeignKey($"{nameof(LfCmPerson.EducationRA)}{nameof(Guid)}");
        modelBuilder.Entity<LfCmPerson>()
            .HasMany(l => l.PositionsRC)
            .WithMany()
            .UsingEntity(j => j.ToTable($"{nameof(LfCmPerson)}_{nameof(LfCmPerson.PositionsRC)}"));

        modelBuilder.Entity<LfTsString>().HasNoKey();
    }


}