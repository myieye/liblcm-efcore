using AutoMapper;
using LfSync.LcmModelGenerator;
using Microsoft.IdentityModel.Tokens;
using SIL.Extensions;
using SIL.LCModel.Application;
using SIL.LCModel.Core.KernelInterfaces;
using SIL.LCModel.Core.Text;
using SIL.LCModel.Core.WritingSystems;
using SIL.LCModel.EFCore.Model;
using SIL.Linq;

namespace SIL.LCModel.EFCore.Migration;

public static class AutoMapperConfig
{
    private const string JSONB_NULL = "<|NULL|>";

    private static readonly Dictionary<Type, Type> LcmToLfTypes = new();

    public static Type GetLfType(Type lcmType)
    {
        return LcmToLfTypes[lcmType];
    }

    public static Dictionary<Type, Type> FindTypeMappings(string typeQuery)
    {
        return LcmToLfTypes.Where(kvp => kvp.Key.Name.Contains(typeQuery) || kvp.Value.Name.Contains(typeQuery)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    public static IMapper InitMapper(LcmCache cache, CustomFieldService customFieldService)
    {
        GuidIncrementor.Increment();
        var config = new MapperConfiguration(cfg =>
        {
            cfg.RecognizePostfixes(new string[] { "RA", "RC", "RS", "OA", "OC", "OS" });
            cfg.RecognizeDestinationPostfixes(new string[] { "Guid" });
            cfg.IncludeSourceExtensionMethods(typeof(TextExtensions));
            cfg.MapLibLCMToLF(cache, customFieldService);
        });
        var mapper = config.CreateMapper();
        config.AssertConfigurationIsValid();
        return mapper;
    }

    public static void MapLibLCMToLF(this IMapperConfigurationExpression cfg, LcmCache cache, CustomFieldService customFieldService)
    {
        var wsManager = cache.ServiceLocator.WritingSystemManager;
        var silData = (ISilDataAccessManaged)cache.MainCacheAccessor;
        var fwData = cache.ServiceLocator.MetaDataCache;

        var initTypeMapper = LcmToLfTypes.IsNullOrEmpty();
        var lfTypes = AppDomain.CurrentDomain.GetAssemblies()
            .First(ass => ass.GetName().Name?.Equals("SIL.LCModel.EFCore") ?? false)
            .GetTypes()
            .Where(t => !t.IsEnum)
            .Where(t => t.IsAssignableTo(typeof(LfObject)) || t.IsValueType)
            .Where(t => t.Namespace?.Equals(typeof(LfObject).Namespace) ?? false)
            .ToDictionary(t => t.Name, t => t);

        var lcmTypesByLfNames = AppDomain.CurrentDomain.GetAssemblies()
            .Where(ass => ass.FullName?.StartsWith("SIL.LCModel") ?? false)
            .SelectMany(ass => ass.GetTypes())
            .Where(t => !t.IsEnum)
            .Where(t => t.IsAssignableTo(typeof(ICmObject)) || t.IsValueType)
            .GroupBy(t => NameUtils.LcmNameToLf(t.Name))
            .Where(t => lfTypes.ContainsKey(t.Key))
            .ToDictionary(g => g.Key, g => g);

        foreach (var lcmTypesByLfName in lcmTypesByLfNames)
        {
            var lfName = lcmTypesByLfName.Key;

            foreach (var lcmType in lcmTypesByLfName.Value)
            {
                if (lcmType == typeof(ITsString))
                {
                    continue;
                }
                var lfType = lfTypes[lfName];
                if (initTypeMapper)
                {
                    LcmToLfTypes.Add(lcmType, lfType);
                }
                //LfToLcmTypes.Add(lfType, lcmType);
                var map = cfg.CreateMap(lcmType, lfType, MemberList.Destination);
                //var reverseMap = map.ReverseMap();
                if (!lcmType.IsValueType)
                {
                    // These properties have naming collision due to Lcm properties both with and without the "RA" postfix
                    if (lfType.IsAssignableTo(typeof(LfScrBook)))
                    {
                        map.ForMember(nameof(LfScrBook.BookId), opt => opt.MapFrom(src => ((IScrBook)src).BookIdRA));
                        map.ForMember(nameof(LfScrBook.BookIdGuid), opt => opt.MapFrom(src => ((IScrBook)src).BookIdRA));
                    }
                    if (lfType.IsAssignableTo(typeof(LfScrScriptureNote)))
                    {
                        map.ForMember(nameof(LfScrScriptureNote.AnnotationType), opt => opt.MapFrom(src => ((IScrScriptureNote)src).AnnotationTypeRA));
                        map.ForMember(nameof(LfScrScriptureNote.AnnotationTypeGuid), opt => opt.MapFrom(src => ((IScrScriptureNote)src).AnnotationTypeRA));
                    }
                    if (lfType.IsAssignableTo(typeof(ICustomFieldOwner)))
                    {
                        map.ForMember(nameof(ICustomFieldOwner.CustomFieldValues), opt => opt.MapFrom((src, _, __, context) =>
                            customFieldService.GetCustomFieldValues((ICmObject)src, context)));
                    }

                    map.PreserveReferences();
                    //reverseMap.PreserveReferences();
                    map.IncludeAllDerived();
                    //reverseMap.IncludeAllDerived();

                    if (lfType.IsAssignableFrom(typeof(LfObject)))
                    {
                        map = map.AfterMap((s, d) =>
                        {
                            if (d.GetType().IsAssignableFrom(typeof(LfObject)))
                            {
                                var a = ((LfObject)d).ClassID;
                            }
                        });
                    }
                }
            }
        }


        cfg.CreateMap<ICmObject, LfObjectId>(MemberList.None)
            .PreserveReferences()
            .IncludeAllDerived()
            .ForMember(dest => dest.Discriminator, opt => opt.MapFrom(src => LcmToLfTypes[src.GetType()].Name));
        cfg.CreateMap<ICmObject, Guid?>().ConvertUsing(src => src == null ? null : src.Guid); // Owner
        cfg.CreateMap<ICmObject, Guid>().ConvertUsing(src => src.Guid); // Owner
        if (GuidIncrementor.HasUsedGuids())
        {
            cfg.ValueTransformers.Add<Guid>(guid => guid.Increment());
        }
        // DateTimeOffset
        cfg.ValueTransformers.Add<DateTime>(date => // TODO: find out how DateTimes are stored in LibLCM uses Local, so we always flip-flop
            date.Kind == DateTimeKind.Local ? date.ToUniversalTime() // 14:00 -> 14:00 UTC
            : date.ToLocalTime()); // TODO is Utc .... is unspecified => Exception
        cfg.CreateMap<ITsTextProps?, List<TextProperty>>().ConvertUsing((src, dest) =>
        {
            var props = dest ?? new List<TextProperty>();
            props.Clear();
            if (src == null)
            {
                return props;
            }
            System.Linq.Enumerable.Range(0, src.IntPropCount).Select(i =>
            {
                int value = src.GetIntProp(i, out int propKey /*FwTextPropType*/, out int variation);
                return (TextProperty)new IntTextProperty
                {
                    Key = propKey,
                    Variation = variation,
                    Value = value,
                };
            }).Concat(System.Linq.Enumerable.Range(0, src.StrPropCount).Select(i =>
            {
                string value = src.GetStrProp(i, out int propKey /*FwTextPropType*/);
                return (TextProperty)new StringTextProperty
                {
                    Key = propKey,
                    Value = value.Replace("\u0000", JSONB_NULL), // Postgres doesn't like null characters
                };
            })).ForEach(props.Add);
            return props;
        });
        cfg.CreateMap<TsRunPart, LfTsRunPart>();
        cfg.CreateMap<ITsString, LfTsString>();
        cfg.CreateMap<ITsMultiString, List<LfWsTsString>>().ConvertUsing((src, dest, c) =>
            {
                dest ??= new List<LfWsTsString>();
                for (int i = 0; i < src.StringCount; i++)
                {
                    var val = src.GetStringFromIndex(i, out var wsHandle);
                    var wsId = wsManager.GetStrFromWs(wsHandle);
                    dest.Add(new LfWsTsString
                    {
                        Text = val.Text,
                        Runs = c.Mapper.Map<List<LfTsRunPart>>(val.Runs()),
                        WritingSystem = wsId,
                    });
                }
                return dest;
            });
    }

    public static void MapLFToLibLCM(this IMapperConfigurationExpression cfg, ILcmServiceLocator services, WritingSystemManager wsManager)
    {
        /*
        cfg.CreateMap<LfPossibility, ICmPossibility>(MemberList.None).PreserveReferences()
        .ConstructUsing((src, ctx) =>
        {
            var idFac = Services.GetInstance<ICmObjectIdFactory>();
            var repo = Services.GetInstance<ICmObjectRepository>();
            var id = idFac.FromGuid(src.Owner);
            var owner = repo.GetObject(id);
            var possFac = Services.GetInstance<ICmPossibilityFactory>();
            // An unhandled exception of type 'System.InvalidOperationException' occurred in SIL.LCModel.dll: 'Not in the right state to register a change.'
            return owner is ICmPossibilityList
                ? possFac.Create(src.Guid, (ICmPossibilityList)owner)
                : possFac.Create(src.Guid, (ICmPossibility)owner);
        })
        //
        .ConvertUsing((src, dest, context) =>
        {
            if (dest == null)
            {
                var idFac = services.GetInstance<ICmObjectIdFactory>();
                var repo = services.GetInstance<ICmObjectRepository>();
                var id = idFac.FromGuid(src.Guid);
                dest = repo.GetObject(id) as ICmPossibility;
            }
            return dest;
        });
        //*/
        cfg.CreateMap<LfTsString, ITsString>().ConvertUsing((src, dest, context) =>
            {
                var tsStringBuilder = new TsIncStrBldr();
                var text = src.Text;
                var prevIchLim = 0;
                src.Runs?.ForEach(run =>
                {
                    run.Props?.ForEach(prop =>
                    {
                        switch (prop)
                        {
                            case IntTextProperty intProp:
                                tsStringBuilder.SetIntPropValues(intProp.Key, intProp.Variation, intProp.Value);
                                break;
                            case StringTextProperty stringProp:
                                tsStringBuilder.SetStrPropValue(stringProp.Key, stringProp.Value?.Replace(JSONB_NULL, "\u0000"));
                                break;
                        }
                    });
                    var runText = text.Substring(prevIchLim, run.IchLim);
                    prevIchLim = run.IchLim;
                    tsStringBuilder.Append(runText);
                    tsStringBuilder.ClearProps();
                });
                return tsStringBuilder.GetString();
            });

        /*cfg.CreateMap<List<LfWsTsString>, IMultiUnicode>()
            .ConvertUsing((src, dest, c) =>
            {
                dest ??= new MultiUnicodeAccessor();
                src.ForEach(wsTsString =>
                {
                    var ws = wsManager.Get(wsTsString.WritingSystem);
                    var tsString = new TsString(wsTsString.Text, wsTsString.Runs.Select(run =>
                    {
                        var props = TsStringUtils.MakePropsBldr();
                        run.Properties?.ForEach(prop =>
                        {
                            switch (prop)
                            {
                                case IntTextProperty intProp:
                                    props.SetIntPropValues(intProp.Key, intProp.Variation, intProp.Value);
                                    break;
                                case StringTextProperty stringProp:
                                    props.SetStrPropValue(stringProp.Key, stringProp.Value);
                                    break;
                            }
                        });
                        return props.GetTextProps();
                    }).ToArray());
                    dest.set_String(ws.Handle, tsString);
                });
                return dest;
            });*/
    }
}

static class GuidIncrementor
{
    private static readonly ISet<Guid> UsedGuids = new HashSet<Guid>();
    private static readonly IDictionary<Guid, Guid> CurrentMappings = new Dictionary<Guid, Guid>();

    public static void Increment()
    {
        CurrentMappings.Clear();
    }

    public static bool HasUsedGuids()
    {
        return UsedGuids.Any();
    }

    public static Guid Increment(this Guid guid)
    {
        if (CurrentMappings.TryGetValue(guid, out Guid value))
        {
            return value;
        }

        Guid newGuid = guid;
        while (UsedGuids.Contains(newGuid))
        {
            newGuid = Guid.NewGuid();
        }
        UsedGuids.Add(newGuid);
        CurrentMappings.Add(guid, newGuid);
        return newGuid;
    }
}