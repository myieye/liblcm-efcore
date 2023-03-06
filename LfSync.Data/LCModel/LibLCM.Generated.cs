using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LfSync.Data.LCModel;

[Table("Object")]
public class LfObject
{
    /// /// <summary>
    /// Project-specific ID of the object.
    /// /// </summary>
    public int Hvo { get; set; }

    /// /// <summary>
    /// Object owner. (Null, if not owned.)
    /// /// </summary>
    public Guid Owner { get; set; }

    /// /// <summary>
    /// Field ID of the owning object where the object is stored.
    /// /// </summary>
    public int OwningFlid { get; set; }

    /// /// <summary>
    /// Owning ord of the owning object where the object is stored.
    /// /// </summary>
    public int OwnOrd { get; set; }

    /// /// <summary>
    /// Class ID of the object.
    /// /// </summary>
    public int ClassID { get; set; }

    /// /// <summary>
    /// Unique ID of the object. If this will hang around, prefer to use the Id.
    /// /// </summary>
    [Key]
    public Guid Guid { get; set; }

}

[Table("Analysis")]
public class LfAnalysis : LfObject
{
    /// /// <summary>
    /// Get the WfiWordform.
    /// /// </summary>
    public Guid WordformGuid { get; set; }
    public LfWfiWordform Wordform { get; set; }

    /// /// <summary>
    /// Returns true if the analysis is or is owned by a wordform. (Not a punctuation form.)
    /// /// </summary>
    public bool HasWordform { get; set; }

    /// /// <summary>
    /// The associated WfiAnalysis, if any; returns null for WfiWordform, this for WfiAnalysis, owner for WfiGloss.
    /// /// </summary>
    public Guid AnalysisGuid { get; set; }
    public LfWfiAnalysis Analysis { get; set; }

}

[Table("Project")]
public abstract class LfProject : LfObject
{
    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

}

[Table("Folder")]
public class LfFolder : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    public List<LfFolder> SubFolders { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    public List<LfFile> Files { get; set; }

}

[Table("Note")]
public class LfNote : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Content { get; set; }

}

[Table("FsComplexFeature")]
public class LfFsComplexFeature : LfFsFeatDefn
{
    public Guid TypeGuid { get; set; }
    public LfFsFeatStrucType Type { get; set; }

}

public abstract class LfMajorObject : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// A collection of all of the publication layouts available for output from the translated scripture database.
    /// </summary>
    public List<LfPublication> Publications { get; set; }

    /// <summary>
    /// Used to define preset header/footer layouts that can be selected and copied to a publication division.
    /// Reason: needed to implement TE-1468
    /// </summary>
    public List<LfPubHFSet> HeaderFooterSets { get; set; }

}

[Table("Segment")]
public class LfSegment : LfObject
{
    public int BeginOffset { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> FreeTranslation { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> LiteralTranslation { get; set; }

    public List<LfNote> Notes { get; set; }

    // M:N
    public List<LfAnalysis> Analyses { get; set; }

    /// <summary>
    /// This string can be used to store a user specified reference for a segment.
    /// This is displayed in the Ref (short for reference) column in the Concordance view.
    /// As of Aug 2011 this can not be specified in FLEx, but can be imported. -NaylorJ
    /// </summary>
    public String Reference { get; set; }

    /// <summary>
    /// This references a media file in the interlinear text.
    /// </summary>
    public Guid MediaURIGuid { get; set; }
    public LfMediaURI MediaURI { get; set; }

    /// <summary>
    /// This string can be used to store the time offset into the mediaFile for the beginning of this segment.
    /// Currently intended to hold ELAN information, not modified by FLEx as of Nov 2011 -NaylorJ.
    /// </summary>
    /// <remarks>
    /// Type is string so ELAN could optionally store their timeslot concept: http://flexelan.blogspot.com/2011/11/proposed-schema.html#comment-form
    /// </remarks>
    public string BeginTimeOffset { get; set; }

    /// <summary>
    /// This string can be used to store the time offset into the mediaFile for the end of this segment.
    /// Currently intended to hold ELAN information, not modified by FLEx as of Nov 2011 -NaylorJ.
    /// </summary>
    /// <remarks>
    /// Type is string so ELAN could optionally store their timeslot concept: http://flexelan.blogspot.com/2011/11/proposed-schema.html#comment-form
    /// </remarks>
    public string EndTimeOffset { get; set; }

    /// <summary>
    /// The person who spoke this sentence, ELAN info.
    /// </summary>
    public Guid SpeakerGuid { get; set; }
    public LfPerson Speaker { get; set; }

}

[Table("Possibility")]
public class LfPossibility : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbreviation { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    public List<LfPossibility> SubPossibilities { get; set; }

    public int SortSpec { get; set; }

    /// <summary>
    /// Indicates whether the data for this possibility item has restrictions for presentation to certain audiences. This value comes from a user-defined list that is used by many different FieldWorks objects (Events, Analysis Records, Lexical Entries and their Senses, etc.) These values are user-definable and initially include: No restrictions, Do not publish, Case by case, Unknown
    /// </summary>
    // M:N
    public List<LfPossibility> Restrictions { get; set; }

    /// <summary>
    /// Indicates confidence in the data collected for this possibility item. This value comes from a user-defined list that is used by many different FieldWorks objects (Events, Analysis Records, Lexical Entries and their Senses, etc.) These values are user-definable and initially include: Low, Medium and High as possibilities.
    /// </summary>
    public Guid ConfidenceGuid { get; set; }
    public LfPossibility Confidence { get; set; }

    /// <summary>
    /// The status of this Possibility. This is a user-definable list but initial list will include: Confirmed, Disproved, Pending.
    /// </summary>
    public Guid StatusGuid { get; set; }
    public LfPossibility Status { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    /// <summary>
    /// Any pertinent discussion for this Possibility.
    /// </summary>
    public Guid DiscussionGuid { get; set; }
    public LfStText Discussion { get; set; }

    /// <summary>
    /// The person(s) who created/modified this Possibility record or any of its fields.
    /// </summary>
    // M:N
    public List<LfPerson> Researchers { get; set; }

    /// <summary>
    /// Used by the help system to launch the appropriate help topic for the Possibility item.
    /// </summary>
    public string HelpId { get; set; }

    /// <summary>
    /// ForeColor for overlay functionality.
    /// </summary>
    public int ForeColor { get; set; }

    /// <summary>
    /// BackColor for overlay functionality.
    /// </summary>
    public int BackColor { get; set; }

    /// <summary>
    /// UnderColor for overlay functionality - the color of the "underline" style when used in Overlays. 
    /// </summary>
    public int UnderColor { get; set; }

    /// <summary>
    /// UnderStyle - style of the underline used in overlays functionality. 
    /// </summary>
    public int UnderStyle { get; set; }

    /// <summary>
    /// Indicates whether overlay bracketing should be hidden or not. True = Hidden.
    /// </summary>
    public Boolean Hidden { get; set; }

    /// <summary>
    /// This flag is set for items that are accessed by the software via GUIDs. The software is assuming that this item is always present with the same GUID on all machines. When set, a user can still edit the item, but it cannot be deleted.
    /// </summary>
    public Boolean IsProtected { get; set; }

}

[Table("PossibilityList")]
public class LfPossibilityList : LfMajorObject
{
    public int Depth { get; set; }

    public int PreventChoiceAboveLevel { get; set; }

    public Boolean IsSorted { get; set; }

    public Boolean IsClosed { get; set; }

    public Boolean PreventDuplicates { get; set; }

    public Boolean PreventNodeChoices { get; set; }

    public List<LfPossibility> Possibilities { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbreviation { get; set; }

    public string HelpFile { get; set; }

    public Boolean UseExtendedFields { get; set; }

    /// <summary>
    /// This determines whether we display name (kpntName = 0), name and abbreviation (kpntNameAndAbbrev = 1), or abbreviation (kpntAbbreviation = 2) when we display names.
    /// </summary>
    public int DisplayOption { get; set; }

    /// <summary>
    /// This is the clsid of the items that can be inserted into this list.
    /// </summary>
    public int ItemClsid { get; set; }

    /// <summary>
    /// This indicates whether the list will display vernacular (True) or analysis encodings (false) as the default.
    /// </summary>
    public Boolean IsVernacular { get; set; }

    public string WritingSystem { get; set; }

    /// <summary>
    /// // the application to get the appropriate writing system from the application. For example,
    /// // a language project has a list of one or more analysis encodings. kwsAnal would
    /// // tell the program to use the first writing system in this list.
    /// #define kwsAnal 0xffffffff // (-1) The first analysis writing system.
    /// #define kwsVern 0xfffffffe // (-2) The first vernacular writing system.
    /// #define kwsAnals 0xfffffffd // (-3) All analysis writing system.
    /// #define kwsVerns 0xfffffffc // (-4) All vernacular writing system.
    /// #define kwsAnalVerns 0xfffffffb // (-5) All analysis then All vernacular writing system.
    /// #define kwsVernAnals 0xfffffffa // (-6) All vernacular then All analysis writing system.
    /// #define kwsLim 0xfffffff9 // (-7) One beyond the last magic value.
    /// </summary>
    public int WsSelector { get; set; }

    /// <summary>
    /// Uniquely identifies a particular version of the possiblity llist so that version changes can be detected and update routines run.
    /// </summary>
    public Guid ListVersion { get; set; }

}

[Table("Filter")]
public class LfFilter : LfObject
{
    public string Name { get; set; }

    public int ClassId { get; set; }

    public int FieldId { get; set; }

    public string FieldInfo { get; set; }

    public Guid App { get; set; }

    public int Type { get; set; }

    public List<LfRow> Rows { get; set; }

    public string ColumnInfo { get; set; }

    public int ShowPrompt { get; set; }

    public string PromptText { get; set; }

}

[Table("Row")]
public class LfRow : LfObject
{
    public List<LfCell> Cells { get; set; }

}

[Table("Cell")]
public class LfCell : LfObject
{
    public String Contents { get; set; }

}

[Table("Possibility")]
public class LfLocation : LfPossibility
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Alias { get; set; }

}

[Table("Possibility")]
public class LfPerson : LfPossibility
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Alias { get; set; }

    public int Gender { get; set; }

    [Column(TypeName = "jsonb")]
    public GenDate DateOfBirth { get; set; }

    public Guid PlaceOfBirthGuid { get; set; }
    public LfLocation PlaceOfBirth { get; set; }

    public Boolean IsResearcher { get; set; }

    // M:N
    public List<LfLocation> PlacesOfResidence { get; set; }

    public Guid EducationGuid { get; set; }
    public LfPossibility Education { get; set; }

    [Column(TypeName = "jsonb")]
    public GenDate DateOfDeath { get; set; }

    // M:N
    public List<LfPossibility> Positions { get; set; }

}

[Table("StText")]
public class LfStText : LfObject
{
    public List<LfStPara> Paragraphs { get; set; }

    /// <summary>
    /// Specifies whether the overall document direction for this structured text is right-to-left (true) or not (false).
    /// </summary>
    public Boolean RightToLeft { get; set; }

    public List<LfTextTag> Tags { get; set; }

    public DateTime DateModified { get; set; }

}

[Table("StPara")]
public abstract class LfStPara : LfObject
{
    /// <summary>
    /// When the user applies formatting to a specific paragraph apart from using a pre-defined style, that formatting information is stored here. It includes information such as font, font style, margins, etc.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<TextProperty> StyleRules { get; set; }

}

[Table("StPara")]
public class LfStTxtPara : LfStPara
{
    /// <summary>
    /// Label to appear at start of paragraph (in margin, if negative first line indent). 
    /// Note: This attribute is not currently used. 
    /// John Thomson's original intent was to use it for the kind of paragraph that has something hanging out in the left margin that isn't predictable (as a bullet or number is) from the stylesheet. The classic example would be a list of terms, with the term sticking out to the left. Since we don't yet have tabs implemented, we could set things up to allow the main body of the paragraph to be aligned, and the label out in the margin. 
    /// </summary>
    public String Label { get; set; }

    /// <summary>
    /// The string of text found within a paragraph. The signature here is string which allows for embedded formatting and language encodings. 
    /// </summary>
    public String Contents { get; set; }

    /// <summary>
    /// This would be set true whenever the paragraph is parsed (tokenized), and false whenever it is edited (changes to StTxtPara.Contents or StText.Paragraphs). This allows us to re-parse only the texts that need it, now that the parser always makes real, persistent annotations.
    /// </summary>
    public Boolean ParseIsCurrent { get; set; }

    /// <summary>
    /// The Contents of StTxtPara are parsed into TextObjects as a side-effect of setting the Contents. Parsed objects include Wordforms and Punctuation (and possibly References or ???). A sequence of references are set to each of these objects as they are found in their respective inventories (Wordform Inventory, Punctuation Inventory, and (future?) ReferenceScheme)
    /// This attribute exists in order to allow for a concordance by WfiWordform, (currently including punctuation) and/or PunctuationForm. This attribute is a "lite" version of AnalyzedTextObjects.
    /// This attribute should only be used if a particular application of StTxtPara requires concordances.
    /// </summary>
    // M:N
    public List<LfObject> TextObjects { get; set; }

    /// <summary>
    /// AnalyzedTextObjects is used when there are associated analyses with any objects in the text. It is primarily meant for morphological interlinear analysis of text.
    /// Reference pointers to TxtWordformInContext (one for every word, punctuation and reference in the text) are set in a sequence.
    /// Note: the name of the class will likely change to TxtObjInContext because it handles more than just words.
    /// Refer to the documentation on TxtWordformInContext for more information.
    /// This attribute is used only if the application requires it. It does not obviate the need for TextObjects
    /// </summary>
    public List<LfObject> AnalyzedTextObjects { get; set; }

    public List<LfSegment> Segments { get; set; }

    /// <summary>
    /// Refer to the documentation on LpTranslation.
    /// </summary>
    public List<LfTranslation> Translations { get; set; }

}

[Table("StStyle")]
public class LfStStyle : LfObject
{
    public string Name { get; set; }

    public Guid BasedOnGuid { get; set; }
    public LfStStyle BasedOn { get; set; }

    public Guid NextGuid { get; set; }
    public LfStStyle Next { get; set; }

    public int Type { get; set; }

    [Column(TypeName = "jsonb")]
    public List<TextProperty> Rules { get; set; }

    /// <summary>
    /// TRUE = the style is for use in published text; FALSE = the style is for non-published text
    /// </summary>
    public Boolean IsPublishedTextStyle { get; set; }

    /// <summary>
    /// TRUE means this style was in the default FW style sheet and that the user will not be allowed to delete or rename these styles; 
    /// FALSE means this style was added by the user.
    /// For further discussion, see below: 
    /// John W. (Mar 20, 2002) adds that in the "Default Style Sheet" specification, we talk about "factory" styles:
    /// "This document describes the style sheet that will ship with the FieldWorks Translation Editor. Generally speaking, users can add, modify or delete styles; this document is concerned with the style sheet as it is installed from the factory, and thus the "factory styles" which cannot be renamed or deleted..
    /// There are two sets of styles, one for published materials (Scripture text, introductions, etc.) and one for non-published materials (back translation, consultant notes, etc.) For the former we started with the main styles found in the Paratext stylesheet for the TEV, and modified it as is appropriate for the FieldWorks environment. 
    /// For the styles listed below (that is, in the specification refered to by John W.)
    /// 1. The user will not be permitted to rename or delete these. 
    /// 2. The user is permitted to change their attributes, including paragraph, font, etc.
    /// 3. The user is permitted to edit their "Usage" attribute. "
    /// Ken Z. added on Mar 20, 2002:
    /// We need some way of saying that certain styles are used by code, and thus can't be deleted or renamed. I believe this might be done right now by hard coding these style names in the styles dialog to keep them from being changed. It seems like IsBuiltIn should be able to serve this function so that we can designate certain styles as built-in and therefore guaranteed to always be there. Unless Bryan or someone else sees a reason not to do this, I think we should add this to the specification. As such, it will be used by more than just the Translation Editor.
    /// Ken Z. also notes the following:
    /// As for Lela-Teli sample styles, they should not have the IsBuiltIn property set even though they are delivered "from the factory". From all responses, I think it is safe to say that any style that has the IsBuiltIn flag set should not be deleted or renamed by any program.
    /// </summary>
    public Boolean IsBuiltIn { get; set; }

    /// <summary>
    /// This applies only to built-in styles; TRUE means the user changed its properties.
    /// </summary>
    public Boolean IsModified { get; set; }

    /// <summary>
    /// A number 0-4 indicating the level of user likely to use this style. Default = 0
    /// </summary>
    public int UserLevel { get; set; }

    /// <summary>
    /// The high level structure to which the application of a style is limited. To be enumerated as follows:
    ///   stcnGeneral – indicating Not limited to a single context.
    ///   stcnText – The main text (eg. of scripture).
    ///   stcnScrIntro – Introduction to a book of scripture
    ///   stcnScrAnnotation – Annotation to the scripture text (e.g. consultant notes)
    ///   stcnFigure – Captions, etc. associated with graphic elements
    ///   stcnInternal – Styles that are applied by the program and modifiable by the user
    ///   stcnScrTitle – The title of a scripture book.
    ///   (others as needed)
    /// </summary>
    public int Context { get; set; }

    /// <summary>
    /// The substructure of a Context to which the application of a style is limited. (Presently only used to distinguish the substructures of scripture sections.) To be enumerated as follows:
    ///   ststHeading - indicating The Heading of a scripture or scripture introduction section. 
    ///   ststContent - indicating The Content of a scripture or scripture introduction section. 
    ///   null - indicating Style is unrestricted for use within this context. 
    ///   (others as needed)
    /// </summary>
    public int Structure { get; set; }

    /// <summary>
    /// The functional context for a style within a given structural context (presently only defined for section ‘body’ structures). To be enumerated as follows:
    ///    stusProse - indicating prose within a section body structure 
    ///    stusLine - indicating poetry within a section body structure 
    ///    stusList - indicating a list within a section body structure 
    ///    stusTable - indicating a table within a section body structure 
    ///    stusChapter - indicating a reference chapter number within a scripture section body structure
    ///    stusVerse - indicating a reference verse number within a scripture section body structure
    ///    null - indicating Style is unrestricted for use within the context and structure. 
    ///   (others as needed)
    /// </summary>
    public int Function { get; set; }

    /// <summary>
    /// A description of the expected usage of the style, displayed on the General tab in the Style dialog.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Usage { get; set; }

}

[Table("Overlay")]
public class LfOverlay : LfObject
{
    public string Name { get; set; }

    /// <summary>
    /// The list that a CmOverlay gets its PossItems from.
    /// </summary>
    public Guid PossListGuid { get; set; }
    public LfPossibilityList PossList { get; set; }

    /// <summary>
    /// An Overlay can have a number of CmPossibilities associated with it for the purposes of tagging text. These CmPossibilities come from a particular CmPossibilityList (defined by PossList). For example, the user might have an overlay for OCM codes having to do with marriage and fishing. He might have another overlay with OCM codes that have to do with cooking.
    /// </summary>
    // M:N
    public List<LfPossibility> PossItems { get; set; }

}

[Table("TextTag")]
public class LfTextTag : LfObject
{
    public Guid BeginSegmentGuid { get; set; }
    public LfSegment BeginSegment { get; set; }

    public Guid EndSegmentGuid { get; set; }
    public LfSegment EndSegment { get; set; }

    /// <summary>
    /// These indices refer to the index of an IAnalysis object in a Segment.Analyses sequence.
    /// </summary>
    public int BeginAnalysisIndex { get; set; }

    /// <summary>
    /// These indices refer to the index of an IAnalysis object in a Segment.Analyses sequence.
    /// </summary>
    public int EndAnalysisIndex { get; set; }

    public Guid TagGuid { get; set; }
    public LfPossibility Tag { get; set; }

}

[Table("Agent")]
public class LfAgent : LfObject
{
    /// <summary>
    /// Arbitrary name of the agent. Examples: Larry, AMPLE, XEROXParser, HermitCrab.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    /// <summary>
    /// Defines what constraint groups are turned off. (Example: in morphological parsing we might turn off a set of rules). It is represented as XML and is empty unless the morphological system is in debug mode. We have not yet determined the nature of the XML representation (Jan 17, 2002).
    /// </summary>
    public string StateInformation { get; set; }

    /// <summary>
    /// T = human, F = computational agent.
    /// </summary>
    public Boolean Human { get; set; }

    public Guid NotesGuid { get; set; }
    public LfStText Notes { get; set; }

    /// <summary>
    /// This attribute is not finalized but for now possible values include:Normal - represents the parser using the current state of the grammar and lexicon. Debug - represents the parser using a limited grammar (user has turned off some group of constraints) Milestone - represents the parser using a particular grammar and lexicon at a particular time as recorded on CmObject (date created). Works in conjunction with StateInformation.
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    /// The agent evaluation which objects being evaluated refer to in order to indicate that this agent approves or accepts them.
    /// </summary>
    public Guid ApprovesGuid { get; set; }
    public LfAgentEvaluation Approves { get; set; }

    /// <summary>
    /// The agent evaluation which objects being evaluated refer to in order to indicate that this agent disapproves or does not accept them.
    /// </summary>
    public Guid DisapprovesGuid { get; set; }
    public LfAgentEvaluation Disapproves { get; set; }

}

[Table("Possibility")]
public class LfAnthroItem : LfPossibility
{
}

[Table("Possibility")]
public class LfCustomItem : LfPossibility
{
}

[Table("CrossReference")]
public class LfCrossReference : LfObject
{
    /// <summary>
    /// To be used after version 1 for indicating the reason for a cross-reference. It is quite likely that a pointer to a list of types of cross-references will also be included in the future.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Comment { get; set; }

}

[Table("Translation")]
public class LfTranslation : LfObject
{
    /// <summary>
    /// The signature is multiString allowing us to have translations in multiple languages (e.g. ENG, FRN, SPN). 
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Translation { get; set; }

    /// <summary>
    /// The type of translation: free, literal, back, front, etc.
    /// </summary>
    public Guid TypeGuid { get; set; }
    public LfPossibility Type { get; set; }

    /// <summary>
    /// A label to hold any kind of metadata about the Translation, in particular used for its status (as in “fresh” or “stale”, etc.). These labels can be stored and retrieved independently for each writing system and so correspond the parallel string in the Translation for each writing system. Different types of CmTranslations can have different sets of status labels according to the need of the type.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Status { get; set; }

}

[Table("AgentEvaluation")]
public class LfAgentEvaluation : LfObject
{
}

[Table("Annotation")]
public abstract class LfAnnotation : LfObject
{
    /// <summary>
    /// Data stored and used by specialized computer agents (e.g. computational parsers) in the FieldWorks system. Most likely will be stored in XML format. 
    /// </summary>
    public string CompDetails { get; set; }

    /// <summary>
    /// Not sure what the signature here should be yet. multiUnicode, StText?
    /// <p>
    /// Probably, in most cases, only string will be needed. 
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Comment { get; set; }

    /// <summary>
    /// An annotation is of a particular type. The AnnotationDefn defines possible behaviors for an annotation.
    /// </summary>
    public Guid AnnotationTypeGuid { get; set; }
    public LfAnnotationDefn AnnotationType { get; set; }

    /// <summary>
    /// Who made this annotation. If a computer parser, the agent will be that parser.
    /// </summary>
    public Guid SourceGuid { get; set; }
    public LfAgent Source { get; set; }

    /// <summary>
    /// Annotations, in many cases, are tags from a predefined list of objects.
    /// We might want to mark up a text for OCM codes. A particular annotation in context may tag an instance of OCM code 152.
    /// WordformsInContext are tagged with Wordforms found in the Wordform Repository.
    /// </summary>
    public Guid InstanceOfGuid { get; set; }
    public LfObject InstanceOf { get; set; }

    /// <summary>
    /// To handle multiparagraph annotations.
    /// </summary>
    public Guid TextGuid { get; set; }
    public LfStText Text { get; set; }

    public Guid FeaturesGuid { get; set; }
    public LfFsFeatStruc Features { get; set; }

    /// <summary>
    /// Date stamp for when this annotation was created, for display to the user. This may differ from the internally generated timestamp that is used for record locking and conflict detection.
    /// </summary>
    public DateTime DateCreated { get; set; }

    /// <summary>
    /// Date and time that this annotation was last modified, for display to the user and for use by automated checking tools. Allows explicit tracking of relevent modifications versus the automatic date stamp created by the database engine.
    /// </summary>
    public DateTime DateModified { get; set; }

}

[Table("Possibility")]
public class LfAnnotationDefn : LfPossibility
{
    /// <summary>
    /// True = user can type in a comment associated with the Annotation. 
    /// False = user cannot type in a comment.
    /// Example: a user may tag a section of text with OCM 152 but also want to provide a comment as to why he tagged it in this way.
    /// </summary>
    public Boolean AllowsComment { get; set; }

    /// <summary>
    /// T = Annotation can carry a FsFeatStruc.
    /// </summary>
    public Boolean AllowsFeatureStructure { get; set; }

    /// <summary>
    /// T = Annotation can be selected from a list of instances of a particular CmObject. 
    /// Example: OCM annotations are contextual instances of the AnthroList items.
    /// </summary>
    public Boolean AllowsInstanceOf { get; set; }

    /// <summary>
    /// ClassDefn id from metatable. States that this AnnotationDefn allows instances of a particular class.
    /// </summary>
    public int InstanceOfSignature { get; set; }

    /// <summary>
    /// Perhaps the only reason for this attribute is so that we can limit the AnnotationDefns displayed in a GUI that the user selects from. Perhaps it is better to use a boolean: 
    /// <p>
    /// UserCanCreate: T | F
    /// </summary>
    public Boolean UserCanCreate { get; set; }

    /// <summary>
    /// When the objects an Annotation refers to are deleted:
    /// T = Keep Annotation 
    /// F = Delete Annotation 
    /// For some types of annotations we may want the annotation to persist, even though the object it annotates no longer exists. 
    /// What happens to an annotation when the object it annotates disappears:
    /// 1. If the object it points to goes away, get rid of the annotation.
    /// 2. If the range becomes empty the Annotation goes away.
    /// QUESTIONS: 
    /// 3. If something gets deleted at the beginning or the end, do you jump right or left?
    /// 4. If an object is owned by another object, do you move the annotation to the owner?
    /// Refer to http://mpj.cx/twiki/bin/view.pl/Wordworks/Mar2003OutcomesMinutesDiscussions for further discussion. 
    /// </summary>
    public Boolean CanCreateOrphan { get; set; }

    /// <summary>
    /// Should the user be prompted before annotated object is deleted? T = Prompt user. F = Delete without prompt.
    /// </summary>
    public Boolean PromptUser { get; set; }

    /// <summary>
    /// T = annotations of this type are copied and pasted when their annotated object is copied and pasted. 
    /// F = these types of annotations are NOT copied along with their annotation object.
    /// </summary>
    public Boolean CopyCutPastable { get; set; }

    /// <summary>
    /// T = Annotations of this type are have the same Begin and EndOffset and thus zeroWidth. 
    /// Potential example: footnotes markers.
    /// </summary>
    public Boolean ZeroWidth { get; set; }

    /// <summary>
    /// Indicates whether this annotation type needs "multi" capabilities.
    /// Also need to indicate which encodings to offer the user. Vernacular, Analysis, etc. 
    /// </summary>
    public Boolean Multi { get; set; }

    /// <summary>
    /// For example, we may want to indicate the following with visual cues. 
    /// Severity:
    /// 0 = NA
    /// 1 = Critical
    /// 2 = Problem
    /// 3 = Warning
    /// 4 = Suggestion
    /// User
    /// </summary>
    public int Severity { get; set; }

    /// <summary>
    /// The user should be able to set the limit of each type of checking error, as appropriate for each project and stage. MaxDupOccur stores how many "duplicate" errors are allowed for each type of check. Other types of annotations could use this if it's useful. ("Duplicates" would be defined differently for different types of annotations.)
    /// </summary>
    public int MaxDupOccur { get; set; }

}

[Table("Annotation")]
public class LfIndirectAnnotation : LfAnnotation
{
    // M:N
    public List<LfAnnotation> AppliesTo { get; set; }

}

[Table("Annotation")]
public class LfBaseAnnotation : LfAnnotation
{
    /// <summary>
    /// For Annotations that annotate a text string fragment or a media file fragment, we set the BeginOffset and EndOffset. 
    /// </summary>
    public int BeginOffset { get; set; }

    /// <summary>
    /// An annotation knows what it is annotating through the BeginObject reference attribute and the Begin and EndOffsets. For those annotations that are not on objects themselves but data within the object, we we need to identify which attribute holds the data through the field id (abbrev: FLID) found in the FieldWorks RDBMS. 
    /// </summary>
    public int Flid { get; set; }

    /// <summary>
    /// See BeginOffset.
    /// </summary>
    public int EndOffset { get; set; }

    public Guid BeginObjectGuid { get; set; }
    public LfObject BeginObject { get; set; }

    public Guid EndObjectGuid { get; set; }
    public LfObject EndObject { get; set; }

    // M:N
    public List<LfObject> OtherObjects { get; set; }

    public string WritingSystem { get; set; }

    /// <summary>
    /// Refer to documentation on CmPossibilityList_WsSelector.
    /// </summary>
    public int WsSelector { get; set; }

    /// <summary>
    /// For Scripture use, this will be used to store begin Scripture references. The int actually encodes book, chapter, and verse for Consultant Notes, Translator Notes, Change History Notes, etc. The attribute is available for other uses in other applications.
    /// </summary>
    public int BeginRef { get; set; }

    /// <summary>
    /// For Scripture use, this will be used to store end Scripture references. The int actually encodes book, chapter, and verse for Consultant Notes, Translator Notes, Change History Notes, etc. The attribute is available for other uses in other applications.
    /// </summary>
    public int EndRef { get; set; }

}

[Table("Annotation")]
public class LfMediaAnnotation : LfAnnotation
{
}

[Table("StText")]
public class LfStFootnote : LfStText
{
    public String FootnoteMarker { get; set; }

}

[Table("UserConfigAcct")]
public class LfUserConfigAcct : LfObject
{
    /// <summary>
    /// Same as Sid in the Syslogins table in the master DB. 
    /// </summary>
    public byte[] Sid { get; set; }

    /// <summary>
    /// Beginner = 1, Intermediate = 3, Advanced = 5
    /// </summary>
    public int UserLevel { get; set; }

    public Boolean HasMaintenance { get; set; }

}

[Table("UserAppFeatAct")]
public class LfUserAppFeatAct : LfObject
{
    // M:N
    public List<LfUserConfigAcct> UserConfigAcct { get; set; }

    /// <summary>
    /// From AppCompat$? Which apps are installed? Look in registry?
    /// </summary>
    public Guid ApplicationId { get; set; }

    /// <summary>
    /// An application returns a hard-coded array of its available features. Features have ids that are referenced in this FeatureId field.
    /// UserConfigAccount, ApplicationId, FeatureId form a unique key for the object. 
    /// </summary>
    public int FeatureId { get; set; }

    public int ActivatedLevel { get; set; }

}

[Table("Publication")]
public class LfPublication : LfObject
{
    public string Name { get; set; }

    public String Description { get; set; }

    /// <summary>
    /// The height of the trimmed page in the final publication, in millipoints. This includes the top and bottom margins and the printable height of the text area.
    ///    0(default) — indicating the equal to the paper size 
    ///    positive value — indicating a specific size page size to lay out on the paper
    /// </summary>
    public int PageHeight { get; set; }

    /// <summary>
    /// The width of the trimmed page in the final publication, in millipoints. This includes the inside and outside margins and the printable width of the text area but it does not include the gutter margin.
    ///    0(default) — indicating the equal to the paper size 
    ///    positive value — indicating a specific size page size to lay out on the paper
    /// </summary>
    public int PageWidth { get; set; }

    /// <summary>
    /// True if orientation of page is “landscape”
    /// </summary>
    public Boolean IsLandscape { get; set; }

    /// <summary>
    /// Width of gutter margin from bound edge.
    /// </summary>
    public int GutterMargin { get; set; }

    /// <summary>
    /// Enumeration indicating the which edge of the paper has the gutter margin, i.e. the bound edge of the publication. The valid values are: glLeft, glRight, glTop.
    /// </summary>
    public int GutterLoc { get; set; }

    /// <summary>
    /// The content divisions (i.e. sections) that determine overall content of the publication.
    /// </summary>
    public List<LfPubDivision> Divisions { get; set; }

    /// <summary>
    /// Width of the separator line between the body text and the footnote text in parts per thousand of the column width. Valid values are 0-1000: 
    ///    0 — indicating that no separator line will appear 
    ///    1000 — indicating that separator line will be drawn for the full width of the footnote column
    ///    333 — indicating a standard 1/3 column width separator line
    ///    any other value — indicating a custom proportion of the separator line to the column width. 
    /// </summary>
    public int FootnoteSepWidth { get; set; }

    /// <summary>
    /// The physical height of the sheet of paper to be printed, in millipoints. This, together with the PaperWidth property, determines the paper size that is requested from a printer. 
    ///    0(default) — indicating the default paper size for the printer 
    ///    positive value — indicating a specific size requested from the printer
    /// </summary>
    public int PaperHeight { get; set; }

    /// <summary>
    /// The physical width of the sheet of paper to be printed, in millipoints. This, together with the PaperHeight property, determines the paper size that is requested from a printer. 
    ///    0(default) — indicating the default paper size for the printer 
    ///    positive value — indicating a specific size requested from the printer
    /// </summary>
    public int PaperWidth { get; set; }

    /// <summary>
    /// Enumeration indicating on which edge the publication is to be bound (which determines the position of the gutter margin): 
    ///    0 (default) — indicating left 
    ///    1 — indicating right 
    ///    2 — indicating top 
    ///    any other value — indicating error: not defined
    /// </summary>
    public int BindingEdge { get; set; }

    /// <summary>
    /// enumeration designating the way pages are laid out on each sheet of paper for printing: 
    ///    0 (default) — indicating simplex: 1 front (recto) page per sheet. (Implies that the gutter margin is always on the leading side of the page.)
    ///    1 — indicating duplex: 1 front (recto) page and 1 back (verso) page per sheet (Implies that the gutter margin alternates between the leading and trailing sides of alternate pages.)
    ///    2 — indicating booklet: 2 front (recto) pages and 2 back (verso) pages per sheet, side-by-side. (Implies two gutter margins in the center of the sheet, on each side.) 
    ///    any other value — indicating error: not defined
    /// </summary>
    public int SheetLayout { get; set; }

    /// <summary>
    /// Number of sheets of paper in each signature for booklet layout. The number of pages per signature will equal four times this value for typical booklet printing. (A 'signature' is a set of sheets in a book, folded together for binding as a unit).
    /// </summary>
    public int SheetsPerSig { get; set; }

    /// <summary>
    /// Default font size for the publication, in millipoints.
    /// </summary>
    public int BaseFontSize { get; set; }

    /// <summary>
    /// Default line spacing for the publication in millipoints, negative if Exact spacing, positive if At Least spacing.
    /// </summary>
    public int BaseLineSpacing { get; set; }

}

[Table("PubDivision")]
public class LfPubDivision : LfObject
{
    /// <summary>
    /// True - if a different header and footer will be used on the first page of the division. False - if the normal header and footer (depending on the page number) will be used.
    /// </summary>
    public Boolean DifferentFirstHF { get; set; }

    /// <summary>
    /// True - if a different header and footer will be used on the even pages in the division. False - if the default header and footer will normally be used for even pages.
    /// </summary>
    public Boolean DifferentEvenHF { get; set; }

    /// <summary>
    /// Enumeration of options for where the content of the division begins: pdContinuous, pdNew, pdOdd
    /// </summary>
    public int StartAt { get; set; }

    /// <summary>
    /// The page layout parameters for this division specifying page size, margins, header and footer positions, etc.
    /// </summary>
    public Guid PageLayoutGuid { get; set; }
    public LfPubPageLayout PageLayout { get; set; }

    /// <summary>
    /// Changed from HeaderFooterSettings.
    /// </summary>
    public Guid HFSetGuid { get; set; }
    public LfPubHFSet HFSet { get; set; }

    /// <summary>
    /// Default number of columns of text for the page layout. This is an overall layout parameter and only applies to sections or paragraphs that permit multi-column layout. E.g. a Title can be set to always lay out in a single column, regardless of this setting.
    /// </summary>
    public int NumColumns { get; set; }

}

[Table("PubPageLayout")]
public class LfPubPageLayout : LfObject
{
    public string Name { get; set; }

    public String Description { get; set; }

    /// <summary>
    /// Height of top margin from top of page
    /// </summary>
    public int MarginTop { get; set; }

    /// <summary>
    /// Height of bottom margin from bottom of page
    /// </summary>
    public int MarginBottom { get; set; }

    /// <summary>
    /// Width of inside margin from gutter margin. Footnote: The first implementation will support only “mirror margins”
    /// </summary>
    public int MarginInside { get; set; }

    /// <summary>
    /// Width of outside margin from outside edge
    /// </summary>
    public int MarginOutside { get; set; }

    /// <summary>
    /// Position of bottom of header from top of page.
    /// </summary>
    public int PosHeader { get; set; }

    /// <summary>
    /// Position of top of footer from bottom of page
    /// </summary>
    public int PosFooter { get; set; }

    /// <summary>
    /// True if the object is factory supplied.
    /// </summary>
    public Boolean IsBuiltIn { get; set; }

    /// <summary>
    /// True if the object’s properties have been modified from the default (approved) settings.
    /// </summary>
    public Boolean IsModified { get; set; }

}

[Table("PubHFSet")]
public class LfPubHFSet : LfObject
{
    public string Name { get; set; }

    public String Description { get; set; }

    /// <summary>
    /// The contents of the default header for pages of a publication division (odd pages use the default header).
    /// </summary>
    public Guid DefaultHeaderGuid { get; set; }
    public LfPubHeader DefaultHeader { get; set; }

    /// <summary>
    /// The contents of the default footer for pages of a publication division (odd pages use the default footer).
    /// </summary>
    public Guid DefaultFooterGuid { get; set; }
    public LfPubHeader DefaultFooter { get; set; }

    /// <summary>
    /// The contents of the header for the first page of a publication division when different from the default.
    /// </summary>
    public Guid FirstHeaderGuid { get; set; }
    public LfPubHeader FirstHeader { get; set; }

    /// <summary>
    /// The contents of the footer for the first page of a publication division when different from the default.
    /// </summary>
    public Guid FirstFooterGuid { get; set; }
    public LfPubHeader FirstFooter { get; set; }

    /// <summary>
    /// The contents of the header for the even pages of a publication division when different from the default.
    /// </summary>
    public Guid EvenHeaderGuid { get; set; }
    public LfPubHeader EvenHeader { get; set; }

    /// <summary>
    /// The contents of the footer for the even pages of a publication division when different from the default.
    /// </summary>
    public Guid EvenFooterGuid { get; set; }
    public LfPubHeader EvenFooter { get; set; }

}

[Table("PubHeader")]
public class LfPubHeader : LfObject
{
    /// <summary>
    /// The contents of the portion of the header that is aligned with the inside margin.
    /// </summary>
    public String InsideAlignedText { get; set; }

    /// <summary>
    /// The contents of the portion of the header that is centered between the margins.
    /// </summary>
    public String CenteredText { get; set; }

    /// <summary>
    /// The contents of the portion of the header that is aligned with the outside margin.
    /// </summary>
    public String OutsideAlignedText { get; set; }

}

[Table("File")]
public class LfFile : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    public string OriginalPath { get; set; }

    public string InternalPath { get; set; }

    /// <summary>
    /// Publishable information about the copyright that should appear on the copyright page of the publication.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Copyright { get; set; }

}

[Table("Picture")]
public class LfPicture : LfObject
{
    public Guid PictureFileGuid { get; set; }
    public LfFile PictureFile { get; set; }

