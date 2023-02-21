using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text.Json;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using extract;
using LfSync.Data.Db;
using LfSync.Data.LCModel;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Win32.SafeHandles;
using SIL.LCModel;
using SIL.LCModel.Application;
using SIL.LCModel.Application.ApplicationServices;
using SIL.LCModel.Core.Cellar;
using SIL.LCModel.Core.KernelInterfaces;
using SIL.LCModel.Core.Text;
using SIL.LCModel.Core.WritingSystems;
using SIL.LCModel.Utils;
using SIL.Linq;

namespace transform;

public class Program
{
    private static WritingSystemManager wsManager;
    private static IMapper mapper;
    private static ILcmServiceLocator Services;

    private static void InitMapper(WritingSystemManager wsManager)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ICmObject, Guid>().ConvertUsing(src => src.Guid); // Owner
            cfg.CreateMap<ILexExampleSentence, LfLexExampleSentence>();
            cfg.CreateMap<ICmPossibility, LfCmPossibility>().AfterMap((src, dest) =>
            {
                dest.DateCreated = DateTime.SpecifyKind(dest.DateCreated, DateTimeKind.Utc);
                dest.DateModified = DateTime.SpecifyKind(dest.DateModified, DateTimeKind.Utc);
            });
            cfg.CreateMap<LfCmPossibility, ICmPossibility>(MemberList.None)
            /*
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
            /*/
            .ConvertUsing((src, dest, context) =>
            {
                if (dest == null)
                {
                    var idFac = Services.GetInstance<ICmObjectIdFactory>();
                    var repo = Services.GetInstance<ICmObjectRepository>();
                    var id = idFac.FromGuid(src.Guid);
                    dest = repo.GetObject(id) as ICmPossibility;
                }
                return dest;
            });
            //*/
            cfg.CreateMap(typeof(ILcmOwningCollection<>), typeof(List<>), MemberList.None);
            cfg.CreateMap<ICmPerson, LfCmPerson>();//.ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner.Guid));
            cfg.CreateMap<ITsString, LfTsString>()
                .ConvertUsing((src, dest, context) =>
                {
                    return new LfTsString
                    {
                        Text = src.Text,
                        Runs = GetJsonForRuns(src.Runs()),
                    };
                });
            cfg.CreateMap<LfTsString, ITsString>()
                .ConvertUsing((src, dest, context) =>
                {
                    var tsStringBuilder = new TsIncStrBldr();
                    var text = src.Text;
                    src.Runs?.ForEach(run =>
                    {
                        run.Properties?.ForEach(prop =>
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
                        var runText = text.Substring(0, run.IndexLim);
                        text = text.Substring(run.IndexLim);
                        tsStringBuilder.Append(runText);
                        tsStringBuilder.ClearProps();
                    });
                    return tsStringBuilder.GetString();
                });
            cfg.CreateMap<ITsMultiString, List<LfWsTsString>>()
                .ConvertUsing((src, dest, c) =>
                {
                    dest ??= new List<LfWsTsString>();
                    for (int i = 0; i < src.StringCount; i++)
                    {
                        var val = src.GetStringFromIndex(i, out var wsHandle);
                        var wsId = wsManager.GetStrFromWs(wsHandle);
                        dest.Add(new LfWsTsString
                        {
                            Text = val.Text,
                            Runs = GetJsonForRuns(val.Runs()),
                            WritingSystem = wsId,
                        });
                    }
                    return dest;
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
        });
        config.AssertConfigurationIsValid();
        mapper = config.CreateMapper();
    }

    private static List<LfTsStringRun> GetJsonForRuns(IEnumerable<TsRunPart> runs)
    {
        return runs.Select(run =>
        {
            ITsTextProps props = run.Props;
            return new LfTsStringRun
            {
                IndexLim = run.IchLim,
                Properties = System.Linq.Enumerable.Range(0, props.IntPropCount).Select(i =>
            {
                int value = props.GetIntProp(i, out int propKey /*FwTextPropType*/, out int variation);
                return (TextProperty)new IntTextProperty
                {
                    Key = propKey,
                    Variation = variation,
                    Value = value,
                };
            }).Concat(System.Linq.Enumerable.Range(0, props.StrPropCount).Select(i =>
            {
                string value = props.GetStrProp(i, out int propKey /*FwTextPropType*/);
                return (TextProperty)new StringTextProperty
                {
                    Key = propKey,
                    Value = value,
                };
            })).ToList(),
            };
        }).ToList();
    }

