using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using SIL.LCModel.Core.Cellar;

namespace SIL.LCModel.EFCore.Model;

public enum CustomFieldType { Integer, SingleString, MultiString, Date, Multiparagraph, SinglePossibility, MultiPossibility  }

public class CustomFieldConfig
{
    [Key]
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required CustomFieldType Type { get; init; }
}

public abstract class CustomFieldValue
{
    [Key]
    public Guid Guid { get; init; }
    public required int ConfigId { get; init; }
    public required CustomFieldConfig Config { get; init; }
}

public abstract class CustomFieldValue<T> : CustomFieldValue
{
    public virtual required T Value { get; init; }
}

public abstract class JsonCustomfieldValue<T> : CustomFieldValue<T>
{
    // in order for the inheriting types to share the same column, they need a shared property with the same c# type (e.g. string instead of T)
    [Column("Value", TypeName = "jsonb")]
    public string? RawValue { get; init; }

    private string? _expectedRawValue;
    private T? _value;
    [NotMapped]
    public override required T Value
    {
        get
        {
            if (_value is null || RawValue != _expectedRawValue)
            {
                _value = JsonSerializer.Deserialize<T>(RawValue!)!;
            }
            return _value;
        }
        init
        {
            _value = value;
            RawValue = JsonSerializer.Serialize(value);
            _expectedRawValue = RawValue;
        }
    }
}

public class IntCustomFieldValue : JsonCustomfieldValue<int> { }
public class StringCustomFieldValue : JsonCustomfieldValue<LfTsString> { }
public class GenDateCustomFieldValue : JsonCustomfieldValue<GenDate> { }
public class WsTsStringCustomFieldValue : JsonCustomfieldValue<List<LfWsTsString>> { }
public class PossibilityListCustomFieldValue : CustomFieldValue<List<LfPossibility>> { }
public class PossibilityCustomFieldValue : CustomFieldValue<LfPossibility>
{
    [Column("PossibilityGuid_Value")]
    public required Guid PossibilityGuid { get; init; }
    [ForeignKey(nameof(PossibilityGuid))]
    override required public LfPossibility Value { get; init; }
}
public class StTextCustomFieldValue : CustomFieldValue<LfStText>
{
    [Column("StTextGuid_Value")]
    public required Guid StTextGuid { get; init; }
    [ForeignKey(nameof(StTextGuid))]
    override required public LfStText Value { get; init; }
}

public interface ICustomFieldOwner
{
    public List<CustomFieldValue> CustomFieldValues { get; set; }
}

public partial class LfLexEntry : ICustomFieldOwner
{
    public required List<CustomFieldValue> CustomFieldValues { get; set; }
}

public partial class LfLexSense : ICustomFieldOwner
{
    public required List<CustomFieldValue> CustomFieldValues { get; set; }
}

public partial class LfLexExampleSentence : ICustomFieldOwner
{
    public required List<CustomFieldValue> CustomFieldValues { get; set; }
}

public partial class LfMoForm : ICustomFieldOwner
{
    public required List<CustomFieldValue> CustomFieldValues { get; set; }
}
