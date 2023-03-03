using System.Text.RegularExpressions;

namespace transform;

internal static partial class LcmUtils
{
    public static string LcmNameToLf(string lcmName)
    {
        return MyRegex().Replace(lcmName, "Lf");
    }

    public static string WithoutLcmPrefix(string lcmName)
    {
        return MyRegex().Replace(lcmName, "");
    }

    [GeneratedRegex("^(I?(Cm)?)?")]
    private static partial Regex MyRegex();
}

internal static class LcmModelConstants
{
    internal static ClassModel LfObject = new()
    {
        Name = "LfObject",
        BaseClass = null,
        TableName = "Object",
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
                Type = "Guid",
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

    internal static ClassModel LfAnalysis = new()
    {
        Name = "LfAnalysis",
        BaseClass = LfObject,
        TableName = "Analysis",
        Abstract = false,
        Properties = new List<PropertyModel>
        {
            new PropertyModel
            {
                Name = "Wordform",
                Type = "LfWfiWordform",
                Order = 1,
                IsOwner = true,
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
                Type = "LfWfiAnalysis",
                Order = 3,
                IsOwner = true,
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