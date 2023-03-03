using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace LfSync.Data.LCModel
{
    public class LfTsString
    {
        //public Guid Owner { get; set; }
        //public int OwningFlid { get; set; }
        public string? Text { get; init; }
        public List<LfTsRunPart> Runs { get; init; }
    }

    public class LfWsTsString : LfTsString
    {
        public string? WritingSystem { get; set; }
    }

    public class LfTsRunPart
    {
        public int IchLim { get; set; }
        public List<TextProperty>? Props { get; set; }
    }

    // $t is a fragile hack: it makes it the first property in Postgres' JSONB column, because it's the shortest property name.
    // Other alternatives: use JSON or use a custom convertor
    // For more on this limitation as well as potential converters see: https://github.com/dotnet/runtime/issues/72604
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$t")]
    [JsonDerivedType(typeof(IntTextProperty), typeDiscriminator: "int-prop")]
    [JsonDerivedType(typeof(StringTextProperty), typeDiscriminator: "string-prop")]
    public abstract class TextProperty
    {
        public int Key { get; set; }
    }

    public class IntTextProperty : TextProperty
    {
        public int Value { get; set; }
        public int Variation { get; set; }
    }

    public class StringTextProperty : TextProperty
    {
        public string? Value { get; set; }
    }
}