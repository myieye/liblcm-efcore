using SIL.LCModel;
using SIL.LCModel.Application;
using SIL.LCModel.Core.Cellar;
using SIL.Linq;
using static transform.Utils;

namespace transform
{
    public class Playground
    {
        public static void PrintWritingSystems(LcmCache cache)
        {
            ILangProject langProj = cache.LangProject;
            //Print(nameof(langProj.AllWritingSystems), langProj.AllWritingSystems);
            Print(nameof(langProj.CurrentVernacularWritingSystems), langProj.CurrentVernacularWritingSystems);
            //Print(nameof(langProj.VernacularWritingSystems), langProj.VernacularWritingSystems);
            Print(nameof(langProj.CurrentAnalysisWritingSystems), langProj.CurrentAnalysisWritingSystems);
            //Print(nameof(langProj.AnalysisWritingSystems), langProj.AnalysisWritingSystems);
            Print(nameof(langProj.CurrentPronunciationWritingSystems), langProj.CurrentPronunciationWritingSystems);
            Print(nameof(cache.ServiceLocator.WritingSystemManager.OtherWritingSystems), cache.ServiceLocator.WritingSystemManager.OtherWritingSystems);
        }

        public static void ExploreCustomFields(LcmCache cache)
        {
            ILangProject langProj = cache.LangProject;
            ILexEntryRepository entryRepo = langProj.Services.GetInstance<ILexEntryRepository>();
            var wsManager = langProj.Services.WritingSystemManager;
            var metaData = langProj.Services.MetaDataCache;
            ISilDataAccessManaged data = (ISilDataAccessManaged)cache.DomainDataByFlid;

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
                    ICmObject prop = cache.GetAtomicPropObject(ownedHvo);
                    if (prop is not IStText)
                    {
                        return;
                    }
                    Print(string.Join(" -- ", ((IStText)prop).ParagraphsOS.OfType<IStTxtPara>().Select(p => p.Contents?.ToString() ?? "")));
                });
            });
        }

        public static bool LexemeContains(ILexEntry entry, string search)
        {
            foreach (int wsid in entry.LexemeFormOA.Form.AvailableWritingSystemIds)
            {
                IMoForm lexeme = entry.LexemeFormOA;
                IMultiUnicode form = lexeme.Form;
                SIL.LCModel.Core.KernelInterfaces.ITsString wsForm = form.get_String(wsid);
                if (wsForm?.ToString()?.Contains(search) ?? false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}