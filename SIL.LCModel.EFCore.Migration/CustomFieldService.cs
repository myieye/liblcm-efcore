using SIL.LCModel;
using SIL.LCModel.Application;
using SIL.LCModel.Core.Cellar;
using SIL.LCModel.EFCore.Model;
using SIL.LCModel.Infrastructure;

namespace SIL.LCModel.EFCore.Migration;

public class CustomFieldService
{
    private readonly LcmCache cache;
    private readonly IFwMetaDataCacheManaged fwData;
    private readonly ISilDataAccessManaged silData;
    private readonly Dictionary<int, List<CustomFieldConfig>> customFieldConfigsByClass;
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

    internal List<CustomFieldConfig> GetCustomFieldConfigs()
    {
        return customFieldConfigsByClass.Values.SelectMany(x => x).ToList();
    }

    internal List<CustomFieldConfig> GetCustomFieldConfigsForClass(int classId)
    {
        return customFieldConfigsByClass[classId];
    }

    private CustomFieldService(LcmCache cache)
    {
        this.cache = cache;
        fwData = cache.ServiceLocator.MetaDataCache;
        silData = (ISilDataAccessManaged)cache.MainCacheAccessor;
        customFieldConfigsByClass = BuildCustomFieldConfigs();
    }

    private Dictionary<int, List<CustomFieldConfig>> BuildCustomFieldConfigs()
    {
        // IFwMetaDataCacheManagedInternal.GetCustomFields() is internal and would presumably be a lot prettier here
        return classesWithCustomFields.ToDictionary(classId => classId, classId => fwData
            .GetFields(classId, false, (int)CellarPropertyTypeFilter.All)
            .Where(fwData.IsCustom)
            .Select(fieldId => new CustomFieldConfig
            {
                Id = fieldId,
                Name = fwData.GetFieldName(fieldId),
                Description = fwData.GetFieldLabel(fieldId),
                Type = (CellarPropertyType)fwData.GetFieldType(fieldId) switch
                {
                    CellarPropertyType.Integer => CustomFieldType.Integer,
                    CellarPropertyType.GenDate => CustomFieldType.Date,
                    CellarPropertyType.String => CustomFieldType.SingleString,
                    CellarPropertyType.MultiUnicode => CustomFieldType.MultiString,
                    CellarPropertyType.OwningAtomic => CustomFieldType.Multiparagraph,
                    CellarPropertyType.ReferenceAtomic => CustomFieldType.SinglePossibility,
                    CellarPropertyType.ReferenceCollection => CustomFieldType.MultiPossibility,
                    _ => throw new ArgumentOutOfRangeException($"Unexpected custom field CellarPropertyType: {fwData.GetFieldType(fieldId)}."),
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
        var customFieldConfigs = customFieldConfigsByClass[classId];
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
                return NullIfEmpty(silData.get_IntProp(obj.Hvo, config.Id), (value) => new IntCustomFieldValue
                {
                    ConfigId = config.Id,
                    Config = config,
                    Value = value,
                });
            case CustomFieldType.SingleString:
                return NullIfEmpty(context.Mapper.Map<LfTsString>(silData.get_StringProp(obj.Hvo, config.Id)), (value) => new StringCustomFieldValue
                {
                    ConfigId = config.Id,
                    Config = config,
                    Value = value,
                });
            case CustomFieldType.Date:
                return NullIfEmpty(context.Mapper.Map<GenDate>(silData.get_GenDateProp(obj.Hvo, config.Id)), (value) => new GenDateCustomFieldValue
                {
                    ConfigId = config.Id,
                    Config = config,
                    Value = value,
                });
            case CustomFieldType.MultiString:
                return NullIfEmpty(context.Mapper.Map<List<LfWsTsString>>(silData.get_MultiStringProp(obj.Hvo, config.Id)), (value) => new WsTsStringCustomFieldValue
                {
                    ConfigId = config.Id,
                    Config = config,
                    Value = value,
                });
            case CustomFieldType.Multiparagraph:
                var textId = silData.get_ObjectProp(obj.Hvo, config.Id);
                if (textId == 0 || !silData.get_IsValidObject(textId))
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
                var possibilityId = silData.get_ObjectProp(obj.Hvo, config.Id);
                if (possibilityId == 0 || !silData.get_IsValidObject(possibilityId))
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
                var possibilityIds = silData.VecProp(obj.Hvo, config.Id);
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