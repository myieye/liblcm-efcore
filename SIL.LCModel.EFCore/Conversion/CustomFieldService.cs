using SIL.LCModel.Application;
using SIL.LCModel.Core.Cellar;
using SIL.LCModel.EFCore.Model;
using SIL.LCModel.Infrastructure;

namespace SIL.LCModel.EFCore.Conversion;

public class CustomFieldService
{
    private readonly LcmCache cache;
    private IFwMetaDataCacheManaged FwData { get => cache.ServiceLocator.MetaDataCache; }
    private ISilDataAccessManaged SilData { get => (ISilDataAccessManaged)cache.MainCacheAccessor; }
    private Dictionary<int, List<CustomFieldConfig>> customFieldConfigsByClass;
    private Dictionary<int, List<CustomFieldConfig>> CustomFieldConfigsByClass
    {
        get
        {
            if (customFieldConfigsByClass == null)
            {
                customFieldConfigsByClass = BuildCustomFieldConfigs();
            }
            return customFieldConfigsByClass;
        }
    }
    private static CustomFieldService? _instance;
    private readonly ISet<int> classesWithCustomFields = new HashSet<int>
    { LexEntryTags.kClassId, LexSenseTags.kClassId, LexExampleSentenceTags.kClassId, MoFormTags.kClassId };

    public static CustomFieldService Instance(LcmCache cache)
    {
        if (_instance == null)
        {
            _instance = new CustomFieldService(cache);
        }
        return _instance;
    }

    public List<CustomFieldConfig> GetCustomFieldConfigs()
    {
        return CustomFieldConfigsByClass.Values.SelectMany(x => x).ToList();
    }

    internal List<CustomFieldConfig> GetCustomFieldConfigsForClass(int classId)
    {
        return CustomFieldConfigsByClass[classId];
    }

    private CustomFieldService(LcmCache cache)
    {
        this.cache = cache;
    }

    private Dictionary<int, List<CustomFieldConfig>> BuildCustomFieldConfigs()
    {
        // IFwMetaDataCacheManagedInternal.GetCustomFields() is internal and would presumably be a lot prettier here
        return classesWithCustomFields.ToDictionary(classId => classId, classId => FwData
            .GetFields(classId, false, (int)CellarPropertyTypeFilter.All)
            .Where(FwData.IsCustom)
            .Select(fieldId => new CustomFieldConfig
            {
                Id = fieldId,
                Name = FwData.GetFieldName(fieldId),
                Description = FwData.GetFieldLabel(fieldId),
                Type = (CellarPropertyType)FwData.GetFieldType(fieldId) switch
                {
                    CellarPropertyType.Integer => CustomFieldType.Integer,
                    CellarPropertyType.GenDate => CustomFieldType.Date,
                    CellarPropertyType.String => CustomFieldType.SingleString,
                    CellarPropertyType.MultiUnicode => CustomFieldType.MultiString,
                    CellarPropertyType.OwningAtomic => CustomFieldType.Multiparagraph,
                    CellarPropertyType.ReferenceAtomic => CustomFieldType.SinglePossibility,
                    CellarPropertyType.ReferenceCollection => CustomFieldType.MultiPossibility,
                    _ => throw new ArgumentOutOfRangeException($"Unexpected custom field CellarPropertyType: {FwData.GetFieldType(fieldId)}."),
                },
            }).ToList());
    }

    public List<CustomFieldValue> GetCustomFieldValues(ICmObject obj, AutoMapper.ResolutionContext context)
    {
        var classId = obj.ClassID;
        if (!classesWithCustomFields.Contains(classId))
        {
            // this happens for types that extend MoForm (e.g. MoAffixAllomorph)
            // null might be more accurate, because I don't think they can actually have custom fields
            // But then where should the property be defined?
            return new List<CustomFieldValue>();
        }
        var customFieldConfigs = CustomFieldConfigsByClass[classId];
        return customFieldConfigs
            .Select(config => GetCustomFieldValue(obj, config, context))
            .Where(value => value != null)
            .ToList() as List<CustomFieldValue>;
    }

