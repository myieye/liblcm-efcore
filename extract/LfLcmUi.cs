using System.ComponentModel;
using SIL.LCModel;

namespace extract;

public class LfLcmUi : ILcmUI
{
    private ISynchronizeInvoke _synchronizeInvoke;

    public LfLcmUi(ISynchronizeInvoke synchronizeInvoke)
    {
        _synchronizeInvoke = synchronizeInvoke;
    }

    public void DisplayCircularRefBreakerReport(string msg, string caption)
    {
        Console.Out.WriteLine(msg);
    }

    public bool ConflictingSave()
    {
        Console.Out.WriteLine("ConsoleLcmUI.ConflictingSave...");
        // Revert to saved state
        return true;
    }

    public bool ConnectionLost()
    {
        throw new NotImplementedException();
    }

    public FileSelection ChooseFilesToUse()
    {
        throw new NotImplementedException();
    }

    public bool RestoreLinkedFilesInProjectFolder()
    {
        throw new NotImplementedException();
    }

    public YesNoCancel CannotRestoreLinkedFilesToOriginalLocation()
    {
        throw new NotImplementedException();
    }

    public void DisplayMessage(MessageType type, string message, string caption, string helpTopic)
    {
        Console.Out.WriteLine("{0}: {1}", type, message);
    }

    public void ReportException(Exception error, bool isLethal)
    {
        Console.Out.WriteLine("Got exception: {0}: {1}\n{2}", error.GetType(), error.Message, error);
    }

    public void ReportDuplicateGuids(string errorText)
    {
        Console.Out.WriteLine("Duplicate GUIDs: " + errorText);
    }

    public bool Retry(string msg, string caption)
    {
        Console.WriteLine(msg);
        return true;
    }

    public bool OfferToRestore(string projectPath, string backupPath)
    {
        return false;
    }

    public void Exit()
    {
        Console.Out.WriteLine("Exiting");
    }

    public ISynchronizeInvoke SynchronizeInvoke => _synchronizeInvoke;

    public DateTime LastActivityTime => DateTime.Now;
}