    public static void Main(string[] args)
    {
        var project = args.Length > 0 ? args[0] : "test-chris-02";
        var extractor = new LcmExtractor(project);
        var cache = extractor.ExtractProject();


        var langProj = cache.LangProject;
        /*langProj.LexDbOA.Entries.Take(100).ForEach(entry =>
        {
            Console.Out.WriteLine(entry.HeadWord.Text);
            if (entry.AllSenses.Count > 0)
            {
                var sense = entry.AllSenses[0];
                Console.Out.WriteLine(sense.Definition.AnalysisDefaultWritingSystem.Text);
                Console.Out.WriteLine(sense.Definition.VernacularDefaultWritingSystem.Text);
            }
        });*/



        Services = langProj.Services;
        var entryRepo = langProj.Services.GetInstance<ILexEntryRepository>();
        wsManager = langProj.Services.WritingSystemManager;
        var metaData = langProj.Services.MetaDataCache;
        ISilDataAccessManaged data = (ISilDataAccessManaged)cache.DomainDataByFlid;


        InitMapper(wsManager);

        var a = mapper.Map<ICmPossibility, LfCmPossibility>(langProj.PartsOfSpeechOA.ReallyReallyAllPossibilities.First());


        var an = langProj.AnthroListOA;


        PersistPossibilityList(langProj.RestrictionsOA);
        PersistPossibilityList(langProj.StatusOA);
        PersistPossibilityList(langProj.ConfidenceLevelsOA);
        PersistPossibilityList(langProj.PeopleOA);
        PersistPossibilityList(langProj.KeyTermsList);
        PersistPossibilityList(langProj.PartsOfSpeechOA);
        PersistPossibilityList(langProj.TranslationTagsOA);
        PersistPossibilityList(langProj.ThesaurusRA);
        PersistPossibilityList(langProj.AnthroListOA);
        PersistPossibilityList(langProj.RolesOA);
        PersistPossibilityList(langProj.LocationsOA);
        PersistPossibilityList(langProj.EducationOA);
        PersistPossibilityList(langProj.TimeOfDayOA);
        PersistPossibilityList(langProj.AffixCategoriesOA);
        PersistPossibilityList(langProj.PositionsOA);
        PersistPossibilityList(langProj.AnnotationDefsOA);
        PersistPossibilityList(langProj.SemanticDomainListOA);
        PersistPossibilityList(langProj.GenreListOA);
        PersistPossibilityList(langProj.TextMarkupTagsOA);

        using (var context = new LibLCMDbContext())
        {
            var s = context.Possibilities.AsEnumerable().Where(p => p.Name.Any(n => n.Text == "No restrictions")).FirstOrDefault();
            Print(s.Name.FirstOrDefault().Text);
        }

        var possRepo = langProj.Services.GetInstance<ICmPossibilityRepository>();
        possRepo.AllInstances().ForEach(example =>
        {
            var dest = mapper.Map<ICmPossibility, LfCmPossibility>(example);
            using (var context = new LibLCMDbContext())
            {
                if (context.Possibilities.Find(dest.Guid) == null)
                {
                    context.Possibilities.Add(dest);
                    "context.SaveChanges();"
                }
            }
        });

        var exampleRepo = langProj.Services.GetInstance<ILexExampleSentenceRepository>();
        exampleRepo.AllInstances().ForEach(example =>
        {
            var dest = mapper.Map<ILexExampleSentence, LfLexExampleSentence>(example);

            using (var context = new LibLCMDbContext())
            {
                if (context.ExampleSentences.Find(dest.Guid) == null)
                {
                    context.ExampleSentences.Add(dest);
                    context.SaveChanges();
                }
            }

        });


        return;

        langProj.RestrictionsOA.ReallyReallyAllPossibilities.ForEach(pos =>
        {
            var dest = mapper.Map<ICmPossibility, LfCmPossibility>(pos);
            var src = mapper.Map<LfCmPossibility, ICmPossibility>(dest);
            Print(dest.Name?.FirstOrDefault(n => !string.IsNullOrWhiteSpace(n.Text))?.Text + " : " + src.Name.BestAnalysisVernacularAlternative);
        });


        entryRepo.AllInstances()
            .Where(entry => LexemeContains(entry, "bubu"))
            .Take(10).ForEach(entry =>
        {
            entry.LexemeFormOA.Form.AvailableWritingSystemIds.ForEach(wsid =>
            {
                var ws = wsManager.Get(wsid);
                var lexeme = entry.LexemeFormOA;
                var form = lexeme.Form;
                var wsForm = form.get_String(wsid);
                if (form != null)
                {
                    Console.Out.WriteLine($"{ws} {form} {wsForm}");
                }
            });

            List<int> customFieldIds = metaData
                .GetFields(entry.ClassID, false, (int)CellarPropertyTypeFilter.All)
                .Where(flid => cache.GetIsCustomField(flid))
                .ToList();

            var customFields = customFieldIds.Select(fieldId =>
            {
                return new
                {
                    FieldId = fieldId,
                    FieldName = metaData.GetFieldName(fieldId),
                    FieldType = metaData.GetFieldType(fieldId),
                    FieldWs = metaData.GetFieldWs(fieldId)
                };
            });

            customFieldIds.ForEach(fieldId =>
            {
                CellarPropertyType LcmFieldType = (CellarPropertyType)metaData.GetFieldType(fieldId);
                if (LcmFieldType != CellarPropertyType.OwningAtom)
                {
                    return;
                }

                int ownedHvo = data.get_ObjectProp(entry.Hvo, fieldId);
                var prop = cache.GetAtomicPropObject(ownedHvo);
                if (prop is not IStText)
                {
                    return;
                }
                Print(string.Join(" -- ", ((IStText)prop).ParagraphsOS.OfType<IStTxtPara>().Select(p => p.Contents?.ToString() ?? "")));
            });
        });

        //Print(nameof(langProj.AllWritingSystems), langProj.AllWritingSystems);
        Print(nameof(langProj.CurrentVernacularWritingSystems), langProj.CurrentVernacularWritingSystems);
        //Print(nameof(langProj.VernacularWritingSystems), langProj.VernacularWritingSystems);
        Print(nameof(langProj.CurrentAnalysisWritingSystems), langProj.CurrentAnalysisWritingSystems);
        //Print(nameof(langProj.AnalysisWritingSystems), langProj.AnalysisWritingSystems);
        Print(nameof(langProj.CurrentPronunciationWritingSystems), langProj.CurrentPronunciationWritingSystems);
        Print(nameof(cache.ServiceLocator.WritingSystemManager.OtherWritingSystems), cache.ServiceLocator.WritingSystemManager.OtherWritingSystems);
    }

    private static bool LexemeContains(ILexEntry entry, string search)
    {
        foreach (int wsid in entry.LexemeFormOA.Form.AvailableWritingSystemIds)
        {
            var lexeme = entry.LexemeFormOA;
            var form = lexeme.Form;
            var wsForm = form.get_String(wsid);
            if (wsForm?.ToString()?.Contains(search) ?? false)
            {
                return true;
            }
        }
        return false;
    }

    public static void Print(string header, IEnumerable<CoreWritingSystemDefinition> writingSystems)
    {
        Print($"--- {header} ---");
        writingSystems.ForEach(ws => Print($"{ws.Handle}: {ws}"));
        Print();
    }

    public static void Print(string text = "")
    {
        Console.Out.WriteLine(text);
    }

    public static void PersistPossibilityList(ICmPossibilityList list)
    {
        using (var context = new LibLCMDbContext())
        {
            list?.ReallyReallyAllPossibilities.ForEach(pos =>
            {
                var dest = mapper.Map<ICmPossibility, LfCmPossibility>(pos);
                if (context.Possibilities.Find(dest.Guid) == null)
                {
                    context.Possibilities.Add(dest);
                }
            });
            context.SaveChanges();
        }
    }


}
