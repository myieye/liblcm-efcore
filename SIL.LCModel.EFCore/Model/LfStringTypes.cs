using System.Text.Json.Serialization;

namespace SIL.LCModel.EFCore.Model;

public class LfTsString
{
    public required string Text { get; init; }
    public required List<LfTsRunPart> Runs { get; init; }
}

public class LfWsTsString : LfTsString
{
    public required string WritingSystem { get; set; }
}

public class LfTsRunPart
{
    public required int IchLim { get; init; }
    public required List<TextProperty> Props { get; init; }
}

// $t is a fragile hack: it makes it the first property in Postgres' JSONB column, because it's the shortest property name.
// Other alternatives: use JSON or use a custom convertor
// For more on this limitation as well as potential converters see: https://github.com/dotnet/runtime/issues/72604
[JsonPolymorphic(TypeDiscriminatorPropertyName = "$t")]
[JsonDerivedType(typeof(IntTextProperty), typeDiscriminator: "int-prop")]
[JsonDerivedType(typeof(StringTextProperty), typeDiscriminator: "string-prop")]
public abstract class TextProperty
{
    public required int Key { get; init; }
}

public class IntTextProperty : TextProperty
{
    public required int Value { get; init; }
    public required int Variation { get; init; }
}

public class StringTextProperty : TextProperty
{
    public required string? Value { get; init; }
}