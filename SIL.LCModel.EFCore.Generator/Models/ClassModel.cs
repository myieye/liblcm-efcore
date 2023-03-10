using System.Collections.Generic;
using System.Linq;
using SIL.LCModel.Core.Phonology;

namespace LfSync.LcmModelGenerator
{
    internal enum ValueType { Relation, Literal, Jsonb }

    internal enum Cardinality { One, Many }

    internal class Relation
    {
        internal ClassModel Left { get; set; }
        internal ClassModel Right { get; set; }
        internal PropertyModel LeftProp { get; set; }
    }

    internal class ClassModel
    {
        internal string Name { get; set; }
        internal string FriendlyName { get => NameUtils.WithoutLfPrefix(Name); }
        /// <summary>
        /// An abbreviation is sometimes necessary to prevent naming collisions when generated names are truncated
        /// </summary>
        internal string DbAbbrev { get; set; }
        internal bool Abstract { get; set; }
        internal ClassModel BaseClass { get; set; }
        internal string TableName { get; set; }
        internal ClassModel Interface { get; set; }
        internal List<PropertyModel> Properties { get; set; }
        internal List<string> Docs { get; set; }
        internal bool ConvertToInterface { get; set; }
    }

    internal class PropertyModel
    {
        internal string Name { get; set; }
        internal string Type { get; set; }
        internal int Order { get; set; }
        internal bool IsOwner { get; set; }
        internal Cardinality Cardinality { get; set; }
        internal ValueType ValueType { get; set; }
        internal bool IsPrimaryKey { get; set; } = false;
        internal List<string> Docs { get; set; }
    }
}