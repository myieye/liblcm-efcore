using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using SIL.LCModel;

namespace LfSync.LcmModelGenerator
{
    internal static class LibLcmModelReader
    {
        internal static Dictionary<string, ClassModel> ReadLibLcmModel(string xmlPath)
        {
            var serializer = new XmlSerializer(typeof(EntireModel));
            EntireModel lcm;
            using (var reader = XmlReader.Create(xmlPath))
            {
                lcm = (EntireModel)serializer.Deserialize(reader);
            }

            var classModels = new Dictionary<string, ClassModel>
            {   
                // Properties not in XML
                { nameof(LcmModelConstants.LfObject), LcmModelConstants.LfObject },
                // Not in XML, but referenced in XML
                { nameof(LcmModelConstants.LfAnalysis), LcmModelConstants.LfAnalysis },
            };
            var baseClassMappings = new Dictionary<string, string>
            {
                { nameof(LcmModelConstants.LfAnalysis), nameof(LcmModelConstants.LfObject) }
            };

            foreach (var clazz in lcm.CellarModule.SelectMany(m => m.@class ?? Array.Empty<@class>()))
            {
                var className = NameUtils.LcmNameToLf(clazz.id);

                if (classModels.ContainsKey(className))
                {
                    continue;
                }

                baseClassMappings.Add(className, NameUtils.LcmNameToLf(clazz.@base));

                var ConvertToInterface = className.Equals(NameUtils.LcmNameToLf(nameof(ICmMajorObject)));
                classModels.Add(className, new ClassModel
                {
                    Name = className,
                    Abstract = clazz.@abstract && !ConvertToInterface,
                    Docs = GetDocs(clazz.comment, clazz.notes),
                    ConvertToInterface = ConvertToInterface,
                    Properties = clazz.props.Items?.Select(prop =>
                    {
                        if (prop is basic bp)
                        {
                            return new PropertyModel
                            {
                                Name = bp.id,
                                Type = MapValueType(bp.sig, out bool isComplexValueType),
                                Order = int.Parse(bp.num),
                                Cardinality = Cardinality.One,
                                IsOwner = true,
                                ValueType = isComplexValueType ? ValueType.Jsonb : ValueType.Literal,
                                Docs = GetDocs(bp.comment, bp.notes),
                            };
                        }
                        else if (prop is owning op)
                        {
                            return new PropertyModel
                            {
                                Name = op.id,
                                Type = NameUtils.LcmNameToLf(op.sig),
                                Order = int.Parse(op.num),
                                Cardinality = op.card == cardType.atomic ? Cardinality.One : Cardinality.Many,
                                IsOwner = true,
                                ValueType = ValueType.Relation,
                                Docs = GetDocs(op.comment, op.notes),
                            };
                        }
                        else if (prop is rel rp)
                        {
                            return new PropertyModel
                            {
                                Name = rp.id,
                                Type = NameUtils.LcmNameToLf(rp.sig),
                                Order = int.Parse(rp.num),
                                Cardinality = rp.card == cardType.atomic ? Cardinality.One : Cardinality.Many,
                                IsOwner = false,
                                ValueType = ValueType.Relation,
                                Docs = GetDocs(rp.comment, rp.notes),
                            };
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }

                    }).ToList() ?? new List<PropertyModel>(),
                });
            }

            foreach (var clazz in classModels.Values)
            {
                baseClassMappings.TryGetValue(clazz.Name, out var baseClassName);
                var baseClass = baseClassName == null ? null : classModels[baseClassName];

                if (baseClass != null && baseClass.ConvertToInterface)
                {
                    clazz.Interface = baseClass;
                }

                while (baseClass != null && baseClass.ConvertToInterface)
                {
                    clazz.Properties.InsertRange(0, baseClass.Properties);
                    baseClass = baseClass.BaseClass;
                }

                var tableName = NameUtils.PickTableName(clazz.Name, baseClass);
                classModels[clazz.Name].BaseClass = baseClass;
                classModels[clazz.Name].TableName = tableName;
                classModels[clazz.Name].DbAbbrev = NameUtils.PickAbbreviation(tableName);
            }

            foreach (var clazz in classModels.Values)
            {
                if (clazz.ConvertToInterface)
                {
                    var baseClass = clazz.BaseClass;
                    clazz.BaseClass = null;
                    while (baseClass != null && !baseClass.ConvertToInterface)
                    {
                        baseClass = baseClass.BaseClass;
                    }
                    clazz.Interface = baseClass;
                }
            }

            return classModels;
        }

        private static string MapValueType(string type, out bool isComplexValueType)
        {
            isComplexValueType = false;
            switch (type)
            {
                case "Time":
                    return "DateTime";
                case "Integer":
                    return "int";
                case "Unicode":
                    return "string";
                case "Binary":
                    return "byte[]";
                case "TextPropBinary":
                    isComplexValueType = true;
                    return "List<TextProperty>";
                case "MultiString":
                case "MultiUnicode":
                    isComplexValueType = true;
                    return "List<LfWsTsString>";
                case "GenDate":
                    isComplexValueType = true;
                    return type;
                default:
                    return type;
            }
        }

        private static List<string> GetDocs(string[] comment, notes notes)
        {
            if ((comment == null || comment.Length <= 0) && string.IsNullOrEmpty(notes?.para))
            {
                return null;
            }
            var docs = new List<string>();
            var summary = comment == null || comment.Length == 0 ? new string[] { notes.para } : comment;
            var remarks = comment == null || comment.Length == 0 ? null : notes?.para;
            docs.Add("<summary>");
            foreach (var line in summary)
            {
                docs.Add(line);
            }
            docs.Add("</summary>");
            if (!string.IsNullOrEmpty(remarks))
            {
                docs.Add("<remarks>");
                docs.Add(remarks);
                docs.Add("</remarks>");
            }
            return docs;
        }
    }
}