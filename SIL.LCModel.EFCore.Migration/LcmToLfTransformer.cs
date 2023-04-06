using System.Diagnostics;
using AutoMapper;
using LibLcmCacheLoader;
using Microsoft.EntityFrameworkCore;
using SIL.LCModel.EFCore.Conversion;
using SIL.LCModel.EFCore.Model;
using SIL.LCModel.Infrastructure.Impl;
using SIL.LCModel.Utils;
using static SIL.LCModel.EFCore.Migration.Playground;

namespace SIL.LCModel.EFCore.Migration;

public partial class Program
{
    public static void Main(string[] args)
    {
        var project = args.Length > 0 ? args[0] : "Sena 3";
        using var extractor = new LcmCacheLoader(project);

        //*
        Watch.Enabled = false;
        var __cache = Watch.Time("Load cache", () => extractor.ExtractProject(typeof(EFCoreBackendProvider)));
        Watch.Enabled = true;
        var cache = Watch.Time("Load cache 2", () => extractor.ExtractProject(typeof(EFCoreBackendProvider)));
        var langProj = cache.LangProject;
        var services = langProj.Services;
        var wsManager = services.WritingSystemManager;

        var fwData = cache.ServiceLocator.MetaDataCache;

        QueryLexicon(cache);
        /*/

        var cache = extractor.ExtractProject();
        var mapper = Time("Init mapper", () => CmToEFCoreAutoMapperConfig.InitMapper(cache));
        var customFieldService = CustomFieldService.Instance(cache);
        Migrate(cache, mapper, customFieldService);

        //*/

        /*
        MigrateXTimes(cache, customFieldService, 100);
        return;
        //*/


    }

    private static void MigrateXTimes(LcmCache cache, CustomFieldService customFieldService, int times)
    {
        for (var i = 0; i < times; i++)
        {
            var mapper = Time("Init mapper", () => CmToEFCoreAutoMapperConfig.InitMapper(cache));
            Migrate(cache, mapper, customFieldService);
            Console.Out.WriteLine($"Migrated: {i + 1}/{times}.");
        }
    }

    private static void QueryLexicon(LcmCache cache)
    {
        var originalValue = "zungunuk";

        var cmEntry = AssertValueInLcmAndEF(originalValue, cache);
        Console.WriteLine("Start state as expected");

        var ws = cmEntry.LexemeFormOA.Form.VernacularDefaultWritingSystem.get_Properties(0).GetIntProp(0, out int propKey /*FwTextPropType*/, out int variation);
        var stackManager = cache.ServiceLocator.GetInstance<IUndoStackManager>();
        var undoStack = stackManager.CreateUndoStack();
        stackManager.SetCurrentStack(undoStack);

        var newValue = "zungunuk!!!";
        undoStack.BeginUndoTask($"Rename to '{newValue}'", $"Rename to '{newValue}'");
        cmEntry.LexemeFormOA.Form.set_String(ws, newValue);
        undoStack.EndUndoTask();

        stackManager.Save();

        AssertValueInLcmAndEF(newValue, cache);
        Console.WriteLine("Update worked");

        undoStack.Undo();
        stackManager.Save();

        AssertValueInLcmAndEF(originalValue, cache);
        Console.WriteLine("Undo worked");

        undoStack.Redo();
        stackManager.Save();

        AssertValueInLcmAndEF(newValue, cache);
        Console.WriteLine("Redo worked");

        undoStack.Undo();
        stackManager.Save();

        AssertValueInLcmAndEF(originalValue, cache);
        Console.WriteLine("Undo to original state worked");
    }

    private static ILexEntry AssertValueInLcmAndEF(string search, LcmCache cache)
    {
        using var context = new LcmDbContext();
        var cmEntry = cache.ServiceLocator.GetInstance<IRepository<ILexEntry>>().AllInstances().Where(entry => LexemeContains(entry, search)).First();
        var lfEntry = context.LexEntrys
            .Where(e => EF.Functions.JsonContains(e.LexemeForm.Form, $$"""[{"{{nameof(LfWsTsString.Text)}}": "{{search}}"}]"""))
            .Include(e => e.LexemeForm)
            .First();

        var cmValue = cmEntry.LexemeFormOA.Form.VernacularDefaultWritingSystem.Text;
        var lfValue = lfEntry.LexemeForm.Form.First().Text;

        if (cmValue != lfValue || cmValue != search)
        {
            throw new Exception($"Values are not equal. ({cmValue} {lfValue} {search})");
        }
        return cmEntry;
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
            var lfType = CmToEFCoreAutoMapperConfig.GetLfType(typeof(TSrc));
            var entities = GetAll<TSrc>(cache);
            var destListType = typeof(List<>).MakeGenericType(lfType);
            return (IEnumerable<object>)mapper.Map(entities, entities.GetType(), destListType, opt => { });
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
