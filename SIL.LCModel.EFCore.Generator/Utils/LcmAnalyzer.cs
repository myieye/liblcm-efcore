using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LfSync.LcmModelGenerator
{
    internal static class LcmAnalyzer
    {

        /** Current Output:
        M:N: Owner:[False:False] -- LfPossibility.Restrictions <-> LfPerson.Researchers Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfPossibility.Restrictions <-> LfLocation.PlacesOfResidence Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfPossibility.Restrictions <-> LfPossibility.Positions Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfPossibility.Restrictions <-> LfAnthroItem.OcmRefs Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfPossibility.Restrictions <-> LfSemanticDomain.RelatedDomains Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfPossibility.Researchers <-> LfPossibility.Restrictions Tables:[Possibility:Possibility]
        M:N: Owner:[False:False] -- LfRnGenericRec.SeeAlso <-> LfRnGenericRec.CounterEvidence Tables:[RnGenericRec:RnGenericRec]
        M:N: Owner:[False:False] -- LfRnGenericRec.SeeAlso <-> LfRnGenericRec.SupersededBy Tables:[RnGenericRec:RnGenericRec]
        M:N: Owner:[False:False] -- LfRnGenericRec.SeeAlso <-> LfRnGenericRec.SupportingEvidence Tables:[RnGenericRec:RnGenericRec]
        M:N: Owner:[False:False] -- LfRnGenericRec.CounterEvidence <-> LfRnGenericRec.SeeAlso Tables:[RnGenericRec:RnGenericRec]
        1:M: Owner:[False:True] -- LfPossibility.Confidence <-> LfPossibility.SubPossibilities Tables:[Possibility:Possibility]
        1:M: Owner:[False:True] -- LfPossibility.Status <-> LfPossibility.SubPossibilities Tables:[Possibility:Possibility]
        1:M: Owner:[False:True] -- LfPerson.PlaceOfBirth <-> LfPossibility.SubPossibilities Tables:[Possibility:Possibility]
        1:M: Owner:[False:True] -- LfPerson.Education <-> LfPossibility.SubPossibilities Tables:[Possibility:Possibility]
        1:M: Owner:[False:True] -- LfRnGenericRec.Text <-> LfRnGenericRec.Records Tables:[RnGenericRec:MajorObject]
        1:M: Owner:[False:True] -- LfMoGlossItem.Target <-> LfMoGlossItem.GlossItems Tables:[MoGlossItem:MoGlossItem]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.RecTypes Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.SenseTypes Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.UsageTypes Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.DomainTypes Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.MorphTypes Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.References Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.VariantEntryTypes Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.ComplexEntryTypes Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.PublicationTypes Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.ExtendedNoteTypes Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.Languages Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.DialectLabels Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfScripture.NoteCategories <-> LfPossibilityList.PartsOfSpeech Tables:[MajorObject:MajorObject]
        1:1: Owner:[True:True] -- LfRnResearchNbk.RecTypes <-> LfPossibilityList.NoteCategories Tables:[MajorObject:MajorObject]
        */

        internal static void LogPotentialBidirectionalNavigationProperties(Dictionary<string, ClassModel> classModels)
        {
            var manyToManyRelations = new List<Relation>();
            var manyToOneRelations = new List<Relation>();
            var oneToOneRelations = new List<Relation>();
            var oneToManyRelations = new List<Relation>();
            foreach (var clazz in classModels.Values)
            {
                foreach (var prop in clazz.Properties)
                {
                    if (prop.ValueType == ValueType.Relation)
                    {
                        var relation = new Relation
                        {
                            Left = clazz,
                            LeftProp = prop,
                            Right = classModels[prop.Type],
                        };
                        if (prop.Cardinality == Cardinality.Many)
                        {
                            if (prop.IsOwner)
                            {
                                manyToOneRelations.Add(relation);
                            }
                            else
                            {
                                manyToManyRelations.Add(relation);
                            }
                        }
                        else
                        {
                            if (prop.Cardinality == Cardinality.One)
                            {
                                if (prop.IsOwner)
                                {
                                    oneToOneRelations.Add(relation);
                                }
                                else
                                {
                                    oneToManyRelations.Add(relation);
                                }
                            }
                        }
                    }
                }
            }

            FindBidirectionalRelations(manyToManyRelations, manyToManyRelations, "M:N", classModels);
            FindBidirectionalRelations(oneToManyRelations, manyToOneRelations, "1:M", classModels);
            FindBidirectionalRelations(oneToOneRelations, oneToOneRelations, "1:1", classModels);
        }

        private static void FindBidirectionalRelations(List<Relation> _relations, List<Relation> _inverseRelations, string tag, Dictionary<string, ClassModel> classModels)
        {
            var relations = new List<Relation>(_relations);
            var inverseRelations = new List<Relation>(_inverseRelations);
            while (relations.Any())
            {
                var from = relations[0];
                relations.RemoveAt(0);
                foreach (var inverse in inverseRelations.Where(to =>
                        to != from
                        && to.Left.TableName == from.Right.TableName
                        && to.Right.TableName == from.Left.TableName).ToList())
                {
                    if (_relations == _inverseRelations)
                    {
                        inverseRelations.Remove(inverse);
                    }
                    var ownerInfo = $"Owner:[{from.LeftProp.IsOwner}:{inverse.LeftProp.IsOwner}]";
                    Console.WriteLine($"{tag}: {ownerInfo} -- {from.Left.Name}.{from.LeftProp.Name} <-> {inverse.LeftProp.Type}.{inverse.LeftProp.Name} Tables:[{from.Left.TableName}:{inverse.Left.TableName}]");
                }
            }
        }

        /** Current Output:

These classes only have owner relations (in their entire hierarchy): (I.e. we could store them as Json in the owning class)
LfNote, LfFilter, LfRow, LfCell, LfPublication, LfPubDivision, LfPubPageLayout, LfPubHFSet, LfPubHeader, LfDomainQ, LfResource, LfScrCheckRun, LfPhCode

These classes have no relations (i.e. are not referenced by any other class. Instances of these values could still have a special meaning and be handled differently, but that meaning could theoretically be captured as an enum property):
LfProject, LfFsComplexFeature, LfMajorObject, LfStTxtPara, LfCustomItem, LfIndirectAnnotation, LfBaseAnnotation, LfMediaAnnotation, LfStFootnote, LfFsClosedFeature, LfFsClosedValue, LfFsComplexValue, LfFsDisjunctiveValue, LfFsNegatedValue, LfFsOpenFeature, LfFsOpenValue, LfFsSharedValue, LfVirtualOrdering, LfScrRefSystem, LfScrImportP6Project, LfScrImportSFFiles, LfConstChartMovedTextMarker, LfConstChartClauseMarker, LfConstChartTag, LfPunctuationForm, LfMoAffixProcess, LfMoEndoCompound, LfMoExoCompound, LfMoInsertPhones, LfMoInsertNC, LfMoModifyFromInput, LfMoDerivTrace, LfPhIterationContext, LfPhSequenceContext, LfPhSimpleContextBdry, LfPhSimpleContextNC, LfPhSimpleContextSeg, LfPhVariable, LfPhNCSegments, LfMoAlloAdhocProhib, LfMoMorphAdhocProhib, LfMoCopyFromInput, LfMoBinaryCompoundRule, LfMoCoordinateCompound, LfMoAdhocProhibGr, LfMoUnclassifiedAffixMsa, LfLexRefType, LfChkSense, LfDsConstChart, LfChkTerm, LfPhRegularRule, LfPhMetathesisRule, LfLangProject.

These abstract classes have no relations: (and could presumably safely be converted to interfaces/removed from the (database) hierarchy (as LfMajorObject was))
LfProject, LfMoDerivTrace.

These classes have 1 inheriting class: (I.e. they could potentially be squashed together, but would need an alternative discriminator at run time and an interface might be beneficial)
LfProject, LfStPara, LfStTxtPara, LfBaseAnnotation, LfStFootnote, LfMoCompoundRule, LfLexEntryType, LfDsChart

These abstract classes have 1 inheriting class: (they could presumably be squashed together)
LfProject, LfStPara, LfMoCompoundRule, LfDsChart.

LfFolder is owned by 2 classes: LfFolder, LfLangProject
LfFile is owned by 2 classes: LfFolder, LfScrImportSFFiles
LfPubHFSet is owned by 2 classes: LfMajorObject, LfPubDivision
LfPossibility is owned by 2 classes: LfPossibility, LfPossibilityList
LfStText is owned by 10 classes: LfPossibility, LfAgent, LfAnnotation, LfScrBook, LfScrSection, LfRnGenericRec, LfLexDb, LfLexAppendix, LfText, LfPhPhonContext
LfTranslation is owned by 2 classes: LfStTxtPara, LfLexExampleSentence
LfFsFeatStruc is owned by 18 classes: LfAnnotation, LfFsFeatStrucDisj, LfMoStemMsa, LfMoAffixAllomorph, LfMoDerivAffMsa, LfMoDerivStepMsa, LfMoInflAffixTemplate, LfMoInflAffMsa, LfMoInflClass, LfMoReferralRule, LfMoStemName, LfPartOfSpeech, LfWfiAnalysis, LfPhPhoneme, LfPhNCFeatures, LfMoDeriv, LfMoGlossItem, LfLexEntryInflType
LfFsFeatureSpecification is owned by 2 classes: LfFsFeatDefn, LfFsFeatStruc
LfScrBook is owned by 2 classes: LfScripture, LfScrDraft
LfStStyle is owned by 2 classes: LfScripture, LfLangProject
LfPossibilityList is owned by 8 classes: LfScripture, LfRnResearchNbk, LfLexDb, LfMoMorphData, LfReversalIndex, LfPhPhonData, LfDsDiscourseData, LfLangProject
LfResource is owned by 2 classes: LfScripture, LfLexDb
LfRnGenericRec is owned by 2 classes: LfRnResearchNbk, LfRnGenericRec
LfLexSense is owned by 2 classes: LfLexEntry, LfLexSense
LfLexExampleSentence is owned by 2 classes: LfLexSense, LfLexExtendedNote
LfPhContextOrVar is owned by 2 classes: LfMoAffixProcess, LfPhPhonData
LfMoStemMsa is owned by 3 classes: LfMoEndoCompound, LfMoExoCompound, LfMoBinaryCompoundRule
LfMoInflClass is owned by 2 classes: LfMoInflClass, LfPartOfSpeech
LfMoReferralRule is owned by 2 classes: LfMoInflClass, LfPartOfSpeech
LfMoStemName is owned by 2 classes: LfMoInflClass, LfPartOfSpeech
LfMoAdhocProhib is owned by 2 classes: LfMoMorphData, LfMoAdhocProhibGr
LfReversalIndexEntry is owned by 2 classes: LfReversalIndex, LfReversalIndexEntry
LfMoGlossItem is owned by 2 classes: LfMoGlossSystem, LfMoGlossItem
LfPhSimpleContext is owned by 2 classes: LfPhSegmentRule, LfPhSegRuleRHS

*/
        public static void LogRelationInfo(Dictionary<string, ClassModel> classModels)
        {
            var ownerRelations = new Dictionary<ClassModel, ISet<ClassModel>>();
            var nonOwnerRelations = new Dictionary<ClassModel, ISet<ClassModel>>();

            foreach (var clazz in classModels.Values)
            {
                foreach (var prop in clazz.Properties)
                {
                    if (prop.ValueType == ValueType.Relation)
                    {
                        var relationDict = prop.IsOwner ? ownerRelations : nonOwnerRelations;
                        var relation = classModels[prop.Type];
                        if (!relationDict.ContainsKey(relation))
                        {
                            relationDict.Add(relation, new HashSet<ClassModel>());
                        }
                        relationDict[relation].Add(clazz);
                    }
                }
            }

            bool HasNoNonOwnerRelations(ClassModel clazz, ISet<ClassModel> visited = null)
            {
                if (visited == null)
                {
                    visited = new HashSet<ClassModel>();
                }
                if (visited.Contains(clazz))
                {
                    return true;
                }
                visited.Add(clazz);
                var hierarchy = classModels.Values.Where(c => c.TableName?.Equals(clazz.TableName) ?? false).ToList();
                return hierarchy.All(c => !nonOwnerRelations.ContainsKey(c) &&
                    c.Properties.Where(p => p.ValueType == ValueType.Relation)
                        .All(p => HasNoNonOwnerRelations(classModels[p.Type], visited)));
            }

            var onlyOwners = classModels.Values.Where(c => ownerRelations.ContainsKey(c) && HasNoNonOwnerRelations(c))
                .Select(c => c.Name);
            Console.Out.WriteLine($"These classes only have owner relations:\n{string.Join(", ", onlyOwners)}.");

            var noRelations = classModels.Values.Where(c => !ownerRelations.ContainsKey(c) && !nonOwnerRelations.ContainsKey(c)).ToList();
            Console.Out.WriteLine($"These classes have no relations:\n{string.Join(", ", noRelations.Select(c => c.Name))}.");

            var abstractNoRelations = noRelations.Where(c => c.Abstract);
            Console.Out.WriteLine($"These abstract classes have no relations:\n{string.Join(", ", abstractNoRelations.Select(c => c.Name))}.");

            var oneDerivingClass = classModels.Values.Where(c => classModels.Values.Count(c2 => c2.BaseClass == c) == 1).ToList();
            Console.Out.WriteLine($"These classes have 1 inheriting class:\n{string.Join(", ", oneDerivingClass.Select(c => c.Name))}.");

            var oneDerivingAbstractClass = oneDerivingClass.Where(c => c.Abstract).ToList();
            Console.Out.WriteLine($"These abstract classes have 1 inheriting class:\n{string.Join(", ", oneDerivingAbstractClass.Select(c => c.Name))}.");

            var results = new StringBuilder();
            foreach (var owned in ownerRelations.Where(o => o.Value.Count > 1))
            {
                var ownerNames = owned.Value.Select(o => o.Name).ToList();
                results.AppendLine($"{owned.Key.Name} is owned by {owned.Value.Count} classes: {string.Join(", ", ownerNames)}");
            }
            Console.Out.WriteLine(results.ToString());
        }
    }
}