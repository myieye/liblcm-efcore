using System.Diagnostics;
using AutoMapper;
using extract;
using LfSync.Data.Db;
using LfSync.Data.LCModel;
using Microsoft.EntityFrameworkCore;
using SIL.LCModel;
using SIL.Linq;
using static transform.Playground;

namespace transform;

public class Program
{
    public static void Main(string[] args)
    {
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

    private static void ReadAndCompare(LcmCache cache)
    {
        using var context = new LibLCMDbContext();
        //context.PossibilityLists
    }

    private static void QueryLexicon(LcmCache cache)
    {
        using var context = new LibLCMDbContext();
        var entriesCm = cache.LanguageProject.LexDbOA.Entries.Where(entry => LexemeContains(entry, "zungunuk")).First();
        var entriesC = context.Entries
            .Include(entry => entry.LexemeFormOA).ToList();
        
        var c = entriesC.Where(e => e.LexemeFormOA.Form.Any(f => f.Text == "zungunuk")).ToList();
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

        context.ChangeTracker.Entries().ForEach(e =>
        {
            if (SavedTypes.Any(t => t.IsAssignableFrom(e.Entity.GetType())))
            {
                e.State = EntityState.Unchanged;
            }
        });
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
