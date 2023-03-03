using LfSync.LcmModelGenerator;

namespace transform;

internal enum ValueType { Relation, Literal, Jsonb }

internal enum Cardinality { One, Many}

internal class Relation
{
    internal required ClassModel Left { get; init; }
    internal required ClassModel Right { get; init; }
    internal required PropertyModel LeftProp { get; init; }
}

internal class ClassModel
{
    internal required string Name { get; init; }
    internal required bool Abstract { get; init; }
    internal required ClassModel? BaseClass { get; set; }
    public string? TableName { get; set; }
    private readonly IReadOnlyList<PropertyModel> _properties;
    internal required IReadOnlyList<PropertyModel> Properties
    {
        get => _properties;
        init
        {
            _properties = value;
            Relations = value
                .Where(p => p.ValueType == ValueType.Relation)
                .GroupBy(p => p.Type)
                .ToDictionary(
                    g => g.Key,
                    g => g.GroupBy(p => p.Cardinality)
                        .ToDictionary(g2 => g2.Key, g2 => g2.Select(p => p).ToHashSet()));
        }

    }
    internal Dictionary<string, Dictionary<Cardinality, HashSet<PropertyModel>>> Relations { get; init; }
}

internal class PropertyModel
{
    internal required string Name { get; init; }
    internal required string Type { get; init; }
    internal required int Order { get; init; }
    internal required bool IsOwner { get; init; }
    internal required Cardinality Cardinality { get; init; }
    internal required ValueType ValueType { get; init; }
    internal bool IsPrimaryKey { get; init; } = false;
    internal required List<string>? Docs { get; init; }
}