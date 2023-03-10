
using System.Text.RegularExpressions;

namespace LfSync.LcmModelGenerator
{
    public static partial class NameUtils
    {
        // (?=[A-Z]) is a lookahead to make sure we only match I's marking interfaces e.g. ICmPossibility, but not I's at the beginning of words e.g. Indirect
        private const string LcmPrefixPattern = "^(I?(Cm)?)?(?=[A-Z])";
        private const string LfPrefixPattern = "^(Lf)?";
        public static string LcmNameToLf(string lcmName)
        {
            return Regex.Replace(lcmName, LcmPrefixPattern, "Lf");
        }

        public static string WithoutLcmPrefix(string lcmName)
        {
            return Regex.Replace(lcmName, LcmPrefixPattern, "");
        }

        public static string WithoutLfPrefix(string lfName)
        {
            return Regex.Replace(lfName, LfPrefixPattern, "");
        }

        internal static string PickTableName(string className, ClassModel baseClass)
        {
            if (className.Equals(nameof(LcmModelConstants.LfObject)))
            {
                return "ObjectId";
            }

            var currName = className;
            if (baseClass != null)
            {
                var nextClass = baseClass;
                while (nextClass != null
                    && !nextClass.Name.Equals(nameof(LcmModelConstants.LfObject)))
                {
                    currName = nextClass.Name;
                    nextClass = nextClass.BaseClass;
                }
            }
            return WithoutLfPrefix(currName);
        }

        internal static string PickAbbreviation(string tableName)
        {
            switch (tableName)
            {
                case "FsAbstractStructure":
                    return "FsAbsStruc";
                default:
                    return null;
            }
        }
    }
}