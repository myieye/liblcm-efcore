
using System.Dynamic;

namespace LfSync.Data.LCModel;

public partial class LfCmPossibility : LfCmObject
{
    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Name
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfWsTsString> Name
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfWsTsString>();

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Abbreviation
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfWsTsString> Abbreviation
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfWsTsString>();

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Description
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfWsTsString> Description
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfWsTsString>();

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the SubPossibilities
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfCmPossibility> SubPossibilitiesOS
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfCmPossibility>();

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the SortSpec
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public int SortSpec
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Restrictions
    ///
    /// <para>Indicates whether the data for this possibility item has restrictions for presentation to certain audiences. This value comes from a user-defined list that is used by many different FieldWorks objects (Events, Analysis Records, Lexical Entries and their Senses, etc.) These values are user-definable and initially include: No restrictions, Do not publish, Case by case, Unknown</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfCmPossibility> RestrictionsRC
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfCmPossibility>();

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the Confidence
    ///
    /// <para>Indicates confidence in the data collected for this possibility item. This value comes from a user-defined list that is used by many different FieldWorks objects (Events, Analysis Records, Lexical Entries and their Senses, etc.) These values are user-definable and initially include: Low, Medium and High as possibilities.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public LfCmPossibility ConfidenceRA
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the Status
    ///
    /// <para>The status of this Possibility. This is a user-definable list but initial list will include: Confirmed, Disproved, Pending.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public LfCmPossibility StatusRA
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the DateCreated
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public DateTime DateCreated
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the DateModified
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public DateTime DateModified
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the Discussion
    ///
    /// <para>Any pertinent discussion for this Possibility.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    /*public IStText DiscussionOA
    {
        get;
        set;
    }*/

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Researchers
    ///
    /// <para>The person(s) who created/modified this Possibility record or any of its fields.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfCmPerson> ResearchersRC
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfCmPerson>();

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the HelpId
    ///
    /// <para>Used by the help system to launch the appropriate help topic for the Possibility item.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public string HelpId
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the ForeColor
    ///
    /// <para>ForeColor for overlay functionality.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public int ForeColor
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the BackColor
    ///
    /// <para>BackColor for overlay functionality.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public int BackColor
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the UnderColor
    ///
    /// <para>UnderColor for overlay functionality - the color of the "underline" style when used in Overlays. </para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public int UnderColor
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the UnderStyle
    ///
    /// <para>UnderStyle - style of the underline used in overlays functionality. </para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public int UnderStyle
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the Hidden
    ///
    /// <para>Indicates whether overlay bracketing should be hidden or not. True = Hidden.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public bool Hidden
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the IsProtected
    ///
    /// <para>This flag is set for items that are accessed by the software via GUIDs. The software is assuming that this item is always present with the same GUID on all machines. When set, a user can still edit the item, but it cannot be deleted.</para>
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public bool IsProtected
    {
        get;
        set;
    }

}

public partial class LfCmPerson : LfCmPossibility
{
    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Alias
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfWsTsString> Alias
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfWsTsString>();

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the Gender
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public int Gender
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the DateOfBirth
    /// </summary>
    /// ------------------------------------------------------------------------------------
    /*GenDate DateOfBirth
    {
        get;
        set;
    }*/

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the PlaceOfBirth
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public LfCmLocation PlaceOfBirthRA
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the IsResearcher
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public bool IsResearcher
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the PlacesOfResidence
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfCmLocation> PlacesOfResidenceRC
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfCmLocation>();

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the Education
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public LfCmPossibility EducationRA
    {
        get;
        set;
    }

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get or set the DateOfDeath
    /// </summary>
    /// ------------------------------------------------------------------------------------
    /*GenDate DateOfDeath
    {
        get;
        set;
    }*/

    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Positions
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfCmPossibility> PositionsRC
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfCmPossibility>();

}

public partial class LfCmLocation : LfCmPossibility
{
    /// ------------------------------------------------------------------------------------
    /// <summary>
    /// Get the Alias
    /// </summary>
    /// ------------------------------------------------------------------------------------
    public List<LfWsTsString> Alias
    {
        get;
        // No "setter" property is needed.
        // One "gets" the accessor and uses that to work with the property.
    } = new List<LfWsTsString>();

}
