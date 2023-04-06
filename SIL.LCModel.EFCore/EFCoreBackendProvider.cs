using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SIL.LCModel.Core.WritingSystems;
using SIL.LCModel.EFCore;
using SIL.LCModel.EFCore.Conversion;
using SIL.LCModel.EFCore.Model;
using SIL.LCModel.Utils;
using SIL.Lexicon;

namespace SIL.LCModel.Infrastructure.Impl
{
    public class EFCoreBackendProvider : IDataSetup, IDataReader, IDataStorer
    {
        private int nextHvo = 1;
        private readonly Dictionary<Guid, int> guidToHvo = new();
        private readonly Dictionary<int, Guid> hvoToGuid = new();
        private readonly Dictionary<Guid, ICmObject> guidToObject = new();
        private readonly LcmCache cache;
        private readonly IMapper mapper;

        private LcmDbContext? _efContext;

        private static readonly MethodInfo QueryMethod =
            new Func<LcmDbContext, IQueryable>(QueryEntities<object>).Method
            .GetGenericMethodDefinition();

        public EFCoreBackendProvider(
            LcmCache cache
        )
        {
            this.cache = cache;
            // ProjectId = cache.ProjectId; Circular dependency
            mapper = Watch.Time("CmToEFCoreAutoMapperConfig.InitMapper()", () => CmToEFCoreAutoMapperConfig.InitMapper(cache));
        }

        public IProjectIdentifier ProjectId { get; private set; }

        public bool UseMemoryWritingSystemManager { get; set; } = false;

        public ISettingsStore ProjectSettingsStore { get; private set; }

        public ISettingsStore UserSettingsStore { get; private set; }

        public IEnumerable<T> AllInstances<T>(int clsid) where T : ICmObject
        {
            var mappedInstances = WithEfContext(context =>
            {
                var entities = QueryEntities(context, typeof(T));
                var filteredEntities = entities.Where(obj => obj.ClassID == clsid).ToList();
                return MapEntities<T>(filteredEntities);
            });
            foreach (var obj in mappedInstances)
            {
                CacheEntity(obj);
            }
            return mappedInstances;
        }

        private void CacheEntity(ICmObject? obj)
        {
            if (obj == null)
                return;

            var guid = obj.Guid;

            if (guidToHvo.ContainsKey(guid))
                return;

            var hvo = GetNextRealHvo();
            obj.Hvo = hvo;
            guidToHvo[guid] = hvo;
            hvoToGuid[hvo] = guid;
            guidToObject[guid] = obj;

            switch (obj)
            {
                case ILexEntry entry:
                    CacheEntity(entry.LexemeFormOA);
                    break;
            }

            CacheEntity(obj.Owner); // eagerly load the owner so it's in sync with the current hierarchy
        }

        private static IQueryable<LfObject> QueryEntities(LcmDbContext context, Type lcmType)
        {
            var lfType = CmToEFCoreAutoMapperConfig.GetLfType(lcmType);
            return (IQueryable<LfObject>)QueryMethod.MakeGenericMethod(lfType).Invoke(null, new[] { context });
        }

        private List<LcmType> MapEntities<LcmType>(IEnumerable<LfObject> entities)
        {
            var lfType = CmToEFCoreAutoMapperConfig.GetLfType(typeof(LcmType));
            var concreteLcmType = CmToEFCoreAutoMapperConfig.GetConcreteLcmType(lfType);
            var returnType = typeof(IEnumerable<>).MakeGenericType(concreteLcmType);
            return ((IEnumerable<LcmType>)mapper.Map(entities, entities.GetType(), returnType, opts => { })).ToList();
        }

        private static IQueryable<T> QueryEntities<T>(LcmDbContext context) where T : class
        {
            var query = context.Set<T>();
            return typeof(T) switch
            {
                Type t when t.IsAssignableTo(typeof(LfLexEntry)) => query.Include(e => (e as LfLexEntry).LexemeForm),
                _ => query,
            };
        }

