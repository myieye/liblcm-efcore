namespace LfSync.Data.LCModel.old;

/// <summary>
/// Interface that allows several classes to be combined into one signature,
/// so the signature need not be LfObject.
/// </summary>
public class LfAnalysis : LfObject
{
    /// <summary>
    /// Get the WfiWordform.
    /// </summary>
    public LfWfiWordform Wordform
    { get; set; }

    /// <summary>
    /// Returns true if the analysis is or is owned by a wordform. (Not a punctuation form.)
    /// </summary>
    public bool HasWordform { get; set; }

    /// <summary>
    /// The associated WfiAnalysis, if any; returns null for WfiWordform, this for WfiAnalysis, owner for WfiGloss.
    /// </summary>
    public LfWfiAnalysis Analysis { get; set; }
}