    /// <summary>
    /// The caption in a string/publication/etc.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Caption { get; set; }

    /// <summary>
    /// Illustration description. This material does not show up on the printed page. This can include special publishing notes, etc.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// An enumeration: 0 - Center Column (no text wrapping around picture, shrinks picture proportionately if wider than the column, caption can occupy full column width); 1 - Center Page (top or bottom of page only, no text wrapping around picture, shrinks picture proportionately if wider than the column, caption can occupy full page width); 2 - Right-align in Column (text wraps to the left of picture, caption can occupy same width as picture); 3 - Left-align in Column (text wraps to the right of picture, caption can occupy same width as picture); 4 - Fill Column (grows picture if necessary to fill column width, caption can occupy full column width); 5 - Fill Page (top or bottom of page only, grows picture if necessary to fill page width, caption can occupy full page width); 6 Full Page (picture occupies full page, grows/shrinks picture if necessary).
    /// </summary>
    public int LayoutPos { get; set; }

    /// <summary>
    /// Percentage by which picture is grown or shrunk. Not used if the LayoutPos is 4 (Fill Column), 5 (Fill Page), 6 (Full Page). 
    /// </summary>
    public int ScaleFactor { get; set; }

    /// <summary>
    /// LocationRangeType, LocationMin and LocationMax together are used to prevent gaps at the end of a page from trying to lay out a picture at an exact location (i.e., where the ORC is). LocationRangeType is an enumeration indicating the type of data contained in LocationMin and LocationMax: 0 - LocationMin and LocationMax are ignored, and the picture must lay out on the line following the ORC, even if this results in a gap; 1 - LocationMin and LocationMax contain Scripture references having the format BBCCCVVV, which encodes book, chapter, and verse; 2 - LocationMin and LocationMax represent a number of paragraphs before or after the paragraph containing the ORC. In non-Scripture text, LocationRangeType should always be 0 or 2.
    /// </summary>
    public int LocationRangeType { get; set; }

    /// <summary>
    /// Depending on the value of LocationRangeType, specifies the minimum Scripture reference or the number of paragraphs before the paragraph containing the ORC reference at which this picture can be laid out. 
    /// </summary>
    public int LocationMin { get; set; }

    /// <summary>
    /// Depending on the value of LocationRangeType, specifies the maximum Scripture reference or the number of paragraphs after the paragraph containing the ORC reference at which this picture can be laid out.
    /// </summary>
    public int LocationMax { get; set; }

    /// <summary>
    /// This property lists publications in which this picture should not appear.
    /// </summary>
    // M:N
    public List<LfPossibility> DoNotPublishIn { get; set; }

}

[Table("FsFeatureSystem")]
public class LfFsFeatureSystem : LfObject
{
    public List<LfFsFeatStrucType> Types { get; set; }

    public List<LfFsFeatDefn> Features { get; set; }

}

[Table("FsClosedFeature")]
public class LfFsClosedFeature : LfFsFeatDefn
{
    public List<LfFsSymFeatVal> Values { get; set; }

}

[Table("FsClosedValue")]
public class LfFsClosedValue : LfFsFeatureSpecification
{
    public Guid ValueGuid { get; set; }
    public LfFsSymFeatVal Value { get; set; }

}

[Table("FsComplexValue")]
public class LfFsComplexValue : LfFsFeatureSpecification
{
    public Guid ValueGuid { get; set; }
    public LfFsAbstractStructure Value { get; set; }

}

[Table("FsDisjunctiveValue")]
public class LfFsDisjunctiveValue : LfFsFeatureSpecification
{
    /// <summary>
    /// Every Fs*Value class has an attribute of "Value".
    /// The only one that has multiple items is FsDisjunctiveValue (after all, how can you have a disjunction with only one item?).
    /// In a sense, even for FsDisjunctiveValue, there is only one "value" associated with a disjunction: it's the first one that "works." For consistency within the entire Fs*Value set, the attribute for FsDisjunctiveValue is in the singular as "Value" rather than "Values" even though it is a collection.
    /// </summary>
    // M:N
    public List<LfFsSymFeatVal> Value { get; set; }

}

[Table("FsFeatDefn")]
public abstract class LfFsFeatDefn : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbreviation { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// Feature of number might have a default value of singular.
    /// </summary>
    public Guid DefaultGuid { get; set; }
    public LfFsFeatureSpecification Default { get; set; }

    /// <summary>
    /// Used by the Gloss Assistant to construct glosses. For gloss components that are not to be shown, leave this attribute empty. 
    /// The gloss abbreviation is distinguished from the standard abbreviation because the latter is used for constructing feature representations where an empty abbreviation would be highly confusing.
    /// MultiUnicode to allow for different Abbreviations for the same concept found in different glossing languages. 
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> GlossAbbreviation { get; set; }

    /// <summary>
    /// Specifies the separator symbol that should appear to the right of a gloss component when the Gloss Assistant system constructs a gloss. MultiUnicode to allow for different glossing separators used in different languages.
    /// Renamed from RightGlossSeparator for the Firebird port.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> RightGlossSep { get; set; }

    /// <summary>
    /// For use in the Gloss Assistant:
    /// T = Display the value of GlossAbbreviation in the gloss.
    /// F = Do not display the value
    /// </summary>
    public Boolean ShowInGloss { get; set; }

    /// <summary>
    /// For use in the Gloss Assistant:
    /// T = Display the value of GlossAbbreviation to the right of any displayed values in the gloss (only if ShowInGloss = T)
    /// F = Display to the left (only if ShowInGloss = T)
    /// Example: ANIM:CL cf. CL:ANIM representing [ CLASS [ ANIMATE ] ]
    /// </summary>
    public Boolean DisplayToRightOfValues { get; set; }

    /// <summary>
    /// Needed to make inflection feature catalog UI work.
    /// </summary>
    public string CatalogSourceId { get; set; }

}

[Table("FsFeatureSpecification")]
public abstract class LfFsFeatureSpecification : LfObject
{
    public int RefNumber { get; set; }

    public int ValueState { get; set; }

    public Guid FeatureGuid { get; set; }
    public LfFsFeatDefn Feature { get; set; }

}

[Table("FsFeatStruc")]
public class LfFsFeatStruc : LfFsAbstractStructure
{
    public List<LfFsFeatStrucDisj> FeatureDisjunctions { get; set; }

    public List<LfFsFeatureSpecification> FeatureSpecs { get; set; }

    public Guid TypeGuid { get; set; }
    public LfFsFeatStrucType Type { get; set; }

}

[Table("FsFeatStrucDisj")]
public class LfFsFeatStrucDisj : LfFsAbstractStructure
{
    public List<LfFsFeatStruc> Contents { get; set; }

}

[Table("FsFeatStrucType")]
public class LfFsFeatStrucType : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbreviation { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// The order of features will be used in the Gloss Assistant system to put feature values in the correct glossing order. For example, the user may want the FsFeatStrucType of TAM (tense aspect modality) to be ordered Aspect, Modality and Tense.
    /// </summary>
    // M:N
    public List<LfFsFeatDefn> Features { get; set; }

    /// <summary>
    /// Needed to make inflection feature catalog UI work.
    /// </summary>
    public string CatalogSourceId { get; set; }

}

[Table("FsAbstractStructure")]
public abstract class LfFsAbstractStructure : LfObject
{
}

[Table("FsFeatureSpecification")]
public class LfFsNegatedValue : LfFsFeatureSpecification
{
    public Guid ValueGuid { get; set; }
    public LfFsSymFeatVal Value { get; set; }

}

[Table("FsFeatDefn")]
public class LfFsOpenFeature : LfFsFeatDefn
{
    public string WritingSystem { get; set; }

    /// <summary>
    /// Refer to documentation on CmPossibilityList_WsSelector.
    /// </summary>
    public int WsSelector { get; set; }

}

[Table("FsFeatureSpecification")]
public class LfFsOpenValue : LfFsFeatureSpecification
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Value { get; set; }

}

[Table("FsFeatureSpecification")]
public class LfFsSharedValue : LfFsFeatureSpecification
{
    public Guid ValueGuid { get; set; }
    public LfFsFeatureSpecification Value { get; set; }

}

[Table("FsSymFeatVal")]
public class LfFsSymFeatVal : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbreviation { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// Used by the Gloss Assistant to construct glosses. For gloss components that are not to be shown, leave this attribute empty. 
    /// The gloss abbreviation is distinguished from the standard abbreviation because the latter is used for constructing feature representations where an empty abbreviation would be highly confusing.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> GlossAbbreviation { get; set; }

    /// <summary>
    /// Specifies the separator symbol that should appear to the right of a gloss component when the Gloss Assistant system constructs a gloss. MultiUnicode to allow for different glossing separators used in different languages.
    /// Changed from RightGlossSeparator for the Firebird Port.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> RightGlossSep { get; set; }

    /// <summary>
    /// For use in the Gloss Assistant:
    /// T = Display the value of GlossAbbreviation in the gloss.
    /// F = Do not display the value
    /// </summary>
    public Boolean ShowInGloss { get; set; }

    /// <summary>
    /// Needed to make inflection feature catalog UI work.
    /// </summary>
    public string CatalogSourceId { get; set; }

}

[Table("Possibility")]
public class LfSemanticDomain : LfPossibility
{
    /// <summary>
    /// Example: (Ron Moe's Standard Format): \ln 23G Live, Die
    /// Multiple Louw & Nida references map to one Unicode string with semicolons as delimiters. At this point, due to royalties, we do not plan to provide the complete Louw & Nida list in our database.
    /// </summary>
    public string LouwNidaCodes { get; set; }

    /// <summary>
    /// Example: (Ron Moe's Standard Format): \hr 761 Life and Death
    /// Multiple OCM references map to one Unicode string with semicolons as delimiters. Some users may not have an OCM code in their database due to royalties, so we can't make actual links to a list.
    /// </summary>
    public string OcmCodes { get; set; }

    /// <summary>
    /// For those that do have an OCM list, we will set links to the appropriate items. We anticipate our program establishing these links when the OCM list is added to the database.
    /// </summary>
    // M:N
    public List<LfAnthroItem> OcmRefs { get; set; }

    /// <summary>
    /// Example: (Ron Moe's Standard Format):\cf Weather; Cloud; Star
    /// We use this property to link related domains. Ideally this should be a bidirectional link, but so far we do not provide this capability in our conceptual model. So for now we'll live with unidirectional links.
    /// </summary>
    // M:N
    public List<LfSemanticDomain> RelatedDomains { get; set; }

    /// <summary>
    /// Each domain has a list of questions used to elicit words. Each question has sample words and sentences, so we group these together into CmDomainQ. The domain then owns a sequence of these. They need to be ordered since important questions come first.
    /// </summary>
    public List<LfDomainQ> Questions { get; set; }

}

[Table("DomainQ")]
public class LfDomainQ : LfObject
{
    /// <summary>
    /// Example: (Ron Moe's Standard Format): \qu (2) What words refer... 
    /// The question is not formatted and has no embedded languages. It is multi because we may have translations in other languages (e.g., \quf are French translations).
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Question { get; set; }

    /// <summary>
    /// Example: (Ron Moe's Standard Format): \ex air, aerial, airspace, atmosphere
    /// A list of sample words in this category. The list may be in English or other languages (e.g., \exf). The words are comma delimited. They are not formatted and they do not have any embedded languages. These words may be used when searching for possible domains for a sense based on the sense gloss. If this process is too slow, we may need to go to separate wordform lists, but we are hoping that complexity will not be necessary. 
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> ExampleWords { get; set; }

    /// <summary>
    /// Example: (Ron Moe's Standard Format): \xe We got up before <dawn>... 
    ///  A list of sample sentences illustrating words elicited from this question. The illustrated word may be bolded. We may have sentences in more than one language. If there are multiple sentences, they are all placed in the same string.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> ExampleSentences { get; set; }

}

[Table("StText")]
public class LfStJournalText : LfStText
{
    /// <summary>
    /// The displayed date when the journal entry was originally created.
    /// </summary>
    public DateTime DateCreated { get; set; }

    /// <summary>
    /// From a list of users, the person who created the journal entry.
    /// </summary>
    public Guid CreatedByGuid { get; set; }
    public LfPerson CreatedBy { get; set; }

    /// <summary>
    /// From a list of users, the person who last modified the journal entry.
    /// </summary>
    public Guid ModifiedByGuid { get; set; }
    public LfPerson ModifiedBy { get; set; }

}

[Table("Media")]
public class LfMedia : LfObject
{
    /// <summary>
    /// This allows a user to enter a label for each media file in multiple writing systems. It also allows formatting or embedded writing systems.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Label { get; set; }

    /// <summary>
    /// Multiple CmMedia objects may reference a single media file, so this property is a reference to a file. CmFile. As with pictures, media files will be copied to root\media directory where root is determined by LangProject_ExtLinkRootDir, which defaults to c:\program files\FieldWorks if not set (or some other location?).
    /// </summary>
    public Guid MediaFileGuid { get; set; }
    public LfFile MediaFile { get; set; }

}

[Table("Resource")]
public class LfResource : LfObject
{
    /// <summary>
    /// Internal name for the resource (the application is responsible for defining the resource and the interface to the resource).
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Version number for the external resource, stored in the database to determine when the version number in the external copy no longer matches.
    /// </summary>
    public Guid Version { get; set; }

}

[Table("VirtualOrdering")]
public class LfVirtualOrdering : LfObject
{
    /// <summary>
    /// The object that has the virtual property whose order is being customized.
    /// </summary>
    public Guid SourceGuid { get; set; }
    public LfObject Source { get; set; }

    /// <summary>
    /// The name of the virtual property whose order is being customized.
    /// </summary>
    public string Field { get; set; }

    /// <summary>
    /// The values of the virtual property in the order the user desires. This list may become out of date. Items it contains not in the current computed value are ignored. Additional items in the virtual are included after the ordered ones.
    /// </summary>
    // M:N
    public List<LfObject> Items { get; set; }

}

[Table("MediaURI")]
public class LfMediaURI : LfObject
{
    /// <summary>
    /// The location and offset of the media file, this should be a subset of the MediaFragment specification.
    /// see http://www.w3.org/2008/WebVideo/Fragments/WD-media-fragments-spec/ 
    /// and discussions at http://flexelan.blogspot.com
    /// </summary>
    public string MediaURI { get; set; }

}

[Table("MediaContainer")]
public class LfMediaContainer : LfObject
{
    public string OffsetType { get; set; }

    public List<LfMediaURI> MediaURIs { get; set; }

}

[Table("Scripture")]
public class LfScripture : LfMajorObject
{
    /// <summary>
    /// The Scripture object is a container for an ordered collection of ScrBooks (Scripture Books).
    /// </summary>
    public List<LfScrBook> ScriptureBooks { get; set; }

    /// <summary>
    /// Scripture requires text style attributes that are uniquely different from styles for general documents in the project. This new style sheet (collection of styles) can be structured just like the style sheet in the Language Project, but is used for all texts authored in the Scripture Editor - Drafts, Back Translations, Notes, UNS Questions,
    /// etc.
    /// This allows us to:
    /// a. utilize styles that are specific for Scripture use;
    /// b. avoid conflicts with the LangProject style sheet if, for example, a Style named 'Paragraph' is desired for both general documents and Scripture
    /// </summary>
    public List<LfStStyle> Styles { get; set; }

    /// <summary>
    /// RefSepr is a string (usually one character) that separates complete references or chapter/verse references in a list. In the U.S.A., this is traditionally a semi-colon (;), e.g., Mat 24:16; Rev 1:2;4:5.
    /// </summary>
    public string RefSepr { get; set; }

    /// <summary>
    /// ChapterVerseSepr is a string (usually one character) that separates the chapter number from the verse number in a reference. In the U.S.A., this is a traditionally colon (:), e.g., Mat 24:16.
    /// </summary>
    public string ChapterVerseSepr { get; set; }

    /// <summary>
    /// VerseSepr is a string (usually one character) that separates non-contiguous verse numbers in a list. In the U.S.A., this is traditionally a comma (,), e.g., Mat 24:16,25.
    /// </summary>
    public string VerseSepr { get; set; }

    /// <summary>
    /// Bridge is a string (usually one character) that bridges contiguous chapter and/or verse ranges in a reference. In the U.S.A., this is traditionally a dash (-), e.g., Mat 24:16-25; Rev 1:7-2:9.
    /// </summary>
    public string Bridge { get; set; }

    /// <summary>
    /// Scripture Import Settings. Supports multiple configurations for importing Scripture and related data from external files.
    /// </summary>
    public List<LfScrImportSet> ImportSettings { get; set; }

    public List<LfScrDraft> ArchivedDrafts { get; set; }

    /// <summary>
    /// The custom marker that will be used as a literal string for the callout (typically a single character).
    /// </summary>
    public string FootnoteMarkerSymbol { get; set; }

    /// <summary>
    /// True if the chapter and verse of the footnote should be displayed below in the footnote; False otherwise.
    /// </summary>
    public Boolean DisplayFootnoteReference { get; set; }

    /// <summary>
    /// True if the footnote sequence should be restarted (..., y, z, a, b, ...), false otherwise (..., y, z, aa, ab, ..)
    /// </summary>
    public Boolean RestartFootnoteSequence { get; set; }

    /// <summary>
    /// Where to restart the footnote sequence, represented as an enumeration (Chapter, Book, OT/NT, etc.)
    /// </summary>
    public int RestartFootnoteBoundary { get; set; }

    /// <summary>
    /// This Boolean tells the Scripture tool to use script chapter/verse digits instead of ASCII (latin) numbers.
    /// </summary>
    public Boolean UseScriptDigits { get; set; }

    /// <summary>
    /// This stores the Unicode character for zero in the given script. It is assumed this is a decimal based system that has consecutive code points from 0 through 9. Note that Tamil does not have a character for zero, but Unicode reserves a code point U+0BE6 for this position so that it can still be used in calculations to find the remaining digits. (Tamil actually displays a Latin 0 for zero.)
    /// </summary>
    public int ScriptDigitZero { get; set; }

    /// <summary>
    /// Whether or not to convert from "European" digits, (1, 2, 3) from scripts using Unicode code points.
    /// Renamed from ConvertCVNumsToEuropeanDigitsOnExport
    /// </summary>
    public Boolean ConvertCVDigitsOnExport { get; set; }

    /// <summary>
    /// Designates one of a several versification schemes. A versification scheme defines how the content of each book of the Bible is partitioned into verses and defines the reference (chapter and verse number) for each verse. Translation Editor determines the number of verses in each chapter based on the versification scheme.
    /// Versification is to be enumerated as follows (matches Paratext versification schemes): 
    ///    (0) - Unknown 
    ///    (1) - Original, Masoretic for OT, Nestle-Aland for NT 
    ///    (2) - Septuagint for (OT) 
    ///    (3) - Vulgate, like the Latin Vulgate, used by many modern versions including French 
    ///    (4) - English, like the RSV, used by many translations patterned on the English text. 
    ///    (5) - Custom, user specified (not yet implemented in Paratext) 
    /// </summary>
    public int Versification { get; set; }

    /// <summary>
    /// String of zero or more vernacular punctuation characters that will be appended automatically to all inserted verse numbers. Null by default.
    /// </summary>
    public string VersePunct { get; set; }

    /// <summary>
    /// String that will be insterted when a chapter number heading is genetrated.
    /// </summary>
    public String ChapterLabel { get; set; }

    /// <summary>
    /// String that will be inserted when a Psalm number heading is generated.
    /// </summary>
    public String PsalmLabel { get; set; }

    /// <summary>
    ///  Book-by-book sequence of annotations that are specific to the scripture text. As of January 2006, these are just scripture notes. We have not yet decided whether to store the annotations generated by checking tools here Scripture annotations are stored book-by-book to make for faster access and filtering.
    /// </summary>
    public List<LfScrBookAnnotations> BookAnnotations { get; set; }

    /// <summary>
    /// List of categories that identify the types of issues that a ScrScriptureNote might deal with.
    /// Changed from ScriptureNoteCategories.
    /// </summary>
    public Guid NoteCategoriesGuid { get; set; }
    public LfPossibilityList NoteCategories { get; set; }

    /// <summary>
    /// Enumeration of footnote callout options:
    /// 0 = 'alphabetic sequence'
    /// 1 = 'custom symbol'
    /// 2 = 'no marker displayed in text'
    /// other values will be added for other kinds of sequences.
    /// Note: coordinate these enumeration values with FootnoteMarkerType.
    /// </summary>
    public int FootnoteMarkerType { get; set; }

    /// <summary>
    /// True if the "source" chapter and verse reference of the cross-reference should be displayed in the note; False otherwise
    /// </summary>
    public Boolean DisplayCrossRefReference { get; set; }

    /// <summary>
    /// The custom marker that will be used as a literal string for the cross-reference callout (typically a single character).
    /// </summary>
    public string CrossRefMarkerSymbol { get; set; }

    /// <summary>
    /// Enumeration of cross-reference callout options:
    /// 0 = 'alphabetic sequence'
    /// 1 = 'custom symbol'
    /// 2 = 'no marker displayed in text'
    /// other values will be added for other kinds of sequences.
    /// Note: coordinate these enumeration values with FootnoteMarkerType.
    /// </summary>
    public int CrossRefMarkerType { get; set; }

    /// <summary>
    /// Indicates whether cross-references are to be combined with the general footnote layout (true) or are to be layed out separately (false).
    /// </summary>
    public Boolean CrossRefsCombinedWithFootnotes { get; set; }

    /// <summary>
    /// If true, display the custom symbol marker in general footnotes (as well as in the text) when the custom symbol option is chosen for the FootnoteMarkerType property.
    /// </summary>
    public Boolean DisplaySymbolInFootnote { get; set; }

    /// <summary>
    /// If true, display the custom symbol callout in cross-reference footnotes (as well as in the text) when the custom symbol option is chosen for the CrossRefMarkerType property.
    /// </summary>
    public Boolean DisplaySymbolInCrossRef { get; set; }

    /// <summary>
    /// The named external resources (e.g. xml files) used by Translation Editor and their version numbers.
    /// </summary>
    public List<LfResource> Resources { get; set; }

}

[Table("ScrBook")]
public class LfScrBook : LfObject
{
    /// <summary>
    /// A ScrBook is made up of ScrSections. ScrSections represent short passages of Scripture. For example, Matthew 1:1-17 in the NIV is a ScrSection with a heading of "The Genealogy of Jesus."
    /// </summary>
    public List<LfScrSection> Sections { get; set; }