        public IEnumerable<ICmObject> AllInstances(int clsid)
        {
            throw new NotImplementedException();
        }

        public bool Commit(HashSet<ICmObjectOrSurrogate> newbies, HashSet<ICmObjectOrSurrogate> dirtballs, HashSet<ICmObjectId> goners)
        {
            WithEfContext(context =>
            {
                if (goners.Count > 0)
                {
                    var gonerObjects = goners.Select(goner => guidToObject[goner.Guid]).ToList();
                    var efGones = (IEnumerable<LfObject>)mapper.Map(gonerObjects, typeof(IEnumerable<ICmObject>), typeof(IEnumerable<LfObject>), opt => { });
                    context.RemoveRange(efGones);
                }

                var newbiesWithoutGoners = newbies.Where(newbie => !goners.Any(goner => goner.Guid == newbie.Id.Guid)).ToList();
                if (newbiesWithoutGoners.Count > 0)
                {
                    var efNewbies = (IEnumerable<LfObject>)mapper.Map(newbiesWithoutGoners, typeof(IEnumerable<ICmObject>), typeof(IEnumerable<LfObject>), opt => { });
                    context.AddRange(efNewbies);
                }

                var oldExistingDirtballs = dirtballs.Where(dirtball =>
                    !newbiesWithoutGoners.Any(newbie => newbie.Id.Guid == dirtball.Id.Guid) &&
                    !goners.Any(goner => goner.Guid == dirtball.Id.Guid)).ToList();
                if (oldExistingDirtballs.Count > 0)
                {
                    var efDirtballs = (IEnumerable<LfObject>)mapper.Map(oldExistingDirtballs, typeof(IEnumerable<ICmObject>), typeof(IEnumerable<LfObject>), opt => { });
                    context.UpdateRange(efDirtballs);
                }

                return context.SaveChanges();
            });

            return true;
        }

        public void CompleteAllCommits()
        {
            // only for irregular situations? (e.g. shutting down, migrating, backing up, unlocking (?), disposing, etc.)
            throw new NotSupportedException();
        }

        public int Count(int clsid)
        {
            switch (clsid)
            {
                case LangProjectTags.kClassId:
                    return 1;
                default:
                    throw new NotImplementedException();
            }
        }

