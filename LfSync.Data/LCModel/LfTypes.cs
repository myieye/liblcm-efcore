using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LfSync.Data.LCModel;

public partial class LfCmObject
{
    /// <summary>
    /// Project-specific ID of the object.
    /// </summary>
    public int Hvo
    {
        get; set;
    }

    /// <summary>
    /// Object owner. (Null, if not owned.)
    /// </summary>
    public Guid Owner
    {
        get; set;
    }

    /// <summary>
    /// Field ID of the owning object where the object is stored.
    /// </summary>
    public int OwningFlid
    {
        get; set;
    }

    /// <summary>
    /// Owning ord of the owning object where the object is stored.
    /// </summary>
    public int OwnOrd
    {
        get; set;
    }

    /// <summary>
    /// Class ID of the object.
    /// </summary>
    public int ClassID
    {
        get; set;
    }

    /// <summary>
    /// Unique ID of the object. If this will hang around, prefer to use the Id.
    /// </summary>
    [Key]
    public Guid Guid
    {
        get; set;
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
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Translation
    {
        get; set;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    }

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
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Status
    {
        get; set;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    }

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
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Example
    {
        get; set;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the Reference
    /// </summary>
    /// ------------------------------------------------------------------------------------
    [Column(TypeName = "jsonb")]
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
        get; set;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the LiftResidue
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public string? LiftResidue
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
        get; set;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    }

}