    /// <summary>
    /// The full book name for the Scripture Book. Initialized from ScrBookRef.BookName. For books that belong to Scripture.ScriptureBooks, this name should be in synch. with ScrBookRef.BookName. After books are moved to ScrDraft.Books, they retain the Name that they had at the time that they were archived. This allows the historic metadata to be persisted. Otherwise the metadata in an archived book would change as ScrBookRef changes.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    /// <summary>
    /// A reference to a ScrBookRef. This association is for convenience. The correct item in ScrBookRef could also be found using ScrBook.CanonicalNum.
    /// </summary>
    public Guid BookIdGuid { get; set; }
    public LfScrBookRef BookId { get; set; }

    /// <summary>
    /// The Title can be a sequence of paragraphs. We might thus have a paragraph style for Main Title and for SubTitles to support titles like:
    /// The <SubTitlePrevious>
    /// Acts <MainTitle>
    /// of the Apostles <SubTitleFollowing>
    /// </summary>
    public Guid TitleGuid { get; set; }
    public LfStText Title { get; set; }

    /// <summary>
    /// The abbreviation for the name of the Scripture Book. Initialized from ScrBookRef.BookAbbrev. For books that belong to Scripture.ScriptureBooks, this name should be in synch. with ScrBookRef.BookAbbrev. After books are moved to ScrDraft.Books, they retain the abbreviation that they had at the time that they were archived. This allows the historic metadata to be persisted. Otherwise the metadata in an archived book would change as ScrBookRef changes.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbrev { get; set; }

    /// <summary>
    /// Id line from SF files (needed for import/export)
    /// </summary>
    public string IdText { get; set; }

    public List<LfScrFootnote> Footnotes { get; set; }

    public List<LfScrDifference> Diffs { get; set; }

    /// <summary>
    /// In this book chapter number headings will be used instead of drop-cap chapter numbers in the text.
    /// </summary>
    public Boolean UseChapterNumHeading { get; set; }

    /// <summary>
    /// Canonical Book number, a unique sequential ID number for which book of the canon that this one is. May be used for ordering the books in canonical order and for identifying the book to other applications. Persists the canonical identity of a book even if the BookId becomes invalid.
    /// </summary>
    public int CanonicalNum { get; set; }

    /// <summary>
    /// A checksum representing the last imported version from an external source (e.g., Paratext)
    /// </summary>
    public string ImportedCheckSum { get; set; }

    /// <summary>
    /// A checksum representing the last imported back translation version from an external source (e.g., Paratext) for each writing system
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> ImportedBtCheckSum { get; set; }

}

[Table("ScrRefSystem")]
public class LfScrRefSystem : LfObject
{
    public List<LfScrBookRef> Books { get; set; }

}

[Table("ScrBookRef")]
public class LfScrBookRef : LfObject
{
    /// <summary>
    /// The current full book name, e.g. 2 Corinthians for each writing system.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> BookName { get; set; }

    /// <summary>
    /// The default human-readable book abbreviation, e.g. 2 Cor., for each writing system.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> BookAbbrev { get; set; }

    /// <summary>
    /// The current alternate full book name, e.g. II Corinthians, for each writing system.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> BookNameAlt { get; set; }

}

[Table("ScrSection")]
public class LfScrSection : LfObject
{
    /// <summary>
    /// Headings are extra-canonical material used to help the reader know what a particular passage is about. Example: "The Genealogy of Jesus" for the passage (ScrSection) of Matthew 1:1-17. Although these are normally just a short-line, they sometimes are multi-lined including Headings and Subheadings. Thus the signature here is a StText - allowing us to have multiple paragraphs, paragraph styles and character styles.
    /// </summary>
    public Guid HeadingGuid { get; set; }
    public LfStText Heading { get; set; }

    /// <summary>
    /// A ScrSection has Content - the actual verses themselves. Content has a signature of StText allowing us to have multiple paragraphs, paragraph styles and character styles all of which will be used extensively for verse material. Chapter and verse references are character styles found in the Contents of the StTxtPara.
    /// </summary>
    public Guid ContentGuid { get; set; }
    public LfStText Content { get; set; }

    /// <summary>
    /// VerseRefStart and VerseRefEnd are integers that contain book, chapter, and
    /// verse numbers in the form BBCCCVVV. Together these two properties indicate
    /// the range of references spanned by a Scripture section. Note that the the
    /// first two digits (the book part) should always be identical and is redundant
    /// since the ScrSection is owned by a ScrBook.
    /// Reasons for change:
    /// This change allows us to:
    /// a. Prepare to remove the Reference string from the StTxtPara object;
    /// b. Display appropriate references in the concordance for words that appear
    /// in section headings;
    /// c. Know what Scripture is covered by a particular section without parsing
    /// all the paragraphs it contains or accessing the ScrRef table;
    /// d. Prepare for the possibility of having chapter breaks embedded inside
    /// paragraphs.
    /// </summary>
    public int VerseRefStart { get; set; }

    /// <summary>
    /// Refer to doc for VerseRefStart
    /// </summary>
    public int VerseRefEnd { get; set; }

    /// <summary>
    /// The minimum book-chapter-verse reference found within the section. This is a calculated property, stored for processing convenience, not primary data.
    /// </summary>
    public int VerseRefMin { get; set; }

    /// <summary>
    /// The maximum book-chapter-verse reference found within the section. This is a calculated property, stored for processing convenience, not primary data.
    /// </summary>
    public int VerseRefMax { get; set; }

}

[Table("ScrImportSet")]
public class LfScrImportSet : LfObject
{
    /// <summary>
    /// Enumeration: Unknown = 0; Paratext = 1; Other = 2
    /// </summary>
    public int ImportType { get; set; }

    /// <summary>
    /// Token to be used for loading project using ScriptureObjects
    /// </summary>
    public string ImportProjToken { get; set; }

    /// <summary>
    /// Display name for this instance of import settings. May be null if settings are not part of a list of settings displayed to the user.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    /// <summary>
    /// Display description for each instance of import settings.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// Currently (Dec 2005) a single source for scripture is suported but this is made a collection to make future expansion feasible.
    /// </summary>
    public List<LfScrImportSource> ScriptureSources { get; set; }

    /// <summary>
    /// Sources for scripture back translations. More than one is used only if back translations are written in diverse analysis languages.
    /// </summary>
    public List<LfScrImportSource> BackTransSources { get; set; }

    /// <summary>
    /// Sources for annotations. Different sources are useful to group different kinds of annotations and/or different originators.
    /// </summary>
    public List<LfScrImportSource> NoteSources { get; set; }

    /// <summary>
    /// The mappings (from delimited external data to internal data structure) that apply to the scripture and back translations sources in this group fo settings. Markers used in both the scripture and back translations sources must be used equivalently within an instance of ScrImportSettings, so one collection of mappings is used for both types of sources.
    /// </summary>
    public List<LfScrMarkerMapping> ScriptureMappings { get; set; }

    /// <summary>
    /// The mappings (from delimited external data to internal data structure) that apply to the annotations sources in this group of settings. Markers in the various annotation sources must be compatible within an instance of ScrImportSettings so one collection of mappings is used for all note sources.
    /// </summary>
    public List<LfScrMarkerMapping> NoteMappings { get; set; }

}

[Table("ScrDraft")]
public class LfScrDraft : LfObject
{
    public string Description { get; set; }

    public List<LfScrBook> Books { get; set; }

    /// <summary>
    /// The date and time that the record is created. Not automatically the same as the time stamp on a CmObject.
    /// </summary>
    public DateTime DateCreated { get; set; }

    /// <summary>
    /// Uses the ScrDraftType enumeration: 0 = Saved Version; 1 = Imported Version 
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// Stores whether certain saved versions can be deleted.
    /// </summary>
    public Boolean Protected { get; set; }

}

[Table("ScrDifference")]
public class LfScrDifference : LfObject
{
    /// <summary>
    /// an integer to store a reference for where the difference starts.
    /// </summary>
    public int RefStart { get; set; }

    /// <summary>
    /// an integer to store a reference for where the difference ends.
    /// </summary>
    public int RefEnd { get; set; }

    /// <summary>
    /// an integer to identify the type of difference.<p/>
    /// Verse not found in current book: MissingInCurrent.<p/>
    /// Verse not found in revision book: MissingInRevision. <p/>
    /// Text of verse in current and revision differ: TextDifference.<p/>
    /// </summary>
    public int DiffType { get; set; }

    /// <summary>
    /// the offset in the paragraph where the difference begins.
    /// </summary>
    public int RevMin { get; set; }

    /// <summary>
    /// the offset in the paragraph past the end of the difference verse.
    /// </summary>
    public int RevLim { get; set; }

    /// <summary>
    /// the paragraph in the revision that the difference is in.
    /// </summary>
    public Guid RevParagraphGuid { get; set; }
    public LfStPara RevParagraph { get; set; }

}

[Table("ScrImportSource")]
public abstract class LfScrImportSource : LfObject
{
    /// <summary>
    /// Permits the writing system of the data to be specified globally for the source. If NULL, the default writing system for the context will be used.
    /// </summary>
    public string WritingSystem { get; set; }

    public Guid NoteTypeGuid { get; set; }
    public LfAnnotationDefn NoteType { get; set; }

}

[Table("ScrImportSource")]
public class LfScrImportP6Project : LfScrImportSource
{
    /// <summary>
    /// The Paratext ID number for the Paratext project.
    /// </summary>
    public string ParatextID { get; set; }

}

[Table("ScrImportSource")]
public class LfScrImportSFFiles : LfScrImportSource
{
    /// <summary>
    /// Enumeration, may be used to designate the format variation of the standard format files in this source (Paratext 5, USFM, etc.) so that import can be tailored to the format.
    /// </summary>
    public int FileFormat { get; set; }

    /// <summary>
    /// The files that this source comprises. Currently (Dec 2005) plan to only set the OriginalPath in the CmFile.
    /// </summary>
    public List<LfFile> Files { get; set; }

}

[Table("ScrMarkerMapping")]
public class LfScrMarkerMapping : LfObject
{
    /// <summary>
    /// Marker used for opening delimiter of a data run.
    /// </summary>
    public string BeginMarker { get; set; }

    /// <summary>
    /// Marker used for closing delimiter of a data run.
    /// </summary>
    public string EndMarker { get; set; }

    /// <summary>
    /// If true, exclude this delimited data from being imported.
    /// </summary>
    public Boolean Excluded { get; set; }

    /// <summary>
    /// Enumeration that designates whether the mapping is to a style (text in the main data stream with this style) or to a metadata property and if to a property, which property. 
    /// 0 - maps to a style
    /// 1 - maps to a Figure
    /// 2 - maps to a Chapter Label
    /// 3 - maps to Title Short
    /// other values TBD, not a closed enumeration.
    /// </summary>
    public int Target { get; set; }

    /// <summary>
    /// Designates the internal destination stream or sub-stream for the data. The integer is a bit-slice composite of an internal enumeration:
    /// h0000 - unknown domain
    /// h0001 - scripture domain
    /// h0002 - back translation domain
    /// h0004 - notes domain
    /// h0008 - footnote domain
    /// </summary>
    public int Domain { get; set; }

    /// <summary>
    /// Permits the writing system of the data to be specified, if it is not based on context and if it is different than the global setting.
    /// </summary>
    public string WritingSystem { get; set; }

    /// <summary>
    /// Style to apply to data in an internal text stream. Ignored of Target is <> 0.
    /// </summary>
    public Guid StyleGuid { get; set; }
    public LfStStyle Style { get; set; }

    public Guid NoteTypeGuid { get; set; }
    public LfAnnotationDefn NoteType { get; set; }

}

[Table("ScrBookAnnotations")]
public class LfScrBookAnnotations : LfObject
{
    /// <summary>
    /// Scripture notes for this book of Scripture. These annotations include consultant notes, translator notes and also "error" annotations generated by checking tools.
    /// </summary>
    public List<LfScrScriptureNote> Notes { get; set; }

    /// <summary>
    /// Records the date and results of the latest run of each check
    /// </summary>
    public List<LfScrCheckRun> ChkHistRecs { get; set; }

}

[Table("Annotation")]
public class LfScrScriptureNote : LfBaseAnnotation
{
    /// <summary>
    /// Place to indicate a status for whether and how the issue which the note concerns has been resolved. This is an open for enumeration for internal use whose meaning can change depending on the annotation type.
    /// </summary>
    public int ResolutionStatus { get; set; }

    /// <summary>
    /// Place to indicate zero to many standard categories to which the issue discussed in the note might belong. USB and CONNOT categories will be supplied on a factory installed list. This is an open (user modifiable) list.
    /// </summary>
    // M:N
    public List<LfPossibility> Categories { get; set; }

    /// <summary>
    /// Quotation from the scripture text to indicate the topic of the note. May be in an analysis language, a vernacular language or both.
    /// </summary>
    public Guid QuoteGuid { get; set; }
    public LfStJournalText Quote { get; set; }

    /// <summary>
    /// The core contents of the note, the reviewer’s discussion (explanation) of the translation or interpretation issue. Not to be confused with the discussion between users in response to the note which is contained in the Responses collection.
    /// </summary>
    public Guid DiscussionGuid { get; set; }
    public LfStJournalText Discussion { get; set; }

    /// <summary>
    /// The reviewer's summary recommendation concerning the issue. For consultant notes, may contain a suggested rendering, test questions to ask the translation team, or other specific course of action recommended.
    /// </summary>
    public Guid RecommendationGuid { get; set; }
    public LfStJournalText Recommendation { get; set; }

    /// <summary>
    /// The reviewer's description of how the issue raised in the note was resolved. Used in conjunction with the ResolutionStatus attribute when details are needed.
    /// </summary>
    public Guid ResolutionGuid { get; set; }
    public LfStJournalText Resolution { get; set; }

    /// <summary>
    /// Place to record discussion between the stakeholders in response to the note. In consultant notes, a two-way interchange between the consultant and consultee.
    /// </summary>
    public List<LfStJournalText> Responses { get; set; }

    /// <summary>
    /// Date that this scripture note was changed to the resolved status.
    /// </summary>
    public DateTime DateResolved { get; set; }

}

[Table("ScrCheckRun")]
public class LfScrCheckRun : LfObject
{
    /// <summary>
    /// A GUID uniquely identifying the check.
    /// </summary>
    public Guid CheckId { get; set; }

    /// <summary>
    /// Date and time the check was completed.
    /// </summary>
    public DateTime RunDate { get; set; }

    /// <summary>
    /// Result of the check. An integer representing an enumeration (0 - No inconsistencies found; 1 - Only ignored inconsistencies found; 2 - Unignored inconsistencies found).
    /// </summary>
    public int Result { get; set; }

}

[Table("StPara")]
public class LfScrTxtPara : LfStTxtPara
{
}

[Table("StText")]
public class LfScrFootnote : LfStFootnote
{
    /// <summary>
    /// The Scripture paragraph that contains the ORC for this footnote.
    /// </summary>
    public Guid ParaContainingOrcGuid { get; set; }
    public LfScrTxtPara ParaContainingOrc { get; set; }

}

[Table("RnResearchNbk")]
public class LfRnResearchNbk : LfMajorObject
{
    /// <summary>
    /// A collection containing all of the top-level records in the notebook. (Keep in mind that records can contain records, so that this attribute only contains the top-level records.) This is the main content attribute of the notebook.
    /// </summary>
    public List<LfRnGenericRec> Records { get; set; }

    /// <summary>
    /// At a global level, the user can use this attribute to view all of the reminders that have been made within the individual records. (The view will presumably permit ordering (and/or sorting) and filtering of these reminders, in support of creating printouts that can help guide further work or elicitation.)
    /// </summary>
    public List<LfReminder> Reminders { get; set; }

    /// <summary>
    /// A list of record types that the user can modify. Types included by default are: Performance, Almanac, Conversation, Observation, LiteratureSummary, Analysis.
    /// </summary>
    public Guid RecTypesGuid { get; set; }
    public LfPossibilityList RecTypes { get; set; }

    /// <summary>
    /// CrossReference objects that capture crossReferences between two RnGenericRecords are owned here by the ResearchNotebook.
    /// </summary>
    public List<LfCrossReference> CrossReferences { get; set; }

}

[Table("RnGenericRec")]
public class LfRnGenericRec : LfObject
{
    /// <summary>
    /// A caption or title for the record, such as "Emilio and Maria's Wedding". 
    /// </summary>
    public String Title { get; set; }

    /// <summary>
    /// A collection of versions that the record has gone through. This includes an archival of previous versions of the actual records.
    /// </summary>
    public Guid VersionHistoryGuid { get; set; }
    public LfStText VersionHistory { get; set; }

    /// <summary>
    /// A place where the user can record reminders for further research, such as further editing to do to the record, or additional types of data to seek, or whatever comes to mind.
    /// </summary>
    // M:N
    public List<LfReminder> Reminders { get; set; }

    /// <summary>
    /// Tthe persons who obtained, entered, or analyzed the data. If more than one person was involved, then all researchers can be cited here.
    /// </summary>
    // M:N
    public List<LfPerson> Researchers { get; set; }

    /// <summary>
    /// An indication of how confident the researcher is about the data in this record. Example values high, medium, low, uncertain.
    /// </summary>
    public Guid ConfidenceGuid { get; set; }
    public LfPossibility Confidence { get; set; }

    /// <summary>
    /// Any restrictions that might exist for this data.
    /// </summary>
    // M:N
    public List<LfPossibility> Restrictions { get; set; }

    /// <summary>
    /// OcmCodes - User applies OCM tags to this particular record.April 5, 2001 - The following documentation needs to be updated.This is where the user applies tagging at the scope of the entire record. Tags will be to such lists as the FRAME (the modified Outline of Cultural Materials), a grammar outline, and numerous other outlines that will be included with the system. After doing this tagging, the user will be able to quickly find all records that pertain to a particular topic. (In the user interface, we will provide mechanisms to facilitate fast tagging, including choosing which outline to tag from.)
    /// </summary>
    // M:N
    public List<LfAnthroItem> AnthroCodes { get; set; }

    /// <summary>
    /// The Tags attribute is used for explicit tagging by the end-user, where he indicates that a given tag applies to the entire record. The PhraseTags attribute by contrast is a behind-the-scenes tag. When the user tags a word or phrase within a description, the editing mechanism will add that tag to this attribute. The purpose is to provide a means for fast searching. The user can do a quick back-reference search to arrive at the appropriate records, and then do a text search to find the actual tagged phrase. In this manner we avoid having to do a sequential search through every record in the notebook.
    /// </summary>
    // M:N
    public List<LfPossibility> PhraseTags { get; set; }

    /// <summary>
    /// A collection of lower-level records. This permits a hierarchical grouping of records (e.g., all of the records dealing with Emilio and Maria's Wedding.) By placing this attribute at the RnGenericRecord level, we are making the claim that any type of record can have subrecords. Thus, for example, a Formal Interview might include some Observations that happened during the interview; a Performance Record might include several formal interviews about the performance; a Cartographic Record might include Reports on Conversations that helped in creating the map.
    /// </summary>
    public List<LfRnGenericRec> SubRecords { get; set; }

    /// <summary>
    /// The date and time that the record is created.
    /// </summary>
    public DateTime DateCreated { get; set; }

    /// <summary>
    /// The date and time that the record is last modified.
    /// </summary>
    public DateTime DateModified { get; set; }

    /// <summary>
    /// A RnGenericRecord can refer to one or more CrossReference objects. For version 1 of Research Notebook, CrossReference objects will have two backreferences representing a bi-directional cross-reference.
    /// </summary>
    // M:N
    public List<LfCrossReference> CrossReferences { get; set; }

    /// <summary>
    /// A listing of any external sources, such as tape or video records, pictures in a scrapbook, etc.
    /// </summary>
    public Guid ExternalMaterialsGuid { get; set; }
    public LfStText ExternalMaterials { get; set; }

    /// <summary>
    /// Questions that have arisen as a result of trying to prove a hypothesis or when examining an event record. These may be used later in elicitation sessions or become the bases of new hypotheses.
    /// </summary>
    public Guid FurtherQuestionsGuid { get; set; }
    public LfStText FurtherQuestions { get; set; }

    /// <summary>
    /// See Also cross-references for Events or Analyses
    /// </summary>
    // M:N
    public List<LfRnGenericRec> SeeAlso { get; set; }

    /// <summary>
    /// The date of the event.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public GenDate DateOfEvent { get; set; }

    /// <summary>
    /// Data records which refute the hypothesis.
    /// </summary>
    // M:N
    public List<LfRnGenericRec> CounterEvidence { get; set; }

    /// <summary>
    /// An indication of the current status of the record. Included default possibilities include: Confirmed, Disproved, Pending
    /// </summary>
    public Guid StatusGuid { get; set; }
    public LfPossibility Status { get; set; }

    /// <summary>
    /// A hypothesis can be superceeded by another hypothesis; this attribute refers to that superceeding hypothesis.
    /// </summary>
    // M:N
    public List<LfRnGenericRec> SupersededBy { get; set; }

    /// <summary>
    /// Data records which support the hypothesis.
    /// </summary>
    // M:N
    public List<LfRnGenericRec> SupportingEvidence { get; set; }

    /// <summary>
    /// A summary of the results of the research.
    /// </summary>
    public Guid ConclusionsGuid { get; set; }
    public LfStText Conclusions { get; set; }

    /// <summary>
    /// A statement of the hypothesis.
    /// </summary>
    public Guid HypothesisGuid { get; set; }
    public LfStText Hypothesis { get; set; }

    /// <summary>
    /// A plan for researching the hypothesis. Eventually we will tie this into project management; for now we just supply a text description.
    /// </summary>
    public Guid ResearchPlanGuid { get; set; }
    public LfStText ResearchPlan { get; set; }

    /// <summary>
    /// A list of locations in which the event occurred.
    /// </summary>
    // M:N
    public List<LfLocation> Locations { get; set; }

    /// <summary>
    /// The person(s) who reported the event to the researcher.
    /// </summary>
    // M:N
    public List<LfPerson> Sources { get; set; }

    /// <summary>
    /// The time that the event occurred. The types of items in the list here can be vernacular words that capture how the culture captures different times during the day.
    /// </summary>
    // M:N
    public List<LfPossibility> TimeOfEvent { get; set; }

    /// <summary>
    /// The type of event. Included possibilities include: Performance, Almanac, Conversation, Observation, Literature Summary, Analysis.
    /// </summary>
    public Guid TypeGuid { get; set; }
    public LfPossibility Type { get; set; }

    /// <summary>
    /// The content of the event.
    /// </summary>
    public Guid DescriptionGuid { get; set; }
    public LfStText Description { get; set; }

    /// <summary>
    /// A list of roles involved in the event and the participants who fill those roles. The user can specify participants directly in which case their role is assigned as unspecified.
    /// </summary>
    public List<LfRnRoledPartic> Participants { get; set; }

    /// <summary>
    /// Notes of a personal, perhaps non-publishable nature. You know ... personal frustrations, swear words and the like that you want to hide when your administrator checks your work.
    /// </summary>
    public Guid PersonalNotesGuid { get; set; }
    public LfStText PersonalNotes { get; set; }

    /// <summary>
    /// Any pertinent discussion relating to the hypothesis.
    /// </summary>
    public Guid DiscussionGuid { get; set; }
    public LfStText Discussion { get; set; }

    /// <summary>
    /// A text (suitable for analysis in the Words/Texts tool) that is associated with this record. For example, the record may be a description of how it was obtained.
    /// </summary>
    public Guid TextGuid { get; set; }
    public LfText Text { get; set; }

}

[Table("Reminder")]
public class LfReminder : LfObject
{
    /// <summary>
    /// The nature of the reminder, e.g., a question to get answered, or a note about some work that should be done. 
    /// </summary>
    public String Description { get; set; }

    /// <summary>
    /// A date which the user can set to be reminded to do something or check something. 
    /// </summary>
    [Column(TypeName = "jsonb")]
    public GenDate Date { get; set; }

}

[Table("RnRoledPartic")]
public class LfRnRoledPartic : LfObject
{
    /// <summary>
    /// A list of people (or one person) involved in the event in the role specified below.
    /// </summary>
    // M:N
    public List<LfPerson> Participants { get; set; }

    /// <summary>
    /// The role of the above participant(s). The role may be set to "unspecified."
    /// </summary>
    public Guid RoleGuid { get; set; }
    public LfPossibility Role { get; set; }

}

[Table("MoStemMsa")]
public class LfMoStemMsa : LfMoMorphSynAnalysis
{
    /// <summary>
    /// gives any morphosyntactic features belonging to the stem in addition to those specified by PartOfSpeech.InherentFeatureValues.
    /// In most cases, there will be none, but this attribute may be useful for exceptional words (such as the pluralia tantum words pants and scissors, which are grammatically plural even though the default for English nouns is singular). The features are restricted to those in vAllPossibleFeatures of my PartOfSpeech.
    /// </summary>
    public Guid MsFeaturesGuid { get; set; }
    public LfFsFeatStruc MsFeatures { get; set; }

    /// <summary>
    /// Most users will be more familiar with the notion of PartOfSpeech or morphosyntactic category than the notion of the object MorphoSyntacticInformation. This attribute, PartOfSpeech, stores the reference to the PartOfSpeech.
    /// </summary>
    public Guid PartOfSpeechGuid { get; set; }
    public LfPartOfSpeech PartOfSpeech { get; set; }

    /// <summary>
    /// refers to an MoInflectionClass (i.e. a conjugation or declension class). If none is listed, PartOfSpeech.vDefaultInflectionClass is used. If there is no vDefaultInflectionClass, then there are presumably no inflection classes (since the default value for vDefaultInflectionClass is the first inflection class of the paradigm). The assumption here is that inflection class membership is essentially an arbitrary label, i.e. that the inflection class membership of a stem cannot and should not be defined by a set of stem allomorphs or lists of 'principal parts' (see discussion in Carstairs-McCarthy 1998b: 332-334).
    /// </summary>
    public Guid InflectionClassGuid { get; set; }
    public LfMoInflClass InflectionClass { get; set; }

    /// <summary>
    /// refers to the MoStratum to which this MoMorphoSyntaxAnalysis object belongs.
    /// In an earlier version of this document, this attr belonged to MoForm. But that implied that one allomorph might belong to one stratum, and another allomorph to another stratum, which seems wrong. It is here, rather than on the superclass, because MoInflectionalAffixMsas do not need to "know" their stratum (their stratum is specified by the MoInflAffixTemplate in which they appear). (The other subclass of MoMorphoSyntaxAnalysis which has this attr is MoDerivationalAffixMsa.)
    /// </summary>
    public Guid StratumGuid { get; set; }
    public LfMoStratum Stratum { get; set; }

    /// <summary>
    /// Refers to a collection of CmPossibility, giving any exceptional properties of the stem that relate to restricting the productivity of affixes. (Other terms for this are 'exception features,' 'rule features' and 'ad hoc features'.) Usually these represent restrictions which are shared among a set of more than two morphemes (unlike AMPLE's 'ad hoc pairs', which concern a pair of morphemes). An example from English is the feature [+Latinate], marking that part of the English vocabulary which is etymologically derived from Latin, and which has certain synchronic properties. For example, the suffix -ity attaches only to [+Latinate] stems (Aronoff 1976: 51): felicity, vivacity, *widity, *strongity The similar suffix -ness, on the other hand, attaches to more or less all adjectives regardless of this feature. Similar restrictions are apparently found in other languages which have undergone substantial borrowing, e.g. Mohawk and Dutch are said to have restrictions which depend on whether or not stems were borrowed from French. Maybe there are other sources of such restrictions as well. These restrictions cannot be handled by inflection classes. The reason is that inflection classes and exception features are likely to be cross-cutting distinctions. Another sort of restriction for which exception features have sometimes been used, is for certain restricted (morpho-)phonological alternations, such as the Velar Softening rule of English (Chomsky and Halle 1968; Aronoff 1976: 51). However, this use is sometimes complicated by restrictions on adjacency, which cannot be easily modeled. An apparent alternative to exception features would be morphosyntactic features. However, exception features are (by definition) invisible to the syntax, and the use of morphosyntactic features for this purpose could incorrectly prevent unification of features in syntax, e.g. if we build an NP consisting of a [+Latinate] noun and an [-Latinate] determiner. See also MoDerivationalAffixMsa.FromProductivityRestrictions. Do exception features percolate? There is some inconclusive discussion of this in Aronoff 1976: 52. Note that the answer to this will not directly affect the domain model, only the parser and generator (unless we decide to leave it up to the user, and put a toggle somewhere). See also note under MoDerivationalAffixMsa.
    /// Changed from ProductivityRestrictions.
    /// </summary>
    // M:N
    public List<LfPossibility> ProdRestrict { get; set; }

    /// <summary>
    /// The FromPartsOfSpeech lists the categories (POSes) of words that this clitic may attach to. It can delimit a subset of categories if need be or it can be empty.
    /// </summary>
    // M:N
    public List<LfPartOfSpeech> FromPartsOfSpeech { get; set; }

    /// <summary>
    /// The Slots property applies only to clitics and refers to the inflectional affix slots in affix templates.
    /// </summary>
    // M:N
    public List<LfMoInflAffixSlot> Slots { get; set; }

}

[Table("LexEntry")]
public class LfLexEntry : LfObject
{
    public int HomographNumber { get; set; }

    /// <summary>
    /// If this is missing, then this defaults to the lexicalForm but the user has the option of specifying a real citation form especially useful for bound roots.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> CitationForm { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public List<LfMoMorphSynAnalysis> MorphoSyntaxAnalyses { get; set; }

    /// <summary>
    /// I am not currently sure whether senses belong on minor entries or not but we did allow this in LinguaLinks so I will leave it here for now for compatibility's sake.
    /// </summary>
    public List<LfLexSense> Senses { get; set; }

    /// <summary>
    /// Bibliographic information
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Bibliography { get; set; }

    /// <summary>
    /// Each entry may have multiple etymology specifications.
    /// </summary>
    public List<LfLexEtymology> Etymology { get; set; }

    /// <summary>
    /// Only certain people can use the entry under certain circumstances
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Restrictions { get; set; }

    /// <summary>
    /// This is a short definition at an entry level. (It used to be on LexMajorEntry.) 
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> SummaryDefinition { get; set; }

    /// <summary>
    /// This field is here for ease of use for the user. However, if the user fills out the components on the MSA of the subentry, the literal meaning can be derived. If Literal Meaning is empty and the components are filled in, the derived literal meaning should be displayed as virtual (in italics perhaps?) (It used to be on LexSubentry.)
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> LiteralMeaning { get; set; }

    /// <summary>
    /// If a user has specified Morphology, then FW should by default set a link to the entry that has a morph type of root. In the case of two or more roots, FW makes an arbitrary decision. Like other parts of the WW system, default choices should be indicated to the user so they can review them. In the majority of cases for subentry-like entries this will be only one entry (establishment points to establish) but with the possibility of more for entries that have more than one root in them (blackboard may point to board and black). For inflected forms, there will ALWAYS be only one entry pointed to (men points to man). (This used to be on LexSubentry and MainEntryOrSense on LexMinorEntry.) Subentries can be "subs" of either a major entry, another subentry, a minor entry (very rare) or a particular sense of any of the above. In this latter case, common in Philippine and Indonesian lexicons, the subentry usually appears under the sense of the entry.
    /// </summary>
    // M:N
    public List<LfObject> MainEntriesOrSenses { get; set; }