        public void CreateNewLanguageProject(IProjectIdentifier projectId)
        {
            ProjectId = projectId;
            InitializeWritingSystemManager();
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int GetHvoFromObjectOrId(ICmObjectOrId id)
        {
            throw new NotImplementedException();
        }

        public int GetNextRealHvo()
        {
            return nextHvo++;
        }

        public T GetObject<T>(Guid guid) where T : class, ICmObject
        {
            if (typeof(T).Equals(typeof(ICmObject)))
                // ICmObject is too generic, so we have to revert to the cache
                return guidToObject[guid] as T;

            var lfObject = WithEfContext(context =>
                QueryEntities(context, typeof(T))
                    .Where(obj => obj.Guid == guid)
                    .Single());
            var lcmObject = MapEntities<T>(new[] { lfObject }).Single();
            CacheEntity(lcmObject);
            return lcmObject;
        }

        public T GetObject<T>(ICmObjectId id) where T : class, ICmObject
        {
            return GetObject<T>(id.Guid);
        }

        public T GetObject<T>(int hvo) where T : class, ICmObject
        {
            return GetObject<T>(hvoToGuid[hvo]);
        }
        
        public ICmObject GetObject(int hvo)
		{
            return GetObject<ICmObject>(hvo);
        }

        public ICmObject GetObjectIfFluffed(ICmObjectId id)
        {
            throw new NotImplementedException();
        }

        public ICmObjectOrId GetObjectOrIdWithHvoFromGuid(Guid guid)
        {
            throw new NotImplementedException();
        }

        public int GetOrAssignHvoFor(ICmObjectId id)
        {
            throw new NotImplementedException();
        }

        public bool HasObject(int hvo)
        {
            throw new NotImplementedException();
        }

        public bool HasObject(Guid guid)
        {
            throw new NotImplementedException();
        }

        public void InitializeFromSource(IProjectIdentifier projectId, BackendStartupParameter sourceDataStore, string userWsIcuLocale, IThreadedProgress progressDlg)
        {
            ProjectId = projectId;
            InitializeWritingSystemManager();
            throw new NotImplementedException();
        }

        public void InitializeFromSource(IProjectIdentifier projectId, LcmCache sourceCache)
        {
            ProjectId = projectId;
            InitializeWritingSystemManager();
            throw new NotImplementedException();
        }

        public void LoadDomain(BackendBulkLoadDomain bulkLoadDomain)
        {
            throw new NotImplementedException();
        }

        public void LoadDomainAsync(BackendBulkLoadDomain bulkLoadDomain)
        {
            throw new NotImplementedException();
        }

        public bool RenameDatabase(string sNewBasename)
        {
            // The XML backend has to rename files and folders.
            // We just update a line in the database.
            throw new NotImplementedException();
        }

        public void StartupExtantLanguageProject(IProjectIdentifier projectId, bool fBootstrapSystem, IThreadedProgress progressDlg)
        {
            ProjectId = projectId;
            InitializeWritingSystemManager();
            // The juicy bit for XML data providers. We might do nothing...
        }

        public bool TryGetObject(int hvo, out ICmObject obj)
        {
            throw new NotImplementedException();
        }

        public bool TryGetObject(Guid guid, out ICmObject obj)
        {
            throw new NotImplementedException();
        }

        private T WithEfContext<T>(Func<LcmDbContext, T> action)
        {
            var outerAction = _efContext == null;
            var context = _efContext ??= new LcmDbContext();

            T result = action(context);

            if (outerAction)
            {
                _efContext.Dispose();
                _efContext = null;
            }

            return result;
        }

        // Duplication from BackendProvider

        protected void CreateSettingsStores()
        {
            if (UseMemoryWritingSystemManager || string.IsNullOrEmpty(ProjectId.ProjectFolder))
                return;

            string sharedSettingsPath = LexiconSettingsFileHelper.GetSharedSettingsPath(ProjectId.ProjectFolder);
            if (!Directory.Exists(sharedSettingsPath))
                Directory.CreateDirectory(sharedSettingsPath);
            ProjectSettingsStore = new FileSettingsStore(LexiconSettingsFileHelper.GetProjectLexiconSettingsPath(ProjectId.ProjectFolder));
            UserSettingsStore = new FileSettingsStore(LexiconSettingsFileHelper.GetUserLexiconSettingsPath(ProjectId.ProjectFolder));
        }

        private void InitializeWritingSystemManager()
        {
            // if there is no project path specified, then just use the default memory-based manager.
            // this will happen with the memory-only BEP.
            if (UseMemoryWritingSystemManager || string.IsNullOrEmpty(ProjectId.ProjectFolder))
                return;

            CreateSettingsStores();

            var globalRepo = SingletonsContainer.Get<CoreGlobalWritingSystemRepository>();
            string storePath = Path.Combine(ProjectId.ProjectFolder, LcmFileHelper.ksWritingSystemsDir);
            WritingSystemManager wsManager = cache.ServiceLocator.WritingSystemManager;

            Watch.Time("BackendProvider.InitializeWritingSystemManager: new CoreLdmlInFolderWritingSystemRepository()", () =>
                wsManager.WritingSystemStore = new CoreLdmlInFolderWritingSystemRepository(storePath, ProjectSettingsStore, UserSettingsStore, globalRepo));

            // Writing systems are not "modified" when the system is freshly-initialized
            foreach (CoreWritingSystemDefinition ws in wsManager.WritingSystemStore.AllWritingSystems)
                ws.AcceptChanges();
        }
    }
}