using System.Text.RegularExpressions;
using AutoMapper;
using LfSync.Data.LCModel;
using SIL.LCModel;
using SIL.LCModel.Core.KernelInterfaces;
using SIL.LCModel.Core.Text;
using SIL.LCModel.Core.WritingSystems;
using SIL.Linq;

namespace transform;

public static class AutoMapperConfig
{
    private static readonly Dictionary<Type, Type> LcmToLfTypes = new();
    private static readonly Dictionary<Type, Type> LfToLcmTypes = new();

    public static Type GetLfType(Type lcmType)
    {
        return LcmToLfTypes[lcmType];
    }

    public static IMapper InitMapper(ILcmServiceLocator services, WritingSystemManager wsManager)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.MapLibLCMToLF(services, wsManager);
            cfg.MapLFToLibLCM(services, wsManager);
        });
        return config.CreateMapper();
    }

    private static HashSet<object> setA = new HashSet<object>();
    private static HashSet<object> setB = new HashSet<object>();
    public static void MapLibLCMToLF(this IMapperConfigurationExpression cfg, ILcmServiceLocator services, WritingSystemManager wsManager)
    {
        var lfTypes = AppDomain.CurrentDomain.GetAssemblies().Where(ass => ass.FullName.StartsWith("LfSync.Data"))
            .SelectMany(ass => ass.GetTypes())
            .Where(t => !t.IsEnum)
            .Where(t => t.Namespace?.StartsWith(typeof(LfObject).Namespace) ?? false)
            .ToDictionary(t => t.Name, t => t);

        var lcmTypesByLfNames = AppDomain.CurrentDomain.GetAssemblies().Where(ass => ass.FullName.StartsWith("SIL.LCModel"))
            .SelectMany(ass => ass.GetTypes())
            .Where(t => !t.IsEnum)
            .GroupBy(t => Regex.Replace(t.Name, "^(I(Cm)?)?", ""))
            .Where(t => lfTypes.ContainsKey(t.Key) || lfTypes.ContainsKey($"Lf{t.Key}"))
            .ToDictionary(g => lfTypes.ContainsKey(g.Key) ? g.Key : $"Lf{g.Key}", g =>
                // Prefer the type with the fewest properties, because they contains the data.
                // Extra properties in classes contain constants, projections etc.
                g.FirstOrDefault(t => t.IsInterface)
                ?? g.FirstOrDefault(t => t.IsAbstract)
                ?? g.FirstOrDefault(t => t.Namespace != null && !t.Namespace.Contains("Impl"))
                ?? g.First());

        foreach (var lcmTypesByLfName in lcmTypesByLfNames)
        {
            var lfName = lcmTypesByLfName.Key;
            var lcmType = lcmTypesByLfName.Value;
            var lfType = lfTypes[lfName];
            LcmToLfTypes.Add(lcmType, lfType);
            LfToLcmTypes.Add(lfType, lcmType);
            var map = cfg.CreateMap(lcmType, lfType);
            var reverseMap = map.ReverseMap();
            if (!lcmType.IsValueType)
            {
                map = map.PreserveReferences();
                reverseMap.PreserveReferences();
                if (!lcmType.Name.Equals("ITsString")) // Error "Cannot include map in itself"
                {
                    map = map.IncludeAllDerived();
                    reverseMap.IncludeAllDerived();
                }

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

        cfg.CreateMap<ICmObject, Guid?>().ConvertUsing(src => src == null ? null : src.Guid); // Owner
        cfg.ValueTransformers.Add<DateTime>(date => // LibLCM uses Local, so we always flip-flop
            date.Kind == DateTimeKind.Local ? DateTime.SpecifyKind(date, DateTimeKind.Utc)
            : DateTime.SpecifyKind(date, DateTimeKind.Local));
        //cfg.CreateMap(typeof(ILcmOwningCollection<>), typeof(List<>), MemberList.None); // seemed to be required at some point...
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
                    Value = value,
                };
            })).ForEach(props.Add);
            return props;
        });
        cfg.CreateMap<ITsString, LfTsString>().ConvertUsing((src, dest, context) =>
            {
                return new LfTsString
                {
                    Text = src.Text,
                    Runs = context.Mapper.Map<List<LfTsRunPart>>(src.Runs()),
                };
            });
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
                                tsStringBuilder.SetStrPropValue(stringProp.Key, stringProp.Value);
                                break;
                        }
                    });
                    var runText = text.Substring(0, run.IchLim);
                    text = text.Substring(run.IchLim);
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