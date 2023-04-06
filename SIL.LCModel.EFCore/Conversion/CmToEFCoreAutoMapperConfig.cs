using AutoMapper;
using AutoMapper.Internal;
using LfSync.LcmModelGenerator;
using SIL.Extensions;
using SIL.LCModel.Core.KernelInterfaces;
using SIL.LCModel.Core.Text;
using SIL.LCModel.Core.WritingSystems;
using SIL.LCModel.DomainImpl;
using SIL.LCModel.EFCore.Model;
using SIL.LCModel.Utils;
using SIL.Linq;
using StructureMap.TypeRules;

namespace SIL.LCModel.EFCore.Conversion;

public static class CmToEFCoreAutoMapperConfig
{
    private const string JSONB_NULL = "<|NULL|>";

    private static readonly Dictionary<Type, Type> LcmToLfTypes = new();
    private static readonly Dictionary<Type, Type> LfToConcreteLcmTypes = new();
    private static Dictionary<string, Type>? _lfTypesByName;
    private static Dictionary<string, Type> LfTypesByName
    {
        get
        {
            return _lfTypesByName ??= AppDomain.CurrentDomain.GetAssemblies()
                .First(ass => ass.GetName().Name?.Equals("SIL.LCModel.EFCore") ?? false)
                .GetTypes()
                .Where(t => !t.IsEnum)
                .Where(t => t.IsAssignableTo(typeof(LfObject)) || t.IsValueType)
                .Where(t => t.Namespace?.Equals(typeof(LfObject).Namespace) ?? false)
                .ToDictionary(t => t.Name, t => t);
        }
    }
    private static Dictionary<string, Type>? _lcmObjectOrIdOrValueTypesByName;
    private static Dictionary<string, Type> LcmObjectOrIdOrValueTypesByName
    {
        get
        {
            return _lcmObjectOrIdOrValueTypesByName ??= System.Linq.Enumerable
                .DistinctBy(AppDomain.CurrentDomain.GetAssemblies()
                    .Where(ass => ass.FullName?.StartsWith("SIL.LCModel") ?? false)
                    .SelectMany(ass => ass.GetTypes())
                    .Where(t => !t.IsEnum)
                    .Where(t => t.IsAssignableTo(typeof(ICmObjectOrId)) || t.IsValueType),
                    t => t.Name)
                .ToDictionary(t => t.Name, t => t);
        }
    }
    private static Dictionary<string, IGrouping<string, Type>>? _lcmTypesByLfNames;
    private static Dictionary<string, IGrouping<string, Type>> LcmTypesByLfNames
    {
        get
        {
            if (_lcmTypesByLfNames == null)
            {
                var lfTypesByName = LfTypesByName;
                _lcmTypesByLfNames = LcmObjectOrIdOrValueTypesByName.Values
                    .GroupBy(t => NameUtils.LcmNameToLf(t.Name))
                    .Where(t => lfTypesByName.ContainsKey(t.Key))
                    .ToDictionary(g => g.Key, g => g);
            }
            return _lcmTypesByLfNames;
        }
    }

    private static LcmCache Cache;