    /// <summary>
    /// Free text field for notes about environment of a variant or any other note. (This used to be on LexVariant and LexMinorEntry.)
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Comment { get; set; }

    /// <summary>
    /// The user may initially add entries not knowing if they are highly regular/predictable. Once discovering that an entry is "non-lexical", the user may still want to retain for example sentences, conjugation charts, etc. This boolean specifies that the parser is not to use the morphs or MSA info in its parsing. Default = False.
    /// </summary>
    public Boolean DoNotUseForParsing { get; set; }

    /// <summary>
    /// This property lists publications in which this main entry should not appear. Currently the hiding (and consequent adjusting of homograph numbers etc) only takes place in Dictionary view.
    /// </summary>
    // M:N
    public List<LfPossibility> DoNotShowMainEntryIn { get; set; }

    /// <summary>
    /// The lexeme form is the form of the entry that is normally used by linguists in interlinear text. The lexeme form is either the default allomorph for this lexEntry (e.g. French 'march' as opposed to citation form 'marcher') or the abstract underlying representation of it. (e.g. -[C][V]^2) When it is an abstract representation, the IsAbstract property is set. The lexeme form is equivalent to the base form in LinguaLinks or the \lx field in MDF files.
    /// </summary>
    public Guid LexemeFormGuid { get; set; }
    public LfMoForm LexemeForm { get; set; }

    /// <summary>
    /// This holds alternate forms, or allomorphs, in addition to the lexeme form. The lexeme form is also an allomorph if it is not abstract. These forms along with the lexeme form (when not abstract) are used by the parser.
    /// </summary>
    public List<LfMoForm> AlternateForms { get; set; }

    /// <summary>
    /// We may need more than one pronunciation per entry. For example either/neither have two different pronunciations. Some people may want to order these based on frequency of use, so it is a sequence instead of a collection.
    /// </summary>
    public List<LfLexPronunciation> Pronunciations { get; set; }

    /// <summary>
    ///  A place where we can store standard format markers that are not processed in any other way.
    /// </summary>
    public String ImportResidue { get; set; }

    /// <summary>
    /// Stores XML data that's not part of our model.
    /// </summary>
    public string LiftResidue { get; set; }

    /// <summary>
    /// This property is empty for main entries. For variant and complex entries, one or more LexEntryRef is used to point to the major entries. One variant entry could apply to more than one main entry, so each one could have a separate LexEntryRef. It’s possible for an entry to be a complex entry as well as a variant. This could be represented by one or more LexEntryRefs. Some may want to order multiple entries in a particular way, so we have a sequence instead of a collection.
    /// </summary>
    public List<LfLexEntryRef> EntryRefs { get; set; }

    /// <summary>
    /// This property lists publications in which this entry should not appear, either as a main entry or as any kind of link target. Currently the hiding (and consequent adjusting of homograph numbers etc) only takes place in Dictionary view.
    /// </summary>
    // M:N
    public List<LfPossibility> DoNotPublishIn { get; set; }

    /// <summary>
    /// This property lists dialects in which this entry is used.
    /// </summary>
    // M:N
    public List<LfPossibility> DialectLabels { get; set; }

}

[Table("ConstChartRow")]
public class LfConstChartRow : LfObject
{
    public String Notes { get; set; }

    /// <summary>
    /// This is an enum with these values: Normal, Dependent, Song, Speech
    /// </summary>
    public int ClauseType { get; set; }

    public Boolean EndParagraph { get; set; }

    public Boolean EndSentence { get; set; }

    public Boolean StartDependentClauseGroup { get; set; }

    public Boolean EndDependentClauseGroup { get; set; }

    public List<LfConstituentChartCellPart> Cells { get; set; }

    public String Label { get; set; }

}

[Table("LexExampleSentence")]
public class LfLexExampleSentence : LfObject
{
    /// <summary>
    /// This multilingual attribute holds the vernacular example sentence. It is multilingual to allow multiple encodings in the same language (e.g., Thai, Laotian, and Vietnamese). It is multiString rather than multiUnicode to allow formatting - for example, applying bold to the word associated with the LexEntry.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Example { get; set; }

    public String Reference { get; set; }

    public List<LfTranslation> Translations { get; set; }

    public string LiftResidue { get; set; }

    /// <summary>
    /// This property lists publications in which this example should not appear.
    /// </summary>
    // M:N
    public List<LfPossibility> DoNotPublishIn { get; set; }

}

[Table("LexDb")]
public class LfLexDb : LfMajorObject
{
    public List<LfLexAppendix> Appendixes { get; set; }

    public Guid SenseTypesGuid { get; set; }
    public LfPossibilityList SenseTypes { get; set; }

    public Guid UsageTypesGuid { get; set; }
    public LfPossibilityList UsageTypes { get; set; }

    public Guid DomainTypesGuid { get; set; }
    public LfPossibilityList DomainTypes { get; set; }

    public Guid MorphTypesGuid { get; set; }
    public LfPossibilityList MorphTypes { get; set; }

    // M:N
    public List<LfLexEntry> LexicalFormIndex { get; set; }

    // M:N
    public List<LfMoForm> AllomorphIndex { get; set; }

    public Guid IntroductionGuid { get; set; }
    public LfStText Introduction { get; set; }

    /// <summary>
    /// Used for flags to determine which form to use for headword, etc.
    /// </summary>
    public Boolean IsHeadwordCitationForm { get; set; }

    public Boolean IsBodyInSeparateSubentry { get; set; }

    /// <summary>
    /// Ken Zook: We are pretty well beyond the point where we'll ever allow multiple language projects in a database, so I think it's time we make these indexes owned. Since they are really part of the lexical database, I'm recommending they be owned by the lexical database.
    /// </summary>
    public List<LfReversalIndex> ReversalIndexes { get; set; }

    /// <summary>
    /// This holds the possibility list that holds LexRefType items which own the actual references.
    /// </summary>
    public Guid ReferencesGuid { get; set; }
    public LfPossibilityList References { get; set; }

    /// <summary>
    /// The named external resources (e.g. xml files) used by FLEX and their version numbers.
    /// </summary>
    public List<LfResource> Resources { get; set; }

    /// <summary>
    /// This Variant Entry Types list is used to classify a LexEntryRef via VariantEntryTypes. ItemClsid should be set to LexEntryType, IsSorted to true, and Depth to 127. The list is hierarchical with the top level being the type of variant (e.g., dialectal) and subitems being the conditions (e.g., British English, American English) for that type of variant. Normally the user will set this property to a subitem, although a top level item could be used if the user does not want to specify the condition. The user is free to provide additional nesting if useful. All items in the list will be LexEntryType, so the user will need to specify an appropriate Abbreviation and ReverseAbbr for each item in the list. This gives greater control to the user than having the program try to piece together information from a hierarchy of LexEntryTypes. The Abbreviation is used when displaying the main entry from the minor entry (e.g., Brit. dial. of color). The ReverseAbbr is used when displaying the minor entry from the main entry (e.g., Brit. dial. colour). Entries using this list will be displayed as minor entries in the dictionary; usually following the main entry headword and will typically produce a separate minor entry in the dictionary referring to the main entry. The initial list may have:
    /// Dialectal Variant
    ///     British
    ///     American
    /// Free Variant
    /// Inflectional Variant
    ///     Singular
    ///     Plural
    ///     First Person Singular (1SG)
    ///     Third Person Singular Present (3SG.PRES)
    /// Location
    ///     New York
    ///     Los Angeles
    /// Register
    ///     Formal
    ///     Informal
    /// Sociolect
    ///     Upper Class
    ///     Lower Class
    /// Spelling Variant
    /// </summary>
    public Guid VariantEntryTypesGuid { get; set; }
    public LfPossibilityList VariantEntryTypes { get; set; }

    /// <summary>
    /// This Complex Entry Types list is used to classify a LexEntryRef via the ComplexEntryTypes property. ItemClsid should be set to LexEntryType, IsSorted to true, and Depth to 127. The list will typically be flat, but the user is free to introduce a hierarchy if desirable. When entries use this list, they will be displayed as subentries in the dictionary. Entries using this list will be displayed as subentries in the dictionary; usually at the end of the major entry and will typically produce a separate major entry in the dictionary referring to the main entry. The display is dependent on whether a root-based or lexeme-based view of the dictionary is being printed. The initial list may have:
    /// Acronym
    /// Compound
    /// Contractions
    /// Derivation
    /// Idiom
    /// Phrasal Verb
    /// Saying
    /// </summary>
    public Guid ComplexEntryTypesGuid { get; set; }
    public LfPossibilityList ComplexEntryTypes { get; set; }

    /// <summary>
    /// This list stores the types of publications that the user defines which may be referenced in various "DoNotPublishIn" properties. By default it contains just one item, "Main Dictionary".
    /// </summary>
    public Guid PublicationTypesGuid { get; set; }
    public LfPossibilityList PublicationTypes { get; set; }

    /// <summary>
    /// This Extended Note Type list is used to classify a LexExtendedNote via the ExtendedNoteTypes property. ItemClsid should be set to CmPossibility, IsSorted to true, and Depth to 127. The list will typically be flat, but the user is free to introduce a hierarchy if desirable. The initial list may have:
    /// Cultural
    /// Grammar
    /// Semantic
    /// Collocation
    /// Discourse
    /// </summary>
    public Guid ExtendedNoteTypesGuid { get; set; }
    public LfPossibilityList ExtendedNoteTypes { get; set; }

    /// <summary>
    /// This list stores the languages that the user defines which may be selected in the LexEtymology.LanguageRS field.
    /// </summary>
    public Guid LanguagesGuid { get; set; }
    public LfPossibilityList Languages { get; set; }

    /// <summary>
    /// This list stores the dialects that the user defines which may be assigned to any LexEntry or LexSense.
    /// </summary>
    public Guid DialectLabelsGuid { get; set; }
    public LfPossibilityList DialectLabels { get; set; }

}

[Table("ConstituentChartCellPart")]
public abstract class LfConstituentChartCellPart : LfObject
{
    /// <summary>
    /// Specifically a column identifier.
    /// </summary>
    public Guid ColumnGuid { get; set; }
    public LfPossibility Column { get; set; }

    public Boolean MergesAfter { get; set; }

    public Boolean MergesBefore { get; set; }

}

[Table("ConstituentChartCellPart")]
public class LfConstChartWordGroup : LfConstituentChartCellPart
{
    public Guid BeginSegmentGuid { get; set; }
    public LfSegment BeginSegment { get; set; }

    public Guid EndSegmentGuid { get; set; }
    public LfSegment EndSegment { get; set; }

    /// <summary>
    /// Indicate the words that occur in the indicated cell of the chart.
    /// </summary>
    public int BeginAnalysisIndex { get; set; }

    /// <summary>
    /// Indicate the words that occur in the indicated cell of the chart.
    /// </summary>
    public int EndAnalysisIndex { get; set; }

}

[Table("ConstituentChartCellPart")]
public class LfConstChartMovedTextMarker : LfConstituentChartCellPart
{
    /// <summary>
    /// The target ConstChartWordGroup is in the column that shows the actual position of the text, while the marker indicates where the “something was moved from here” marker should appear.
    /// </summary>
    public Guid WordGroupGuid { get; set; }
    public LfConstChartWordGroup WordGroup { get; set; }

    public Boolean Preposed { get; set; }

}

[Table("ConstituentChartCellPart")]
public class LfConstChartClauseMarker : LfConstituentChartCellPart
{
    /// <summary>
    /// Indicates that the specified rows are dependent clauses (or song or speech).
    /// </summary>
    // M:N
    public List<LfConstChartRow> DependentClauses { get; set; }

}

[Table("ConstituentChartCellPart")]
public class LfConstChartTag : LfConstituentChartCellPart
{
    /// <summary>
    /// If Tag is null, then this represents a User-entered marker indicating the User wants a special "missing" marker to show up in this cell highlighting that fact that nothing occurs in this cell (presumably because normally there would be something in this column).
    /// </summary>
    /// <remarks>
    /// The CmPossibilities come from the list of chart tags. [Presentation note: currently a "missing" marker is displayed as "---".]
    /// </remarks>
    public Guid TagGuid { get; set; }
    public LfPossibility Tag { get; set; }

}

[Table("PunctuationForm")]
public class LfPunctuationForm : LfObject
{
    public String Form { get; set; }

}

[Table("LexPronunciation")]
public class LfLexPronunciation : LfObject
{
    /// <summary>
    /// This is the pronunciation usually in an approximately phonemic encoding for purposes of showing up in the printed dictionary.The pronunciation can be represented with more than one encoding.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Form { get; set; }

    /// <summary>
    /// Some pronunciations can be related to specific areas, so this points to the location list.
    /// </summary>
    public Guid LocationGuid { get; set; }
    public LfLocation Location { get; set; }

    /// <summary>
    /// A pronunciation may have more than one media file to allow for a man's voice and a woman's voice, slight dialect differences, etc.
    /// </summary>
    public List<LfMedia> MediaFiles { get; set; }

    /// <summary>
    /// This provides a place to store CV patterns of the pronunciation form. It defaults to the top analysis writing system, but being a string, it can be forced to some other writing system.
    /// </summary>
    public String CVPattern { get; set; }

    /// <summary>
    /// This provides a place to store tone patterns of the pronunciation form. It defaults to the top analysis writing system, but being a string, it can be forced to some other writing system. Tone may be marked as HL, 12, etc.
    /// </summary>
    public String Tone { get; set; }

    public string LiftResidue { get; set; }

    /// <summary>
    /// This property lists publications in which this pronunciation should not appear.
    /// </summary>
    // M:N
    public List<LfPossibility> DoNotPublishIn { get; set; }

}

[Table("LexSense")]
public class LfLexSense : LfObject
{
    public Guid MorphoSyntaxAnalysisGuid { get; set; }
    public LfMoMorphSynAnalysis MorphoSyntaxAnalysis { get; set; }

    // M:N
    public List<LfAnthroItem> AnthroCodes { get; set; }

    public List<LfLexSense> Senses { get; set; }

    // M:N
    public List<LfLexAppendix> Appendixes { get; set; }

    /// <summary>
    /// This is multiString to allow for embedding of one encoding within another and also to allow the user to manipulate formatting of different parts of the string.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Definition { get; set; }

    // M:N
    public List<LfPossibility> DomainTypes { get; set; }

