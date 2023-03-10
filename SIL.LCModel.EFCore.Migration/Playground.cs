using static SIL.LCModel.EFCore.Migration.Utils;

namespace SIL.LCModel.EFCore.Migration
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