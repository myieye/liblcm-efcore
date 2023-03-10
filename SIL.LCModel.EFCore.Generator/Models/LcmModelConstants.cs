using System.Collections.Generic;
using SIL.LCModel;
using static LfSync.LcmModelGenerator.NameUtils;

namespace LfSync.LcmModelGenerator
{
    internal static class LcmModelConstants
    {
        internal static ClassModel LfObject = new ClassModel()
        {
            Name = nameof(LfObject),
            DbAbbrev = null,
            BaseClass = null,
            TableName = PickTableName(nameof(LfObject), null),
            Abstract = false,
            Properties = new List<PropertyModel>
            {
                new PropertyModel
                {
                    Name = "Hvo",
                    Type = "int",
                    Order = 1,
                    IsOwner = false,
                    Cardinality = Cardinality.One,
                    ValueType = ValueType.Literal,
                    Docs = new List<string>
                    {
                        "/// <summary>",
                        "Project-specific ID of the object.",
                        "/// </summary>"
                    }
                },
                new PropertyModel
                {
                    Name = "Owner",
                    Type = "Guid?",
                    Order = 2,
                    IsOwner = false,
                    Cardinality = Cardinality.One,
                    ValueType = ValueType.Literal,
                    Docs = new List<string>
                    {
                        "/// <summary>",
                        "Object owner. (Null, if not owned.)",
                        "/// </summary>"
                    }
                },
                new PropertyModel
                {
                    Name = "OwningFlid",
                    Type = "int",
                    Order = 3,
                    IsOwner = false,
                    Cardinality = Cardinality.One,
                    ValueType = ValueType.Literal,
                    Docs = new List<string>
                    {
                        "/// <summary>",
                        "Field ID of the owning object where the object is stored.",
                        "/// </summary>"
                    }
                },
                new PropertyModel
                {
                    Name = "OwnOrd",
                    Type = "int",
                    Order = 4,
                    IsOwner = false,
                    Cardinality = Cardinality.One,
                    ValueType = ValueType.Literal,
                    Docs = new List<string>
                    {
                        "/// <summary>",
                        "Owning ord of the owning object where the object is stored.",
                        "/// </summary>"
                    }
                },
                new PropertyModel
                {
                    Name = "ClassID",
                    Type = "int",
                    Order = 5,
                    IsOwner = false,
                    Cardinality = Cardinality.One,
                    ValueType = ValueType.Literal,
                    Docs = new List<string>
                    {
                        "/// <summary>",
                        "Class ID of the object.",
                        "/// </summary>"
                    }
                },
                new PropertyModel
                {
                    Name = "Guid",
                    Type = "Guid",
                    IsPrimaryKey = true,
                    Order = 6,
                    IsOwner = false,
                    Cardinality = Cardinality.One,
                    ValueType = ValueType.Literal,
                    Docs = new List<string>
                    {
                        "/// <summary>",
                        "Unique ID of the object. If this will hang around, prefer to use the Id.",
                        "/// </summary>"
                    }
                }
            }
        };

        // Set properties as not owned, because:
        // For Wordform (IWfiWordform): A unique constraint broke (also: marked as owner=none in xml)
        // For Analysis (IWfiAnalysis): I was under the assumption that every type is only owned by one other type
        //                              and this is owned by others.
        //                              However, that assumption was nonsense, see: LogMultipleOwnerStats.
        internal static ClassModel LfAnalysis = new ClassModel()
        {
            Name = nameof(LfAnalysis),
            DbAbbrev = null,
            BaseClass = LfObject,
            TableName = PickTableName(nameof(LfAnalysis), LfObject),
            Abstract = false,
            Properties = new List<PropertyModel>
            {
                new PropertyModel
                {
                    Name = "Wordform",
                    Type = LcmNameToLf(nameof(IWfiWordform)),
                    Order = 1,
                    IsOwner = false,
                    Cardinality = Cardinality.One,
                    ValueType = ValueType.Relation,
                    Docs = new List<string>
                    {
                        "/// <summary>",
                        "Get the WfiWordform.",
                        "/// </summary>"
                    }
                },
                new PropertyModel
                {
                    Name = "HasWordform",
                    Type = "bool",
                    Order = 2,
                    IsOwner = true,
                    Cardinality = Cardinality.One,
                    ValueType = ValueType.Literal,
                    Docs = new List<string>
                    {
                        "/// <summary>",
                        "Returns true if the analysis is or is owned by a wordform. (Not a punctuation form.)",
                        "/// </summary>"
                    }
                },
                new PropertyModel
                {
                    Name = "Analysis",
                    Type = LcmNameToLf(nameof(IWfiAnalysis)),
                    Order = 3,
                    IsOwner = false,
                    Cardinality = Cardinality.One,
                    ValueType = ValueType.Relation,
                    Docs = new List<string>
                    {
                        "/// <summary>",
                        "The associated WfiAnalysis, if any; returns null for WfiWordform, this for WfiAnalysis, owner for WfiGloss.",
                        "/// </summary>"
                    }
                }
            }
        };
    }
}