    public CustomFieldValue? GetCustomFieldValue(ICmObject obj, CustomFieldConfig config, AutoMapper.ResolutionContext context)
    {
        switch (config.Type)
        {
            case CustomFieldType.Integer:
                return NullIfEmpty(SilData.get_IntProp(obj.Hvo, config.Id), (value) => new IntCustomFieldValue
                {
                    ConfigId = config.Id,
                    Config = config,
                    Value = value,
                });
            case CustomFieldType.SingleString:
                return NullIfEmpty(context.Mapper.Map<LfTsString>(SilData.get_StringProp(obj.Hvo, config.Id)), (value) => new StringCustomFieldValue
                {
                    ConfigId = config.Id,
                    Config = config,
                    Value = value,
                });
            case CustomFieldType.Date:
                return NullIfEmpty(context.Mapper.Map<GenDate>(SilData.get_GenDateProp(obj.Hvo, config.Id)), (value) => new GenDateCustomFieldValue
                {
                    ConfigId = config.Id,
                    Config = config,
                    Value = value,
                });
            case CustomFieldType.MultiString:
                return NullIfEmpty(context.Mapper.Map<List<LfWsTsString>>(SilData.get_MultiStringProp(obj.Hvo, config.Id)), (value) => new WsTsStringCustomFieldValue
                {
                    ConfigId = config.Id,
                    Config = config,
                    Value = value,
                });
            case CustomFieldType.Multiparagraph:
                var textId = SilData.get_ObjectProp(obj.Hvo, config.Id);
                if (textId == 0 || !SilData.get_IsValidObject(textId))
                {
                    return null;
                }
                var stText = context.Mapper.Map<LfStText>(cache.GetAtomicPropObject(textId));
                return NullIfEmpty(stText, (value) => new StTextCustomFieldValue
                {
                    ConfigId = config.Id,
                    Config = config,
                    Value = stText,
                    StTextGuid = stText.Guid,
                });
            case CustomFieldType.SinglePossibility:
                var possibilityId = SilData.get_ObjectProp(obj.Hvo, config.Id);
                if (possibilityId == 0 || !SilData.get_IsValidObject(possibilityId))
                {
                    return null;
                }
                var possibility = context.Mapper.Map<LfPossibility>(cache.GetAtomicPropObject(possibilityId));
                return NullIfEmpty(possibility, (value) => new PossibilityCustomFieldValue
                {
                    ConfigId = config.Id,
                    Config = config,
                    Value = value,
                    PossibilityGuid = value.Guid,
                });
            case CustomFieldType.MultiPossibility:
                var possibilityIds = SilData.VecProp(obj.Hvo, config.Id);
                var possibilities = possibilityIds.Select(id => context.Mapper.Map<LfPossibility>(cache.GetAtomicPropObject(id))).ToList();
                return NullIfEmpty(possibilities, (value) => new PossibilityListCustomFieldValue
                {
                    ConfigId = config.Id,
                    Config = config,
                    Value = value,
                });
            default: throw new IndexOutOfRangeException($"Unexpected custom field type: {config.Type}");
        }
    }

    private static CustomFieldValue? NullIfEmpty<T>(T value, Func<T, CustomFieldValue> createCustomFieldValue)
    {
        var isEmpty = IsEmpty(value);
        return isEmpty ? null : createCustomFieldValue(value);
    }

    private static bool IsEmpty<T>(T value)
    {
        return // this could be more efficient
            EqualityComparer<T>.Default.Equals(value, default) ||
            value is LfTsString stringValue && string.IsNullOrWhiteSpace(stringValue.Text) ||
            value is List<LfWsTsString> multiStringValue && multiStringValue.All(s => string.IsNullOrWhiteSpace(s.Text)) ||
            value is LfStText stTextValue && stTextValue.Paragraphs.Cast<LfStTxtPara>().All(p => string.IsNullOrWhiteSpace(p.Contents)) ||
            value is List<LfPossibility> possibilityValue && possibilityValue.All(p => p == null || p.Guid == Guid.Empty) ||
            value is LfObject objectValue && objectValue.Guid == Guid.Empty;
    }
}

static class CustomFieldConfigExtensions
{

    public static void AddIfNotEmpty<T>(this List<CustomFieldValue> customFieldValues, CustomFieldValue<T> customFieldValue)
    {
        var value = customFieldValue.Value;

        customFieldValues.Add(customFieldValue);
    }

}