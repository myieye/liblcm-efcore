using SIL.LCModel.EFCore.Model;

namespace SIL.LCModel.EFCore.Migration;

public static class WritingSystemService
{

    public static List<WritingSystem> GetWritingSystems(LcmCache cache)
    {
        var analysisWs = cache.ServiceLocator.WritingSystems.AnalysisWritingSystems;
        var vernacularWs = cache.ServiceLocator.WritingSystems.VernacularWritingSystems;
        var wsManager = cache.ServiceLocator.WritingSystemManager;
        return wsManager.WritingSystems.Select(ws => new WritingSystem
        {
            Id = ws.Id,
            LanguageTag = ws.LanguageTag,
            Abbreviation = ws.Abbreviation,
            LanguageName = ws.LanguageName,
            DisplayName = ws.DisplayLabel,
            IcuLocale = ws.IcuLocale,
            IsRightToLeft = ws.RightToLeftScript,
            IsVoice = ws.IsVoice,
            IpaType = ws.IpaStatus,
            CharacterSet = ws.CharacterSets.Select(cs => new CharacterSet
            {
                Type = cs.Type,
                Characters = cs.Characters.ToList(),
            }).ToList(),
            DefaultFontName = ws.DefaultFontName,
            IsVernacular = vernacularWs.Contains(ws),
            IsAnalysis = analysisWs.Contains(ws),
            IsHidden = !(vernacularWs.Contains(ws) || analysisWs.Contains(ws)),
        }).ToList();
    }
}
