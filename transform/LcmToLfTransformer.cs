using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text.Json;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using extract;
using LfSync.Data.LCModel;
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

    private static void InitMapper(WritingSystemManager wsManager)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ILexExampleSentence, LfLexExampleSentence>();
            cfg.CreateMap<ICmPossibility, LfCmPossibility>();
            cfg.CreateMap(typeof(ILcmOwningCollection<>), typeof(List<>), MemberList.None);
            cfg.CreateMap<ICmPerson, LfCmPerson>();
            cfg.CreateMap<ITsString, LfTsString>()
                .ConvertUsing((src, dest, context) =>
                {
                    return new LfTsString
                    {
                        Text = src.Text,
                        Runs = GetJsonForRuns(src.Runs()),
                    };
                });
            cfg.CreateMap<ITsMultiString, List<LfWsTsString>>()
                .ConvertUsing((src, dest) =>
                {
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
        });
        config.AssertConfigurationIsValid();
        mapper = config.CreateMapper();
    }

    private static string GetJsonForRuns(IEnumerable<TsRunPart> runs)
    {
        return JsonSerializer.Serialize(runs.Select(run =>
        {
            ITsTextProps props = run.Props;
            return System.Linq.Enumerable.Range(0, props.IntPropCount).Select(i =>
            {
                int value = props.GetIntProp(i, out int propKey /*FwTextPropType*/, out int variation);
                return JsonSerializer.Serialize(new
                {
                    propKey,
                    variation,
                    value,
                });
            }).Concat(System.Linq.Enumerable.Range(0, props.StrPropCount).Select(i =>
            {
                string value = props.GetStrProp(i, out int propKey /*FwTextPropType*/);
                return JsonSerializer.Serialize(new
                {
                    propKey,
                    value,
                });
            }));
        }));
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



        var entryRepo = langProj.Services.GetInstance<ILexEntryRepository>();
        wsManager = langProj.Services.WritingSystemManager;
        var metaData = langProj.Services.MetaDataCache;
        ISilDataAccessManaged data = (ISilDataAccessManaged)cache.DomainDataByFlid;


        InitMapper(wsManager);

        var a = mapper.Map<ICmPossibility, LfCmPossibility>(langProj.PartsOfSpeechOA.ReallyReallyAllPossibilities.First());

        langProj.PartsOfSpeechOA.ReallyReallyAllPossibilities.ForEach(pos =>
        {
            var dest = mapper.Map<ICmPossibility, LfCmPossibility>(pos);
            Print(mapper.Map<ICmPossibility, LfCmPossibility>(pos).Name?.FirstOrDefault(n => !string.IsNullOrWhiteSpace(n.Text))?.Text + " : " + pos.Name.BestAnalysisVernacularAlternative);
        });

        var exampleRepo = langProj.Services.GetInstance<ILexExampleSentenceRepository>();

        exampleRepo.AllInstances().ForEach(example =>
        {
            var dest = mapper.Map<ILexExampleSentence, LfLexExampleSentence>(example);
            Print(dest.Example.FirstOrDefault()?.Text);
        });

        return;


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


}
