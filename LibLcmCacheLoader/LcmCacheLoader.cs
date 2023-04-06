using SIL.LCModel;
using SIL.LCModel.Utils;
using SIL.WritingSystems;

namespace LibLcmCacheLoader;

public class LcmCacheLoader : IDisposable
{
    private readonly string _projectName;

    public LcmCacheLoader(string projectName)
    {
        _projectName = projectName;
		Watch.Time("Icu.Wrapper.Init()", () => Icu.Wrapper.Init());
		Watch.Time("Sldr.Initialize()", () => Sldr.Initialize());
    }

    public LcmCache ExtractProject(Type? customBackendProvider = null)
    {
        var cache = LoadCache(_projectName, customBackendProvider);
        if (cache == null)
        {
            throw new InvalidOperationException("Failed to load project.");
        }
        return cache;
    }

    private static LcmCache? LoadCache(string projectName, Type? customBackendProvider)
    {
        var progress = new LcmThreadedProgress();
        var lcmUi = new LfLcmUi(new SingleThreadedSynchronizeInvoke());
        var projectDir = new LcmDirectories("C:\\ProgramData\\SIL\\FieldWorks\\Projects", "C:\\ProgramData\\SIL\\FieldWorks\\Templates");
        var projectId = new LcmProjectIdentifier(projectDir, projectName);
        return Watch.Time("LcmCache.CreateCacheFromExistingData()", () => LcmCache.CreateCacheFromExistingData(
            projectId, null /* Thread.CurrentThread.CurrentUICulture.Name */, lcmUi,
            projectId.LcmDirectories, new LcmSettings(), progress, customBackendProvider));
    }

    public void Dispose()
    {
		Icu.Wrapper.Cleanup();
		Sldr.Cleanup();
    }
}