    public List<LfLexExampleSentence> Examples { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Gloss { get; set; }

    public String ScientificName { get; set; }

    public Guid SenseTypeGuid { get; set; }
    public LfPossibility SenseType { get; set; }

    // M:N
    public List<LfPossibility> ThesaurusItems { get; set; }

    // M:N
    public List<LfPossibility> UsageTypes { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> AnthroNote { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Bibliography { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> DiscourseNote { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> EncyclopedicInfo { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> GeneralNote { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> GrammarNote { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> PhonologyNote { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Restrictions { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> SemanticsNote { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> SocioLinguisticsNote { get; set; }

    public String Source { get; set; }

    public Guid StatusGuid { get; set; }
    public LfPossibility Status { get; set; }

    // M:N
    public List<LfSemanticDomain> SemanticDomains { get; set; }

    public List<LfPicture> Pictures { get; set; }

    /// <summary>
    ///  A place where we can store standard format markers that are not processed in any other way.
    /// </summary>
    public String ImportResidue { get; set; }

    public string LiftResidue { get; set; }

    /// <summary>
    /// This property lists publications in which this sense should not appear, either in its main place or as any kind of link target. Currently the hiding only takes place in Dictionary view.
    /// </summary>
    // M:N
    public List<LfPossibility> DoNotPublishIn { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Exemplar { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> UsageNote { get; set; }

    public List<LfLexExtendedNote> ExtendedNote { get; set; }

    /// <summary>
    /// This property lists dialects in which this sense is used.
    /// </summary>
    // M:N
    public List<LfPossibility> DialectLabels { get; set; }

}

[Table("MoAdhocProhib")]
public abstract class LfMoAdhocProhib : LfObject
{
    /// <summary>
    /// refers to one of the following possibilities:
    /// Anywhere: The morphemes (or allomorphs) in question are constrained from appearing anywhere together in the same word.
    /// SomewhereToLeft and SomewhereToRight: The second (and later) morpheme (or allomorph) is constrained from appearing anywhere in the word to the left (right) of the first morpheme (respectively, allomorph).
    /// AdjacentToLeft and AdjacentToRight: The second (and later) morpheme (or allomorph) is constrained from appearing immediately to the left (right) of the first morpheme (respectively, allomorph) in the same word.
    /// </summary>
    public int Adjacency { get; set; }

    /// <summary>
    /// Indicates whether the rule is currently active and therefore will be used by the parser (false) or if it is not active (true) and therefore ignored by the parser (but still available for the user to see).
    /// The default value is false.
    /// </summary>
    public Boolean Disabled { get; set; }

}

[Table("MoAffixAllomorph")]
public class LfMoAffixAllomorph : LfMoAffixForm
{
    /// <summary>
    /// owns an FsFeatStruc, defining the morphosyntactic features which the stem to which this affix attaches must bear. See discussion of the MsEnvPartOfSpeech attribute above.
    /// </summary>
    public Guid MsEnvFeaturesGuid { get; set; }
    public LfFsFeatStruc MsEnvFeatures { get; set; }

    /// <summary>
    /// refers to a collection of PhEnvironment objects, describing what the phonetic environment of this allomorph is.
    /// The use of the term 'phonetic' is not intended to distinguish this from a phonological context, merely to say that the context is described in terms of its phonetic properties, not its morphosyntactic properties or lexically marked exception properties.
    /// If this attribute is uninstantiated, there is no phonetic restriction on the environment.
    /// The reason this is a collection attr (rather than atomic) is to allow for the situation during analysis before the user has managed to collapse what appear to be disparate environments into a single environment. (Note that the 'elsewhere' case can be represented by an empty environment under the assumption of disjunctive ordering.) Hence, a step in the stealth-to-wealth process will be to reduce the cardinality of this collection to one. A collection may of course also be useful for allomorphs which actually does appear in a disparate set of environments.
    /// For the reason why this is a ref attribute, rather than an owning attribute, see the discussion of MoMorphologicalData.PhoneEnvs.
    /// An important assumption here is that the phonetic environment to which this allomorph refers is the derived phonological environment. In the absence of phonological rules, this means that the phonetic environment refers to the allomorph(s) to its left, not to some base form of the morphemes. (If we later implement phonological rules, this implies we implement cyclic phonological processes.) The effect of iterative application of phonological rules would not be possible under this approach, although most cases might fall out from the step-wise attachment of affixes, which more or less amounts to cyclic rule application (without rules).
    /// Alternatively, we could allow reference to either (or both) the underlying and derived environments (which would in turn imply that every morpheme would need to have an underlying form); this would be similar to two-level phonology.
    /// </summary>
    // M:N
    public List<LfPhEnvironment> PhoneEnv { get; set; }

    /// <summary>
    /// refers to a PartOfSpeech, defining the morphosyntactic features which the stem to which this affix attaches must bear.
    /// Together with the MsEnvFeatures attribute (below), this attribute defines the morphosyntactic context in which this allomorph must appear. However, there are linguistic reasons for thinking that allomorphs should not in fact be able to specify morphosyntactic requirements on their environment. That is, there are often (always?) better analyses of allomorphy which do not rely on the morphosyntactic properties of the stem (see e.g. Matthews' 1972b reanalysis of Huave). The attribute is there because AMPLE provides that power (although AMPLE allows the user to test the morphosyntactic properties of arbitrary morphemes to the left or right, while the intention here is that an allomorph can only test the morphosyntactic properties of the stem to which it attaches).
    /// Since the parts of speech are contained in an inheritance hierarchy, a question arises: if this attr points to an abstract part of speech (verb, say), does a stem with a more specific part of speech (transitive verb, say) match? In the absence of any reason to think it does not, I would suggest that reference to an abstract part of speech entails that more specific parts of speech are included. Otherwise, it is hard to imagine how one could use this attribute-it would be necessary to allow a seq, or else to have separate but homophonous allomorphs for each specific part of speech.
    /// It is not clear what should be done if there are conflicts between the morphosyntactic requirements imposed by this attribute, and those imposed by the affix owning this allomorph. Such conflicts "should" not arise (since allomorphs shouldn't have special morphosyntactic requirements of their own, as argued in the previous paragraph). While it would be fairly simple to ensure that conflicts do not arise between stated morphosyntactic properties, there is the potential for implicit conflicts (e.g. the affix calls for attachment to a noun, while the allomorph requires that the stem have a certain feature value for subject agreement-something which nouns presumably do not mark).
    /// </summary>
    public Guid MsEnvPartOfSpeechGuid { get; set; }
    public LfPartOfSpeech MsEnvPartOfSpeech { get; set; }

    /// <summary>
    /// refers to an ordered seq of PhEnvironment, encoding the position relative to the stem in which this allomorph goes (for example, before the stem, after the stem, orbetween the first two consonants of the stem).
    /// A default value for this attr should be provided for prefixes and suffixes, based on MoForm.MorphType. For a prefix, this would be __#X (where X represents the entire stem), and for a suffix, X#__. This attr need not be displayed for prefixes andsuffixes.
    /// Note that it would not be possible to simplify the model by eliminating this attr, and letting the position of infixation be determined by the phonological environment of the allomorph(s). The reason this can't be done is that what is important for purposes of allomorphy vs. what is important for positioning the infix, are two different things. The reason for having this attr as a property of the allomorph, rather than of the MSA, is that this allows us to distinguish two different allomorphs which differ as to whether they are infixed or not. For example, there is a Tagalog affix whose infixed form is -in-, and whose prefixed form is ?in- (although the word-initial glottal happens not to be written orthographically).
    /// An alternative to having this attr on MoAffixAllomorph would be to add a subclass of this class for infixes (as well as suprafixes and other sorts of affixes that must appear in a particular position, other than before or after the stem). This new subclass would then have the extra attribute for position. One disadvantage of having such a subclass, is that it would be the only subclass of MoAffixAllomorph, whereas in fact all specific types of affixes (prefixes, suffixes, infixes,...) are sub-types. Having a default value of this attr for prefixes and suffixes adequately characterizes the difference between prefixes and suffixes on the one hand, and infixes on the other.
    /// The attr is a seq (as opposed to atomic) to account for affixes whose position relative to the stem is determined by the phonology of the stem. For example, in Tagalog the in affix occurs after the first consonant of a C-initial stem, or (prefixed) before a vowel-initial stem. (Note that this implies that an affix may not be purely a prefix or infix, contrary to the implication of the MorphType attr. The alternative is to require the user to treat such an affix as having two allomorphs, one a prefix and one an infix; but this would seem to be an unnecessary burden for the user.)
    /// The attr is an ordered seq (as opposed to a collection) in order to allow disjunctive ordering. Taking the example given above, disjunctive ordering would require the following environments, stored in an ordered seq:
    ///     #C__, #__
    /// Nondisjunctive ordering would require the following environments (which could be stored in a collection):
    ///     #C__, #__V
    /// Using an ordered seq does not force the parser/ generator to use the ordering, but allows for parsers which do use the order (such as Hermit Crab).
    /// </summary>
    // M:N
    public List<LfPhEnvironment> Position { get; set; }

}

[Table("MoAffixForm")]
public abstract class LfMoAffixForm : LfMoForm
{
    /// <summary>
    /// refers to a collection of MoInflectionClass, giving the conjugation or declension classes to which this allomorph belongs. This supports the collapsing into allomorphs of affixes which differ only in their form and in their requirements for inflection class.
    /// The allomorph which is the default will not specify any inflection class, and will therefore be used for all inflection classes not specified by other allomorphs. An empty value of this attribute therefore does not mean that this allomorph is not used in any inflection classes.
    /// In theory, this attr should be atomic, at least for inflectional affixes. That is, an inflectional affix should either specify a single inflection class, or it should be the elsewhere case, in which case it does not specify any inflection class (Carstairs-McCarthy 1994). It is nonetheless defined here as a seq attr, (1) for stealth-to-wealth reasons, and (2) because this theoretical claim may be wrong. There should however be tools to help the analyst discover inflectional affixes which have more than one inflection class specified in this attr, and if possible correct the analysis.
    /// </summary>
    // M:N
    public List<LfMoInflClass> InflectionClasses { get; set; }

}

[Table("MoAffixForm")]
public class LfMoAffixProcess : LfMoAffixForm
{
    /// <summary>
    /// Owns an ordered seq of PhContextOrVar, describing the form of the stem to which the affix attaches. The left-to-right order of the PhContextOrVars in this attribute corresponds to the order of the portions of the input word which match. (N.B.: There could be ambiguity, for instance if the input had two adjacent PhVariables. The system should check for this, and warn the user.)
    /// Given that PhContextOrVar can itself own an PhSequenceContext, the use of a seq attribute here may seem like overkill. However, it is only the topmost members of this Input attribute that can be numbered (the numbering is part of the user interface, and allows the user to point back to particular pieces of the input for the output). Perhaps this numbering can be done differently, in which case the Input attribute won't need to be seq.
    /// </summary>
    public List<LfPhContextOrVar> Input { get; set; }

    /// <summary>
    /// Owns an ordered seq of MoRuleMapping, describing the form output by attachment of this affix. Typically this consists of a copy of the Input plus some constant for the affix, but reduplication, infixation, simulfixes and suprafixes will be more complex. The left-to-right order of the MoRuleMapping objects in this attribute corresponds to the order of the pieces of the output word which will be constructed by the rule.
    /// </summary>
    public List<LfMoRuleMapping> Output { get; set; }

}

[Table("MoCompoundRule")]
public abstract class LfMoCompoundRule : LfObject
{
    /// <summary>
    /// Short label for the compound rule.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    /// <summary>
    /// Description of the compound rule.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// refers to an MoStratum, giving the stratum to which this rule belongs. The assumption behind the fact that this is an atomic attribute, is that a given compound rule (i.e. type of compound) can belong to only one stratum. If compounding happens in more than one stratum, then there must be more than one compounding rule. See also the discussion of MoStratum.vCompoundRules..
    /// </summary>
    public Guid StratumGuid { get; set; }
    public LfMoStratum Stratum { get; set; }

    /// <summary>
    /// refers to a collection of CmPossibility, giving any restriction classes which the stem resulting from this compound rule will bear. Specifically: if this attribute is non-empty, the stem resulting from this rule will have these restriction classes as the value of its ProductivityRestrictions (overriding any restriction classes borne by the daughter stems). If on the other hand this attribute is empty, the ProductivityRestrictions of the output stem will be the same as those of the head (for MoEndocentricCompounds) or empty (for MoExocentricCompounds).
    /// Changed from ToProductivityRestrictions.
    /// </summary>
    // M:N
    public List<LfPossibility> ToProdRestrict { get; set; }

    /// <summary>
    /// Indicates whether the rule is currently active and therefore will be used by the parser (false) or if it is not active (true) and therefore ignored by the parser (but still available for the user to see).
    /// The default value is false.
    /// </summary>
    public Boolean Disabled { get; set; }

}

[Table("MoDerivAffMsa")]
public class LfMoDerivAffMsa : LfMoMorphSynAnalysis
{
    /// <summary>
    /// specifies the morphosyntactic features which the stem to which this affix attaches must bear. See also the discussion of the FromPartOfSpeech attribute above.
    /// </summary>
    public Guid FromMsFeaturesGuid { get; set; }
    public LfFsFeatStruc FromMsFeatures { get; set; }

    /// <summary>
    /// ToMsFeatures: owns a FsFeatStruc, giving the morphosyntactic features which the word derived from this affix contains. In brief, the morphosyntactic features of the output word will contain all these feature values plus any nonconflicting feature values of the stem, provided the features are included in PartOfSpeech.BearableFeatures or PartOfSpeech.InflectableFeatures of the output word. (Or putting it differently, the ToMsFeatures override any conflicting features which would otherwise be percolated up from the stem.)
    /// </summary>
    public Guid ToMsFeaturesGuid { get; set; }
    public LfFsFeatStruc ToMsFeatures { get; set; }

    /// <summary>
    /// specifies the category of the stem to which this affix attaches. See comments above on the "Unitary Base Hypothesis." Note also that in AMPLE, it is possible to map a series of categories into another series of categories; that capability is not defined here. If the parts of speech list is hierarchical, the problem could be partially circumvented by specifying an abstract category in this attribute. However, that would not solve the problem of mapping the output category, because at best we could specify more than a single output category.
    /// Note that we do not (yet) have provision for subcategorization lists or argument structure. This means that some restrictions on the stem to which an affix would be attached cannot be handled elegantly. (They could be handled inelegantly, by creating an ad hoc feature for each subcategorization, e.g. [+ditransitive].) For example, the English suffix -able attaches only to transitive verbs (washable, *seemable); the English suffix -ee attaches only to verbs which allow animate objects or indirect objects (addressee, *tearee) (examples from Scalise 1986: 45). Nor do we treat semantic restrictions on the base to which the affix attaches. For example, it has been proposed that the English prefix re- attaches only to verbs whose meaning entails a change of state (John repunched the holes in the paper, *John repunched Bill in the face) (Aronoff 1976: 47, observation attributed to an unpublished paper of Williams).
    /// </summary>
    public Guid FromPartOfSpeechGuid { get; set; }
    public LfPartOfSpeech FromPartOfSpeech { get; set; }

    /// <summary>
    /// specifes the category(PartOfSpeech) of the word resulting from the attachment of this affix.
    /// Note that as with the FromPartOfSpeech, we do not (yet) cover subcategorization lists or argument structure here. Thus, we cannot handle subcategorization-changing affixes, such as causatives, by changing a subcategorization list, only by changing category or morphosyntactic features. Likewise, we cannot handle the change in argument structure that accompanies some category-changing affixes. For example, when the prefix en- verbalizes an adjective, the argument of which the adjective was predicated becomes the direct object of the verb (The picture is large - to enlarge the picture; example from Scalise 1986: 28).
    /// </summary>
    public Guid ToPartOfSpeechGuid { get; set; }
    public LfPartOfSpeech ToPartOfSpeech { get; set; }

    /// <summary>
    /// specifies the inflection (conjugation or declension) class which the stem to which this affix attaches must belong. In general, derivational affixes are arguably not marked for this property, so this attribute may be superfluous. However, it will certainly be necessary if non-Inflectional inflectional morphology is to be modeled using this class. (And it may turn out that some derivational affixes are sensitive to the inflectional class of their stem.)
    /// Under the realizational model of inflectional morphology, the inflection class to which an allomorph of an inflectional (realizational) affix belongs is indicated by MoAffixForm.InflectionClasses. That attribute is also available for allomorphs of derivational affixes (i.e. this class). That might be overkill, in that if a derivational affix attaches to stems of a single inflectional class, we could assign a single allomorph to that affix, and capture the restriction of the affix to the inflectional class as a restriction on that allomorph. However, the fromInflectionClass attribute here is parallel to the toInflectionClass attribute (defined below), which is independently needed. (Andy suggests that it may also be the case that a derivational affix would apply to a single inflection class, but have multiple allomorphs, in which case it would be convenient to have the attribute here, thereby avoiding the need to mark each allomorph for the same inflection class.)
    /// </summary>
    public Guid FromInflectionClassGuid { get; set; }
    public LfMoInflClass FromInflectionClass { get; set; }

    /// <summary>
    /// specifies the inflection (conjugation or declension) class which the word derived from this affix attaches belongs.
    /// An example of the use of this attribute would be to mark the conjugation class resulting from the attachment of a verbalizer. Another example is the use of the noun (declension) class 3 in Swahili to mark dimunitives (Beard 1998: 62).
    /// Note that a PartOfSpeech has an attr defaultInflClass, to which a derived word will belong if no toInflClass is defined here.
    /// </summary>
    public Guid ToInflectionClassGuid { get; set; }
    public LfMoInflClass ToInflectionClass { get; set; }

    /// <summary>
    /// In traditional interlinearizing programs, the user is encouraged to provide a part-of-speech or category for all morphemes in a word. Inflectional affixes such as PAST, PRESENT and FUTURE might be labelled as tense. Derivational affixes often take labels very similar to their glosses - CAUSATIVE might be labelled as causative or causative marker or simply verb affix. This field is provided here to allow the user to label affixes in this way for "stealth" purposes only. Inflectional affixes should ultimately be captured in inflectional templates and slot names used for interlinearizing. Derivational affixes should be default have a CmPossibility of "derv" (derivational affix).
    /// </summary>
    /// <remarks>
    /// This field is also provided for import of legacy data. The import mechanism should differentiate between affixes and roots/stems. Roots and stems will have their parts-of-speech placed in the PartOfSpeech list while affixes will have theirs placed in the AffixCategoryList.
    /// </remarks>
    public Guid AffixCategoryGuid { get; set; }
    public LfPossibility AffixCategory { get; set; }

    /// <summary>
    /// FromStemName: refers to an MoStemName, telling the stem to which this affix attaches. If this attr is empty, this affix attaches to the default stem of an MoStemMsa, as given by the vDefaultStems attr. (The vDefaultStems attr is a seq attr, to allow for a choice based on phonological constraints; in the absence of phonologically conditioned stem selection, there should be only one default stem.)
    /// </summary>
    public Guid FromStemNameGuid { get; set; }
    public LfMoStemName FromStemName { get; set; }

    /// <summary>
    /// Stratum: refers to the MoStratum to which this MoMorphoSyntaxAnalysis object belongs.
    /// In an earlier version of this document, this attr belonged to MoForm. But that implied that one allomorph might belong to one stratum, and another allomorph to another stratum, which seems wrong. It is here, rather than on the superclass, because MoInflectionalAffixMsas do not need to "know" their stratum (their stratum is specified by the MoInflAffixTemplate in which they appear). (The other subclass of MoMorphoSyntaxAnalysis which has this attr is MoStemMsa.)
    /// </summary>
    public Guid StratumGuid { get; set; }
    public LfMoStratum Stratum { get; set; }

    /// <summary>
    /// FromProductivityRestrictions: refers to a collection of CmPossibility, giving any restriction classes which the stem to which this affix attaches must bear. If this attribute is empty, this affix may attach to a stem regardless of what restriction classes the stem bears (see MoStemMsa.ProductivityRestrictions). If there are two or more restriction classes listed for this affix, then the stem must have at least all of these restriction classes in its MoStemMsa.ProductivityRestrictions attribute in order for this affix to attach to the stem. The stem could have more restriction classes, but not less.
    /// Changed from FromProductivityRestrictions.
    /// </summary>
    // M:N
    public List<LfPossibility> FromProdRestrict { get; set; }

    /// <summary>
    /// Specifies any restriction classes which the MoDerivationalStepMsa resulting from attaching this affix to a stem will bear (in its ProductivityRestrictions attribute). Specifically: if this attribute is non-empty, the stem resulting from the attachment of this affix will have these restriction classes as the value of its ProductivityRestrictions (overriding any restriction classes borne by the stem to which this affix attached). If on the other hand this attribute is empty, the ProductivityRestrictions of the output stem will be the same as those of the input stem.
    /// Changed from ToProductivityRestrictions.
    /// </summary>
    // M:N
    public List<LfPossibility> ToProdRestrict { get; set; }

}

[Table("MoDerivStepMsa")]
public class LfMoDerivStepMsa : LfMoMorphSynAnalysis
{
    /// <summary>
    /// refers to a PartOfSpeech, telling the category of the word.
    /// </summary>
    public Guid PartOfSpeechGuid { get; set; }
    public LfPartOfSpeech PartOfSpeech { get; set; }

    /// <summary>
    /// owns an FsFeatStruc, giving the morphosyntactic features which result from percolation. N.B.: This does not include inflectional features which are to be realized by inflectional affixes (and which may be incompatible with the current part of speech, or contradict percolated features).
    /// </summary>
    public Guid MsFeaturesGuid { get; set; }
    public LfFsFeatStruc MsFeatures { get; set; }

    /// <summary>
    /// Owns an FsFeatStruc, giving the morphosyntactic features which the word is to be inflected for at the end of the derivation.
    /// Changed from InflectionFeatures for the database port.
    /// </summary>
    public Guid InflFeatsGuid { get; set; }
    public LfFsFeatStruc InflFeats { get; set; }

    /// <summary>
    /// InflectionClass: refers to an MoInflectionClass. This gives the inflection class to which the word being derived belongs, at this stage in the derivation. The algorithm for computing this is rather complex (which is why I have not defined this as a virtual attr), but basically it is this: If the last MoDerivationalAffix attached specifies a ToInflectionClass, then this attr is that inflection class. If the last MoDerivationalAffix attached does not specify a ToInflectionClass, then we collect all the derivational affixes attached inside that one which have the same ToPartOfSpeech or a PartOfSpeech which is a subcategory or a supercategory of the last derivational affix's part of speech, stopping when we come to a part of speech which is not the same or a subcategory or a supercategory. The outermost of these affixes which specifies a ToInflectionClass is used for this stage's InflectionClass. If none of these affixes specifies a ToInflectionClass, and the MoStemMsa is accessible (meaning none of the affixes has a contrary ToPartOfSpeech), then we use the InflectionClass of that stem. If all of these possibilities fail, we use the vDefaultInflectionClass of the PartOfSpeech.
    /// </summary>
    public Guid InflectionClassGuid { get; set; }
    public LfMoInflClass InflectionClass { get; set; }

    /// <summary>
    /// Specifies the restriction classes which the word has at this stage in the derivation.
    /// Changed from ProductivityRestrictions
    /// </summary>
    // M:N
    public List<LfPossibility> ProdRestrict { get; set; }

}

[Table("MoEndoCompound")]
public class LfMoEndoCompound : LfMoBinaryCompoundRule
{
    /// <summary>
    /// owns a Boolean, defaulting to true (meaning that the right-hand constituent is the head).
    /// </summary>
    public Boolean HeadLast { get; set; }

    /// <summary>
    /// Any attribute specified in this msa will override the corresponding attribute of the head msa of the compound.
    /// </summary>
    public Guid OverridingMsaGuid { get; set; }
    public LfMoStemMsa OverridingMsa { get; set; }

}

[Table("MoExoCompound")]
public class LfMoExoCompound : LfMoBinaryCompoundRule
{
    /// <summary>
    /// owns an MoStemMsa, giving the morphosyntactic information about the output of this compound. (Since the morphosyntactic properties of the daughters cannot be inherited in an exocentric compound, there is no question here of conflicts between the properties specified in this attribute and the properties of the daughters.)
    /// There is no provision for choosing a part of speech based on the argument properties of either element of the compound.
    /// </summary>
    public Guid ToMsaGuid { get; set; }
    public LfMoStemMsa ToMsa { get; set; }

}

[Table("MoForm")]
public abstract class LfMoForm : LfObject
{
    /// <summary>
    /// It is not clear to me what is supposed to go into this attribute for process affixes (MoAffixProcess), since these do not have a form per se (and in some cases, such as reduplication, there is no form at all). One could use this for a description of the process affix, but that usage would then not parallel the usage in other subclasses.
    /// Null inflectional affixes are usually unnecessary in a realizational theory of morphology; putative null derivational affixes can usually be modeled by multiple parts of speech for (lexically listed) stems; and null stems are quite rare. Nonetheless, for purposes of stealth to wealth, as well as for the rare situation where null affixes or stems are actually required, this Form attr can hold an empty string. (See e.g. the discussion of spanned slots in the MoInflAffixTemplate class for one situation where null affixes may be necessary.) There is no assurance that all the strings in this multilingual attr will be null or non-null, but even this looseness may occasionally be useful—where an affix is overt in one encoding, but covert in another. An example would be an affix consisting of a tone: tones might be marked in some encodings, but unmarked in others.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Form { get; set; }

    /// <summary>
    /// refers to an MoMorphType which is an item on a possibilities list. Possibilities include at least: prefix, suffix, infix, circumfix, root, bound root, and probably proclitic and enclitic. Note that most of these are appropriate for one or the other subclass, but since there is only one possibilities list, the types must be limited by procedural code. Other kinds of affixation (circumfixes, simulfixes, suprafixes etc.) are probably beyond the capabilities of Item-and-Arrangement morphology, and may therefore need to be prevented from appearing (or grayed out) with the class MoAffixAllomorph.
    /// Additional Notes: It is of course possible to analyze reduplication as the attachment of a prosodic constituent, such as a syllable (see McCarthy and Prince 1990), provided there is some way of filling the melodic information into that skeleton. But the system described here does not provide a way of automatically copying such melodic information, so reduplication cannot be treated in that way at present. (And in many cases, reduplication under prosodic morphology requires the base to be parsed into two constituents, so that affixation still involves more than specifying the prosodic form of the affix.)
    /// </summary>
    public Guid MorphTypeGuid { get; set; }
    public LfMoMorphType MorphType { get; set; }

    /// <summary>
    /// This is used to indicate a lexeme form is an abstract form (e.g.,-[C][V]^2, or iN) and should not be used for parsing.
    /// </summary>
    public Boolean IsAbstract { get; set; }

    public string LiftResidue { get; set; }

}

[Table("MoInflAffixSlot")]
public class LfMoInflAffixSlot : LfObject
{
    /// <summary>
    /// See discussion in class documentation.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    /// <summary>
    /// multilingual string, containing the user's description/ explanation of this slot (optionally including any consistent semantics-or an explanation that there is no consistent semantics).
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// Optional: Boolean, default False. A value of true indicates that this slot is optional and therefore does not have to appear. This is not intended for slots which have what might be called a zero morpheme-see the discussion of the 'Affixes' attribute immediately above. Rather, this attribute is intended for the situation in which a language optionally marks some feature-value combinations. For example, in Tzeltal the plurality of a noun is only optionally marked: a suffix indicates that the noun is plural, but the absence of a plural suffix does not mean the noun is necessarily singular. For this situation, an optional slot containing the plural morpheme would be appropriate.
    /// Implementation Note: In the Tzeltal case discussed above, it would probably be inappropriate for the parser to say that a noun without an overt plural suffix was ambiguous between a singular reading and a plural one. Rather, it should unambiguously parse as unmarked for plurality.
    /// </summary>
    public Boolean Optional { get; set; }

}

[Table("MoInflAffixTemplate")]
public class LfMoInflAffixTemplate : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// refers to an ordered seq of MoInflAffixSlot; during the course of a derivation, each Affix Slot is applied in sequence, beginning with the top-most slot. While in many (most?) languages the order of attachment of Inflectional affixes is irrelevant, it may occasionally be necessary to specify a derivational order to account for allomorphy.
    /// Since the left-to-right order is likely to be discovered earlier than the derivation order, it will probably be necessary to provide a default derivation order which can be computed from the order in the PrefixSlots and SuffixSlots attributes (below). Existing front-ends to AMPLE (such as CarlaMen) do something similar by allowing the user to choose to apply all prefixes before all suffixes, or vice versa, and something similar will probably suffice as a default here.
    /// </summary>
    // M:N
    public List<LfMoInflAffixSlot> Slots { get; set; }

    /// <summary>
    /// refers to the MoStratum to which this MoInflAffixTemplate belongs. Normally that would be the final stratum (or at least to the final stratum in which morphology takes place; if one is modeling post-lexical phonology, that would usually be in a stratum after the inflectional morphology). However, in languages where some derivational affixes attach outside of (some) inflection, that derivational morphology (and any subsequent inflectional morphology) will be in a stratum outside of a stratum containing the inflectional affix template.
    /// This definition assumes there are no cycles, i.e. that one does not get the same kind of inflectional affixes both inside and outside of derivational affixes. That's not obviously correct, e.g. one might have
    ///     [[[[Noun_root] noun_template ] verbalizer ] verb_template]
    /// and
    ///     [[[[Verb_root] verb_template ] nominalizer ] noun_template]
    /// where the two instances of noun_template and of verb_template are the same. This would be a counterexample (or would require duplicating the templates in the two strata, obviously a sign that something is wrong with the analysis).
    /// </summary>
    public Guid StratumGuid { get; set; }
    public LfMoStratum Stratum { get; set; }

    /// <summary>
    /// owns an FsFeatStruc defining the region of the paradigm for which this template is relevant. The idea here is that in some regions of the template (typically, things like participles or imperatives), there may be fewer affix slots than in other regions. While one could use the same template for all regions, with affixes in some of the slots restricted to appearing only with certain features (such as [?participle]), this is probably not the simplest analysis (since it requires all affixes in those slots to be so marked, including what would otherwise be default affixes).
    /// If this attr is empty, then this template pertains to the entire paradigm except for any regions covered by templates ordered before this one in the PartOfSpeech.AffixTemplates attr of the owner.
    /// </summary>
    /// <remarks>
    /// The algorithm for choosing the appropriate template can use the first template whose _pRegion_ is a subset of the inflectional features to be realized on the word. That means that the exceptional templates (e.g. those for participles or imperatives) can be ordered first, and the default template last--so the default template doesn't actually have to specify anything in its pRegion attr.The idea here is that in some regions of the template (typically, things like participles or imperatives), there may be fewer affix slots than in other regions. While one could use the same template for all regions, with affixes in some of the slots restricted to appearing only with certain features (such as [-participle]), this is probably not the simplest analysis (since it requires all affixes in those slots to be so marked, including what would otherwise be default affixes).If this attr is empty, then this template pertains to the entire paradigm except for any regions covered by templates ordered before this one in the pAffixTemplates attr of the owning PartOfSpeech.
    /// </remarks>
    public Guid RegionGuid { get; set; }
    public LfFsFeatStruc Region { get; set; }

    /// <summary>
    /// refers to an ordered seq of MoInflAffixSlot, i.e. those slots which correspond (roughly) to prefixes. The order is from the innermost affix out, i.e. right-to-left.
    /// The reason for this attribute (and for the SuffixSlots attribute, below) is that the Slots attribute is a derivation order, i.e. the order in which the affixes are applied during a derivation; while the partition into prefix and suffix slots is for purposes of display, and to support the stealth-to-wealth concept (see discussion above, under slots).
    /// For most languages, the PrefixSlots and the SuffixSlots will partition the entire set of slots. Of course, this assumes that no affix slot contains both prefixes and suffixes (i.e. there is no discontinuous bleeding), and that affixes of reduplication, infixes, circumfixes, simulfixes etc. can be shoe-horned into one or the other of these attributes. There are almost certainly languages where this will not work, and for which the user may wish to ignore the prefix and suffix division. Accordingly, some alternative sort of display should be available for that situation. An example of such a language is Huave (Matthews 1972b), for which some slots contain both prefixes and suffixes; see also Stump's (1992) discussion of "ambifixal position classes."
    /// </summary>
    /// <remarks>
    /// The reason for this attribute (and for the pSuffixSlots attribute, below) is that the pSlots attribute is a derivation order, i.e. the order in which the affixes are applied during a derivation; while the partition into prefix and suffix slots is for purposes of display, and to support the stealth-to-wealth concept (see discussion above, under slots).For most languages, the pPrefixSlots and the pSuffixSlots will partition the entire set of slots. Of course, this assumes that there is no affix slot contains both prefixes and suffixes (i.e. there is no discontinuous bleeding), and that affixes of reduplication, infixes, circumfixes, simulfixes etc. can be shoe-horned into one or the other of these attributes. There are almost certainly languages where this will not work, and for which the user may wish to ignore the prefix and suffix division. Accordingly, some alternative sort of display should be available for that situation.
    /// </remarks>
    // M:N
    public List<LfMoInflAffixSlot> PrefixSlots { get; set; }

    /// <summary>
    /// refers to an ordered seq of MoInflAffixSlot, i.e. those slots which correspond (roughly) to suffixes. The order is from the innermost affix out, i.e. left-to-right. See discussion re PrefixSlots concerning other types of affixes.
    /// </summary>
    // M:N
    public List<LfMoInflAffixSlot> SuffixSlots { get; set; }

    /// <summary>
    /// In languages like Quechua, one can inflect a verb stem with all but tense. Instead one adds a derivational affix (participle) which creates a noun. The resulting stem is then inflected like a noun. 
    /// To model this, we need the regular verbal template (including tense) and a template that has all but tense. When the former is applied to a stem, it produces a well-formed word. The latter is not. 
    /// If we add a boolean to MoInflAffixTemplate that indicates that the template is non-final, then we can have our word grammar reject an analysis that ends with the non-final template (i.e. it does not have the required derivation and inflection). The default value for this boolean would indicate "final". 
    /// The attribute could be called Final (with a default value of "true").
    /// </summary>
    public Boolean Final { get; set; }

    /// <summary>
    /// Indicates whether the template is currently active and therefore will be used by the parser (false) or if it is not active (true) and therefore ignored by the parser (but still available for the user to see).
    /// The default value is false.
    /// </summary>
    public Boolean Disabled { get; set; }

    /// <summary>
    /// Refers to an ordered seq of MoInflAffixSlot, i.e. those slots which correspond to proclitics. The order is from the innermost proclitic out, i.e. right-to-left.
    /// The reason for this attribute (and for the EncliticSlots property) is that the Slots attribute is a derivation order, i.e. the order in which the proclitics are applied during a derivation.
    /// </summary>
    // M:N
    public List<LfMoInflAffixSlot> ProcliticSlots { get; set; }

    /// <summary>
    /// Refers to an ordered seq of MoInflAffixSlot, i.e. those slots which correspond to enclitics. The order is from the innermost enclitic out, i.e. left-to-right.
    /// The reason for this attribute (and for the ProcliticSlots property) is that the Slots attribute is a derivation order, i.e. the order in which the enclitics are applied during a derivation.
    /// </summary>
    // M:N
    public List<LfMoInflAffixSlot> EncliticSlots { get; set; }

}

[Table("MoInflAffMsa")]
public class LfMoInflAffMsa : LfMoMorphSynAnalysis
{
    /// <summary>
    /// Owns an FsFeatStruc, representing the morphosyntactic features realized by this affix.
    /// Most commonly, the feature values of this FsFeatStruc will belong to the PartOfSpeechGrammar.doc - PartOfSpeech.vAllInflectableFeatures of the stem to which the inflectional affix attaches, but may also include any of the features in the vAllInherentFeatureValues or vAllBearableFeatures attrs. For example, in Tzeltal there are two incompletive aspect prefixes, distinguished by whether the stem to which they attach is transitive or intransitive. The aspect feature would be an inflectable feature of verbs, but the transitivity feature would be either an inherent feature of the stem (assuming transitive and intransitive verbs have distinct parts of speech) or a bearable feature (if transitive and intransitive verbs are both treated as having the part of speech verb, and are distinguished by the transitivity feature alone).
    /// In determining what feature values can be added to a given FsFeatStruc, it will probably be desirable to disallow conflicting feature values (or even assigning the same feature value twice). However, it is permissible to have two different feature values at different places in an FsComplexValue; for example, [[Subject [Person 1]] [Object [Person 2]]].
    /// In the course of a stealth-to-wealth analysis, a single affix might occupy a set of cells in a paradigm, where the cells do not form a natural class, and where they are not an 'elsewhere' case, or at least the user does not recognize them as such. This situation can be accommodated by the use of FsFeatStruc.FeatDisj. The goal at the 'wealth' end would be to find a natural class for the cells, thereby eliminating the feature disjunction, or to use disjunctive ordering within an MoInflAffixSlot to allow the statement of the features in a non-disjunctive manner.
    /// Changed from InflectionFeatures for the database port.
    /// </summary>
    public Guid InflFeatsGuid { get; set; }
    public LfFsFeatStruc InflFeats { get; set; }

    /// <summary>
    /// In traditional interlinearizing programs, the user is encouraged to provide a part-of-speech or category for all morphemes in a word. Inflectional affixes such as PAST, PRESENT and FUTURE might be labelled as tense. Derivational affixes often take labels very similar to their glosses - CAUSATIVE might be labelled as causative or causative marker or simply verb affix. This field is provided here to allow the user to label affixes in this way for "stealth" purposes only. Inflectional affixes should ultimately be captured in inflectional templates and slot names used for interlinearizing. Derivational affixes should be default have a CmPossibility of "derv" (derivational affix).
    /// </summary>
    /// <remarks>
    /// This field is also provided for import of legacy data. The import mechanism should differentiate between affixes and roots/stems. Roots and stems will have their parts-of-speech placed in the PartOfSpeech list while affixes will have theirs placed in the AffixCategoryList.
    /// </remarks>
    public Guid AffixCategoryGuid { get; set; }
    public LfPossibility AffixCategory { get; set; }

    public Guid PartOfSpeechGuid { get; set; }
    public LfPartOfSpeech PartOfSpeech { get; set; }

    // M:N
    public List<LfMoInflAffixSlot> Slots { get; set; }

    /// <summary>
    /// Refers to a collection of CmPossibility, giving any restriction classes which the stem to which this affix attaches must bear. If this attribute is empty, this affix may attach to a stem regardless of what restriction classes the stem bears (see MoStemMsa.ProductivityRestrictions). If there are two or more restriction classes listed for this affix, then the stem must have at least all of these restriction classes in its MoStemMsa.ProductivityRestrictions attribute in order for this affix to attach to the stem. The stem could have more restriction classes, but not less. (Note that unlike the case with MoDerivationalAffixMsa, there is no 'to productivity restrictions' attribute for inflectional affixes: inflectional affixes cannot add restriction classes to a word.)
    /// Changed from FromProductivityRestrictions.
    /// </summary>
    // M:N
    public List<LfPossibility> FromProdRestrict { get; set; }

}

[Table("MoInflClass")]
public class LfMoInflClass : LfObject
{
    /// <summary>
    /// a multiUnicode string, storing an abbreviated form of the Name. Probably useful for displays. Probably defaults to the first eight or so chars of the Name.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbreviation { get; set; }

    /// <summary>
    /// multilingual string, containing the user's description/ explanation of this inflection class.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// A multiUnicode string, e.g. "3rd. declension" or "?er verbs".
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    /// <summary>
    /// owns a collection of MoInflectionClasses, each of which is a specialization of this Inflection Class. Part of the S2W process is decreasing the number of inflection classes by pushing identical information in subclasses up into the parent inflection class, and by accounting for differences among subclasses in other ways (e.g. as phonologically predictable allomorphy, or by features such as gender that are not among the PartOfSpeech.InflectableFeatures attribute of the owner).
    /// </summary>
    public List<LfMoInflClass> Subclasses { get; set; }

    /// <summary>
    /// owns a sequence of MoReferralRule. Like the attribute pRulesOfReferral in the class PartOfSpeech, except that rules of referral which are owned by the PartOfSpeech hold for all lexemes of that part of speech (regardless of inflection class), whereas rules of referral owned by this class hold only for lexemes of a particular class. (In Stump's (1993a) notation, the latter case corresponds to indicating a 'CLASS' for the Referral Rule.)
    /// </summary>
    public List<LfMoReferralRule> RulesOfReferral { get; set; }

    /// <summary>
    /// owns a collection of MoStemNames, which define any non-default inflectional stems of the inflection class (but not the default stem) in addition to those found in the PartOfSpeech.
    /// The MoStemNames are interpreted as a disjunctively ordered list, i.e. in selecting a Stem for a given word, the list of StemNames is searched linearly, stopping at the first one for which one of its cells unifies with the FsFeatStruc of the word to be derived (see Choosing a Stem Allomorph). The order of the MoStemNames in this attribute is therefore important.
    /// If this attribute is empty, it defaults to the value of the same attribute in its owner. This allows e.g. defining a set of stem names for all verbs, and inheriting those names for all inflection classes of verb (as well as for all subcategories of verb). It should probably be possible to block such inheritance without specifying any stem names, so there needs to be some specified value for that ('nil', say).
    /// </summary>
    public List<LfMoStemName> StemNames { get; set; }

    /// <summary>
    /// ReferenceForms: owns a collection of FsFeatStruc, each of which defines the cell whose inflection uniquely picks out an inflection class. (Cf. Carstairs-McCarthy 1991, particularly section 8). Usually, the reference forms belonging to a PartOfSpeech will suffice for all the MoInflectionClasses, i.e. a single "Primary Reference Form" (Carstairs-McCarthy's term). In some cases, however, it may prove necessary to provide a secondary reference form to distinguish among "mixed" classes (see again the discussion in Carstairs-McCarthy 1991.) This attr is then where the secondary reference form would be stored. The classes which need to be distinguished by ReferenceForms will presumably constitute the members of the Subclasses attr of some parent inflection class, together with that parent inflection class. The appropriate class to list the ReferenceForms will then be that parent class, and the daughter classes will inherit that property via their vAllReferenceForms (see below).
    /// Note that this attribute performs no particular function in any of the algorithms used for computing affixed forms. However, it may be useful in the context of a dictionary, e.g. for providing principal parts.
    /// </summary>
    public List<LfFsFeatStruc> ReferenceForms { get; set; }

}

[Table("MoMorphData")]
public class LfMoMorphData : LfObject
{
    /// <summary>
    /// owns a col of MoStratum objects, in order from shallowest to deepest.
    /// </summary>
    public List<LfMoStratum> Strata { get; set; }

    /// <summary>
    /// owns a seq of MoCompoundRules. (Alternatively, these could be owned in the stratum to which they belong - see MoStratum.vCompoundRules for discussion.) The order corresponds to the order in which the compounding rules apply in a derivation.
    /// </summary>
    public List<LfMoCompoundRule> CompoundRules { get; set; }

    /// <summary>
    /// Used to hold the list of ad hoc cooccurrence restrictions. (Ideally, this is empty!)
    /// </summary>
    public List<LfMoAdhocProhib> AdhocCoProhibitions { get; set; }

    // M:N
    public List<LfAgent> AnalyzingAgents { get; set; }

    /// <summary>
    /// WfiWordSets are a collection of words that the user might want to use to test his word grammar as he adjusts morphological rules and the lexicon.
    /// </summary>
    public List<LfWfiWordSet> TestSets { get; set; }

    public Guid GlossSystemGuid { get; set; }
    public LfMoGlossSystem GlossSystem { get; set; }

    /// <summary>
    /// We need a place to put "maximum parses" and other related parameters. 
    /// Note: The following parameters could easily need to be controlled by the user (and are already set as parameters in the XSLT that creates the AD.CTL file): 
    /// prmMaxNull - maximum number of nulls <p/>
    /// prmMaxPrefixes - maximum number of prefixes (default is 5) <p/>
    /// prmMaxSuffixes - maximum number of suffixes (default is 255) <p/>
    /// prmMaxInfixes - maximum number of infixes (default is 0 unless there are infixes in which case it is 1) <p/>
    /// prmMaxRoots - maximum number of roots that can compound (default is 2 if there are compound rules; otherwise it is 1) <p/>
    /// [There is one other parameter for max number of properties, but we should be able to calculate that number based on the data - I'll fix this.] 
    /// </summary>
    public string ParserParameters { get; set; }

    /// <summary>
    /// This reflects what is also referred to as exception features in the literature. It defines class identifiers that can be associated with non-productive derivational or inflectional affixes that only go on stems that belong to the same class. An example from English is the feature [+Latinate], marking that part of the English vocabulary which is etymologically derived from Latin, and which has certain synchronic properties. For example, the suffix -ity attaches only to [+Latinate] stems (Aronoff 1976: 51): felicity, vivacity, *widity, *strongity. The similar suffix -ness, on the other hand, attaches to more or less all adjectives regardless of this feature. Similar restrictions are apparently found in other languages which have undergone substantial borrowing, e.g. Mohawk and Dutch are said to have restrictions which depend on whether or not stems were borrowed from French. Maybe there are other sources of such restrictions as well. These restrictions cannot be handled by inflection classes. The reason is that inflection classes and exception features are likely to be cross-cutting distinctions.
    /// Changed from ProductivityRestrictions
    /// </summary>
    public Guid ProdRestrictGuid { get; set; }
    public LfPossibilityList ProdRestrict { get; set; }

}

[Table("MoMorphSynAnalysis")]
public abstract class LfMoMorphSynAnalysis : LfObject
{
    /// <summary>
    /// points to an ordered seq of other MoMorphoSyntaxAnalysis objects, which are interpreted as the morphemes or stems that make up this object.
    /// Additional Notes:
    /// Ordinarily, this would only be appropriate for stems which are not roots, hence it would be an attribute of MoStemMsa. I believe it is here on the superclass because under the stealth-to-wealth concept, the user may be in a state where he realizes something is composite, but has not yet worked out all the morphemes of which it is composed. This attribute could then be used to point to the parts that have already been discovered. Possibly when the user succeeds in completely decomposing the stem or composite affix, this object could go away, although it may be beneficial to retain it for future comparisons. Another possible use might be for a portmanteaux affix with a partial analysis, or for 'complex' affixes like the English ?ation (which under the Word Based Hypothesis, cannot be composed of the suffixes ?at and ?ion because of its appearance in words like recitation, since there is no word *recitate).
    /// I have defined this as an ordered seq on the assumption that the order of the components will match the left-to-right order of the morphemes. This is not unproblematic: some morphemes may be unanalyzed, and some morphemes may not appear in a strict left-to-right order (e.g. infixes). The former problem could be fixed by the use of placeholder (uninstantiated) Msas; the latter could be fixed either by defining a canonical order, or by using derivational order instead.
    /// </summary>
    // M:N
    public List<LfMoMorphSynAnalysis> Components { get; set; }

    /// <summary>
    /// Stores the gloss string generated by the sequence of MoGlossItems (association GlossBundle). The user can override this if necessary.
    /// </summary>
    public string GlossString { get; set; }

    /// <summary>
    /// The functional gloss for this MSA is the ordered bundle of MoGlossItems that it points to. These are ordered as necessary to create the desired gloss string.
    /// When the user selects gloss items from the language-specific gloss system to form a composite gloss, this analysis is stored in the MSA as a gloss bundle (which an attribute on MSA that stores a set of references to all the selected gloss items). The language-specific feature structure for an MSA is automatically generated by computing the unification of all the feature structure fragments in the gloss bundle.
    /// </summary>
    // M:N
    public List<LfMoGlossItem> GlossBundle { get; set; }

    public string LiftResidue { get; set; }

}

[Table("Possibility")]
public class LfMoMorphType : LfPossibility
{
    /// <summary>
    /// like pPrefix, but added after the fForm. Often a dash for prefixes and infixes, and perhaps proclitics.
    /// </summary>
    public string Postfix { get; set; }

    /// <summary>
    /// Attached to the beginning of the fForm of an MoForm which belongs to this MoMorphType for display purposes (??). Typically, this will be a dash for suffixes, infixes and perhaps enclitics. 
    /// </summary>
    public string Prefix { get; set; }

    /// <summary>
    /// Determines sorting when there are homographic forms that are of different morph types. For example what order does in, in-, -in, in= and =in and -in- appear IN the dictionary. 
    /// </summary>
    public int SecondaryOrder { get; set; }

}

[Table("MoReferralRule")]
public class LfMoReferralRule : LfObject
{
    /// <summary>
    /// a multiUnicode string. Not used in any algorithms, but people like to name things. Maybe we want an abbreviation (for displays), too?
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    /// <summary>
    /// multilingual string, containing the user's description/ explanation of this rule.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// owns an FsFeatStruc, constituting the morphosyntactic feature values which must be present in a word in order for this Rule of Referral to apply.
    /// Often these features form an 'environment' which is not altered in the Output. However, this is true only if the input features are disjunctive with the output features. For instance, suppose in some language the nominative plural of nouns is syncretic with the nominative singular. Assuming singular and plural are the two possible values of 'number' in this language, this syncretism can be represented by a rule which has as input [case: nominative] and as output [number: singular]. But it is not always possible to make the input and output features disjunctive, particularly (but not only) where features are non-binary. For example, if the above syncretism held in a language which distinguished dual number, and the nominative dual was distinct from the singular (and plural) nominative forms, then it would be necessary to mention the 'number' feature both in the input and in the output, to prevent the rule from overapplying to the dual. It might be possible (and desirable) to have a view of rules of referral in which the input features which are unaffected in the output are distinguished (as a sort of environment) from the input features which are changed in the output.
    /// Additional notes: In Stump's (1993a, (11) page 457) format for a Rule of Referral, this corresponds to τ on the left-hand side.
    /// </summary>
    public Guid InputGuid { get; set; }
    public LfFsFeatStruc Input { get; set; }

    /// <summary>
    /// Constitutes the morphosyntactic feature values which the Rule of Referral outputs.
    /// Additional notes: In Stump's (1993a, (11) page 457) format for a Rule of Referral, this corresponds to [F1:v1...Fm:Vm]. Note that the input and output fields may refer to the same features, albeit with different values. This is particularly likely for non-binary features (see Stump's rules (20) and (28), for example), but may also be necessary with binary features (e.g. Stump's rule (54b)). Accordingly, it would be possible to split the input features into a set of features whose values will be changed in the output, and a set of features which effectively form the environment for the change. This could even be done in the 'view' of the rule.
    /// </summary>
    public Guid OutputGuid { get; set; }
    public LfFsFeatStruc Output { get; set; }

}

[Table("MoForm")]
public class LfMoStemAllomorph : LfMoForm
{
    /// <summary>
    /// refers to a collection of PhEnvironment objects, describing what the phonetic environment of this allomorph is.
    /// The reason this is a collection attr (rather than atomic) is to allow for the situation during analysis before the user has managed to collapse what appear to be disparate environments into a single environment. (Note that the 'elsewhere' case can be represented by an empty environment under the assumption of disjunctive ordering.) Hence, a step in the stealth-to-wealth process will be to reduce the cardinality of this collection to one. A collection may of course also be useful for allomorphs which actually does appear in a disparate set of environments.
    /// For discussion of why this is a ref attribute, rather than an owning attribute, see MoMorphologicalData.PhoneEnvs.
    /// If this attribute is uninstantiated, there is no phonetic restriction on the environment.
    /// </summary>
    // M:N
    public List<LfPhEnvironment> PhoneEnv { get; set; }

    /// <summary>
    /// refers to a MoStemName. Ordinarily, only one allomorph of any given stem will bear a given stem name, but this may not be true if there are phonologically conditioned allomorphs as well. If this attribute is empty, this stem is used as the default stem for the paradigm.
    /// </summary>
    public Guid StemNameGuid { get; set; }
    public LfMoStemName StemName { get; set; }

}

[Table("LexAppendix")]
public class LfLexAppendix : LfObject
{
    public Guid ContentsGuid { get; set; }
    public LfStText Contents { get; set; }

}

[Table("MoStemName")]
public class LfMoStemName : LfObject
{
    /// <summary>
    /// a multiUnicode string, storing an abbreviated form of the Name. Probably useful for displays. Probably defaults to the first eight or so chars of the Name &#xA &#xD Another test.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbreviation { get; set; }

    /// <summary>
    /// multilingual string, containing the user' s description/ explanation of this stem (e.g. how it might be replaced by a suitable phonologically-based allomorphy condition, or why it cannot be so replaced).&#xA; Another test.&#xD; Another test.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// multiUnicode string; a convenient name, such as &apos 3-stem&apos (in Latin, cf. Aronoff 1992)
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    /// <summary>
    /// owns a collection of FsFeatStrucs. Conceptually, this is analogous to MoInflectionalAffixMsa.InflectionalFeatures, defining the parts of the paradigm that use this stem. However, unlike an inflectional affix, it is possible for a stem to have more than one FsFeatStruc and therefore pertain to more than one contiguous region of a paradigm, i.e. a stem need have no particular (or at least no consistent) semantics over and above the semantics of the lexeme it belongs to. (Again, see Aronoff 1992.) An example is the '1sg/subj' stem which for many Spanish verbs is used for the past subjunctive and the 1sg present indicative, such as teng- 'have'.
    /// In addition to being relevant to one or more regions of a paradigm, a stem may be relevant to derivational morphology. This is indicated in the model by referencing the MoStemName from the MoDerivationalAffixMsa.
    /// </summary>
    public List<LfFsFeatStruc> Regions { get; set; }

    /// <summary>
    /// refers to an inflectional affix (MoInflectionalAffixMsa) that is attached to the stem selected by the DefaultStem to give this stem, if the stem's lexical entry does not have an MoStemAllomorph with this stem name.
    /// If this attribute is empty, the default shape of this kind of stem is the same as that of the default stem; effectively, the stem is then formed by null affixation. The situation in which this attribute is empty is common in languages where some lexemes have a suppletive stem, but where the majority of lexemes use a regular stem without any special affixation. In Spanish, for instance, some verbs have an irregular stem used in the first person singular present indicative and in the present subjunctive, but for most verbs, the stem used in these regions of the paradigm is the same as that used elsewhere.
    /// Note that in the course of doing S2W morphology, the user might initially assign Spanish stem-changing and non-stem-changing verbs to different paradigms. Later, noticing that the only difference between the two paradigms is the stem change, he could collapse the two paradigms (as advocated in Carstairs 1987, chapter 6), retaining the special '1s present indicative/present subjunctive' form for the irregular verbs, and leaving the '1s present indicative/present subjunctive' form empty for regular verbs.
    /// While it would be nice to limit the possibilities for this attr to less than all the affixes in the lexical database, it is not clear that there is any way to do so.
    /// </summary>
    public Guid DefaultAffixGuid { get; set; }
    public LfMoInflAffMsa DefaultAffix { get; set; }

    /// <summary>
    /// refers to another MoStemName, which specifies the stem to be used (in conjunction with the DefaultAffix, if the latter is specified) if the stem's lexical entry does not list an MoStemAllomorph with this stem name. That is, if a lexeme does not have an irregular (listed) stem, this attribute specifies that some more regular stem will be used, either as a base (if there is a DefaultAffix) or by itself (if there is no DefaultAffix).
    /// If no DefaultStem is specified, then for any lexeme which does not explicitly list an (irregular) MoStemAllomorph with this stem name, the base for this MoStemName has the same form as the lexeme's (MoStemMsa's) DefaultStems. (The DefaultStems attr is a seq, allowing for phonological selection of one among several default stems; most often, the seq will contain a single stem.) Thus a regular stem for a given stem is constructed from the DefaultStem of that lexeme as specified by this MoStemName plus the DefaultAffix given by this MoStemName. This covers the common situation in which a relatively small subset of the words of a given paradigm have irregular forms, while the others have a stem based on the default stem with or without a stem-forming affix.
    /// Note that we can get into an infinite loop here, if any MoStemName calls for itself or (more likely) another MoStemName which (recursively) calls for the first MoStemName. This of course constitutes an error; fortunately, it should be easy to detect this situation.
    /// The possibilities for this attr are the StemNames of the PartOfSpeech which owns this MoStemName (not including this MoStemName).
    /// </summary>
    public Guid DefaultStemGuid { get; set; }
    public LfMoStemName DefaultStem { get; set; }

}

[Table("MoStratum")]
public class LfMoStratum : LfObject
{
    /// <summary>
    /// stores an abbreviated form of the Name. Probably useful for displays. Probably defaults to the first eight or so chars of the Name.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbreviation { get; set; }

    /// <summary>
    /// For the user's description/explanation of this stratum.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// Not used in any algorithms, but people like to name things...
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    /// <summary>
    /// refers to a PhPhonemeSet which provides the phonemes and boundary markers relevant to this stratum.
    /// In Hermit Crab, there were two attributes similar to this on strata: an InputLevelOfRepresentation, and an OutputLevelOfRepresentation. It was not clear that this bought anything that having different levels of representation in successive strata would not have bought.
    /// </summary>
    public Guid PhonemesGuid { get; set; }
    public LfPhPhonemeSet Phonemes { get; set; }

}

[Table("Possibility")]
public class LfPartOfSpeech : LfPossibility
{
    /// <summary>
    /// Owns a FsFeatStruc, representing (some of) the feature values inherently associated with this category (e.g. [+N +V]).
    /// Changed from InherentFeatureValues
    /// </summary>
    /// <remarks>
    /// vAllInherentFeatureValues: a virtual attribute, computing the combination of the inherent feature values of this category (InherentFeatureValues, above) and those of its parents. What 'combination' means is questionable: it could either be the unification of [my InherentFeatureValues, vAllInherentFeatureValues of my owner], in which case the inheritance hierarchy would be monotonic; or it could be the default unification of those values, where 'my InherentFeatureValues' would override any conflicting feature values inherited from the parents. Probably the latter is what is needed.
    /// </remarks>
    public Guid InherFeatValGuid { get; set; }
    public LfFsFeatStruc InherFeatVal { get; set; }

    /// <summary>
    /// owns a collection seq of FsFeatStruc, indicating the cells (feature-value combinations) which are disallowed in the paradigm. This is intended to account for defective paradigms, which are not common (e.g. deponent verbs in Greek, which are verbs that have no active forms). Since defective paradigms are relatively rare, this will probably be a seldom-used attribute. It is not intended to account for syncretism in the paradigm, i.e. the situation where one cell 'uses' the affixes of another cell (for which MoReferralRules are supplied instead, should disjunctive ordering of the affixes in an MoInflAffixSlot not suffice.).Since this attribute is defined at the level of the part of speech, it is not possible to define cells which are empty in only one inflection class. It is not obvious that this is correct, e.g. it is not obvious that deponent verbs in Greek belonged to a separate part of speech from other verbs. Pluralia tantum words like scissors and trousers are another example, since it is not clear that they belong to a separate part of speech from other nouns. Yet another example of a set of words that cannot plausibly be assigned to a separate category comes from Russian. Halle (1973: 7-8) says there are about a hundred verbs, all in a particular conjugation class, which lack first person singular non-past forms. It is unclear what the status of this gap is; it may be semantically or pragmatically based (some of the glosses are 'I conquer', 'I talk rudely', 'I behave foolishly'). According to Halle, "Russian grammar books frequently note that such forms… 'do not exist', or 'are not used', or 'are avoided'." Perhaps this is more of a sociolinguistic issue. Jensen (1990: 117-119) discusses some other defective paradigms, although he admits that his Latin examples are suspect: the defective paradigm is based on the corpus of Latin literature, and it may be that the corpus, not the paradigm, is defective. Jensen also lists as examples a few French verbs which lack certain forms: "cloré ['to close, enclose']… lacks the passé simple and the first and second persons plural of the present. Gésir ['to lie'] lacks all tenses but the present and imperfect indicative, and lacks the first and second persons singular of the present." He notes that synonyms supply the missing forms, so these gaps probably cannot be explained on semantic or pragmatic grounds. Jensen also gives as examples English modal verbs, which lack participle and 'infinitive' (to V) forms. In this case, the customary solution is to create a separate part of speech (modals), as a subclass of the category Verb.There are at least two verbs in English with defective paradigms: sight-see (*sight-sees, *sight-saw, sight-seen-but sight-seeing), and beware (which occurs only in this base form. Another puzzle with respect to defective paradigms, is the fact that while the singular of pluralia tantum words is ungrammatical in isolation, they are found in compounds: scissor-handle and trouser-leg. It is not clear how a defective distribution of certain elements of the paradigm should be handled. Matthews (1972a: 197, fn. 2) suggests that defective paradigms be handled in the syntax, although it is unclear how this would work.
    /// </summary>
    public List<LfFsFeatStruc> EmptyParadigmCells { get; set; }

    /// <summary>
    /// owns an ordered seq of MoReferralRule; used for statements like "the accusative plural of nouns is identical to the nominative plural" or "the accusative plural of second declension nouns is identical to the nominative plural'. (Note that rules of referral which are owned by the PartOfSpeech hold for all lexemes of that part of speech, regardless of inflection class; whereas rules of referral owned by an MoInflectionClass hold only for lexemes of that class. In Stump's (1993a) notation, the latter case corresponds to indicating a 'CLASS' for the Referral Rule.)I (MM) have defined this as an ordered seq, because in rare cases one referral rule might override another such rule. See the discussion of the similar RulesOfReferral attr in MoInflectionClass.
    /// </summary>
    /// <remarks>
    /// vAllRulesOfReferral: virtual attribute = [my RulesOfReferral, vAllRulesOfReferral of my owner].
    /// </remarks>
    public List<LfMoReferralRule> RulesOfReferral { get; set; }

    /// <summary>
    /// owns a collection seq of MoInflectionClasses, each of which is an inflection class (conjugation or declension class) immediately owned by this part of speech. This does not include sub-inflection classes of those classes, for which see vAllSubInflectionClasses; nor does it include any inflection classes defined on more abstract parts of speech, for which see vAllSuperInflectionClasses. See also vAllInflectionClasses.
    /// </summary>
    /// <remarks>
    /// vAllSuperInflectionClasses: a virtual attr = [vAllSubInflectionClasses of my owner, vAllSuperInflectionClasses of my owner]. This gives the inflection classes defined on super-categories of this part of speech. This does not include any inflection classes defined on this part of speech.vAllSubInflectionClasses: a virtual attr = [my InflectionClasses, vAllSubInflectionClasses of my InflectionClasses]. Note that this does not include any inflection classes belonging to sub-types of this part of speech. For example, the vAllSubInflectionClasses of 'verb' would not include any special inflection classes found with transitive verbs.vAllInflectionClasses: a virtual attr = [my vAllSuperInflectionClasses, my vAllSubInflectionClasses]. This includes all the inflection classes relevant to this part of speech.There is no provision here for overriding the inflection classes of a super-category, although this could probably be done by assigning the same name to two inflection classes, then taking the 'unique' over the names. But it's not clear that this would ever be necessary or desirable. It's not even clear that combining inherited and owned inflection classes is a good idea, but given that (1) we will certainly want parts of speech to be able to inherit inflection classes (so e.g. we can define inflection classes for verbs, and let transitive and intransitive verbs inherit it), and that (2) we must allow parts of speech to own inflection classes, it's not clear what else we could do.
    /// </remarks>
    public List<LfMoInflClass> InflectionClasses { get; set; }

    /// <summary>
    /// owns an ordered seq of MoInflAffixTemplates, which define how affixation (but not choice of stems) works for this part of speech. The reason this is an ordered sequence attribute, rather than atomic, is to allow the user to capture the fact that the number of slots can be different for different parts of the paradigm (infinitives, for example, or tenses which are partly inflected on the main verb and partly on an auxiliary verb). The order of templates in this attribute is relevant: the first MoInflAffixTemplates whose Region attr is a subset of the inflectional features to be realized on the word, is chosen.Note the assumption here that all the words belonging to a single part of speech have fundamentally the same paradigm (and therefore the same set of affix templates), and that differences are accounted by membership in distinct MoInflectionClasses (Carstairs 1987: 10-11, Carstairs-McCarthy 1998b: 324). The fact that in languages which mark the verb for agreement with both subject and object, transitive verbs have different paradigms from intransitive verbs (transitives usually have an additional slot for object marking-or for subject marking, in the case of ergative languages), might seem to be a counterexample. The reason that is not a counterexample, is that transitive and intransitive verbs can be treated as separate parts of speech using the inheritance hierarchy.
    /// </summary>
    public List<LfMoInflAffixTemplate> AffixTemplates { get; set; }

    /// <summary>
    /// owns a collection seq of MoInflAffixSlot, which may be referred to in MoInflAffixTemplates.The reason for having the ownership of Affix Slots reside here, rather than their being owned by the Affix Templates themselves, is to allow different Affix Templates to share Affix Slots. For example, suppose that in some language, both subject and object agreement are marked on the verb, and that the user has accordingly specified distinct parts of speech (and therefore distinct paradigms) for transitive and intransitive verbs. In all likelihood, most of the slots will be alike (tense and aspect marking, etc., and perhaps the subject agreement slot). The common affix slots can be shared if they are owned by the super-category verb (see the attribute vAllAffixSlots, below). Similarly, in Tzeltal nouns use the same prefixes for marking possessors as transitive verbs use for marking subjects. Assuming appropriate morphosyntactic features could be devised to represent the person of possessors and subject-of-transitives in Tzeltal, it would be nice to use the same MoInflAffixSlot for both. But this would be impossible, if the Affix Slots were owned by the Affix Templates (since nouns and verbs do not in general share those templates). It becomes possible if the Affix Slots are owned at some point in the part of speech inheritance hierarchy above noun and (transitive) verb, and referred to by the Affix Templates for these two categories.
    /// </summary>
    /// <remarks>
    /// vAllAffixSlots: virtual attribute = [my affixSlots, allAffixSlots of my owner]. While there is no explicit provision for a category to override an affix slot inherited from its owner, an affix slot is effectively overridden if it is not used. For example, in Tzeltal (as discussed above), nouns and transitive verbs use the same prefix slot, which could be modeled by placing the ownership of this prefix slot at a point in the category hierarchy above noun and transitive verb. Because the prefix slot is stored there, it would also be inherited by intransitive verbs, which do not mark person with prefixes. But the fact that intransitive verbs do not use that slot is captured by the fact that the affix template for intransitive verbs does not refer to the prefix slot.
    /// </remarks>
    public List<LfMoInflAffixSlot> AffixSlots { get; set; }

    /// <summary>
    /// owns a collection seq of MoStemNames, which define any non-default inflectional stems of the category (but not the default stem). For example, Aronoff (1992) discusses what he calls the '3-stem' of Latin verbs, a form which exists in all verb conjugations, and which is used as the base in a variety of places of the paradigm (which places are not identifiable on semantic or other grounds without using 'or'). The MoStemNames are interpreted as a disjunctively ordered list, i.e. in selecting a Stem for a given word, the list of StemNames is searched linearly, stopping at the first one for which one of its cells unifies with the FsFeatStruc of the word to be derived (see Choosing a Stem Allomorph). The order of the MoStemNames in this attribute is therefore important.If this attribute is empty, it defaults to the value of the same attribute in its owner. This allows e.g. defining a set of stem names for all verbs, and inheriting those names for subcategories of verb. It should probably be possible to block such inheritance without specifying any stem names, so there needs to be some specified value for that ('nil', say). An example might be modal verbs in English, which are presumably a subclass of verbs, but which lack certain forms.
    /// </summary>
    /// <remarks>
    /// vAllStemNames: a virtual attr gives all the stem names relevant for this part of speech. Defined like the following (see also discussion of this attr under MoInflectionClass.) [my StemNames, selectIf({|SN| not of includes(name of SN) over name of my StemNames}) of vAllStemNames of my owner]
    /// </remarks>
    public List<LfMoStemName> StemNames { get; set; }

    /// <summary>
    /// refers to a collection seq of FsFeatureDefn, each of which is a morphosyntactic feature which a word of this part of speech can bear. This is primarily intended for features which may be important to the derivational morphology, although these features may also be relevant to inflectional morphology. For example, the English suffix -ess is added only to animate nouns: waitress, lioness, actress, but *tabless, *officess; ?ful attaches to abstract nouns: graceful, useful, helpful, but *personful, *buildingful, *actorful.The notion of features that a given part of speech can bear is generally implicit in works on morphology, but see Lieber 1992: 90-91.
    /// </summary>
    /// <remarks>
    /// vAllBearableFeatures: a virtual attribute returning a seq of FsFeatureDefn, and defined as [my BearableFeatures, vAllBearableFeatures of my owner]. This allows the linguist to define for example a set of features which all verbs can bear, while adding an additional set of features which can be born by transitive verbs.
    /// </remarks>
    // M:N
    public List<LfFsFeatDefn> BearableFeatures { get; set; }

    /// <summary>
    /// refers to a collection seq of FsFeatureDefn, each of which is a morphosyntactic feature which a word of this part of speech is inflected for. Note that MoInflectionalAffixMsas may be sensitive to other features as well.
    /// Changed from InflectableFeatures
    /// </summary>
    /// <remarks>
    /// vAllInflectableFeatures: a virtual attribute returning a seq of FsFeatureDefn, and defined as [my InflectableFeatures, vAllInflectableFeatures of my owner]. This allows the linguist to define for example a set of features marked on all verbs (such as tense and subject person), while adding an additional set of features for transitive verbs (such as object person).vAllPossibleFeatures: a virtual attribute returning a seq of FsFeatureDefn, and defined as [my vAllBearableFeatures, my vAllInflectableFeatures].
    /// </remarks>
    // M:N
    public List<LfFsFeatDefn> InflectableFeats { get; set; }

    /// <summary>
    /// owns a collection seq of FsFeatStruc, each of which defines the cell whose inflection uniquely picks out an inflection class. (Cf. Carstairs-McCarthy 1991, particularly section 8). Usually, the reference forms belonging to a part of speech will suffice for all the MoInflectionClasses, i.e. a single "Primary Reference Form" (Carstairs-McCarthy's term). In some cases, however, it may prove necessary to provide a secondary reference form to distinguish among "mixed" classes (see again the discussion in Carstairs-McCarthy 1991.) Any secondary reference forms are provided in the attr of the same name of the particular MoInflectionClasses to which they pertain.Note that this attribute performs no particular function in any of the algorithms used for computing affixed forms. However, it may be useful in the context of a dictionary, e.g. for providing principal parts.
    /// </summary>
    /// <remarks>
    /// vAllReferenceForms: a virtual attr =[my ReferenceForms, vAllReferenceForms of my owner].
    /// </remarks>
    public List<LfFsFeatStruc> ReferenceForms { get; set; }

    /// <summary>
    /// A feature structure which specifies features that should be assumed in the absence of any inflectional affixes for the features defined. Example: In English, nouns are by default singular [num:sg].
    /// </summary>
    public Guid DefaultFeaturesGuid { get; set; }
    public LfFsFeatStruc DefaultFeatures { get; set; }

    /// <summary>
    /// refers to one of the classes in vAllInflectionClasses; defaults to the first MoInflectionClasses in vAllInflectionClasses (which would be the first class defined for this part of speech; this choice makes sense, i.e. the default is likely to be the largest inflection class, not a subclass of some class.) According to Wurzel (as described in Carstairs-McCarthy 1998b), the default class is the Inflection Class to which newly coined lexemes are usually assigned, to which lexemes from other classes 'drift' in the process of historical change, and the class to which children tend to assign lexemes before they learn the correct class. For our purposes, however, it may be simpler just to think of the default class as being the largest class numerically, i.e. the class to which words in the lexical database are assigned as a first guess.
    /// </summary>
    public Guid DefaultInflectionClassGuid { get; set; }
    public LfMoInflClass DefaultInflectionClass { get; set; }

    /// <summary>
    /// This property is used to store a unique key string indicating the reference for the part of speech from the Gold (or some other) master list.
    /// </summary>
    public string CatalogSourceId { get; set; }

}

[Table("ReversalIndex")]
public class LfReversalIndex : LfMajorObject
{
    public Guid PartsOfSpeechGuid { get; set; }
    public LfPossibilityList PartsOfSpeech { get; set; }

    public List<LfReversalIndexEntry> Entries { get; set; }

    public string WritingSystem { get; set; }

}

[Table("ReversalIndexEntry")]
public class LfReversalIndexEntry : LfObject
{
    public List<LfReversalIndexEntry> Subentries { get; set; }

    public Guid PartOfSpeechGuid { get; set; }
    public LfPartOfSpeech PartOfSpeech { get; set; }

    /// <summary>
    /// This property contains the index entry forms. The primary form is in the ReversalIndex_WritingSystem. Other acceptable writing systems are ones that are the same language as the primary form (the IcuLocal is identical up to the first _).
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> ReversalForm { get; set; }

    // M:N
    public List<LfLexSense> Senses { get; set; }

}

[Table("Text")]
public class LfText : LfMajorObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Source { get; set; }

    public Guid ContentsGuid { get; set; }
    public LfStText Contents { get; set; }

    /// <summary>
    /// This associates a text with any number of genres.
    /// </summary>
    // M:N
    public List<LfPossibility> Genres { get; set; }

    /// <summary>
    /// This abbreviation is used when referencing segments from the text.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbreviation { get; set; }

    /// <summary>
    /// The user will set this for texts that have translated material as opposed to original texts.
    /// </summary>
    public Boolean IsTranslated { get; set; }

    /// <summary>
    /// A container for media files which are associated with this text, and possibly referenced by segments in the text.
    /// </summary>
    public Guid MediaFilesGuid { get; set; }
    public LfMediaContainer MediaFiles { get; set; }

}

[Table("WfiAnalysis")]
public class LfWfiAnalysis : LfObject
{
    public Guid CategoryGuid { get; set; }
    public LfPartOfSpeech Category { get; set; }

    /// <summary>
    /// WfiAnalysis parallels MorphoSyntacticItem in the lexical database. Allowing MSFeatures here allows the user to easily convert a wordform to a subentry. This also supports S2W in that a user may know the features that a wordform bears but not its component parts (e.g may know that it's plural without knowing what the plural morpheme is). Additionally, in the case of suppletion, there may not be a morpheme to identify.
    /// </summary>
    public Guid MsFeaturesGuid { get; set; }
    public LfFsFeatStruc MsFeatures { get; set; }

    /// <summary>
    /// In a thorough analysis this attribute will not be used. However, if the linguist wishes to only analyze stems this is an easy way to accomplish this.
    /// </summary>
    // M:N
    public List<LfLexEntry> Stems { get; set; }

    public Guid DerivationGuid { get; set; }
    public LfMoDeriv Derivation { get; set; }

    public List<LfWfiGloss> Meanings { get; set; }

    public List<LfWfiMorphBundle> MorphBundles { get; set; }

    /// <summary>
    /// Allows Morph Sketch Generator to extract example wordforms where a compound rule applied.
    /// </summary>
    // M:N
    public List<LfMoCompoundRule> CompoundRuleApps { get; set; }

    /// <summary>
    /// Allows Morph Sketch Generator to extract example wordforms where an inflectional template is used.
    /// Changed from InflectionalTemplateApps.
    /// </summary>
    // M:N
    public List<LfMoInflAffixTemplate> InflTemplateApps { get; set; }

    /// <summary>
    /// Refers to either the Approves or Disapproves evaluations of various agents to indicate that the agent does or does not approve this analysis.
    /// </summary>
    // M:N
    public List<LfAgentEvaluation> Evaluations { get; set; }

}

[Table("WfiGloss")]
public class LfWfiGloss : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Form { get; set; }

}

[Table("WfiWordform")]
public class LfWfiWordform : LfObject
{
    /// <summary>
    /// The form of the word. This is multiUnicode in order to allow the user to encode the wordform in more than one encoding (for example, in Japanese a word can be encoded in Kanji, Hiragana, Katakana or Romanji).
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Form { get; set; }

    public List<LfWfiAnalysis> Analyses { get; set; }

    /// <summary>
    /// The current status of a wordform (e.g. undecided, correct, incorrect). This will be used to display and allow the changing of a word's status in the concordance view of the translation editor.
    /// </summary>
    public int SpellingStatus { get; set; }

    /// <summary>
    /// We calculate a checksum based on the result string returned from the parser. If this value has changed from the last time, we file the new results. Otherwise, we leave the results alone.
    /// </summary>
    public int Checksum { get; set; }

}

[Table("WordFormLookup")]
public class LfWordFormLookup : LfObject
{
    public String Form { get; set; }

    public int ThesaurusCentral { get; set; }

    // M:N
    public List<LfPossibility> ThesaurusItems { get; set; }

    public int AnthroCentral { get; set; }

    // M:N
    public List<LfAnthroItem> AnthroCodes { get; set; }

}

[Table("WordformLookupList")]
public class LfWordformLookupList : LfMajorObject
{
    public List<LfWordFormLookup> Wordforms { get; set; }

    public string WritingSystem { get; set; }

}

[Table("MoRuleMapping")]
public abstract class LfMoRuleMapping : LfObject
{
}

[Table("MoRuleMapping")]
public class LfMoInsertPhones : LfMoRuleMapping
{
    /// <summary>
    /// refers to an ordered seq of PhPhonemes and/or PhBdryMarkers (thus the signature is the superclass PhTerminalUnit).
    /// </summary>
    // M:N
    public List<LfPhTerminalUnit> Content { get; set; }

}

[Table("MoRuleMapping")]
public class LfMoInsertNC : LfMoRuleMapping
{
    /// <summary>
    /// refers to a PhNaturalClass to be added into the output at this position.
    /// </summary>
    public Guid ContentGuid { get; set; }
    public LfPhNaturalClass Content { get; set; }

}

[Table("MoRuleMapping")]
public class LfMoModifyFromInput : LfMoRuleMapping
{
    /// <summary>
    /// refers to a PhContextOrVar from the input of the MoAffixProcess owning this object; the meaning is that the stretch of the input word matched by that PhContextOrVar is copied over to the output, but modified in accordance with the modification attribute. Typically, this will be a single phoneme, which is modified by the addition of one or two features (e.g. by being palatalized).
    /// </summary>
    public Guid ContentGuid { get; set; }
    public LfPhContextOrVar Content { get; set; }

    /// <summary>
    /// refers to an PhNCFeatures object, specifying the features to be added to the phonemes matched by the content to give a portion of the output.
    /// </summary>
    public Guid ModificationGuid { get; set; }
    public LfPhNCFeatures Modification { get; set; }

}

[Table("MoDerivTrace")]
public abstract class LfMoDerivTrace : LfObject
{
    /// <summary>
    /// owns a string in the encoding of this level, representing the form resulting from attaching an affix, applying an inflectional affix slot, or applying a phonological rule. However, this attr is overridden, and defined as a virtual attr, in the classes MoStratumApp and MoAffixTemplateApp.
    /// The parallel attr for output morphosyntactic properties is defined in the subclasses, because some of those subclasses change the morphosyntactic properties of the word (derivational affixes), some do not (inflectional affixes and templates, and phonological rules), while for strata application, the output MSA is the output MSA of the last trace object it owns.
    /// </summary>
    /// <remarks>
    /// The parallel attr for output morphosyntactic properties is defined in the subclasses, because some of those subclasses change the morphosyntactic properties of the word (derivational affixes), some do not (inflectional affixes and templates, and phonological rules), while for strata application, the output MSA is the output MSA of the last trace object it owns.
    /// </remarks>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> OutputForm { get; set; }

}

[Table("MoDerivTrace")]
public class LfMoCompoundRuleApp : LfMoDerivTrace
{
    /// <summary>
    /// LeftForm: refers to a form (Wordform? MoStemAllomorph?), that of the left-hand member of the compound.
    /// </summary>
    public Guid LeftFormGuid { get; set; }
    public LfMoStemAllomorph LeftForm { get; set; }

    /// <summary>
    /// RightForm: refers to a form (Wordform? MoStemAllomorph?), that of the right-hand member of the compound.
    /// </summary>
    public Guid RightFormGuid { get; set; }
    public LfMoStemAllomorph RightForm { get; set; }

    /// <summary>
    /// refers to an MoAffixAllomorph, that of the linker between the two parts of the compound. If there is no linker, this attr is none.
    /// </summary>
    public Guid LinkerGuid { get; set; }
    public LfMoAffixAllomorph Linker { get; set; }

}

[Table("MoDerivTrace")]
public class LfMoDerivAffApp : LfMoDerivTrace
{
    /// <summary>
    /// refers to the MoAffixAllomorph, giving the phonetic form of the affix.
    /// </summary>
    public Guid AffixFormGuid { get; set; }
    public LfMoAffixAllomorph AffixForm { get; set; }

    /// <summary>
    /// refers to an MoDerivationalAffixMsa, giving the morphosyntactic information about the affix.
    /// </summary>
    public Guid AffixMsaGuid { get; set; }
    public LfMoDerivAffMsa AffixMsa { get; set; }

    /// <summary>
    /// owns an MoDerivationalStepMsa, giving the morphosyntactic information resulting from attaching the derivational affix.
    /// </summary>
    public Guid OutputMsaGuid { get; set; }
    public LfMoDerivStepMsa OutputMsa { get; set; }

}

[Table("MoDerivTrace")]
public class LfMoInflAffixSlotApp : LfMoDerivTrace
{
    /// <summary>
    /// refers to an MoInflAffixSlot in the MoInflAffixTemplate pointed to by the Template attr of my owner.
    /// </summary>
    public Guid SlotGuid { get; set; }
    public LfMoInflAffixSlot Slot { get; set; }

    /// <summary>
    /// refers to an MoAffixForm, the allomorph of the inflectional affix which was attached.
    /// If the application of this slot results in an implicit zero affix (because none of the MoInflectionalAffixMsas belonging to this MoInflAffixSlot matched the InflectionalFeatures of the owning MoDerivation), this AffixForm will be none.
    /// </summary>
    public Guid AffixFormGuid { get; set; }
    public LfMoAffixForm AffixForm { get; set; }

    /// <summary>
    /// refers to an MoInflectonalAffixMsa, the inflectional affix which was attached. Note that this MSA does not result in any change to the MSA of the word.
    /// As with the AffixForm attr, if the application of this slot results in an implicit zero affix (because none of the MoInflectionalAffixMsas belonging to this MoInflAffixSlot matched the InflectionalFeatures of the owning MoDerivation), this AffixMsa attr will be none.
    /// </summary>
    public Guid AffixMsaGuid { get; set; }
    public LfMoInflAffMsa AffixMsa { get; set; }

}

[Table("MoDerivTrace")]
public class LfMoInflTemplateApp : LfMoDerivTrace
{
    /// <summary>
    /// refers to the MoInflAffixTemplate whose application this trace structure represents.
    /// </summary>
    public Guid TemplateGuid { get; set; }
    public LfMoInflAffixTemplate Template { get; set; }

    /// <summary>
    /// owns an ordered seq of MoInflAffixSlotApps, representing the sequence of inflectional affix slots belonging to this template that were applied in the derivation.
    /// An alternative to having this attr and a separate class for slot applications, would be to have an attr here for inflectional affix applications themselves, bypassing the "middleman." The distinction between slot applications and the attachment of a particular affix belonging to a slot is that if no affix in a particular slot applies, the effect is that of an implicit zero affix. Under this alternative, there would thus be no indication that the slot in question had been tried. It seems better to have this attr record the slot applications, on the assumption that one wants to know if there was an implicit zero affix.
    /// I have defined this as an ordered seq, but it would be possible to derive the ordering from the order of the MoInflAffixSlots in the Slots attr of the MoInflAffixTemplate of this template application. However, this would not work if the user had changed the order of slots since this derivation was created.
    /// </summary>
    public List<LfMoInflAffixSlotApp> SlotApps { get; set; }

}

[Table("MoDerivTrace")]
public class LfMoPhonolRuleApp : LfMoDerivTrace
{
    /// <summary>
    /// refers to the phonological rule (class to be defined) whose application this trace structure represents
    /// </summary>
    public Guid RuleGuid { get; set; }
    public LfObject Rule { get; set; }

    /// <summary>
    /// Boolean; true means the rule applied vacuously, false means it made some change to the phonetic form to which it applied. The point of having this attr is for display purposes: it allows the user to quickly tell whether a rule made a change to its input.
    /// This could be defined either as an owning attr or as a virtual attr (the latter would test for equality of the vInputForm and OutputForm attrs).
    /// The alternative to having this attr would be to use a special mark in the OutputForm of this class (see definition of this attr in MoDerivationTrace) when a phonological rule applies vacuously. But that wouldn’t work if another MoDerivationTrace’s InputForm needs to refer to the OutputForm of this rule application.
    /// </summary>
    /// <remarks>
    /// This could be defined either as an owning attr or as a virtual attr (the latter would test for equality of the vInputForm and outputForm attrs).The alternative to having this attr would be to use a special mark in the outputForm of this class (see definition of this attr in MoDerivationTrace) when a phonological rule applies vacuously. But that wouldn't work if another MoDerivationTrace's inputForm needs to refer to the outputForm of this rule application.
    /// </remarks>
    public Boolean VacuousApp { get; set; }

}

[Table("MoDerivTrace")]
public class LfMoStratumApp : LfMoDerivTrace
{
    /// <summary>
    /// refers to the MoStratum whose application this trace structure represents.
    /// </summary>
    public Guid StratumGuid { get; set; }
    public LfMoStratum Stratum { get; set; }

    /// <summary>
    /// owns an ordered seq of MoCompoundRuleApp, representing the application of compound rules belonging to this stratum. The order is the order of application in derivation (which may be the reverse of the order in parsing).
    /// </summary>
    public List<LfMoCompoundRuleApp> CompoundRuleApps { get; set; }

    /// <summary>
    /// Owns an ordered seq of MoDerivationalAffixApp, representing the attachment of derivational affixes belonging to this stratum. The order is the order of application in derivation (which may be the reverse of the order in parsing).
    /// Changed from DerivationalAffixApps.
    /// </summary>
    public List<LfMoDerivAffApp> DerivAffApp { get; set; }

    /// <summary>
    /// owns an MoInflAffixTemplateApp, representing the application of an MoInflAffixTemplate belonging to this stratum and matching the InflectionClass of the MoStemMsa at the point of application.
    /// </summary>
    public Guid TemplateAppGuid { get; set; }
    public LfMoInflTemplateApp TemplateApp { get; set; }

    /// <summary>
    /// owns an ordered seq of MoPhonolRuleApp, representing the application of the phonological rules of this stratum. Note that the fact that this attr belongs to the MoStratumApp precludes modeling cyclic application. That restriction could easily be lifted. The order is the order of application in derivation (which may be the reverse of the order in parsing).
    /// </summary>
    public List<LfMoPhonolRuleApp> PRuleApps { get; set; }

}

[Table("PhContextOrVar")]
public abstract class LfPhContextOrVar : LfObject
{
}

[Table("PhContextOrVar")]
public abstract class LfPhPhonContext : LfPhContextOrVar
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    public Guid DescriptionGuid { get; set; }
    public LfStText Description { get; set; }

}

[Table("PhContextOrVar")]
public class LfPhIterationContext : LfPhPhonContext
{
    /// <summary>
    /// an Integer (defaults to zero)
    /// </summary>
    public int Minimum { get; set; }

    /// <summary>
    /// an Integer (defaults to infinite; note that there needs to be a way to display and set a value of " infinity" )
    /// </summary>
    public int Maximum { get; set; }

    /// <summary>
    /// a PhPhonologicalContext (but not normally another PhIterationContext)
    /// </summary>
    public Guid MemberGuid { get; set; }
    public LfPhPhonContext Member { get; set; }

}

[Table("PhContextOrVar")]
public class LfPhSequenceContext : LfPhPhonContext
{
    /// <summary>
    /// an ordered seq of PhPhonologicalContext (but not normally another PhSequenceContext)
    /// </summary>
    // M:N
    public List<LfPhPhonContext> Members { get; set; }

}

[Table("PhContextOrVar")]
public abstract class LfPhSimpleContext : LfPhPhonContext
{
}

[Table("PhContextOrVar")]
public class LfPhSimpleContextBdry : LfPhSimpleContext
{
    public Guid FeatureStructureGuid { get; set; }
    public LfPhBdryMarker FeatureStructure { get; set; }

}

[Table("PhContextOrVar")]
public class LfPhSimpleContextNC : LfPhSimpleContext
{
    public Guid FeatureStructureGuid { get; set; }
    public LfPhNaturalClass FeatureStructure { get; set; }

    /// <summary>
    /// Refers to a collection seq of PhFeatureConstraint. The use of a plusConstraint only makes sense if there are two or more contexts in a rule that make use of the same constraint. If two such constraints occur in the environment of the rule (treating the input as part of the environment), then the feature referred to by the constraint is required to have the same value in every place where the word matches the pattern. For example, if a plusConstraint for the feature voiced appears on two adjacent consonant contexts in a rule, then the word being matched must have two adjacent consonants with identical voicing. If one of the constraints is in the environment and one in the output of the rule, then the effect is that of a rule of assimilation: in the form output by the rule, the phoneme affected by the rule will have the same value as the value on the phoneme matched by the environment.This attribute is not intended to be implemented immediately, but is included here for completeness (since it is apparently difficult to add new attributes once a COM interface has been defined).Note that although this attr is defined as a collection seq (not an ordered seq), the order is assumed to be stable. Otherwise the labels used in SPE-style rules would be subject to change. On the other hand, the use of a seq attr here may be overkill; from a linguistic standpoint, a single constraint (plus or minus) might be adequate.
    /// Renamed from PlusConstraints for the Firebird port.
    /// </summary>
    // M:N
    public List<LfPhFeatureConstraint> PlusConstr { get; set; }

    /// <summary>
    /// refers to a collection seq of PhFeatureConstraints; see discussion under the plusConstraints attr. A feature in question is required to have opposite value from a plusConstraint elsewhere in the rule, and thus makes sense only if a constraint with the same value appears elsewhere in the rule.See implementation comments under plusConstraints.
    /// Changed from MinusConstraints for the Firebird Port.
    /// </summary>
    // M:N
    public List<LfPhFeatureConstraint> MinusConstr { get; set; }

}

[Table("PhContextOrVar")]
public class LfPhSimpleContextSeg : LfPhSimpleContext
{
    /// <summary>
    /// Allows the user to write phonological rules that are sensitive to a particular phoneme (as opposed to a class of phonemes).
    /// </summary>
    public Guid FeatureStructureGuid { get; set; }
    public LfPhPhoneme FeatureStructure { get; set; }

}

[Table("PhContextOrVar")]
public class LfPhVariable : LfPhContextOrVar
{
}

[Table("PhPhonemeSet")]
public class LfPhPhonemeSet : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    /// <summary>
    /// collection seq of PhPhoneme.
    /// </summary>
    public List<LfPhPhoneme> Phonemes { get; set; }

    /// <summary>
    /// collection seq of PhBdryMarker
    /// </summary>
    public List<LfPhBdryMarker> BoundaryMarkers { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

}

[Table("PhTerminalUnit")]
public abstract class LfPhTerminalUnit : LfObject
{
    /// <summary>
    /// a string, often a single character or a single base character plus some diacritics.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// a collection of PhCodes (which amounts to a seq of strings), each in a single encoding (but not perhaps all in the same encoding). Each string is a representation of the phoneme or boundary marker in that encoding.
    /// </summary>
    /// <remarks>
    /// There is not guaranteed to be a unique representation of a phoneme in a single encoding. For example, in Spanish the strings 'c' (in certain contexts), 'qu', and 'k' (in a handful of words) represent the /k/ phoneme. One implication of this is that the translation from phoneme to string will not be unique: the translation may be context sensitive, as in Spanish, or it could be indeterminate, as in English orthography. A work-around for the situation in which the translation is context-sensitive, is to treat the two strings as if they were two different phonemes (which will both happen to belong to the same natural classes, i.e. PhNCSegments). Capitalization provides another example of this problem, since a single phoneme will be represented by both upper- and lower-case letters.Likewise, there is not guaranteed to be a unique phoneme for a given string. There are at least two ways this form of uniqueness might be violated. First, a single string might stand for two or more phonemes, depending on the context. For example, in (Latin American) Spanish the string 'c' represents the phoneme /s/ before a front vowel, and the phoneme /k/ elsewhere. Second, a sequence of letters might be ambiguous in terms of its division into strings representing phonemes. For example, in English the letters 'sh' can represent a single phonological unit, as in the word 'ship'; or they may represent two units, as in 'mishap'.Provided the departures from biuniqueness are predictable (as in Spanish, but not in English), it is possible to provide a fairly simple translator between the two representations (a finite state transducer, for example). Conceptually, it would handle simple rewrite rules like the following:'c' /s/ / __ i, e /k/ / __'qu' /k/ __ i, e'z' /s/ I have not specified in these examples whether the symbols in the environments are phonemes or strings. Note that it is necessary to define the positions in which 'qu' represents /k/ (or alternatively, where 'c' represents /k/), in order to preserve biuniqueness. (Otherwise, the translation of /k/ would be ambiguous.) The translation between /s/ and 'z', on the other hand, does not require that an environment be stated. The general guideline is that there can be only one 'elsewhere' case for each translation, in both directions.Concerning the translation between phonemes and strings, see also http://intranet.sil.org/softwaredev/Projects/CELLARII/Design/ConceptualModel/Encodings/CLR2_EncodingRequirements.html - RcmEnc5.3. (This document is dated 27 January, 1998. Is there a more recent document that covers this?)
    /// </remarks>
    public List<LfPhCode> Codes { get; set; }

}

[Table("PhTerminalUnit")]
public class LfPhBdryMarker : LfPhTerminalUnit
{
}

[Table("PhTerminalUnit")]
public class LfPhPhoneme : LfPhTerminalUnit
{
    /// <summary>
    /// This is the IPA symbol for the basic phonetic form of this phoneme. 
    /// We use it to produce a first guess at the phonological features and the (English) description of this phoneme. 
    /// We also show it in the Grammar Sketch.
    /// </summary>
    public String BasicIPASymbol { get; set; }

    /// <summary>
    /// The Features attribute is how the user provides the phonological features of a phoneme (phonological segment).
    /// This means that the features contained in the FsFeatStruc must be from LangProject:PhFeatureSystem.
    /// </summary>
    public Guid FeaturesGuid { get; set; }
    public LfFsFeatStruc Features { get; set; }

}

[Table("PhNaturalClass")]
public abstract class LfPhNaturalClass : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbreviation { get; set; }

}

[Table("PhNaturalClass")]
public class LfPhNCFeatures : LfPhNaturalClass
{
    /// <summary>
    /// owns an FsFeatStruc, specifying the feature values which characterize this natural class. The meaning is that any phoneme which includes (N.B.: not unifies with) the specified feature values matches this natural class.
    /// </summary>
    /// <remarks>
    /// vSegments: a virtual attr returning a collection seq of PhPhoneme which are picked out by the features of this natural class.
    /// </remarks>
    public Guid FeaturesGuid { get; set; }
    public LfFsFeatStruc Features { get; set; }

}

[Table("PhNaturalClass")]
public class LfPhNCSegments : LfPhNaturalClass
{
    /// <summary>
    /// refers to a collection seq of PhPhoneme, which are interpreted as the members of this class.
    /// </summary>
    // M:N
    public List<LfPhPhoneme> Segments { get; set; }

}

[Table("PhFeatureConstraint")]
public class LfPhFeatureConstraint : LfObject
{
    /// <summary>
    /// refers to an FsFeatureDefnPhFeatureNode, the feature with respect to which the constraint ensures agreement (or disagreement).The use of an atomic attr, rather than a seq attr, emulates to a certain extent the insight of autosegmental phonology and feature geometry that a rule can change (or refer to in the environment) only a single feature node. Note however that the fact that the feature can be a nonterminal feature (an FsComplexFeature), allows agreement with respect to a number of features dominated by a single node (e.g. a place of articulation feature, which might dominate the features labial, coronal, and back).
    /// </summary>
    public Guid FeatureGuid { get; set; }
    public LfFsFeatDefn Feature { get; set; }

}

[Table("PhEnvironment")]
public class LfPhEnvironment : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    public Guid LeftContextGuid { get; set; }
    public LfPhPhonContext LeftContext { get; set; }

    public Guid RightContextGuid { get; set; }
    public LfPhPhonContext RightContext { get; set; }

    /// <summary>
    /// This is for storing AMPLE and Shoebox (converted to AMPLE) info about phonetic environments. This will probably be eventually deleted when we decide what to do with Shoebox/AMPLE import and relationship to the LexEntry legacy information.
    /// </summary>
    public string AMPLEStringSegment { get; set; }

    /// <summary>
    /// This simple string representation of the phonetic environment is parsed by specialized field editor for use by AMPLE. For Phase 1 implementation. Phase 2 will use Left and Right contexts.
    /// </summary>
    public String StringRepresentation { get; set; }

}

[Table("PhCode")]
public class LfPhCode : LfObject
{
    /// <summary>
    /// Put something here. 
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Representation { get; set; }

}

[Table("PhPhonData")]
public class LfPhPhonData : LfObject
{
    /// <summary>
    /// owns a collection of PhPhonemeSets, describing the phonemic inventory of the language. The reason for allowing this to be a collection (rather than atomic) is to allow for phonological descriptions at multiple levels (strata),
    /// </summary>
    public List<LfPhPhonemeSet> PhonemeSets { get; set; }

    public List<LfPhEnvironment> Environments { get; set; }

    /// <summary>
    /// Change this here.
    /// </summary>
    public List<LfPhNaturalClass> NaturalClasses { get; set; }

    /// <summary>
    /// Change this here.
    /// </summary>
    public List<LfPhContextOrVar> Contexts { get; set; }

    /// <summary>
    /// The feature constraints are what allow us to use alpha notation in phonological rules (to deal with things like assimilation to place of articulation).
    /// It is a sequence so we can know the alpha value (is it alpha, beta, gamma, or delta, say).
    /// The user need never see these as a list to be edited or maintained by hand.
    /// The UI can show them as greek letters in phonological rule displays.
    /// </summary>
    public List<LfPhFeatureConstraint> FeatConstraints { get; set; }

    /// <summary>
    /// The rule features are a way to limit the application of rules, either by excluding or requiring these "features."
    /// The CmPossibilityList contains zero or more PhPhonRuleFeat classes.
    /// These refer to a CmObject, where that CmObject would probably be a MoInflClass (e.g. a conjugation class), an FsSymFeatVal (e.g. feminine gender), or a CmPossibility (for an exception "feature").
    /// </summary>
    public Guid PhonRuleFeatsGuid { get; set; }
    public LfPossibilityList PhonRuleFeats { get; set; }

    /// <summary>
    /// These are the ordered sequence of phonological rules. They are given in the order in which they are to be applied.
    /// </summary>
    public List<LfPhSegmentRule> PhonRules { get; set; }

}

[Table("MoDeriv")]
public class LfMoDeriv : LfObject
{
    /// <summary>
    /// refers to an MoStemAllomorph, a stem found in the lexicon.
    /// </summary>
    /// <remarks>
    /// MM: [Previously, I had called this attr pInputForm. I changed the attr name to draw attention to the fact that this is just the stem, not any affixes.]
    /// </remarks>
    public Guid StemFormGuid { get; set; }
    public LfMoStemAllomorph StemForm { get; set; }

    /// <summary>
    /// refers to an MoStemMsa, a stem found in the lexicon. Note that this object and the allomorph pointed to by the StemForm must belong to the same LexEntry.
    /// </summary>
    /// <remarks>
    /// MM: Previously, I had called this attr pInputMsa; see discussion of pStemForm above.
    /// </remarks>
    public Guid StemMsaGuid { get; set; }
    public LfMoStemMsa StemMsa { get; set; }

    /// <summary>
    /// Owns (but see below) an FsFeatStruc giving the inflectional features (to be) realized in this derivation.
    /// It is not clear whether this should be an owning or virtual attr. If derivations are always owned by some higher object that could logically hold such a feature structure (e.g. a test case or a cell in a paradigm), then this attr should just return that feature structure.
    /// Changed from InflectionalFeatures.
    /// </summary>
    public Guid InflectionalFeatsGuid { get; set; }
    public LfFsFeatStruc InflectionalFeats { get; set; }

    /// <summary>
    /// owns an ordered seq of MoStratumApp structures, representing the sequence of applications of strata (i.e. of the affixes and phonological rules of those strata) to an underlying form. The order is from the deepest stratum to the shallowest.
    /// </summary>
    public List<LfMoStratumApp> StratumApps { get; set; }

}

[Table("MoAdhocProhib")]
public class LfMoAlloAdhocProhib : LfMoAdhocProhib
{
    /// <summary>
    /// refers to a seq of MoForm objects, the co-occurrence of which is ungrammatical. Usually, there will be exactly two such allomorphs. If there are three or more allomorphs, the intended meaning is that a word is ungrammatical in which all such morphemes appear (but the co-occurrence of only some of the morphemes is not prohibited). Having only one morpheme in this attribute should be flagged as a Warning, since such a restriction can do nothing.
    /// When the Adjacency attribute is 'Anywhere', the fact that this attribute is a seq, rather than a collection, is unimportant. But the order of allomorphs becomes important when the Adjacency attribute has any other value. Specifically, the order of the allomorphs in this attribute is interpreted as a left-to-right order.
    /// </summary>
    // M:N
    public List<LfMoForm> Allomorphs { get; set; }

    public Guid FirstAllomorphGuid { get; set; }
    public LfMoForm FirstAllomorph { get; set; }

    /// <summary>
    /// Changed from RestOfAllomorphs.
    /// </summary>
    // M:N
    public List<LfMoForm> RestOfAllos { get; set; }

}

[Table("MoAdhocProhib")]
public class LfMoMorphAdhocProhib : LfMoAdhocProhib
{
    /// <summary>
    /// refers to a collection seq of MoMorphoSyntaxAnalysis objects, the co-occurrence of which is ungrammatical. Usually, there will be exactly two such morphemes. If there are three or more morphemes, the intended meaning is that a word is ungrammatical in which all such morphemes appear (but the co-occurrence of only some of the morphemes is not prohibited). Having only one morpheme in this attribute should be flagged as a Warning, since such a restriction can do nothing.
    /// Note: we are assuming here that the user interface cannot simply prohibit constraints with a single morpheme, because they arise in the process of creating a constraint. (You cannot count to two until you've counted to one.)
    /// </summary>
    // M:N
    public List<LfMoMorphSynAnalysis> Morphemes { get; set; }

    public Guid FirstMorphemeGuid { get; set; }
    public LfMoMorphSynAnalysis FirstMorpheme { get; set; }

    /// <summary>
    /// Changed from RestOfMorphemes.
    /// </summary>
    // M:N
    public List<LfMoMorphSynAnalysis> RestOfMorphs { get; set; }

}

[Table("MoRuleMapping")]
public class LfMoCopyFromInput : LfMoRuleMapping
{
    /// <summary>
    /// refers to a PhContextOrVar in MoAffixProcess.Input of the owner of this object; the meaning is that the stretch of the input word matched by that PhContextOrVar is copied over without alteration to the output.
    /// </summary>
    public Guid ContentGuid { get; set; }
    public LfPhContextOrVar Content { get; set; }

}

[Table("WfiWordSet")]
public class LfWfiWordSet : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    // M:N
    public List<LfWfiWordform> Cases { get; set; }

}

[Table("MoCompoundRule")]
public class LfMoBinaryCompoundRule : LfMoCompoundRule
{
    /// <summary>
    /// owns an MoStemMsa, giving the morphosyntactic information about the left-hand member of this compound. If this MoStemMsa specifies a PartOfSpeech, then the left-hand member of this compound must belong to that part of speech. If this MoStemMsa specifies an FsFeatStruc, then the left-hand member of this compound must have (not unify with!) the features of that feature structure.
    /// Since the parts of speech are contained in an inheritance hierarchy, a question arises: if this MSA points to an abstract part of speech (verb, say), does a word with a more specific part of speech (transitive verb, say) match? In the absence of any reason to think it does not, I would suggest that reference to an abstract part of speech entails that more specific parts of speech are included. Otherwise, it is hard to imagine how one could use this attribute - it would be necessary to allow a collection of parts of speech, or else to have separate compound rule for each specific part of speech.
    /// </summary>
    public Guid LeftMsaGuid { get; set; }
    public LfMoStemMsa LeftMsa { get; set; }

    /// <summary>
    /// owns an MoStemMsa, giving the morphosyntactic information about the right-hand member of this compound, in the same fashion as the LeftMsa attribute.
    /// </summary>
    public Guid RightMsaGuid { get; set; }
    public LfMoStemMsa RightMsa { get; set; }

    /// <summary>
    /// owns an MoAffixForm in the encoding of the language, giving the phoneme(s) inserted between the two parts of the compound (cf. Linguist List 10.1477, http://linguistlist.org/10/10-1477.html). If this field is empty, nothing is inserted between the two parts.
    /// The linker is semantically meaningless (else it would be a morpheme).
    /// </summary>
    public Guid LinkerGuid { get; set; }
    public LfMoAffixForm Linker { get; set; }

}

[Table("MoCompoundRule")]
public class LfMoCoordinateCompound : LfMoBinaryCompoundRule
{
}

[Table("MoGlossSystem")]
public class LfMoGlossSystem : LfObject
{
    public List<LfMoGlossItem> Glosses { get; set; }

}

[Table("MoGlossItem")]
public class LfMoGlossItem : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Abbreviation { get; set; }

    /// <summary>
    /// Types:
    /// 1. fsType The item corresponds to a feature structure type. 
    /// 2. feature The item corresponds to an inflectional feature. 
    /// 3. value The item corresponds to an inflectional feature value. 
    /// 4. complex The item corresponds to a complex feature that embeds another feature structure. 
    /// 5. deriv The item is the gloss for a derivational morpheme. 
    /// 6. group The item is in the list only for the purpose of organization and grouping 
    /// 7. xref The item is a cross-reference to the term that is used in preference to this one. 
    /// </summary>
    public int Type { get; set; }

    public string AfterSeparator { get; set; }

    /// <summary>
    /// separates the gloss for the feature name from the gloss string for the value bundle
    /// </summary>
    public string ComplexNameSeparator { get; set; }

    /// <summary>
    /// to control whether the name gloss precedes or follows the value bundle gloss. It should be possible to specify global defaults for these, as well as to override them for specific gloss items.
    /// </summary>
    public Boolean ComplexNameFirst { get; set; }

    /// <summary>
    /// Each top-level gloss item in the master gloss list needs a status attribute to indicate whether the subtree it dominates is visible or hidden. A hidden gloss item corresponds to a feature structure type that is only embedded as the value of complex features and so does not appear in the gloss possibilities chooser as a top-level choice but appears only in subtrees under complex features.
    /// </summary>
    public Boolean Status { get; set; }

    /// <summary>
    /// A gloss item in the language-specific gloss system is formalized by a feature structure fragment. The feature structure for a glossed morpheme is thus the unification of all the feature structure fragments for its component gloss items.
    /// When the user selects gloss items from the language-specific gloss system to form a composite gloss, this analysis is stored in the MSA as a gloss bundle (which an attribute on MSA that stores a set of references to all the selected gloss items). The language-specific feature structure for an MSA is automatically generated by computing the unification of all the feature structure fragments in the gloss bundle.
    /// Changed from FeatureStructureFragment.
    /// </summary>
    public Guid FeatStructFragGuid { get; set; }
    public LfFsFeatStruc FeatStructFrag { get; set; }

    public List<LfMoGlossItem> GlossItems { get; set; }

    /// <summary>
    /// Note also that this attribute has two different functions.
    /// 1. If a gloss item is a cross-reference, it needs a target attribute to point to a the preferred term in the master gloss list. A cross-reference item lists a term that the user would be looking for, but redirects the user to a standardized term elsewhere in the tree.
    /// 2. An additional status is added to indicate that a gloss item that has been copied into a subtree under a complex feature is a proxy for the original gloss item in the master gloss list. A proxy item uses the target attribute to point to its source item. No other attributes on a proxy item should be used since the values on the target item are its values. (The implementation might use term to store the "carried-down" suffix to the gloss string when carry is active.)
    /// visible The item is an original item that should be shown in the gloss chooser.
    /// hidden The item is an original item, but should not be shown in the gloss chooser.
    /// proxy The item should be shown in the gloss chooser, but it is a proxy standing in for an original item.
    /// </summary>
    public Guid TargetGuid { get; set; }
    public LfMoGlossItem Target { get; set; }

    /// <summary>
    /// Stores a reference to the XML ID of the Etic Gloss List. 
    /// </summary>
    public string EticID { get; set; }

}

[Table("MoAdhocProhib")]
public class LfMoAdhocProhibGr : LfMoAdhocProhib
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    public List<LfMoAdhocProhib> Members { get; set; }

}

[Table("WfiMorphBundle")]
public class LfWfiMorphBundle : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Form { get; set; }

    public Guid MorphGuid { get; set; }
    public LfMoForm Morph { get; set; }

    public Guid MsaGuid { get; set; }
    public LfMoMorphSynAnalysis Msa { get; set; }

    public Guid SenseGuid { get; set; }
    public LfLexSense Sense { get; set; }

    /// <summary>
    /// This will provide a place for both the manual interlinearizer and the parser filer to store the link to the gloss in the inflection type.
    /// It is optional in that we do not need to store it for every morpheme bundle, only those that need it.
    /// </summary>
    public Guid InflTypeGuid { get; set; }
    public LfLexEntryInflType InflType { get; set; }

}

[Table("LexEtymology")]
public class LfLexEtymology : LfObject
{
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Comment { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Form { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Gloss { get; set; }

    /// <summary>
    /// This will be a choice from the Languages list in the Lists area (list owned by LexDb).
    /// </summary>
    // M:N
    public List<LfPossibility> Language { get; set; }

    public string LiftResidue { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> PrecComment { get; set; }

    /// <summary>
    /// For the lexicographer, not intended for printing. For now, at least, this appears in the UI, but not in the dictionary configurations.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Note { get; set; }

    /// <summary>
    /// For the lexicographer, not intended for printing.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Bibliography { get; set; }

    /// <summary>
    /// Notes on the source language.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> LanguageNotes { get; set; }

}

[Table("ChkRef")]
public class LfChkRef : LfObject
{
    /// <summary>
    /// Index to a target text unit. For Scripture the BCV (book/chapter/verse) reference in the English versification.
    /// </summary>
    public int Ref { get; set; }

    /// <summary>
    /// In the Biblical Terms list, this will contain the specific Greek or Hebrew word(s) in the original text, though not necessarily the surface (i.e., inflected) form. This may be useful to display for the user. Together with the Ref and Location, this might be useful for associating existing ChkRef objects with ChkTerms in a list that is being restructured according to a new system of organization.
    /// </summary>
    public String KeyWord { get; set; }

    /// <summary>
    /// Checking status for this item (as defined by the reference-keyword).
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// The target vernacular rendering of the checking item at this reference.
    /// </summary>
    public Guid RenderingGuid { get; set; }
    public LfWfiWordform Rendering { get; set; }

    /// <summary>
    /// Information about the location of the ChkTerm in the original source text (for Scripture terms, the 1-based index of the word in the verse in the original language). Leave as 0 if not needed.
    /// </summary>
    public int Location { get; set; }

}

[Table("MoMorphSynAnalysis")]
public class LfMoUnclassifiedAffixMsa : LfMoMorphSynAnalysis
{
    public Guid PartOfSpeechGuid { get; set; }
    public LfPartOfSpeech PartOfSpeech { get; set; }

}

[Table("Possibility")]
public class LfLexEntryType : LfPossibility
{
    /// <summary>
    /// This abbreviation may be used in the minor/subentry when referring to the major entry. For example, LexEntryType_Abbreviation could have "var." and LexEntryType_ReverseAbbr could have "var. of" 
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> ReverseAbbr { get; set; }

    /// <summary>
    /// This name may be used in the minor/subentry when referring to the major entry. For example, LexEntryType_ReverseName could have "Dialectal Variant of" and LexEntryType_Name could have "Dialectal Variant" 
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> ReverseName { get; set; }

}

[Table("Possibility")]
public class LfLexRefType : LfPossibility
{
    /// <summary>
    /// This is used for the generic/whole abbreviation for trees.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> ReverseAbbreviation { get; set; }

    /// <summary>
    /// MappingType (max=127) (used as an enum) with possible values: 
    /// 0 = sense collection (unordered many to many) 
    /// 1 = sense pair (one to one) 
    /// 2 = sense tree (one to unordered many) 
    /// 3 = sense sequence (ordered many to many) 
    /// 4 = entry collection (unordered many to many) 
    /// 5 = entry pair (one to one) 
    /// 6 = entry tree (one to unordered many) 
    /// 7 = entry or sense collection (unordered many to many) 
    /// 8 = entry or sense tree (one to ordered many) 
    /// This enum determines the type of relation represented by the set. It basically determines how the software treats the items in LexReference_Targets. For 0-3 the button to the right would call up a sense chooser. For 4-6 it would call up an entry chooser. For 7-8 it would call up a chooser that allows either entries or senses. For all but 2, 6, and 8 the field label for all items would come from CmPossibility_Abbreviation. For 2, 6, and 8, the label for the first item would be CmPossibility_Abbreviation, while the label for the other items would be CmLexRefType_ReverseAbbreviation.
    /// </summary>
    public int MappingType { get; set; }

    /// <summary>
    /// This holds all of the references of this type.
    /// </summary>
    public List<LfLexReference> Members { get; set; }

    /// <summary>
    /// This is used for the generic/whole name for trees.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> ReverseName { get; set; }

}

[Table("LexReference")]
public class LfLexReference : LfObject
{
    /// <summary>
    /// This allows the user to add a comment to the set. We don't allow comments on individual links, but generally this comment can refer to individual items, if desired.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Comment { get; set; }

    // M:N
    public List<LfObject> Targets { get; set; }

    /// <summary>
    /// This allows the user to add a name to the set.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    public string LiftResidue { get; set; }

}

[Table("ChkSense")]
public class LfChkSense : LfObject
{
    /// <summary>
    /// A short explanation of the relationship of the lexical sense to the check item. 
    /// For example, in the Key Terms list, may add an additional explanation of why the lexical item is chosen to render the key term, beyond the definition given for the Sense.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Explanation { get; set; }

    /// <summary>
    /// In Scripture, a target lexical sense for a key term. More generically, a lexical sense associated with a checklist item. With the LexSense as a starting point, the stem, citation form, literal meaning, definition, gloss and likely inflectional word forms for the rendering can be determined. Note that we do not determine the lexical stem directly but rather make a semantic connection to it through the particular sense of the stem that is relevant to the ChkItem. We can always determine the stem from the sense but not vice versa.
    /// </summary>
    public Guid SenseGuid { get; set; }
    public LfLexSense Sense { get; set; }

}

[Table("DsChart")]
public abstract class LfDsChart : LfMajorObject
{
    /// <summary>
    /// Type of Discourse Chart. Each type of chart can have a different organization and layout of columns. Template must refer to a top-level CmPossibility in (eventually one of?) the template possibility lists of the DsDiscourseData (a Template).
    /// </summary>
    public Guid TemplateGuid { get; set; }
    public LfPossibility Template { get; set; }

}

[Table("DsChart")]
public class LfDsConstChart : LfDsChart
{
    /// <summary>
    /// The linguistic text that the chart organizes (currently part of a Text, but could also be part of Scripture).
    /// </summary>
    public Guid BasedOnGuid { get; set; }
    public LfStText BasedOn { get; set; }

    /// <summary>
    /// The main content of the chart. Each ConstChartRow represents a row/clause.
    /// </summary>
    public List<LfConstChartRow> Rows { get; set; }

}

[Table("DsDiscourseData")]
public class LfDsDiscourseData : LfObject
{
    /// <summary>
    /// Templates describing possible chart organizations. Top level Possibilities are Chart Templates. SubPossibilities represent groups of columns or columns. (This is stretching the idea of 'possibilities' somewhat, and it is unusual that the top-level possibilities are really a different kind of thing from the leaves, but it can be thought of as an extension of the idea that non-leaf nodes perform a grouping function.)
    /// Changed from ConstChartTemplates for the port.
    /// </summary>
    public Guid ConstChartTemplGuid { get; set; }
    public LfPossibilityList ConstChartTempl { get; set; }

    /// <summary>
    /// Actual instances of discourse charts (tentatively of all types, even though we currently only have one type: Constituent Chart).
    /// </summary>
    public List<LfDsChart> Charts { get; set; }

    /// <summary>
    /// This list stores markers that can be inserted into the chart to provide additional labelling. The top-level is several different kinds of markers (initially Tense/Aspect/Mood, Pronouns, and Demonstatives), and below those are the (sometimes hierarchical) lists of possible markers for that type. Combining them like this makes it easy to add new categories as well as items.
    /// </summary>
    public Guid ChartMarkersGuid { get; set; }
    public LfPossibilityList ChartMarkers { get; set; }

}

[Table("Possibility")]
public class LfChkTerm : LfPossibility
{
    /// <summary>
    /// List of references where this checking item needs to be checked. E.g., a list of scripture references where a specific sense of a key term needs to be checked.
    /// </summary>
    public List<LfChkRef> Occurrences { get; set; }

    /// <summary>
    /// Alternate glosses (in UI/analysis writing systems) that should appear in the list of terms (when sorted/grouped by gloss). Multiple glosses are separated by semi-colons.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> SeeAlso { get; set; }

    /// <summary>
    /// Represents the renderings (i.e. vernacular equivalents) for a term. A ChkRendering is added whenever a rendering is ascribed to a ChkRef for which a ChkRendering does not already exist in this collection.
    /// </summary>
    public List<LfChkRendering> Renderings { get; set; }

    /// <summary>
    /// A fixed identifier that matches the term in one or more external source files (e.g., BiblicalTerms.xml, localizations of that file, and/or files that link terms to semantic domains) to uniquely identify the term so it can be correctly matched (and updated, etc.) from the right entry in the external files. This can also be used to obtain a consistent secondary sort when two key terms have identical Lemma forms and/or glosses.
    /// </summary>
    public int TermId { get; set; }

}

[Table("ChkRendering")]
public class LfChkRendering : LfObject
{
    /// <summary>
    /// A vernacular wordform that occurs in the text and is a valid equivalent for rendering the term that owns this ChkRendering object. This is required to be filled in when a ChkRendering is created.
    /// </summary>
    public Guid SurfaceFormGuid { get; set; }
    public LfWfiWordform SurfaceForm { get; set; }

    /// <summary>
    /// The literal meaning of the vernacular term or phrase used for rendering the ChkTerm. This will be displayed as the back translation of the vernacular rendering. This is optional, but when supplied (by the user) must be one of the glosses for one of the senses of the SurfaceForm.
    /// </summary>
    public Guid MeaningGuid { get; set; }
    public LfWfiGloss Meaning { get; set; }

    /// <summary>
    /// An optional short explanation of why this rendering was chosen to render the term.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Explanation { get; set; }

}

[Table("LexEntryRef")]
public class LfLexEntryRef : LfObject
{
    /// <summary>
    /// This points to one or more LexEntryType items in the Variant Entry Types list for variant entries. It is unused for complex entries, although the model allows for both to be used if desirable. Normally a variant LexEntryRef will only use PrimaryLexemes to point to a single entry or sense. Entries using VariantEntryTypes will be displayed as minor entries in the dictionary; usually following the main entry headword and will typically produce a separate minor entry in the dictionary referring to the main entry. The LexEntryType is used to determine how to display the variant information in the main entry context as well as the minor entry context. The Variant Entry Types list is hierarchical with the top level being the type of variant (e.g., dialectal) and subitems being the conditions (e.g., British English, American English) for that type of variant. Normally the user will set this property to a subitem, although a top level item could be used if the user does not want to specify the condition. Each LexEntryType Abbreviation and ReverseAbbr should contain everything needed for displaying the references for this entry. Flex will not attempt to combine names from different hierarchical levels. The Abbreviation is used when displaying the main entry from the minor entry (e.g., Brit. dial. of color). The ReverseAbbr is used when displaying the minor entry from the main entry (e.g., Brit. dial. colour). This is a sequence because some minor entries can have more than one relationship to the same main entry. For example, colour is a spelling variant and a British dialectal variant. The user could use two LexEntryRefs to represent this, but it would be easier to use a single LexEntryRef with two VariantEntryTypes references.
    /// </summary>
    // M:N
    public List<LfLexEntryType> VariantEntryTypes { get; set; }

    /// <summary>
    /// This property points to one or more items in the Complex Entry Types list for complex entries. It is unused for variant entries, although the model allows for both to be used if desirable. Normally a complex LexEntryRef will point to more than one main entry or sense via PrimaryLexemes and ComponentLexemes. Entries using ComplexEntryTypes will be displayed as subentries in the dictionary; usually at the end of the major entry and will typically produce a separate major entry in the dictionary referring to the main entry. The display is dependent on whether a root-based or stem-based view of the dictionary is being printed. The referenced LexEntryType is used to control the display of the complex information in the main entry context as well as the minor entry context. See the description of VariantEntryTypes for using the information from the LexEntryRef for display purposes.
    /// </summary>
    // M:N
    public List<LfLexEntryType> ComplexEntryTypes { get; set; }

    /// <summary>
    /// The UI limits this to a sequence of LexEntry or LexSense. For variants, this field is unused.
    /// For complex entries, this field points to a subset of ComponentLexemes. The entries or senses in this property determine the main entries that will have subentries generated for this entry in a root-based dictionary. For example, if ComponentLexemes has kick, the, bucket, and PrimaryLexemes only has kick, then kick is the only entry that will show a ‘kick the bucket’ subentry in a root-based display.
    /// </summary>
    // M:N
    public List<LfObject> PrimaryLexemes { get; set; }

    /// <summary>
    /// The UI limits this to a sequence of LexEntry or LexSense. For variants, this field points to the main entry or sense. When not hidden, this will produce a minor variant entry that always shows the main entry referenced here. This variant will always be shown in the main entry being referenced. ComponentLexemes is ignored in this case.
    /// For complex entries, this property lists the components for this idiom, derivation, compound, etc. All of the listed components will be displayed in the subentry following the headword. For example, emphanizoo (cmpd. of en, pha, -an, -id). Whether they get displayed as subentries is controlled by the PrimaryLexemes property. This allows the user to specify component lexemes for productive lexemes without cluttering the printed dictionary.]
    /// </summary>
    // M:N
    public List<LfObject> ComponentLexemes { get; set; }

    /// <summary>
    /// This field indicates whether the variant or compound entry should be listed as a minor entry referencing the main entry in the lexicon. The lexicographer typically wants to limit minor entries to ones that are not alphabetically close to the main entry. It defaults to 0 which is easiest to implement in the model and is probably the most common situation. The UI for this could say Show Minor Entry, if desired. If there are multiple LexEntryRefs in the same entry, the entry will show as a minor entry unless all of the LexEntryRefs have HideMinorEntry set to 1. The minor entry would only display information for LexEntryRefs that have this property set to 0. For example, we could limit a reference on a minor entry (e.g., Entry: man (pl. men) Entry: people (reg. var. men) Minor Entry: men pl. of man, but not reg. var. of people) I don’t think this is a good example, but I suspect someone might have a productive derivation where they would only want to list a few of the references in the minor entry. By leaving this property on LexEntryRef, this would be possible. If we are certain that everyone will always want to list every occurrence in a minor entry for a variant or a subentry, then we could add this to LexEntry instead of LexEntryRef. We are using an integer instead of a Boolean for the possibility of controlling printing for different dictionary publications. Each bit in the integer could represent a Boolean for a particular dictionary, thus allowing 32 different dictionaries. We are not implementing the support for multiple dictionaries at this point, and the final design may use a different means for controlling minor entries.
    /// </summary>
    public int HideMinorEntry { get; set; }

    /// <summary>
    /// This field is available for summary information to show with the variant info being displayed from the main entry. It may be in more than one language and might support formatting and embedded languages. Chuck Grimes feels this is important and it is not simply the gloss of the variant entry. This field would contain the MDF \ve, \vn, and \vr information, which may be the name of a dialect and/or any pertinent comment, such as usage restrictions, simple gloss, or inflection. In MDF the contents of \ve is displayed after the variant in parentheses. Since the \ve field is imported from the major entry, and the \ve may differ for the same \va used in different entries, by storing the information with the LexEntryRef we do not lose anything. If we imported it into the SummaryDefinition of the minor entry, we would have to concatenate the various \ve fields and would lose the distinction of which reference they came from. However, my searches so far have not uncovered any place two different main entries refer to the same variant entry, If this does not happen, we could probably ignore this and just use the SummaryDefinition of the minor entry. When displaying the variant entry in a main entry, this summary could be printed following the variant headword. When displaying a subentry in a main entry in the stem-based format, this summary would be displayed following the subentry headword. Would we ever need a different summary for two different LexEntryRefs owned by the same entry? If not, we could do without this property.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Summary { get; set; }

    public string LiftResidue { get; set; }

    /// <summary>
    /// This property is needed in the UI to know whether the current LexEntryRef should show up as a variant or a complex form. We currently use VariantTypes and ComplexFormTypes to determine this, but there are occasions when both of these are missing but we still need to show something in the UI. This integer will be used as an enum with 0 for variants and 1 for complex forms. We may later need to specify inflected forms and perhaps combinations of these.
    /// </summary>
    public int RefType { get; set; }

    /// <summary>
    /// The UI limits this to a sequence of LexEntry or LexSense. For variants, this field is unused.
    /// For complex entries, this field points to a subset of ComponentLexemes. The entries or senses in this property will list this item as a complex form (in a stem-based dictionary). For example, if ComponentLexemes has un, and known, and ShowComplexFormsIn only has known, then 'unknown' will be listed as a complex form of 'known' but not of 'un-'.
    /// </summary>
    // M:N
    public List<LfObject> ShowComplexFormsIn { get; set; }

}

[Table("PhSegmentRule")]
public class LfPhSegmentRule : LfObject
{
    /// <summary>
    /// A description of the rule, possibly including hyperlinks to some items that motivated the rule.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Description { get; set; }

    /// <summary>
    /// A name to help the user identify the rule in a list of phonological rules.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Name { get; set; }

    /// <summary>
    /// The direction and manner in which the rule applies.
    /// The possible values are:
    /// 1 - left-to-right iterative;
    /// 2 - right-to-left iterative;
    /// 3 - simultaneous.
    /// </summary>
    public int Direction { get; set; }

    /// <summary>
    /// The initial stratum to which this rule applies. If not specified, this rule applies to all strata.
    /// </summary>
    public Guid InitialStratumGuid { get; set; }
    public LfMoStratum InitialStratum { get; set; }

    /// <summary>
    /// The final stratum to which this rule applies.
    /// </summary>
    public Guid FinalStratumGuid { get; set; }
    public LfMoStratum FinalStratum { get; set; }

    /// <summary>
    /// For regular rules, this is the structural description of the rule (i.e the A in the general formula of A -> B / C _ D). If A is missing, then this is an insertion (epenthetic) rule. For metathesis rules, this is the structural description (i.e. the input) of the rule. Each ordered PhSimpleContext corresponds to a number (the index) that can be referred to in the structural change attribute.
    /// </summary>
    public List<LfPhSimpleContext> StrucDesc { get; set; }

    /// <summary>
    /// Indicates whether the rule is currently active and therefore will be used by the parser (false) or if it is not active (true) and therefore ignored by the parser (but still available for the user to see).
    /// The default value is false.
    /// </summary>
    public Boolean Disabled { get; set; }

}

[Table("PhSegmentRule")]
public class LfPhRegularRule : LfPhSegmentRule
{
    /// <summary>
    /// The right hand sides of the rule (i.e. the B, C, and D of the general formula (A -> B / C _ D).
    /// </summary>
    public List<LfPhSegRuleRHS> RightHandSides { get; set; }

}

[Table("PhSegmentRule")]
public class LfPhMetathesisRule : LfPhSegmentRule
{
    /// <summary>
    /// The structural change (i.e. the output )of the rule. It contains an ordered sequence of integers, each of which corresponds to an index in the structural description. 
    /// Since we do not have a way to model a sequence of integers, we use a string to store the integers. The integers are separated by a space.
    /// </summary>
    public String StrucChange { get; set; }

}

[Table("PhSegRuleRHS")]
public class LfPhSegRuleRHS : LfObject
{
    /// <summary>
    /// The left context of the rule.
    /// </summary>
    public Guid LeftContextGuid { get; set; }
    public LfPhPhonContext LeftContext { get; set; }

    /// <summary>
    /// The right context of the rule.
    /// </summary>
    public Guid RightContextGuid { get; set; }
    public LfPhPhonContext RightContext { get; set; }

    /// <summary>
    /// The structural change (i.e. the output) of the rule. If this is missing, the rule is a deletion rule
    /// </summary>
    public List<LfPhSimpleContext> StrucChange { get; set; }

    /// <summary>
    /// When present, this limits the rule application to apply only when the input is for one of the Parts of Speech given in the collection.
    /// The hierarchical nature of Parts of Speech is respected, so if "transitive verb" is a sub-category of "verb" and one specifies "verb" as an input POS, then the rule will also apply to "transitive verb.
    /// </summary>
    // M:N
    public List<LfPartOfSpeech> InputPOSes { get; set; }

    /// <summary>
    /// This refers to a set of rule features (which are a possibility list).
    /// This encodes negative rule feature requirements, such as conjugation class membership or gender.
    /// In order for this rule to apply to a lexical entry, the lexical entry must not contain in its Rule Features list any of the feature names of this list.
    /// If this field is omitted, there are no excluded rule features.
    /// Warning: The names in the RequiredRuleFeatures list and this list should be mutually exclusive.
    /// </summary>
    // M:N
    public List<LfPhPhonRuleFeat> ExclRuleFeats { get; set; }

    /// <summary>
    /// These are required rule features. This collection refers to a set of rule features (which are a possibility list).
    /// This encodes positive rule feature requirements, such as conjugation class membership or gender.
    /// In order for this rule to apply to a lexical entry, the lexical entry must contain in its Rule Features list all the feature names of this list.
    /// If this field is omitted, there are no required Rule Features.
    /// Warning: The names in the ExcludedRuleFeatures list and this list should be mutually exclusive.
    /// </summary>
    // M:N
    public List<LfPhPhonRuleFeat> ReqRuleFeats { get; set; }

}

[Table("Possibility")]
public class LfPhPhonRuleFeat : LfPossibility
{
    /// <summary>
    /// This refers to a CmObject, where that CmObject would probably be a MoInflClass (e.g. a conjugation class), an FsSymFeatVal (e.g. feminine gender), or a CmPossibility (for an exception "feature").
    /// Any such MoInflClass would be owned by a PartOfSpeech (or by a nested MoInflClass within a PartOfSpeech); any such FsSymFeatVal would be owned by an FsClosedFeature;
    /// and the exception "feature" CmPossibility would be in the possibility list owned by MoMorphData:ProdRestrict.
    /// </summary>
    public Guid ItemGuid { get; set; }
    public LfObject Item { get; set; }

}

[Table("Possibility")]
public class LfLexEntryInflType : LfLexEntryType
{
    /// <summary>
    /// Any gloss string which will be added before the gloss of the stem.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> GlossPrepend { get; set; }

    /// <summary>
    /// Any gloss string which will be added after the gloss of the stem.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> GlossAppend { get; set; }

    /// <summary>
    /// These are the inflectional features of the inflection type. For example, if the type is perfective, then this will be [aspect:perfective].
    /// If it is (nominal) plural, then this will be [noun_agreement:[number:plural]]. 
    /// These features are added to the inflected form (in the word grammar, this is with the rule corresponding to the inflectional template).
    /// </summary>
    public Guid InflFeatsGuid { get; set; }
    public LfFsFeatStruc InflFeats { get; set; }

    /// <summary>
    /// This indicates any slot(s) in inflectional templates which would normally be filled by an inflectional affix bearing the same inflectional feature(s) as those in InflFeats.
    /// That is, regularly inflected forms will usually have an inflectional affix filling some slot. These irregularly inflected forms will not have that inflectional affix (this is why they are irregular)
    /// but the automated parsers will still need to know which slot(s) should be considered filled.
    /// For example, if the type is perfective and regularly inflected verbs have a perfective prefix in the aspect slot (which happens to be the second slot before the stem), the user would indicate that second, aspect slot here
    /// </summary>
    // M:N
    public List<LfMoInflAffixSlot> Slots { get; set; }

}

[Table("LexExtendedNote")]
public class LfLexExtendedNote : LfObject
{
    /// <summary>
    /// From the LexDb.ExtendedNoteTypes possibility list.
    /// </summary>
    public Guid ExtendedNoteTypeGuid { get; set; }
    public LfPossibility ExtendedNoteType { get; set; }

    /// <summary>
    /// User's discussion of the topic.
    /// </summary>
    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> Discussion { get; set; }

    /// <summary>
    /// These are examples that illustrate the discussion.
    /// The LexExample model includes Translation Type and Reference, but they will be empty and not shown.
    /// </summary>
    public List<LfLexExampleSentence> Examples { get; set; }

}

[Table("Project")]
public class LfLangProject : LfProject
{
    public string EthnologueCode { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> WorldRegion { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> MainCountry { get; set; }

    [Column(TypeName = "jsonb")]
    public List<LfWsTsString> FieldWorkLocation { get; set; }

    public Guid PartsOfSpeechGuid { get; set; }
    public LfPossibilityList PartsOfSpeech { get; set; }

    public Guid TranslationTagsGuid { get; set; }
    public LfPossibilityList TranslationTags { get; set; }

    public Guid ThesaurusGuid { get; set; }
    public LfPossibilityList Thesaurus { get; set; }

    // M:N
    public List<LfWordformLookupList> WordformLookupLists { get; set; }

    public Guid AnthroListGuid { get; set; }
    public LfPossibilityList AnthroList { get; set; }

    public Guid LexDbGuid { get; set; }
    public LfLexDb LexDb { get; set; }

    public Guid ResearchNotebookGuid { get; set; }
    public LfRnResearchNbk ResearchNotebook { get; set; }

    /// <summary>
    /// Changed from AnalysisWritingSystems.
    /// This is a space-delimited list of writing system tags.
    /// </summary>
    public string AnalysisWss { get; set; }

    /// <summary>
    /// Changed from CurrentVernacularWritingSystems
    /// This is a space-delimited list of writing system tags.
    /// </summary>
    public string CurVernWss { get; set; }

    /// <summary>
    /// Changed from CurrentAnalysisWritingSystems
    /// This is a space-delimited list of writing system tags.
    /// </summary>
    public string CurAnalysisWss { get; set; }

    /// <summary>
    /// Changed from CurrentPronunciationWritingSystems
    /// This is a space-delimited list of writing system tags.
    /// </summary>
    public string CurPronunWss { get; set; }

    public Guid MsFeatureSystemGuid { get; set; }
    public LfFsFeatureSystem MsFeatureSystem { get; set; }

    public Guid MorphologicalDataGuid { get; set; }
    public LfMoMorphData MorphologicalData { get; set; }

    /// <summary>
    /// Styles for use in the Data Notebook and Lexical database.
    /// </summary>
    public List<LfStStyle> Styles { get; set; }

    public List<LfFilter> Filters { get; set; }

    public Guid ConfidenceLevelsGuid { get; set; }
    public LfPossibilityList ConfidenceLevels { get; set; }

    public Guid RestrictionsGuid { get; set; }
    public LfPossibilityList Restrictions { get; set; }

    public Guid RolesGuid { get; set; }
    public LfPossibilityList Roles { get; set; }

    public Guid StatusGuid { get; set; }
    public LfPossibilityList Status { get; set; }

    public Guid LocationsGuid { get; set; }
    public LfPossibilityList Locations { get; set; }

    public Guid PeopleGuid { get; set; }
    public LfPossibilityList People { get; set; }

    public Guid EducationGuid { get; set; }
    public LfPossibilityList Education { get; set; }

    public Guid TimeOfDayGuid { get; set; }
    public LfPossibilityList TimeOfDay { get; set; }

    /// <summary>
    /// In traditional interlinearizing programs, the user is encouraged to provide a part-of-speech or category for all morphemes in a word. Inflectional affixes such as PAST, PRESENT and FUTURE might be labelled as tense. Derivational affixes often take labels very similar to their glosses - CAUSATIVE might be labelled as causative or causative marker or simply verb affix. The AffixCategoryList is provided here to allow the user to label affixes in this way for "stealth" purposes only. Inflectional affixes should ultimately be captured in inflectional templates and slot names used for interlinearizing. Derivational affixes should be default have a MoAffixCategory of "derv" (derivational affix). Refer to MoInflectionalAffixMsa and MoDerivationalAffixMsa for more information.
    /// </summary>
    public Guid AffixCategoriesGuid { get; set; }
    public LfPossibilityList AffixCategories { get; set; }

    public Guid PhonologicalDataGuid { get; set; }
    public LfPhPhonData PhonologicalData { get; set; }

    public Guid PositionsGuid { get; set; }
    public LfPossibilityList Positions { get; set; }

    public List<LfOverlay> Overlays { get; set; }

    /// <summary>
    /// At this point, in time (Jan, 2002) CmAnalyzingAgents are used only by MoMorphological data. Refer to CmAnalyzingAgent for more info.
    /// </summary>
    public List<LfAgent> AnalyzingAgents { get; set; }

    public Guid TranslatedScriptureGuid { get; set; }
    public LfScripture TranslatedScripture { get; set; }

    /// <summary>
    /// Changed from VernacularWritingSystems
    /// This is a space-delimited list of writing system tags.
    /// </summary>
    public string VernWss { get; set; }

    /// <summary>
    /// LinkedFiles Root Directory: Linked Files links may have a full path name or a relative path name. This property holds the relative path definition when relative path names are used. It could be a physical path name (e.g., c:\FwData) or a network name that could be accessed by other users (e.g., \\ls-daffy\FwData).
    /// </summary>
    public string LinkedFilesRootDir { get; set; }

    public List<LfAnnotation> Annotations { get; set; }

    public List<LfUserConfigAcct> UserAccounts { get; set; }

    public List<LfUserAppFeatAct> ActivatedFeatures { get; set; }

    /// <summary>
    /// Changed from AnnotationDefinitions.
    /// </summary>
    public Guid AnnotationDefsGuid { get; set; }
    public LfPossibilityList AnnotationDefs { get; set; }

    public List<LfFolder> Pictures { get; set; }

    public Guid SemanticDomainListGuid { get; set; }
    public LfPossibilityList SemanticDomainList { get; set; }

    /// <summary>
    /// The CheckLists will be a collection of CmPossibilityList objects, each with a unique identifier. For example, one CmPossibilityList will be called KeyTerms which will represent a hierarchical list of Biblical key terms. The possibility lists can be imported programmatically from external files. Each CmPossibilityList will hold ChkItem objects (derived from CmPossibility).
    /// </summary>
    public List<LfPossibilityList> CheckLists { get; set; }

    /// <summary>
    /// This contains a list of folders holding media file objects. For now, we will have one CmFolder called "Local Media" that holds all media.
    /// </summary>
    public List<LfFolder> Media { get; set; }

    /// <summary>
    /// This property holds the list of defined genres (instances of CmPossibility) used by texts.
    /// </summary>
    public Guid GenreListGuid { get; set; }
    public LfPossibilityList GenreList { get; set; }

    /// <summary>
    /// The place for all our discourse analysis data.
    /// </summary>
    public Guid DiscourseDataGuid { get; set; }
    public LfDsDiscourseData DiscourseData { get; set; }

    /// <summary>
    /// Top eval Possibilities are major tag categories ( Syntax, Semantics, RRG, etc.) The actual tags are their SubPossibilities [After V1, more hierarchy may be possible.]
    /// </summary>
    public Guid TextMarkupTagsGuid { get; set; }
    public LfPossibilityList TextMarkupTags { get; set; }

    /// <summary>
    /// This contains one folder holding owning CmFile objects. The CmFolder is called "File paths in TsStrings" that holds all externalLink's to files found in TsStrings.
    /// </summary>
    public Guid FilePathsInTsStringsGuid { get; set; }
    public LfFolder FilePathsInTsStrings { get; set; }

    /// <summary>
    /// This is a writing system tag used for determining homogragh numbers of headwords.
    /// </summary>
    public string HomographWs { get; set; }

    /// <summary>
    /// This feature system contains the phonological features used by phonological rules.
    /// They are kept separate from the morpho-syntactic features in the MsFeatureSystem attribute.
    /// </summary>
    public Guid PhFeatureSystemGuid { get; set; }
    public LfFsFeatureSystem PhFeatureSystem { get; set; }

}

