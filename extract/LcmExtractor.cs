using SIL.LCModel;
using SIL.LCModel.Utils;
using SIL.WritingSystems;

namespace extract;

public class LcmExtractor
{
    private readonly string _projectName;

    public LcmExtractor(string projectName)
    {
        _projectName = projectName;
    }

    public LcmCache ExtractProject()
    {
        Sldr.Initialize();
        var cache = BuildCache(_projectName);
        Sldr.Cleanup();
        if (cache == null)
        {
            throw new InvalidOperationException("Failed to load project.");
        }
        return cache;
    }

    private static LcmCache? BuildCache(string projectName)
    {
        var progress = new LcmThreadedProgress();
        var lcmUi = new LfLcmUi(new SingleThreadedSynchronizeInvoke());
        var projectDir = new LcmDirectories("C:\\ProgramData\\SIL\\FieldWorks\\Projects", "C:\\ProgramData\\SIL\\FieldWorks\\Templates");
        var projectId = new LcmProjectIdentifier(projectDir, projectName);
        return LcmCache.CreateCacheFromExistingData(
            projectId, Thread.CurrentThread.CurrentUICulture.Name, lcmUi,
            projectId.LcmDirectories, new LcmSettings(), progress);
    }
}
