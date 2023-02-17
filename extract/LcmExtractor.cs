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

    public LcmCache? ExtractProject()
    {
        Sldr.Initialize();
        var cache = BuildCache(_projectName);
        Sldr.Cleanup();
        return cache;
    }

    private static LcmCache? BuildCache(string projectName)
    {
        var progress = new LcmThreadedProgress();
        var lcmUi = new LfLcmUi(new SingleThreadedSynchronizeInvoke());
        var projectDir = new LcmDirectories("C:\\ProgramData\\SIL\\FieldWorks\\Projects", "C:\\ProgramData\\SIL\\FieldWorks\\Templates");
        var projectId = new LcmProjectIdentifier(projectDir, projectName);

        try
        {
            return LcmCache.CreateCacheFromExistingData(
                projectId, Thread.CurrentThread.CurrentUICulture.Name, lcmUi,
                projectId.LcmDirectories, new LcmSettings(), progress);
        }
        catch (LcmDataMigrationForbiddenException)
        {
            Console.Out.WriteLine("LCM: Incompatible version (can't migrate data)");
            return null;
        }
        catch (LcmNewerVersionException)
        {
            Console.Out.WriteLine("LCM: Incompatible version (version number newer than expected)");
            return null;
        }
        catch (LcmFileLockedException)
        {
            Console.Out.WriteLine("LCM: Access denied");
            return null;
        }
        catch (LcmInitializationException e)
        {
            Console.Out.WriteLine("LCM: Unknown error: {0}", e.Message);
            return null;
        }
    }
}
// See https://aka.ms/new-console-template for more information