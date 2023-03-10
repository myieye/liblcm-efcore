using System.Diagnostics;
using AutoMapper;
using LibLcmCacheLoader;
using Microsoft.EntityFrameworkCore;
using SIL.LCModel.EFCore.Model;
using static SIL.LCModel.EFCore.Migration.Playground;

namespace SIL.LCModel.EFCore.Migration;

public partial class Program
{
    public static void Main(string[] args)
    {
        var project = args.Length > 0 ? args[0] : "Sena 3";
        using var extractor = new LcmCacheLoader(project);
        var cache = Time("Load data", () => extractor.ExtractProject());
        var langProj = cache.LangProject;
        var services = langProj.Services;
        var wsManager = services.WritingSystemManager;

        var fwData = cache.ServiceLocator.MetaDataCache;
        var customFieldService = CustomFieldService.Instance(cache);

        /*
        MigrateXTimes(cache, customFieldService, 100);
        return;
        //*/

        var mapper = Time("Init mapper", () => AutoMapperConfig.InitMapper(cache, customFieldService));
        Migrate(cache, mapper, customFieldService);
        QueryLexicon(cache);
    }

    private static void MigrateXTimes(LcmCache cache, CustomFieldService customFieldService, int times)
    {
        for (var i = 0; i < times; i++)
        {
            var mapper = Time("Init mapper", () => AutoMapperConfig.InitMapper(cache, customFieldService));
            Migrate(cache, mapper, customFieldService);
            Console.Out.WriteLine($"Migrated: {i + 1}/{times}.");
        }
    }

    private static void QueryLexicon(LcmCache cache)
    {
        using var context = new LcmDbContext();
        var search = "zungunuk";
        var entriesCm = cache.LanguageProject.LexDbOA.Entries.Where(entry => LexemeContains(entry, "zungunuk")).First();
        var entriesC = context.LexEntrys
            .Where(e => EF.Functions.JsonContains(e.LexemeForm.Form, $$"""[{"{{nameof(LfWsTsString.Text)}}": "{{search}}"}]"""));
    }

    private static ISet<Type> SavedEntityTypes = new HashSet<Type>();

    public static void Migrate(LcmCache cache, IMapper mapper, CustomFieldService customFieldService)
    {
        var customFieldConfigs = customFieldService.GetCustomFieldConfigs();
        using var context = new LcmDbContext();
        Time("Add custom field configs", () => context.AddRange(customFieldConfigs));
        Time("Save custom field configs", () => context.SaveChanges());
        SavedEntityTypes.Add(typeof(CustomFieldConfig));
        var writingSystems = WritingSystemService.GetWritingSystems(cache);
        Time("Add writing systems", () => context.AddRange(writingSystems));
        Time("Save writing systems", () => context.SaveChanges());
        SavedEntityTypes.Add(typeof(WritingSystem));

        SaveAll<ICmObject>(cache, mapper);
    }

    public static void SaveAll<TSrc>(LcmCache cache, IMapper mapper) where TSrc : class, ICmObject
    {
        var lfEntities = Time($"Map {typeof(TSrc).Name}s", () =>
        {
            var lfType = AutoMapperConfig.GetLfType(typeof(TSrc));
            var entities = GetAll<TSrc>(cache);
            var destListType = typeof(List<>).MakeGenericType(lfType);
            return (IEnumerable<object>)mapper.Map(entities, entities.GetType(), destListType);
        });

        using var context = new LcmDbContext();
        Time("Add range", () => context.AddRange(lfEntities));

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (SavedEntityTypes.Contains(entry.Entity.GetType()))
            {
                entry.State = EntityState.Modified;
            }
        }

        Time("Save changes", () => context.SaveChanges());
    }

    public static List<T> GetAll<T>(LcmCache cache) where T : class, ICmObject
    {
        var repo = cache.ServiceLocator.GetInstance<IRepository<T>>();
        return repo.AllInstances().ToList<T>();
    }

    public static T Time<T>(string name, Func<T> action)
    {
        Utils.Print($"Starting {name}...");
        var sw = Stopwatch.StartNew();
        var result = action();
        sw.Stop();
        Utils.Print($"{name}: {sw.ElapsedMilliseconds}ms");
        return result;
    }

    public static void Time(string name, Action action)
    {
        Time(name, () =>
        {
            action();
            return 0;
        });
    }
}