    private static IMapper _mapper;
    private static IMapper Mapper
    {
        get
        {
            if (_mapper == null)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    var prefixes = new string[] { "m_" };
                    var postfixes = new string[] { "RA", "RC", "RS", "OA", "OC", "OS" };
                    var destinationPostfixes = new string[] { "Guid" }.Concat(postfixes).ToArray();
                    var cmPropsWithNoField = new string[] { nameof(ICmObject.OwningFlid), nameof(ICmObject.OwnOrd), nameof(ICmObject.ClassID) };
                    cfg.RecognizePostfixes(postfixes);
                    cfg.RecognizePrefixes(prefixes);
                    cfg.RecognizeDestinationPostfixes(destinationPostfixes);
                    cfg.RecognizeDestinationPrefixes(prefixes);
                    cfg.IncludeSourceExtensionMethods(typeof(TextExtensions));
                    cfg.ShouldMapField = field => field.IsPublic // default + ...
                        || field.DeclaringType.IsAssignableTo(typeof(ICmObjectOrId));
                    cfg.ShouldMapProperty = property =>
                    {
                        if (!property.IsPublic())
                            return false; // default - ...
                        var declaringType = property.DeclaringType;
                        return !declaringType.Equals(typeof(IEmbeddedObject)) &&
                            !declaringType.Equals(typeof(IFilter)) &&
                            (!property.DeclaringType.IsAssignableTo(typeof(ICmObjectOrId)) || cmPropsWithNoField.Contains(property.Name));
                    };
                    cfg.MapLibLCMToLF();
                    cfg.MapLFToLibLCM();
                });
                config.AssertConfigurationIsValid();
                _mapper = config.CreateMapper();
            }
            return _mapper;
        }
    }

    public static Type GetLfType(Type lcmType)
    {
        return LcmToLfTypes[lcmType];
    }

    public static Type GetConcreteLcmType(Type lfType)
    {
        return LfToConcreteLcmTypes[lfType];
    }

    public static Dictionary<Type, Type> FindTypeMappings(string typeQuery)
    {
        return LcmToLfTypes.Where(kvp => kvp.Key.Name.Contains(typeQuery) || kvp.Value.Name.Contains(typeQuery)).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    public static IMapper InitMapper(LcmCache cache)
    {
        Cache = cache;
        GuidIncrementor.Increment();
        return Mapper;
    }

    public static void MapLibLCMToLF(this IMapperConfigurationExpression cfg)
    {
        var initTypeMapper = LcmToLfTypes?.Count == 0;
        var lfTypesByName = LfTypesByName;
        var lcmTypesByLfNames = LcmTypesByLfNames;

        foreach (var lcmTypesByLfName in lcmTypesByLfNames)
        {
            var lfName = lcmTypesByLfName.Key;

            foreach (var lcmType in lcmTypesByLfName.Value)
            {
                if (lcmType == typeof(ITsString))
                {
                    continue;
                }
                var lfType = lfTypesByName[lfName];
                if (initTypeMapper)
                {
                    LcmToLfTypes.Add(lcmType, lfType);
                    if (lcmType.IsConcrete())
                    {
                        LfToConcreteLcmTypes.Add(lfType, lcmType);
                    }
                }

                var map = cfg.CreateMap(lcmType, lfType,
                    lcmType.IsAssignableTo(typeof(IWritingSystemContainer)) ? MemberList.None // TODO: LfLangProject doesn't have a writing-system configuration
                        : lcmType.IsInterface ? MemberList.None // Interfaces don't have fields, so the configuration blows up. But the classes get validated, so I assume we're ok
                        : MemberList.Destination);
                var reverseMap = map.ReverseMap();
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
                            CustomFieldService.Instance(Cache).GetCustomFieldValues((ICmObject)src, context)));
                    }

                    map.PreserveReferences();
                    reverseMap.PreserveReferences();
                    map.IncludeAllDerived();
                    reverseMap.IncludeAllDerived();

                    reverseMap.ForAllMembers(opt =>
                    {
                        opt.SetMappingOrder(10);
                        // This is nested, because actions passed to ForAllMembers are called after actions passed to ForMember
                        // But we need to make sure that the cache is set first (and, yes, setting the order only for the cache property doesn't work :())
                        reverseMap.ForMember(nameof(ICmObject.Cache), opt =>
                        {
                            opt.SetMappingOrder(1);
                            opt.MapFrom(_ => Cache);
                        });
                        reverseMap.ForMember(nameof(ICmObject.Hvo), opt =>
                        {
                            opt.SetMappingOrder(1);
                        });
                    });

                    reverseMap.BeforeMap((lfObject, lcmObject, context) =>
                    {
                        context.GetCmObjectStack().Push((ICmObject)lcmObject);
                    });
                    reverseMap.AfterMap((lfObject, lcmObject, context) =>
                    {
                        context.GetCmObjectStack().Pop();
                    });

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


        LcmObjectOrIdOrValueTypesByName.Values.Where(type => !type.IsValueType).ForEach((lcmType) =>
        {
            cfg.CreateMap(lcmType, typeof(LfObjectId))
                .PreserveReferences()
                .IncludeAllDerived()
                // Preserve references doesn't cut it, because sometimes we get actual objects and sometimes we need to fluff up IDs
                .ConvertUsing((lcmObject, _, ctx) => ctx.GetOrCreateLfObjectId(lcmObject as ICmObjectOrId, Cache));
        });


        lfTypesByName.Values.Where(lfType => !lfType.IsValueType).ForEach((lfType) =>
        {
            cfg.CreateMap(lfType, typeof(object))
                .IncludeAllDerived()
                .PreserveReferences()
                .ConvertUsing((src, _, ctx) =>
                {
                    if (src == null)
                        return null;
                    var lcmType = GetConcreteLcmType(src.GetType());
                    return ctx.Mapper.Map(src, lfType, lcmType);
                });
        });

        cfg.CreateMap<Guid?, object>()
            .ConvertUsing((src, dest, ctx) =>
            {
                return dest ?? src;
            });

        cfg.CreateMap<Guid, object>()
            .ConvertUsing((src, dest, ctx) =>
            {
                return dest ?? src;
            });

        LcmObjectOrIdOrValueTypesByName.Values.Where(type => type.IsAssignableTo(typeof(ICmObjectOrId)) && !type.IsAssignableTo(typeof(ICmObject))).ForEach((lcmIdType) =>
        {
            lfTypesByName.Values.ForEach((lfType) =>
            {
                cfg.CreateMap(lcmIdType, lfType)
                    .IncludeAllDerived()
                    .ConvertUsing((src, dest) => dest);
            });
        });

        //*
        LcmObjectOrIdOrValueTypesByName.Values.Where(type => type.IsAssignableTo(typeof(ICmObjectOrId))).ForEach((lcmIdType) =>
        {
            cfg.CreateMap(lcmIdType, typeof(Guid))
                .IncludeAllDerived()
                .ConvertUsing(src => (src as ICmObjectOrId).Id.Guid);
        });

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
                if (src == null)
                {
                    return new List<LfWsTsString>();
                }
                var wsManager = Cache.ServiceLocator.WritingSystemManager;
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

    public static void MapLFToLibLCM(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap(typeof(List<>), typeof(ILcmOwningCollection<>), MemberList.None)
            .ConvertUsing(typeof(OwningCollectionConverter<,>));
        cfg.CreateMap(typeof(List<>), typeof(ILcmReferenceCollection<>), MemberList.None)
            .ConvertUsing(typeof(ReferenceCollectionConverter<,>));
        cfg.CreateMap(typeof(List<>), typeof(ILcmOwningSequence<>), MemberList.None)
            .ConvertUsing(typeof(OwningSequenceConverter<,>));
        cfg.CreateMap(typeof(List<>), typeof(ILcmReferenceSequence<>), MemberList.None)
            .ConvertUsing(typeof(ReferenceSequenceConverter<,>));
        cfg.CreateMap<Guid, ICmObjectId>().ConstructUsing((guid, ctx) =>
        {
            var factory = Cache.ServiceLocator.GetInstance<ICmObjectIdFactory>();
            return factory.FromGuid(guid);
        });
        cfg.CreateMap<Guid, ICmObjectOrId>().ConstructUsing((guid, ctx) =>
        {
            var factory = Cache.ServiceLocator.GetInstance<ICmObjectIdFactory>();
            return factory.FromGuid(guid);
        });
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

        void FillITsMultiString(List<LfWsTsString> source, ITsMultiString dest, ResolutionContext ctx)
        {
            var wsManager = Cache.ServiceLocator.WritingSystemManager;
            source.ForEach(wsTsString =>
            {
                var tsString = ctx.Mapper.Map<LfWsTsString, ITsString>(wsTsString);
                var wsHandle = wsManager.GetWsFromStr(wsTsString.WritingSystem);
                (dest as SmallDictionary<int, ITsString>).Add(wsHandle, tsString);
            });
        }

        cfg.CreateMap<List<LfWsTsString>, IMultiString>().IncludeAllDerived()
            .ConvertUsing((src, dest, c) =>
            {
                dest = MultiStringFactory.CreateMultiString(c.GetCmObjectStack().Peek(), 1);
                FillITsMultiString(src, dest, c);
                return dest;
            });

        cfg.CreateMap<List<LfWsTsString>, IMultiUnicode>()
            .ConvertUsing((src, dest, c) =>
            {
                dest = MultiStringFactory.CreateMultiUnicode(c.GetCmObjectStack().Peek(), 1);
                FillITsMultiString(src, dest, c);
                return dest;
            });
    }

    class OwningCollectionConverter<TSource, TDestination>
        : ITypeConverter<List<TSource>, ILcmOwningCollection<TDestination>> where TDestination : class, ICmObject
    {
        public ILcmOwningCollection<TDestination> Convert(List<TSource> src, ILcmOwningCollection<TDestination> dest, ResolutionContext ctx)
        {

            var cmObject = ctx.GetCmObjectStack().Peek();
            return CollectionFactory.CreateOwningCollection<TDestination>(Cache, cmObject, 1);
        }
    }

    class ReferenceCollectionConverter<TSource, TDestination>
        : ITypeConverter<List<TSource>, ILcmReferenceCollection<TDestination>> where TDestination : class, ICmObject
    {
        public ILcmReferenceCollection<TDestination> Convert(List<TSource> src, ILcmReferenceCollection<TDestination> dest, ResolutionContext ctx)
        {
            var cmObject = ctx.GetCmObjectStack().Peek();
            return CollectionFactory.CreateReferenceCollection<TDestination>(Cache, cmObject, 1);
        }
    }

    class OwningSequenceConverter<TSource, TDestination>
        : ITypeConverter<List<TSource>, ILcmOwningSequence<TDestination>> where TDestination : class, ICmObject
    {
        public ILcmOwningSequence<TDestination> Convert(List<TSource> src, ILcmOwningSequence<TDestination> dest, ResolutionContext ctx)
        {

            var cmObject = ctx.GetCmObjectStack().Peek();
            return CollectionFactory.CreateOwningSequence<TDestination>(Cache, cmObject, 1);
        }
    }

    class ReferenceSequenceConverter<TSource, TDestination>
        : ITypeConverter<List<TSource>, ILcmReferenceSequence<TDestination>> where TDestination : class, ICmObject
    {
        public ILcmReferenceSequence<TDestination> Convert(List<TSource> src, ILcmReferenceSequence<TDestination> dest, ResolutionContext ctx)
        {
            var cmObject = ctx.GetCmObjectStack().Peek();
            return CollectionFactory.CreateReferenceSequence<TDestination>(Cache, cmObject, 1);
        }
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

static class MapperExtensions
{
    public static Stack<ICmObject> GetCmObjectStack(this ResolutionContext context)
    {
        return (Stack<ICmObject>)context.Items.GetOrCreate("cm-object-stack", () => new Stack<ICmObject>());
    }

    public static LfObjectId GetOrCreateLfObjectId(this ResolutionContext context, ICmObjectOrId lcmObject, LcmCache cache)
    {
        var existingIds = (Dictionary<Guid, LfObjectId>)context.Items.GetOrCreate("lf-object-ids", () => new Dictionary<Guid, LfObjectId>());
        var guid = lcmObject.Id.Guid;
        return existingIds.GetOrCreate(guid, () =>
        {
            if (!lcmObject.GetType().IsAssignableTo(typeof(ICmObject)))
            {
                // We have to fluff it up in order to determine the type. This should only happen during a migration to EF
                lcmObject = cache.ServiceLocator.GetInstance<ICmObjectRepository>().GetObject(lcmObject as ICmObjectId);
            }
            return new LfObjectId
            {
                Guid = guid,
                Discriminator = CmToEFCoreAutoMapperConfig.GetLfType(lcmObject.GetType()).Name,
            };
        });
    }
}
