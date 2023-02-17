namespace LfSync.Data.LCModel;

public partial class LfCmObject
{
    /// <summary>
    /// Project-specific ID of the object.
    /// </summary>
    public int Hvo
    {
        get;
    }

    /// <summary>
    /// Object owner. (Null, if not owned.)
    /// </summary>
    public LfCmObject Owner
    {
        get;
    }

    /// <summary>
    /// Field ID of the owning object where the object is stored.
    /// </summary>
    public int OwningFlid
    {
        get;
    }

    /// <summary>
    /// Owning ord of the owning object where the object is stored.
    /// </summary>
    public int OwnOrd
    {
        get;
    }

    /// <summary>
    /// Class ID of the object.
    /// </summary>
    public int ClassID
    {
        get;
    }

    /// <summary>
    /// Unique ID of the object. If this will hang around, prefer to use the Id.
    /// </summary>
    public Guid Guid
    {
        get;
    }
}

public partial class LfCmTranslation : LfCmObject
{
    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Translation
    ///
    /// <para>The signature is multiString allowing us to have translations in multiple languages (e.g. ENG, FRN, SPN). </para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfWsTsString> Translation
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfWsTsString>();

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the Type
    ///
    /// <para>The type of translation: free, literal, back, front, etc.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public LfCmPossibility TypeRA
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Status
    ///
    /// <para>A label to hold any kind of metadata about the Translation, in particular used for its status (as in “fresh” or “stale”, etc.). These labels can be stored and retrieved independently for each writing system and so correspond the parallel string in the Translation for each writing system. Different types of CmTranslations can have different sets of status labels according to the need of the type.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfWsTsString> Status
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfWsTsString>();

}

public partial class LfLexExampleSentence : LfCmObject
{
    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Example
    ///
    /// <para>This multilingual attribute holds the vernacular example sentence. It is multilingual to allow multiple encodings in the same language (e.g., Thai, Laotian, and Vietnamese). It is multiString rather than multiUnicode to allow formatting - for example, applying bold to the word associated with the LexEntry.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfWsTsString> Example
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfWsTsString>();

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the Reference
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public LfTsString Reference
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Translations
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfCmTranslation> TranslationsOC
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfCmTranslation>();

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the LiftResidue
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public string LiftResidue
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the DoNotPublishIn
    ///
    /// <para>This property lists publications in which this example should not appear.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfCmPossibility> DoNotPublishInRC
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfCmPossibility>();

}