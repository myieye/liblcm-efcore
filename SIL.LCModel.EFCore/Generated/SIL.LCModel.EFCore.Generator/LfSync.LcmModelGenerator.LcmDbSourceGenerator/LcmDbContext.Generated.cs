using Microsoft.EntityFrameworkCore;
using SIL.LCModel.EFCore.Model;

namespace SIL.LCModel.EFCore;

public partial class LcmDbContext : DbContext
{
    public DbSet<LfAnalysis> Analysiss { get; set; }

    public DbSet<LfProject> Projects { get; set; }

    public DbSet<LfFolder> Folders { get; set; }

    public DbSet<LfNote> Notes { get; set; }

    public DbSet<LfFsComplexFeature> FsComplexFeatures { get; set; }

    public DbSet<LfSegment> Segments { get; set; }

    public DbSet<LfPossibility> Possibilitys { get; set; }

    public DbSet<LfPossibilityList> PossibilityLists { get; set; }

    public DbSet<LfFilter> Filters { get; set; }

    public DbSet<LfRow> Rows { get; set; }

    public DbSet<LfCell> Cells { get; set; }

    public DbSet<LfLocation> Locations { get; set; }

    public DbSet<LfPerson> Persons { get; set; }

    public DbSet<LfStText> StTexts { get; set; }

    public DbSet<LfStPara> StParas { get; set; }

    public DbSet<LfStTxtPara> StTxtParas { get; set; }

    public DbSet<LfStStyle> StStyles { get; set; }

    public DbSet<LfOverlay> Overlays { get; set; }

    public DbSet<LfTextTag> TextTags { get; set; }

    public DbSet<LfAgent> Agents { get; set; }

    public DbSet<LfAnthroItem> AnthroItems { get; set; }

    public DbSet<LfCustomItem> CustomItems { get; set; }

    public DbSet<LfCrossReference> CrossReferences { get; set; }

    public DbSet<LfTranslation> Translations { get; set; }

    public DbSet<LfAgentEvaluation> AgentEvaluations { get; set; }

    public DbSet<LfAnnotation> Annotations { get; set; }

    public DbSet<LfAnnotationDefn> AnnotationDefns { get; set; }

    public DbSet<LfIndirectAnnotation> IndirectAnnotations { get; set; }

    public DbSet<LfBaseAnnotation> BaseAnnotations { get; set; }

    public DbSet<LfMediaAnnotation> MediaAnnotations { get; set; }

    public DbSet<LfStFootnote> StFootnotes { get; set; }

    public DbSet<LfUserConfigAcct> UserConfigAccts { get; set; }

    public DbSet<LfUserAppFeatAct> UserAppFeatActs { get; set; }

    public DbSet<LfPublication> Publications { get; set; }

    public DbSet<LfPubDivision> PubDivisions { get; set; }

    public DbSet<LfPubPageLayout> PubPageLayouts { get; set; }

    public DbSet<LfPubHFSet> PubHFSets { get; set; }

    public DbSet<LfPubHeader> PubHeaders { get; set; }

    public DbSet<LfFile> Files { get; set; }

    public DbSet<LfPicture> Pictures { get; set; }

    public DbSet<LfFsFeatureSystem> FsFeatureSystems { get; set; }

    public DbSet<LfFsClosedFeature> FsClosedFeatures { get; set; }

    public DbSet<LfFsClosedValue> FsClosedValues { get; set; }

    public DbSet<LfFsComplexValue> FsComplexValues { get; set; }

    public DbSet<LfFsDisjunctiveValue> FsDisjunctiveValues { get; set; }

    public DbSet<LfFsFeatDefn> FsFeatDefns { get; set; }

    public DbSet<LfFsFeatureSpecification> FsFeatureSpecifications { get; set; }

    public DbSet<LfFsFeatStruc> FsFeatStrucs { get; set; }

    public DbSet<LfFsFeatStrucDisj> FsFeatStrucDisjs { get; set; }

    public DbSet<LfFsFeatStrucType> FsFeatStrucTypes { get; set; }

    public DbSet<LfFsAbstractStructure> FsAbstractStructures { get; set; }

    public DbSet<LfFsNegatedValue> FsNegatedValues { get; set; }

    public DbSet<LfFsOpenFeature> FsOpenFeatures { get; set; }

    public DbSet<LfFsOpenValue> FsOpenValues { get; set; }

    public DbSet<LfFsSharedValue> FsSharedValues { get; set; }

    public DbSet<LfFsSymFeatVal> FsSymFeatVals { get; set; }

    public DbSet<LfSemanticDomain> SemanticDomains { get; set; }

    public DbSet<LfDomainQ> DomainQs { get; set; }

    public DbSet<LfStJournalText> StJournalTexts { get; set; }

    public DbSet<LfMedia> Medias { get; set; }

    public DbSet<LfResource> Resources { get; set; }

    public DbSet<LfVirtualOrdering> VirtualOrderings { get; set; }

    public DbSet<LfMediaURI> MediaURIs { get; set; }

    public DbSet<LfMediaContainer> MediaContainers { get; set; }

    public DbSet<LfScripture> Scriptures { get; set; }

    public DbSet<LfScrBook> ScrBooks { get; set; }

    public DbSet<LfScrRefSystem> ScrRefSystems { get; set; }

    public DbSet<LfScrBookRef> ScrBookRefs { get; set; }

    public DbSet<LfScrSection> ScrSections { get; set; }

    public DbSet<LfScrImportSet> ScrImportSets { get; set; }

    public DbSet<LfScrDraft> ScrDrafts { get; set; }

    public DbSet<LfScrDifference> ScrDifferences { get; set; }

    public DbSet<LfScrImportSource> ScrImportSources { get; set; }

    public DbSet<LfScrImportP6Project> ScrImportP6Projects { get; set; }

    public DbSet<LfScrImportSFFiles> ScrImportSFFiless { get; set; }

    public DbSet<LfScrMarkerMapping> ScrMarkerMappings { get; set; }

    public DbSet<LfScrBookAnnotations> ScrBookAnnotationss { get; set; }

    public DbSet<LfScrScriptureNote> ScrScriptureNotes { get; set; }

    public DbSet<LfScrCheckRun> ScrCheckRuns { get; set; }

    public DbSet<LfScrTxtPara> ScrTxtParas { get; set; }

    public DbSet<LfScrFootnote> ScrFootnotes { get; set; }

    public DbSet<LfRnResearchNbk> RnResearchNbks { get; set; }

    public DbSet<LfRnGenericRec> RnGenericRecs { get; set; }

    public DbSet<LfReminder> Reminders { get; set; }

    public DbSet<LfRnRoledPartic> RnRoledPartics { get; set; }

    public DbSet<LfMoStemMsa> MoStemMsas { get; set; }

    public DbSet<LfLexEntry> LexEntrys { get; set; }

    public DbSet<LfConstChartRow> ConstChartRows { get; set; }

    public DbSet<LfLexExampleSentence> LexExampleSentences { get; set; }

    public DbSet<LfLexDb> LexDbs { get; set; }

    public DbSet<LfConstituentChartCellPart> ConstituentChartCellParts { get; set; }

    public DbSet<LfConstChartWordGroup> ConstChartWordGroups { get; set; }

    public DbSet<LfConstChartMovedTextMarker> ConstChartMovedTextMarkers { get; set; }

    public DbSet<LfConstChartClauseMarker> ConstChartClauseMarkers { get; set; }

    public DbSet<LfConstChartTag> ConstChartTags { get; set; }

    public DbSet<LfPunctuationForm> PunctuationForms { get; set; }

    public DbSet<LfLexPronunciation> LexPronunciations { get; set; }

    public DbSet<LfLexSense> LexSenses { get; set; }

    public DbSet<LfMoAdhocProhib> MoAdhocProhibs { get; set; }

    public DbSet<LfMoAffixAllomorph> MoAffixAllomorphs { get; set; }

    public DbSet<LfMoAffixForm> MoAffixForms { get; set; }

    public DbSet<LfMoAffixProcess> MoAffixProcesss { get; set; }

    public DbSet<LfMoCompoundRule> MoCompoundRules { get; set; }

    public DbSet<LfMoDerivAffMsa> MoDerivAffMsas { get; set; }

    public DbSet<LfMoDerivStepMsa> MoDerivStepMsas { get; set; }

    public DbSet<LfMoEndoCompound> MoEndoCompounds { get; set; }

    public DbSet<LfMoExoCompound> MoExoCompounds { get; set; }

    public DbSet<LfMoForm> MoForms { get; set; }

    public DbSet<LfMoInflAffixSlot> MoInflAffixSlots { get; set; }

    public DbSet<LfMoInflAffixTemplate> MoInflAffixTemplates { get; set; }

    public DbSet<LfMoInflAffMsa> MoInflAffMsas { get; set; }

    public DbSet<LfMoInflClass> MoInflClasss { get; set; }

    public DbSet<LfMoMorphData> MoMorphDatas { get; set; }

    public DbSet<LfMoMorphSynAnalysis> MoMorphSynAnalysiss { get; set; }

    public DbSet<LfMoMorphType> MoMorphTypes { get; set; }

    public DbSet<LfMoReferralRule> MoReferralRules { get; set; }

    public DbSet<LfMoStemAllomorph> MoStemAllomorphs { get; set; }

    public DbSet<LfLexAppendix> LexAppendixs { get; set; }

    public DbSet<LfMoStemName> MoStemNames { get; set; }

    public DbSet<LfMoStratum> MoStratums { get; set; }

    public DbSet<LfPartOfSpeech> PartOfSpeechs { get; set; }

    public DbSet<LfReversalIndex> ReversalIndexs { get; set; }

    public DbSet<LfReversalIndexEntry> ReversalIndexEntrys { get; set; }

    public DbSet<LfText> Texts { get; set; }

    public DbSet<LfWfiAnalysis> WfiAnalysiss { get; set; }

    public DbSet<LfWfiGloss> WfiGlosss { get; set; }

    public DbSet<LfWfiWordform> WfiWordforms { get; set; }

    public DbSet<LfWordFormLookup> WordFormLookups { get; set; }

    public DbSet<LfWordformLookupList> WordformLookupLists { get; set; }

    public DbSet<LfMoRuleMapping> MoRuleMappings { get; set; }

    public DbSet<LfMoInsertPhones> MoInsertPhoness { get; set; }

    public DbSet<LfMoInsertNC> MoInsertNCs { get; set; }

    public DbSet<LfMoModifyFromInput> MoModifyFromInputs { get; set; }

    public DbSet<LfMoDerivTrace> MoDerivTraces { get; set; }

    public DbSet<LfMoCompoundRuleApp> MoCompoundRuleApps { get; set; }

    public DbSet<LfMoDerivAffApp> MoDerivAffApps { get; set; }

    public DbSet<LfMoInflAffixSlotApp> MoInflAffixSlotApps { get; set; }

    public DbSet<LfMoInflTemplateApp> MoInflTemplateApps { get; set; }

    public DbSet<LfMoPhonolRuleApp> MoPhonolRuleApps { get; set; }

    public DbSet<LfMoStratumApp> MoStratumApps { get; set; }

    public DbSet<LfPhContextOrVar> PhContextOrVars { get; set; }

    public DbSet<LfPhPhonContext> PhPhonContexts { get; set; }

    public DbSet<LfPhIterationContext> PhIterationContexts { get; set; }

    public DbSet<LfPhSequenceContext> PhSequenceContexts { get; set; }

    public DbSet<LfPhSimpleContext> PhSimpleContexts { get; set; }

    public DbSet<LfPhSimpleContextBdry> PhSimpleContextBdrys { get; set; }

    public DbSet<LfPhSimpleContextNC> PhSimpleContextNCs { get; set; }

    public DbSet<LfPhSimpleContextSeg> PhSimpleContextSegs { get; set; }

    public DbSet<LfPhVariable> PhVariables { get; set; }

    public DbSet<LfPhPhonemeSet> PhPhonemeSets { get; set; }

    public DbSet<LfPhTerminalUnit> PhTerminalUnits { get; set; }

    public DbSet<LfPhBdryMarker> PhBdryMarkers { get; set; }

    public DbSet<LfPhPhoneme> PhPhonemes { get; set; }

    public DbSet<LfPhNaturalClass> PhNaturalClasss { get; set; }

    public DbSet<LfPhNCFeatures> PhNCFeaturess { get; set; }

    public DbSet<LfPhNCSegments> PhNCSegmentss { get; set; }

    public DbSet<LfPhFeatureConstraint> PhFeatureConstraints { get; set; }

    public DbSet<LfPhEnvironment> PhEnvironments { get; set; }

    public DbSet<LfPhCode> PhCodes { get; set; }

    public DbSet<LfPhPhonData> PhPhonDatas { get; set; }

    public DbSet<LfMoDeriv> MoDerivs { get; set; }

    public DbSet<LfMoAlloAdhocProhib> MoAlloAdhocProhibs { get; set; }

    public DbSet<LfMoMorphAdhocProhib> MoMorphAdhocProhibs { get; set; }

    public DbSet<LfMoCopyFromInput> MoCopyFromInputs { get; set; }

    public DbSet<LfWfiWordSet> WfiWordSets { get; set; }

    public DbSet<LfMoBinaryCompoundRule> MoBinaryCompoundRules { get; set; }

    public DbSet<LfMoCoordinateCompound> MoCoordinateCompounds { get; set; }

    public DbSet<LfMoGlossSystem> MoGlossSystems { get; set; }

    public DbSet<LfMoGlossItem> MoGlossItems { get; set; }

    public DbSet<LfMoAdhocProhibGr> MoAdhocProhibGrs { get; set; }

    public DbSet<LfWfiMorphBundle> WfiMorphBundles { get; set; }

    public DbSet<LfLexEtymology> LexEtymologys { get; set; }

    public DbSet<LfChkRef> ChkRefs { get; set; }

    public DbSet<LfMoUnclassifiedAffixMsa> MoUnclassifiedAffixMsas { get; set; }

    public DbSet<LfLexEntryType> LexEntryTypes { get; set; }

    public DbSet<LfLexRefType> LexRefTypes { get; set; }

    public DbSet<LfLexReference> LexReferences { get; set; }

    public DbSet<LfChkSense> ChkSenses { get; set; }

    public DbSet<LfDsChart> DsCharts { get; set; }

    public DbSet<LfDsConstChart> DsConstCharts { get; set; }

    public DbSet<LfDsDiscourseData> DsDiscourseDatas { get; set; }

    public DbSet<LfChkTerm> ChkTerms { get; set; }

    public DbSet<LfChkRendering> ChkRenderings { get; set; }

    public DbSet<LfLexEntryRef> LexEntryRefs { get; set; }

    public DbSet<LfPhSegmentRule> PhSegmentRules { get; set; }

    public DbSet<LfPhRegularRule> PhRegularRules { get; set; }

    public DbSet<LfPhMetathesisRule> PhMetathesisRules { get; set; }

    public DbSet<LfPhSegRuleRHS> PhSegRuleRHSs { get; set; }

    public DbSet<LfPhPhonRuleFeat> PhPhonRuleFeats { get; set; }

    public DbSet<LfLexEntryInflType> LexEntryInflTypes { get; set; }

    public DbSet<LfLexExtendedNote> LexExtendedNotes { get; set; }

    public DbSet<LfLangProject> LangProjects { get; set; }

    partial void OnModelCreating_Generated(ModelBuilder builder)
    {
        builder.Ignore<LfObject>();
        builder.Entity<LfAnalysis>();
        builder.Entity<LfProject>();
        builder.Entity<LfFolder>();
        builder.Entity<LfNote>();
        builder.Entity<LfFsComplexFeature>();
        builder.Entity<LfSegment>();
        builder.Entity<LfPossibility>();
        builder.Entity<LfPossibilityList>();
        builder.Entity<LfFilter>();
        builder.Entity<LfRow>();
        builder.Entity<LfCell>();
        builder.Entity<LfLocation>();
        builder.Entity<LfPerson>();
        builder.Entity<LfStText>();
        builder.Entity<LfStPara>();
        builder.Entity<LfStTxtPara>();
        builder.Entity<LfStStyle>();
        builder.Entity<LfOverlay>();
        builder.Entity<LfTextTag>();
        builder.Entity<LfAgent>();
        builder.Entity<LfAnthroItem>();
        builder.Entity<LfCustomItem>();
        builder.Entity<LfCrossReference>();
        builder.Entity<LfTranslation>();
        builder.Entity<LfAgentEvaluation>();
        builder.Entity<LfAnnotation>();
        builder.Entity<LfAnnotationDefn>();
        builder.Entity<LfIndirectAnnotation>();
        builder.Entity<LfBaseAnnotation>();
        builder.Entity<LfMediaAnnotation>();
        builder.Entity<LfStFootnote>();
        builder.Entity<LfUserConfigAcct>();
        builder.Entity<LfUserAppFeatAct>();
        builder.Entity<LfPublication>();
        builder.Entity<LfPubDivision>();
        builder.Entity<LfPubPageLayout>();
        builder.Entity<LfPubHFSet>();
        builder.Entity<LfPubHeader>();
        builder.Entity<LfFile>();
        builder.Entity<LfPicture>();
        builder.Entity<LfFsFeatureSystem>();
        builder.Entity<LfFsClosedFeature>();
        builder.Entity<LfFsClosedValue>();
        builder.Entity<LfFsComplexValue>();
        builder.Entity<LfFsDisjunctiveValue>();
        builder.Entity<LfFsFeatDefn>();
        builder.Entity<LfFsFeatureSpecification>();
        builder.Entity<LfFsFeatStruc>();
        builder.Entity<LfFsFeatStrucDisj>();
        builder.Entity<LfFsFeatStrucType>();
        builder.Entity<LfFsAbstractStructure>();
        builder.Entity<LfFsNegatedValue>();
        builder.Entity<LfFsOpenFeature>();
        builder.Entity<LfFsOpenValue>();
        builder.Entity<LfFsSharedValue>();
        builder.Entity<LfFsSymFeatVal>();
        builder.Entity<LfSemanticDomain>();
        builder.Entity<LfDomainQ>();
        builder.Entity<LfStJournalText>();
        builder.Entity<LfMedia>();
        builder.Entity<LfResource>();
        builder.Entity<LfVirtualOrdering>();
        builder.Entity<LfMediaURI>();
        builder.Entity<LfMediaContainer>();
        builder.Entity<LfScripture>();
        builder.Entity<LfScrBook>();
        builder.Entity<LfScrRefSystem>();
        builder.Entity<LfScrBookRef>();
        builder.Entity<LfScrSection>();
        builder.Entity<LfScrImportSet>();
        builder.Entity<LfScrDraft>();
        builder.Entity<LfScrDifference>();
        builder.Entity<LfScrImportSource>();
        builder.Entity<LfScrImportP6Project>();
        builder.Entity<LfScrImportSFFiles>();
        builder.Entity<LfScrMarkerMapping>();
        builder.Entity<LfScrBookAnnotations>();
        builder.Entity<LfScrScriptureNote>();
        builder.Entity<LfScrCheckRun>();
        builder.Entity<LfScrTxtPara>();
        builder.Entity<LfScrFootnote>();
        builder.Entity<LfRnResearchNbk>();
        builder.Entity<LfRnGenericRec>();
        builder.Entity<LfReminder>();
        builder.Entity<LfRnRoledPartic>();
        builder.Entity<LfMoStemMsa>();
        builder.Entity<LfLexEntry>();
        builder.Entity<LfConstChartRow>();
        builder.Entity<LfLexExampleSentence>();
        builder.Entity<LfLexDb>();
        builder.Entity<LfConstituentChartCellPart>();
        builder.Entity<LfConstChartWordGroup>();
        builder.Entity<LfConstChartMovedTextMarker>();
        builder.Entity<LfConstChartClauseMarker>();
        builder.Entity<LfConstChartTag>();
        builder.Entity<LfPunctuationForm>();
        builder.Entity<LfLexPronunciation>();
        builder.Entity<LfLexSense>();
        builder.Entity<LfMoAdhocProhib>();
        builder.Entity<LfMoAffixAllomorph>();
        builder.Entity<LfMoAffixForm>();
        builder.Entity<LfMoAffixProcess>();
        builder.Entity<LfMoCompoundRule>();
        builder.Entity<LfMoDerivAffMsa>();
        builder.Entity<LfMoDerivStepMsa>();
        builder.Entity<LfMoEndoCompound>();
        builder.Entity<LfMoExoCompound>();
        builder.Entity<LfMoForm>();
        builder.Entity<LfMoInflAffixSlot>();
        builder.Entity<LfMoInflAffixTemplate>();
        builder.Entity<LfMoInflAffMsa>();
        builder.Entity<LfMoInflClass>();
        builder.Entity<LfMoMorphData>();
        builder.Entity<LfMoMorphSynAnalysis>();
        builder.Entity<LfMoMorphType>();
        builder.Entity<LfMoReferralRule>();
        builder.Entity<LfMoStemAllomorph>();
        builder.Entity<LfLexAppendix>();
        builder.Entity<LfMoStemName>();
        builder.Entity<LfMoStratum>();
        builder.Entity<LfPartOfSpeech>();
        builder.Entity<LfReversalIndex>();
        builder.Entity<LfReversalIndexEntry>();
        builder.Entity<LfText>();
        builder.Entity<LfWfiAnalysis>();
        builder.Entity<LfWfiGloss>();
        builder.Entity<LfWfiWordform>();
        builder.Entity<LfWordFormLookup>();
        builder.Entity<LfWordformLookupList>();
        builder.Entity<LfMoRuleMapping>();
        builder.Entity<LfMoInsertPhones>();
        builder.Entity<LfMoInsertNC>();
        builder.Entity<LfMoModifyFromInput>();
        builder.Entity<LfMoDerivTrace>();
        builder.Entity<LfMoCompoundRuleApp>();
        builder.Entity<LfMoDerivAffApp>();
        builder.Entity<LfMoInflAffixSlotApp>();
        builder.Entity<LfMoInflTemplateApp>();
        builder.Entity<LfMoPhonolRuleApp>();
        builder.Entity<LfMoStratumApp>();
        builder.Entity<LfPhContextOrVar>();
        builder.Entity<LfPhPhonContext>();
        builder.Entity<LfPhIterationContext>();
        builder.Entity<LfPhSequenceContext>();
        builder.Entity<LfPhSimpleContext>();
        builder.Entity<LfPhSimpleContextBdry>();
        builder.Entity<LfPhSimpleContextNC>();
        builder.Entity<LfPhSimpleContextSeg>();
        builder.Entity<LfPhVariable>();
        builder.Entity<LfPhPhonemeSet>();
        builder.Entity<LfPhTerminalUnit>();
        builder.Entity<LfPhBdryMarker>();
        builder.Entity<LfPhPhoneme>();
        builder.Entity<LfPhNaturalClass>();
        builder.Entity<LfPhNCFeatures>();
        builder.Entity<LfPhNCSegments>();
        builder.Entity<LfPhFeatureConstraint>();
        builder.Entity<LfPhEnvironment>();
        builder.Entity<LfPhCode>();
        builder.Entity<LfPhPhonData>();
        builder.Entity<LfMoDeriv>();
        builder.Entity<LfMoAlloAdhocProhib>();
        builder.Entity<LfMoMorphAdhocProhib>();
        builder.Entity<LfMoCopyFromInput>();
        builder.Entity<LfWfiWordSet>();
        builder.Entity<LfMoBinaryCompoundRule>();
        builder.Entity<LfMoCoordinateCompound>();
        builder.Entity<LfMoGlossSystem>();
        builder.Entity<LfMoGlossItem>();
        builder.Entity<LfMoAdhocProhibGr>();
        builder.Entity<LfWfiMorphBundle>();
        builder.Entity<LfLexEtymology>();
        builder.Entity<LfChkRef>();
        builder.Entity<LfMoUnclassifiedAffixMsa>();
        builder.Entity<LfLexEntryType>();
        builder.Entity<LfLexRefType>();
        builder.Entity<LfLexReference>();
        builder.Entity<LfChkSense>();
        builder.Entity<LfDsChart>();
        builder.Entity<LfDsConstChart>();
        builder.Entity<LfDsDiscourseData>();
        builder.Entity<LfChkTerm>();
        builder.Entity<LfChkRendering>();
        builder.Entity<LfLexEntryRef>();
        builder.Entity<LfPhSegmentRule>();
        builder.Entity<LfPhRegularRule>();
        builder.Entity<LfPhMetathesisRule>();
        builder.Entity<LfPhSegRuleRHS>();
        builder.Entity<LfPhPhonRuleFeat>();
        builder.Entity<LfLexEntryInflType>();
        builder.Entity<LfLexExtendedNote>();
        builder.Entity<LfLangProject>();
        builder.Entity<LfAnalysis>()
        .HasOne(e => e.Wordform)
        .WithMany()
        .HasForeignKey(e => e.WordformGuid);
        builder.Entity<LfAnalysis>()
        .HasOne(e => e.Analysis)
        .WithMany()
        .HasForeignKey(e => e.AnalysisGuid);
        builder.Entity<LfFolder>()
        .HasMany(e => e.SubFolders)
        .WithOne()
        .HasForeignKey("Folder_SubFoldersGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfFolder>()
        .HasMany(e => e.Files)
        .WithOne()
        .HasForeignKey("Folder_FilesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfFsComplexFeature>()
        .HasOne(e => e.Type)
        .WithMany()
        .HasForeignKey(e => e.TypeGuid);
        builder.Entity<LfSegment>()
        .HasMany(e => e.Notes)
        .WithOne()
        .HasForeignKey("Segment_NotesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfSegment>()
        .HasMany(e => e.Analyses)
        .WithMany()
        .UsingEntity(j => j.ToTable($"Segment_Analyses_Analysis"));
        builder.Entity<LfSegment>()
        .HasOne(e => e.MediaURI)
        .WithMany()
        .HasForeignKey(e => e.MediaURIGuid);
        builder.Entity<LfSegment>()
        .HasOne(e => e.Speaker)
        .WithMany()
        .HasForeignKey(e => e.SpeakerGuid);
        builder.Entity<LfPossibility>()
        .HasMany(e => e.SubPossibilities)
        .WithOne()
        .HasForeignKey("Possibility_SubPossibilitiesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPossibility>()
        .HasMany(e => e.Restrictions)
        .WithMany()
        .UsingEntity(j => j.ToTable($"Possibility_Restrictions_Possibility"));
        builder.Entity<LfPossibility>()
        .HasOne(e => e.Confidence)
        .WithMany()
        .HasForeignKey(e => e.ConfidenceGuid);
        builder.Entity<LfPossibility>()
        .HasOne(e => e.Status)
        .WithMany()
        .HasForeignKey(e => e.StatusGuid);
        builder.Entity<LfPossibility>()
        .HasOne(e => e.Discussion)
        .WithOne()
        .HasForeignKey<LfPossibility>(e => e.DiscussionGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPossibility>()
        .HasMany(e => e.Researchers)
        .WithMany()
        .UsingEntity(j => j.ToTable($"Possibility_Researchers_Possibility"));
        builder.Entity<LfPossibilityList>()
        .HasMany(e => e.Publications)
        .WithOne()
        .HasForeignKey("PossibilityList_PublicationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPossibilityList>()
        .HasMany(e => e.HeaderFooterSets)
        .WithOne()
        .HasForeignKey("PossibilityList_HeaderFooterSetsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPossibilityList>()
        .HasMany(e => e.Possibilities)
        .WithOne()
        .HasForeignKey("PossibilityList_PossibilitiesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfFilter>()
        .HasMany(e => e.Rows)
        .WithOne()
        .HasForeignKey("Filter_RowsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRow>()
        .HasMany(e => e.Cells)
        .WithOne()
        .HasForeignKey("Row_CellsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPerson>()
        .HasOne(e => e.PlaceOfBirth)
        .WithMany()
        .HasForeignKey(e => e.PlaceOfBirthGuid);
        builder.Entity<LfPerson>()
        .HasMany(e => e.PlacesOfResidence)
        .WithMany()
        .UsingEntity(j => j.ToTable($"Person_PlacesOfResidence_Possibility"));
        builder.Entity<LfPerson>()
        .HasOne(e => e.Education)
        .WithMany()
        .HasForeignKey(e => e.EducationGuid);
        builder.Entity<LfPerson>()
        .HasMany(e => e.Positions)
        .WithMany()
        .UsingEntity(j => j.ToTable($"Person_Positions_Possibility"));
        builder.Entity<LfStText>()
        .HasMany(e => e.Paragraphs)
        .WithOne()
        .HasForeignKey("StText_ParagraphsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfStText>()
        .HasMany(e => e.Tags)
        .WithOne()
        .HasForeignKey("StText_TagsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfStTxtPara>()
        .HasMany(e => e.TextObjects)
        .WithMany()
        .UsingEntity(j => j.ToTable($"StTxtPara_TextObjects_ObjectId"));
        builder.Entity<LfStTxtPara>()
        .HasMany(e => e.AnalyzedTextObjects)
        .WithOne()
        .HasForeignKey("StPara_AnalyzedTextObjectsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfStTxtPara>()
        .HasMany(e => e.Segments)
        .WithOne()
        .HasForeignKey("StPara_SegmentsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfStTxtPara>()
        .HasMany(e => e.Translations)
        .WithOne()
        .HasForeignKey("StPara_TranslationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfStStyle>()
        .HasOne(e => e.BasedOn)
        .WithMany()
        .HasForeignKey(e => e.BasedOnGuid);
        builder.Entity<LfStStyle>()
        .HasOne(e => e.Next)
        .WithMany()
        .HasForeignKey(e => e.NextGuid);
        builder.Entity<LfOverlay>()
        .HasOne(e => e.PossList)
        .WithMany()
        .HasForeignKey(e => e.PossListGuid);
        builder.Entity<LfOverlay>()
        .HasMany(e => e.PossItems)
        .WithMany()
        .UsingEntity(j => j.ToTable($"Overlay_PossItems_Possibility"));
        builder.Entity<LfTextTag>()
        .HasOne(e => e.BeginSegment)
        .WithMany()
        .HasForeignKey(e => e.BeginSegmentGuid);
        builder.Entity<LfTextTag>()
        .HasOne(e => e.EndSegment)
        .WithMany()
        .HasForeignKey(e => e.EndSegmentGuid);
        builder.Entity<LfTextTag>()
        .HasOne(e => e.Tag)
        .WithMany()
        .HasForeignKey(e => e.TagGuid);
        builder.Entity<LfAgent>()
        .HasOne(e => e.Notes)
        .WithOne()
        .HasForeignKey<LfAgent>(e => e.NotesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfAgent>()
        .HasOne(e => e.Approves)
        .WithOne()
        .HasForeignKey<LfAgent>(e => e.ApprovesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfAgent>()
        .HasOne(e => e.Disapproves)
        .WithOne()
        .HasForeignKey<LfAgent>(e => e.DisapprovesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfTranslation>()
        .HasOne(e => e.Type)
        .WithMany()
        .HasForeignKey(e => e.TypeGuid);
        builder.Entity<LfAnnotation>()
        .HasOne(e => e.AnnotationType)
        .WithMany()
        .HasForeignKey(e => e.AnnotationTypeGuid);
        builder.Entity<LfAnnotation>()
        .HasOne(e => e.Source)
        .WithMany()
        .HasForeignKey(e => e.SourceGuid);
        builder.Entity<LfAnnotation>()
        .HasOne(e => e.InstanceOf)
        .WithMany()
        .HasForeignKey(e => e.InstanceOfGuid);
        builder.Entity<LfAnnotation>()
        .HasOne(e => e.Text)
        .WithOne()
        .HasForeignKey<LfAnnotation>(e => e.TextGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfAnnotation>()
        .HasOne(e => e.Features)
        .WithOne()
        .HasForeignKey<LfAnnotation>(e => e.FeaturesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfIndirectAnnotation>()
        .HasMany(e => e.AppliesTo)
        .WithMany()
        .UsingEntity(j => j.ToTable($"IndirectAnnotation_AppliesTo_Annotation"));
        builder.Entity<LfBaseAnnotation>()
        .HasOne(e => e.BeginObject)
        .WithMany()
        .HasForeignKey(e => e.BeginObjectGuid);
        builder.Entity<LfBaseAnnotation>()
        .HasOne(e => e.EndObject)
        .WithMany()
        .HasForeignKey(e => e.EndObjectGuid);
        builder.Entity<LfBaseAnnotation>()
        .HasMany(e => e.OtherObjects)
        .WithMany()
        .UsingEntity(j => j.ToTable($"BaseAnnotation_OtherObjects_ObjectId"));
        builder.Entity<LfUserAppFeatAct>()
        .HasMany(e => e.UserConfigAcct)
        .WithMany()
        .UsingEntity(j => j.ToTable($"UserAppFeatAct_UserConfigAcct_UserConfigAcct"));
        builder.Entity<LfPublication>()
        .HasMany(e => e.Divisions)
        .WithOne()
        .HasForeignKey("Publication_DivisionsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPubDivision>()
        .HasOne(e => e.PageLayout)
        .WithOne()
        .HasForeignKey<LfPubDivision>(e => e.PageLayoutGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPubDivision>()
        .HasOne(e => e.HFSet)
        .WithOne()
        .HasForeignKey<LfPubDivision>(e => e.HFSetGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPubHFSet>()
        .HasOne(e => e.DefaultHeader)
        .WithOne()
        .HasForeignKey<LfPubHFSet>(e => e.DefaultHeaderGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPubHFSet>()
        .HasOne(e => e.DefaultFooter)
        .WithOne()
        .HasForeignKey<LfPubHFSet>(e => e.DefaultFooterGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPubHFSet>()
        .HasOne(e => e.FirstHeader)
        .WithOne()
        .HasForeignKey<LfPubHFSet>(e => e.FirstHeaderGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPubHFSet>()
        .HasOne(e => e.FirstFooter)
        .WithOne()
        .HasForeignKey<LfPubHFSet>(e => e.FirstFooterGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPubHFSet>()
        .HasOne(e => e.EvenHeader)
        .WithOne()
        .HasForeignKey<LfPubHFSet>(e => e.EvenHeaderGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPubHFSet>()
        .HasOne(e => e.EvenFooter)
        .WithOne()
        .HasForeignKey<LfPubHFSet>(e => e.EvenFooterGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPicture>()
        .HasOne(e => e.PictureFile)
        .WithMany()
        .HasForeignKey(e => e.PictureFileGuid);
        builder.Entity<LfPicture>()
        .HasMany(e => e.DoNotPublishIn)
        .WithMany()
        .UsingEntity(j => j.ToTable($"Picture_DoNotPublishIn_Possibility"));
        builder.Entity<LfFsFeatureSystem>()
        .HasMany(e => e.Types)
        .WithOne()
        .HasForeignKey("FsFeatureSystem_TypesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfFsFeatureSystem>()
        .HasMany(e => e.Features)
        .WithOne()
        .HasForeignKey("FsFeatureSystem_FeaturesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfFsClosedFeature>()
        .HasMany(e => e.Values)
        .WithOne()
        .HasForeignKey("FsFeatDefn_ValuesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfFsClosedValue>()
        .HasOne(e => e.Value)
        .WithMany()
        .HasForeignKey(e => e.ValueGuid);
        builder.Entity<LfFsComplexValue>()
        .HasOne(e => e.Value)
        .WithOne()
        .HasForeignKey<LfFsComplexValue>(e => e.ValueGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfFsDisjunctiveValue>()
        .HasMany(e => e.Value)
        .WithMany()
        .UsingEntity(j => j.ToTable($"FsDisjunctiveValue_Value_FsSymFeatVal"));
        builder.Entity<LfFsFeatDefn>()
        .HasOne(e => e.Default)
        .WithOne()
        .HasForeignKey<LfFsFeatDefn>(e => e.DefaultGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfFsFeatureSpecification>()
        .HasOne(e => e.Feature)
        .WithMany()
        .HasForeignKey(e => e.FeatureGuid);
        builder.Entity<LfFsFeatStruc>()
        .HasMany(e => e.FeatureDisjunctions)
        .WithOne()
        .HasForeignKey("FsAbsStruc_FeatureDisjunctionsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfFsFeatStruc>()
        .HasMany(e => e.FeatureSpecs)
        .WithOne()
        .HasForeignKey("FsAbsStruc_FeatureSpecsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfFsFeatStruc>()
        .HasOne(e => e.Type)
        .WithMany()
        .HasForeignKey(e => e.TypeGuid);
        builder.Entity<LfFsFeatStrucDisj>()
        .HasMany(e => e.Contents)
        .WithOne()
        .HasForeignKey("FsAbsStruc_ContentsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfFsFeatStrucType>()
        .HasMany(e => e.Features)
        .WithMany()
        .UsingEntity(j => j.ToTable($"FsFeatStrucType_Features_FsFeatDefn"));
        builder.Entity<LfFsNegatedValue>()
        .HasOne(e => e.Value)
        .WithMany()
        .HasForeignKey(e => e.ValueGuid);
        builder.Entity<LfFsSharedValue>()
        .HasOne(e => e.Value)
        .WithMany()
        .HasForeignKey(e => e.ValueGuid);
        builder.Entity<LfSemanticDomain>()
        .HasMany(e => e.OcmRefs)
        .WithMany()
        .UsingEntity(j => j.ToTable($"SemanticDomain_OcmRefs_Possibility"));
        builder.Entity<LfSemanticDomain>()
        .HasMany(e => e.RelatedDomains)
        .WithMany()
        .UsingEntity(j => j.ToTable($"SemanticDomain_RelatedDomains_Possibility"));
        builder.Entity<LfSemanticDomain>()
        .HasMany(e => e.Questions)
        .WithOne()
        .HasForeignKey("Possibility_QuestionsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfStJournalText>()
        .HasOne(e => e.CreatedBy)
        .WithMany()
        .HasForeignKey(e => e.CreatedByGuid);
        builder.Entity<LfStJournalText>()
        .HasOne(e => e.ModifiedBy)
        .WithMany()
        .HasForeignKey(e => e.ModifiedByGuid);
        builder.Entity<LfMedia>()
        .HasOne(e => e.MediaFile)
        .WithMany()
        .HasForeignKey(e => e.MediaFileGuid);
        builder.Entity<LfVirtualOrdering>()
        .HasOne(e => e.Source)
        .WithMany()
        .HasForeignKey(e => e.SourceGuid);
        builder.Entity<LfVirtualOrdering>()
        .HasMany(e => e.Items)
        .WithMany()
        .UsingEntity(j => j.ToTable($"VirtualOrdering_Items_ObjectId"));
        builder.Entity<LfMediaContainer>()
        .HasMany(e => e.MediaURIs)
        .WithOne()
        .HasForeignKey("MediaContainer_MediaURIsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScripture>()
        .HasMany(e => e.Publications)
        .WithOne()
        .HasForeignKey("Scripture_PublicationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScripture>()
        .HasMany(e => e.HeaderFooterSets)
        .WithOne()
        .HasForeignKey("Scripture_HeaderFooterSetsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScripture>()
        .HasMany(e => e.ScriptureBooks)
        .WithOne()
        .HasForeignKey("Scripture_ScriptureBooksGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScripture>()
        .HasMany(e => e.Styles)
        .WithOne()
        .HasForeignKey("Scripture_StylesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScripture>()
        .HasMany(e => e.ImportSettings)
        .WithOne()
        .HasForeignKey("Scripture_ImportSettingsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScripture>()
        .HasMany(e => e.ArchivedDrafts)
        .WithOne()
        .HasForeignKey("Scripture_ArchivedDraftsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScripture>()
        .HasMany(e => e.BookAnnotations)
        .WithOne()
        .HasForeignKey("Scripture_BookAnnotationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScripture>()
        .HasOne(e => e.NoteCategories)
        .WithOne()
        .HasForeignKey<LfScripture>(e => e.NoteCategoriesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScripture>()
        .HasMany(e => e.Resources)
        .WithOne()
        .HasForeignKey("Scripture_ResourcesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrBook>()
        .HasMany(e => e.Sections)
        .WithOne()
        .HasForeignKey("ScrBook_SectionsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrBook>()
        .HasOne(e => e.BookId)
        .WithMany()
        .HasForeignKey(e => e.BookIdGuid);
        builder.Entity<LfScrBook>()
        .HasOne(e => e.Title)
        .WithOne()
        .HasForeignKey<LfScrBook>(e => e.TitleGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrBook>()
        .HasMany(e => e.Footnotes)
        .WithOne()
        .HasForeignKey("ScrBook_FootnotesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrBook>()
        .HasMany(e => e.Diffs)
        .WithOne()
        .HasForeignKey("ScrBook_DiffsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrRefSystem>()
        .HasMany(e => e.Books)
        .WithOne()
        .HasForeignKey("ScrRefSystem_BooksGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrSection>()
        .HasOne(e => e.Heading)
        .WithOne()
        .HasForeignKey<LfScrSection>(e => e.HeadingGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrSection>()
        .HasOne(e => e.Content)
        .WithOne()
        .HasForeignKey<LfScrSection>(e => e.ContentGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrImportSet>()
        .HasMany(e => e.ScriptureSources)
        .WithOne()
        .HasForeignKey("ScrImportSet_ScriptureSourcesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrImportSet>()
        .HasMany(e => e.BackTransSources)
        .WithOne()
        .HasForeignKey("ScrImportSet_BackTransSourcesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrImportSet>()
        .HasMany(e => e.NoteSources)
        .WithOne()
        .HasForeignKey("ScrImportSet_NoteSourcesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrImportSet>()
        .HasMany(e => e.ScriptureMappings)
        .WithOne()
        .HasForeignKey("ScrImportSet_ScriptureMappingsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrImportSet>()
        .HasMany(e => e.NoteMappings)
        .WithOne()
        .HasForeignKey("ScrImportSet_NoteMappingsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrDraft>()
        .HasMany(e => e.Books)
        .WithOne()
        .HasForeignKey("ScrDraft_BooksGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrDifference>()
        .HasOne(e => e.RevParagraph)
        .WithMany()
        .HasForeignKey(e => e.RevParagraphGuid);
        builder.Entity<LfScrImportSource>()
        .HasOne(e => e.NoteType)
        .WithMany()
        .HasForeignKey(e => e.NoteTypeGuid);
        builder.Entity<LfScrImportSFFiles>()
        .HasMany(e => e.Files)
        .WithOne()
        .HasForeignKey("ScrImportSource_FilesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrMarkerMapping>()
        .HasOne(e => e.Style)
        .WithMany()
        .HasForeignKey(e => e.StyleGuid);
        builder.Entity<LfScrMarkerMapping>()
        .HasOne(e => e.NoteType)
        .WithMany()
        .HasForeignKey(e => e.NoteTypeGuid);
        builder.Entity<LfScrBookAnnotations>()
        .HasMany(e => e.Notes)
        .WithOne()
        .HasForeignKey("ScrBookAnnotations_NotesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrBookAnnotations>()
        .HasMany(e => e.ChkHistRecs)
        .WithOne()
        .HasForeignKey("ScrBookAnnotations_ChkHistRecsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrScriptureNote>()
        .HasMany(e => e.Categories)
        .WithMany()
        .UsingEntity(j => j.ToTable($"ScrScriptureNote_Categories_Possibility"));
        builder.Entity<LfScrScriptureNote>()
        .HasOne(e => e.Quote)
        .WithOne()
        .HasForeignKey<LfScrScriptureNote>(e => e.QuoteGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrScriptureNote>()
        .HasOne(e => e.Discussion)
        .WithOne()
        .HasForeignKey<LfScrScriptureNote>(e => e.DiscussionGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrScriptureNote>()
        .HasOne(e => e.Recommendation)
        .WithOne()
        .HasForeignKey<LfScrScriptureNote>(e => e.RecommendationGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrScriptureNote>()
        .HasOne(e => e.Resolution)
        .WithOne()
        .HasForeignKey<LfScrScriptureNote>(e => e.ResolutionGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrScriptureNote>()
        .HasMany(e => e.Responses)
        .WithOne()
        .HasForeignKey("Annotation_ResponsesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfScrFootnote>()
        .HasOne(e => e.ParaContainingOrc)
        .WithMany()
        .HasForeignKey(e => e.ParaContainingOrcGuid);
        builder.Entity<LfRnResearchNbk>()
        .HasMany(e => e.Publications)
        .WithOne()
        .HasForeignKey("RnResearchNbk_PublicationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnResearchNbk>()
        .HasMany(e => e.HeaderFooterSets)
        .WithOne()
        .HasForeignKey("RnResearchNbk_HeaderFooterSetsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnResearchNbk>()
        .HasMany(e => e.Records)
        .WithOne()
        .HasForeignKey("RnResearchNbk_RecordsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnResearchNbk>()
        .HasMany(e => e.Reminders)
        .WithOne()
        .HasForeignKey("RnResearchNbk_RemindersGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnResearchNbk>()
        .HasOne(e => e.RecTypes)
        .WithOne()
        .HasForeignKey<LfRnResearchNbk>(e => e.RecTypesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnResearchNbk>()
        .HasMany(e => e.CrossReferences)
        .WithOne()
        .HasForeignKey("RnResearchNbk_CrossReferencesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.VersionHistory)
        .WithOne()
        .HasForeignKey<LfRnGenericRec>(e => e.VersionHistoryGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.Reminders)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_Reminders_Reminder"));
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.Researchers)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_Researchers_Possibility"));
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.Confidence)
        .WithMany()
        .HasForeignKey(e => e.ConfidenceGuid);
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.Restrictions)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_Restrictions_Possibility"));
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.AnthroCodes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_AnthroCodes_Possibility"));
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.PhraseTags)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_PhraseTags_Possibility"));
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.SubRecords)
        .WithOne()
        .HasForeignKey("RnGenericRec_SubRecordsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.CrossReferences)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_CrossReferences_CrossReference"));
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.ExternalMaterials)
        .WithOne()
        .HasForeignKey<LfRnGenericRec>(e => e.ExternalMaterialsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.FurtherQuestions)
        .WithOne()
        .HasForeignKey<LfRnGenericRec>(e => e.FurtherQuestionsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.SeeAlso)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_SeeAlso_RnGenericRec"));
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.CounterEvidence)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_CounterEvidence_RnGenericRec"));
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.Status)
        .WithMany()
        .HasForeignKey(e => e.StatusGuid);
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.SupersededBy)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_SupersededBy_RnGenericRec"));
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.SupportingEvidence)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_SupportingEvidence_RnGenericRec"));
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.Conclusions)
        .WithOne()
        .HasForeignKey<LfRnGenericRec>(e => e.ConclusionsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.Hypothesis)
        .WithOne()
        .HasForeignKey<LfRnGenericRec>(e => e.HypothesisGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.ResearchPlan)
        .WithOne()
        .HasForeignKey<LfRnGenericRec>(e => e.ResearchPlanGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.Locations)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_Locations_Possibility"));
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.Sources)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_Sources_Possibility"));
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.TimeOfEvent)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnGenericRec_TimeOfEvent_Possibility"));
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.Type)
        .WithMany()
        .HasForeignKey(e => e.TypeGuid);
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.Description)
        .WithOne()
        .HasForeignKey<LfRnGenericRec>(e => e.DescriptionGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasMany(e => e.Participants)
        .WithOne()
        .HasForeignKey("RnGenericRec_ParticipantsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.PersonalNotes)
        .WithOne()
        .HasForeignKey<LfRnGenericRec>(e => e.PersonalNotesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.Discussion)
        .WithOne()
        .HasForeignKey<LfRnGenericRec>(e => e.DiscussionGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfRnGenericRec>()
        .HasOne(e => e.Text)
        .WithMany()
        .HasForeignKey(e => e.TextGuid);
        builder.Entity<LfRnRoledPartic>()
        .HasMany(e => e.Participants)
        .WithMany()
        .UsingEntity(j => j.ToTable($"RnRoledPartic_Participants_Possibility"));
        builder.Entity<LfRnRoledPartic>()
        .HasOne(e => e.Role)
        .WithMany()
        .HasForeignKey(e => e.RoleGuid);
        builder.Entity<LfMoStemMsa>()
        .HasOne(e => e.MsFeatures)
        .WithOne()
        .HasForeignKey<LfMoStemMsa>(e => e.MsFeaturesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoStemMsa>()
        .HasOne(e => e.PartOfSpeech)
        .WithMany()
        .HasForeignKey(e => e.PartOfSpeechGuid);
        builder.Entity<LfMoStemMsa>()
        .HasOne(e => e.InflectionClass)
        .WithMany()
        .HasForeignKey(e => e.InflectionClassGuid);
        builder.Entity<LfMoStemMsa>()
        .HasOne(e => e.Stratum)
        .WithMany()
        .HasForeignKey(e => e.StratumGuid);
        builder.Entity<LfMoStemMsa>()
        .HasMany(e => e.ProdRestrict)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoStemMsa_ProdRestrict_Possibility"));
        builder.Entity<LfMoStemMsa>()
        .HasMany(e => e.FromPartsOfSpeech)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoStemMsa_FromPartsOfSpeech_Possibility"));
        builder.Entity<LfMoStemMsa>()
        .HasMany(e => e.Slots)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoStemMsa_Slots_MoInflAffixSlot"));
        builder.Entity<LfLexEntry>()
        .HasMany(e => e.MorphoSyntaxAnalyses)
        .WithOne()
        .HasForeignKey("LexEntry_MorphoSyntaxAnalysesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexEntry>()
        .HasMany(e => e.Senses)
        .WithOne()
        .HasForeignKey("LexEntry_SensesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexEntry>()
        .HasMany(e => e.Etymology)
        .WithOne()
        .HasForeignKey("LexEntry_EtymologyGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexEntry>()
        .HasMany(e => e.MainEntriesOrSenses)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexEntry_MainEntriesOrSenses_ObjectId"));
        builder.Entity<LfLexEntry>()
        .HasMany(e => e.DoNotShowMainEntryIn)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexEntry_DoNotShowMainEntryIn_Possibility"));
        builder.Entity<LfLexEntry>()
        .HasOne(e => e.LexemeForm)
        .WithOne()
        .HasForeignKey<LfLexEntry>(e => e.LexemeFormGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexEntry>()
        .HasMany(e => e.AlternateForms)
        .WithOne()
        .HasForeignKey("LexEntry_AlternateFormsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexEntry>()
        .HasMany(e => e.Pronunciations)
        .WithOne()
        .HasForeignKey("LexEntry_PronunciationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexEntry>()
        .HasMany(e => e.EntryRefs)
        .WithOne()
        .HasForeignKey("LexEntry_EntryRefsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexEntry>()
        .HasMany(e => e.DoNotPublishIn)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexEntry_DoNotPublishIn_Possibility"));
        builder.Entity<LfLexEntry>()
        .HasMany(e => e.DialectLabels)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexEntry_DialectLabels_Possibility"));
        builder.Entity<LfConstChartRow>()
        .HasMany(e => e.Cells)
        .WithOne()
        .HasForeignKey("ConstChartRow_CellsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexExampleSentence>()
        .HasMany(e => e.Translations)
        .WithOne()
        .HasForeignKey("LexExampleSentence_TranslationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexExampleSentence>()
        .HasMany(e => e.DoNotPublishIn)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexExampleSentence_DoNotPublishIn_Possibility"));
        builder.Entity<LfLexDb>()
        .HasMany(e => e.Publications)
        .WithOne()
        .HasForeignKey("LexDb_PublicationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasMany(e => e.HeaderFooterSets)
        .WithOne()
        .HasForeignKey("LexDb_HeaderFooterSetsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasMany(e => e.Appendixes)
        .WithOne()
        .HasForeignKey("LexDb_AppendixesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasOne(e => e.SenseTypes)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.SenseTypesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasOne(e => e.UsageTypes)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.UsageTypesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasOne(e => e.DomainTypes)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.DomainTypesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasOne(e => e.MorphTypes)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.MorphTypesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasMany(e => e.LexicalFormIndex)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexDb_LexicalFormIndex_LexEntry"));
        builder.Entity<LfLexDb>()
        .HasMany(e => e.AllomorphIndex)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexDb_AllomorphIndex_MoForm"));
        builder.Entity<LfLexDb>()
        .HasOne(e => e.Introduction)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.IntroductionGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasMany(e => e.ReversalIndexes)
        .WithOne()
        .HasForeignKey("LexDb_ReversalIndexesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasOne(e => e.References)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.ReferencesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasMany(e => e.Resources)
        .WithOne()
        .HasForeignKey("LexDb_ResourcesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasOne(e => e.VariantEntryTypes)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.VariantEntryTypesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasOne(e => e.ComplexEntryTypes)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.ComplexEntryTypesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasOne(e => e.PublicationTypes)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.PublicationTypesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasOne(e => e.ExtendedNoteTypes)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.ExtendedNoteTypesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasOne(e => e.Languages)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.LanguagesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexDb>()
        .HasOne(e => e.DialectLabels)
        .WithOne()
        .HasForeignKey<LfLexDb>(e => e.DialectLabelsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfConstituentChartCellPart>()
        .HasOne(e => e.Column)
        .WithMany()
        .HasForeignKey(e => e.ColumnGuid);
        builder.Entity<LfConstChartWordGroup>()
        .HasOne(e => e.BeginSegment)
        .WithMany()
        .HasForeignKey(e => e.BeginSegmentGuid);
        builder.Entity<LfConstChartWordGroup>()
        .HasOne(e => e.EndSegment)
        .WithMany()
        .HasForeignKey(e => e.EndSegmentGuid);
        builder.Entity<LfConstChartMovedTextMarker>()
        .HasOne(e => e.WordGroup)
        .WithMany()
        .HasForeignKey(e => e.WordGroupGuid);
        builder.Entity<LfConstChartClauseMarker>()
        .HasMany(e => e.DependentClauses)
        .WithMany()
        .UsingEntity(j => j.ToTable($"ConstChartClauseMarker_DependentClauses_ConstChartRow"));
        builder.Entity<LfConstChartTag>()
        .HasOne(e => e.Tag)
        .WithMany()
        .HasForeignKey(e => e.TagGuid);
        builder.Entity<LfLexPronunciation>()
        .HasOne(e => e.Location)
        .WithMany()
        .HasForeignKey(e => e.LocationGuid);
        builder.Entity<LfLexPronunciation>()
        .HasMany(e => e.MediaFiles)
        .WithOne()
        .HasForeignKey("LexPronunciation_MediaFilesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexPronunciation>()
        .HasMany(e => e.DoNotPublishIn)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexPronunciation_DoNotPublishIn_Possibility"));
        builder.Entity<LfLexSense>()
        .HasOne(e => e.MorphoSyntaxAnalysis)
        .WithMany()
        .HasForeignKey(e => e.MorphoSyntaxAnalysisGuid);
        builder.Entity<LfLexSense>()
        .HasMany(e => e.AnthroCodes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexSense_AnthroCodes_Possibility"));
        builder.Entity<LfLexSense>()
        .HasMany(e => e.Senses)
        .WithOne()
        .HasForeignKey("LexSense_SensesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexSense>()
        .HasMany(e => e.Appendixes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexSense_Appendixes_LexAppendix"));
        builder.Entity<LfLexSense>()
        .HasMany(e => e.DomainTypes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexSense_DomainTypes_Possibility"));
        builder.Entity<LfLexSense>()
        .HasMany(e => e.Examples)
        .WithOne()
        .HasForeignKey("LexSense_ExamplesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexSense>()
        .HasOne(e => e.SenseType)
        .WithMany()
        .HasForeignKey(e => e.SenseTypeGuid);
        builder.Entity<LfLexSense>()
        .HasMany(e => e.ThesaurusItems)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexSense_ThesaurusItems_Possibility"));
        builder.Entity<LfLexSense>()
        .HasMany(e => e.UsageTypes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexSense_UsageTypes_Possibility"));
        builder.Entity<LfLexSense>()
        .HasOne(e => e.Status)
        .WithMany()
        .HasForeignKey(e => e.StatusGuid);
        builder.Entity<LfLexSense>()
        .HasMany(e => e.SemanticDomains)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexSense_SemanticDomains_Possibility"));
        builder.Entity<LfLexSense>()
        .HasMany(e => e.Pictures)
        .WithOne()
        .HasForeignKey("LexSense_PicturesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexSense>()
        .HasMany(e => e.DoNotPublishIn)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexSense_DoNotPublishIn_Possibility"));
        builder.Entity<LfLexSense>()
        .HasMany(e => e.ExtendedNote)
        .WithOne()
        .HasForeignKey("LexSense_ExtendedNoteGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexSense>()
        .HasMany(e => e.DialectLabels)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexSense_DialectLabels_Possibility"));
        builder.Entity<LfMoAffixAllomorph>()
        .HasOne(e => e.MsEnvFeatures)
        .WithOne()
        .HasForeignKey<LfMoAffixAllomorph>(e => e.MsEnvFeaturesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoAffixAllomorph>()
        .HasMany(e => e.PhoneEnv)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoAffixAllomorph_PhoneEnv_PhEnvironment"));
        builder.Entity<LfMoAffixAllomorph>()
        .HasOne(e => e.MsEnvPartOfSpeech)
        .WithMany()
        .HasForeignKey(e => e.MsEnvPartOfSpeechGuid);
        builder.Entity<LfMoAffixAllomorph>()
        .HasMany(e => e.Position)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoAffixAllomorph_Position_PhEnvironment"));
        builder.Entity<LfMoAffixForm>()
        .HasMany(e => e.InflectionClasses)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoAffixForm_InflectionClasses_MoInflClass"));
        builder.Entity<LfMoAffixProcess>()
        .HasMany(e => e.Input)
        .WithOne()
        .HasForeignKey("MoForm_InputGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoAffixProcess>()
        .HasMany(e => e.Output)
        .WithOne()
        .HasForeignKey("MoForm_OutputGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoCompoundRule>()
        .HasOne(e => e.Stratum)
        .WithMany()
        .HasForeignKey(e => e.StratumGuid);
        builder.Entity<LfMoCompoundRule>()
        .HasMany(e => e.ToProdRestrict)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoCompoundRule_ToProdRestrict_Possibility"));
        builder.Entity<LfMoDerivAffMsa>()
        .HasOne(e => e.FromMsFeatures)
        .WithOne()
        .HasForeignKey<LfMoDerivAffMsa>(e => e.FromMsFeaturesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoDerivAffMsa>()
        .HasOne(e => e.ToMsFeatures)
        .WithOne()
        .HasForeignKey<LfMoDerivAffMsa>(e => e.ToMsFeaturesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoDerivAffMsa>()
        .HasOne(e => e.FromPartOfSpeech)
        .WithMany()
        .HasForeignKey(e => e.FromPartOfSpeechGuid);
        builder.Entity<LfMoDerivAffMsa>()
        .HasOne(e => e.ToPartOfSpeech)
        .WithMany()
        .HasForeignKey(e => e.ToPartOfSpeechGuid);
        builder.Entity<LfMoDerivAffMsa>()
        .HasOne(e => e.FromInflectionClass)
        .WithMany()
        .HasForeignKey(e => e.FromInflectionClassGuid);
        builder.Entity<LfMoDerivAffMsa>()
        .HasOne(e => e.ToInflectionClass)
        .WithMany()
        .HasForeignKey(e => e.ToInflectionClassGuid);
        builder.Entity<LfMoDerivAffMsa>()
        .HasOne(e => e.AffixCategory)
        .WithMany()
        .HasForeignKey(e => e.AffixCategoryGuid);
        builder.Entity<LfMoDerivAffMsa>()
        .HasOne(e => e.FromStemName)
        .WithMany()
        .HasForeignKey(e => e.FromStemNameGuid);
        builder.Entity<LfMoDerivAffMsa>()
        .HasOne(e => e.Stratum)
        .WithMany()
        .HasForeignKey(e => e.StratumGuid);
        builder.Entity<LfMoDerivAffMsa>()
        .HasMany(e => e.FromProdRestrict)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoDerivAffMsa_FromProdRestrict_Possibility"));
        builder.Entity<LfMoDerivAffMsa>()
        .HasMany(e => e.ToProdRestrict)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoDerivAffMsa_ToProdRestrict_Possibility"));
        builder.Entity<LfMoDerivStepMsa>()
        .HasOne(e => e.PartOfSpeech)
        .WithMany()
        .HasForeignKey(e => e.PartOfSpeechGuid);
        builder.Entity<LfMoDerivStepMsa>()
        .HasOne(e => e.MsFeatures)
        .WithOne()
        .HasForeignKey<LfMoDerivStepMsa>(e => e.MsFeaturesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoDerivStepMsa>()
        .HasOne(e => e.InflFeats)
        .WithOne()
        .HasForeignKey<LfMoDerivStepMsa>(e => e.InflFeatsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoDerivStepMsa>()
        .HasOne(e => e.InflectionClass)
        .WithMany()
        .HasForeignKey(e => e.InflectionClassGuid);
        builder.Entity<LfMoDerivStepMsa>()
        .HasMany(e => e.ProdRestrict)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoDerivStepMsa_ProdRestrict_Possibility"));
        builder.Entity<LfMoEndoCompound>()
        .HasOne(e => e.OverridingMsa)
        .WithOne()
        .HasForeignKey<LfMoEndoCompound>(e => e.OverridingMsaGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoExoCompound>()
        .HasOne(e => e.ToMsa)
        .WithOne()
        .HasForeignKey<LfMoExoCompound>(e => e.ToMsaGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoForm>()
        .HasOne(e => e.MorphType)
        .WithMany()
        .HasForeignKey(e => e.MorphTypeGuid);
        builder.Entity<LfMoInflAffixTemplate>()
        .HasMany(e => e.Slots)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoInflAffixTemplate_Slots_MoInflAffixSlot"));
        builder.Entity<LfMoInflAffixTemplate>()
        .HasOne(e => e.Stratum)
        .WithMany()
        .HasForeignKey(e => e.StratumGuid);
        builder.Entity<LfMoInflAffixTemplate>()
        .HasOne(e => e.Region)
        .WithOne()
        .HasForeignKey<LfMoInflAffixTemplate>(e => e.RegionGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoInflAffixTemplate>()
        .HasMany(e => e.PrefixSlots)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoInflAffixTemplate_PrefixSlots_MoInflAffixSlot"));
        builder.Entity<LfMoInflAffixTemplate>()
        .HasMany(e => e.SuffixSlots)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoInflAffixTemplate_SuffixSlots_MoInflAffixSlot"));
        builder.Entity<LfMoInflAffixTemplate>()
        .HasMany(e => e.ProcliticSlots)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoInflAffixTemplate_ProcliticSlots_MoInflAffixSlot"));
        builder.Entity<LfMoInflAffixTemplate>()
        .HasMany(e => e.EncliticSlots)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoInflAffixTemplate_EncliticSlots_MoInflAffixSlot"));
        builder.Entity<LfMoInflAffMsa>()
        .HasOne(e => e.InflFeats)
        .WithOne()
        .HasForeignKey<LfMoInflAffMsa>(e => e.InflFeatsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoInflAffMsa>()
        .HasOne(e => e.AffixCategory)
        .WithMany()
        .HasForeignKey(e => e.AffixCategoryGuid);
        builder.Entity<LfMoInflAffMsa>()
        .HasOne(e => e.PartOfSpeech)
        .WithMany()
        .HasForeignKey(e => e.PartOfSpeechGuid);
        builder.Entity<LfMoInflAffMsa>()
        .HasMany(e => e.Slots)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoInflAffMsa_Slots_MoInflAffixSlot"));
        builder.Entity<LfMoInflAffMsa>()
        .HasMany(e => e.FromProdRestrict)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoInflAffMsa_FromProdRestrict_Possibility"));
        builder.Entity<LfMoInflClass>()
        .HasMany(e => e.Subclasses)
        .WithOne()
        .HasForeignKey("MoInflClass_SubclassesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoInflClass>()
        .HasMany(e => e.RulesOfReferral)
        .WithOne()
        .HasForeignKey("MoInflClass_RulesOfReferralGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoInflClass>()
        .HasMany(e => e.StemNames)
        .WithOne()
        .HasForeignKey("MoInflClass_StemNamesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoInflClass>()
        .HasMany(e => e.ReferenceForms)
        .WithOne()
        .HasForeignKey("MoInflClass_ReferenceFormsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoMorphData>()
        .HasMany(e => e.Strata)
        .WithOne()
        .HasForeignKey("MoMorphData_StrataGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoMorphData>()
        .HasMany(e => e.CompoundRules)
        .WithOne()
        .HasForeignKey("MoMorphData_CompoundRulesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoMorphData>()
        .HasMany(e => e.AdhocCoProhibitions)
        .WithOne()
        .HasForeignKey("MoMorphData_AdhocCoProhibitionsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoMorphData>()
        .HasMany(e => e.AnalyzingAgents)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoMorphData_AnalyzingAgents_Agent"));
        builder.Entity<LfMoMorphData>()
        .HasMany(e => e.TestSets)
        .WithOne()
        .HasForeignKey("MoMorphData_TestSetsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoMorphData>()
        .HasOne(e => e.GlossSystem)
        .WithOne()
        .HasForeignKey<LfMoMorphData>(e => e.GlossSystemGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoMorphData>()
        .HasOne(e => e.ProdRestrict)
        .WithOne()
        .HasForeignKey<LfMoMorphData>(e => e.ProdRestrictGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoMorphSynAnalysis>()
        .HasMany(e => e.Components)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoMorphSynAnalysis_Components_MoMorphSynAnalysis"));
        builder.Entity<LfMoMorphSynAnalysis>()
        .HasMany(e => e.GlossBundle)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoMorphSynAnalysis_GlossBundle_MoGlossItem"));
        builder.Entity<LfMoReferralRule>()
        .HasOne(e => e.Input)
        .WithOne()
        .HasForeignKey<LfMoReferralRule>(e => e.InputGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoReferralRule>()
        .HasOne(e => e.Output)
        .WithOne()
        .HasForeignKey<LfMoReferralRule>(e => e.OutputGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoStemAllomorph>()
        .HasMany(e => e.PhoneEnv)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoStemAllomorph_PhoneEnv_PhEnvironment"));
        builder.Entity<LfMoStemAllomorph>()
        .HasOne(e => e.StemName)
        .WithMany()
        .HasForeignKey(e => e.StemNameGuid);
        builder.Entity<LfLexAppendix>()
        .HasOne(e => e.Contents)
        .WithOne()
        .HasForeignKey<LfLexAppendix>(e => e.ContentsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoStemName>()
        .HasMany(e => e.Regions)
        .WithOne()
        .HasForeignKey("MoStemName_RegionsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoStemName>()
        .HasOne(e => e.DefaultAffix)
        .WithMany()
        .HasForeignKey(e => e.DefaultAffixGuid);
        builder.Entity<LfMoStemName>()
        .HasOne(e => e.DefaultStem)
        .WithMany()
        .HasForeignKey(e => e.DefaultStemGuid);
        builder.Entity<LfMoStratum>()
        .HasOne(e => e.Phonemes)
        .WithMany()
        .HasForeignKey(e => e.PhonemesGuid);
        builder.Entity<LfPartOfSpeech>()
        .HasOne(e => e.InherFeatVal)
        .WithOne()
        .HasForeignKey<LfPartOfSpeech>(e => e.InherFeatValGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPartOfSpeech>()
        .HasMany(e => e.EmptyParadigmCells)
        .WithOne()
        .HasForeignKey("Possibility_EmptyParadigmCellsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPartOfSpeech>()
        .HasMany(e => e.RulesOfReferral)
        .WithOne()
        .HasForeignKey("Possibility_RulesOfReferralGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPartOfSpeech>()
        .HasMany(e => e.InflectionClasses)
        .WithOne()
        .HasForeignKey("Possibility_InflectionClassesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPartOfSpeech>()
        .HasMany(e => e.AffixTemplates)
        .WithOne()
        .HasForeignKey("Possibility_AffixTemplatesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPartOfSpeech>()
        .HasMany(e => e.AffixSlots)
        .WithOne()
        .HasForeignKey("Possibility_AffixSlotsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPartOfSpeech>()
        .HasMany(e => e.StemNames)
        .WithOne()
        .HasForeignKey("Possibility_StemNamesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPartOfSpeech>()
        .HasMany(e => e.BearableFeatures)
        .WithMany()
        .UsingEntity(j => j.ToTable($"PartOfSpeech_BearableFeatures_FsFeatDefn"));
        builder.Entity<LfPartOfSpeech>()
        .HasMany(e => e.InflectableFeats)
        .WithMany()
        .UsingEntity(j => j.ToTable($"PartOfSpeech_InflectableFeats_FsFeatDefn"));
        builder.Entity<LfPartOfSpeech>()
        .HasMany(e => e.ReferenceForms)
        .WithOne()
        .HasForeignKey("Possibility_ReferenceFormsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPartOfSpeech>()
        .HasOne(e => e.DefaultFeatures)
        .WithOne()
        .HasForeignKey<LfPartOfSpeech>(e => e.DefaultFeaturesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPartOfSpeech>()
        .HasOne(e => e.DefaultInflectionClass)
        .WithMany()
        .HasForeignKey(e => e.DefaultInflectionClassGuid);
        builder.Entity<LfReversalIndex>()
        .HasMany(e => e.Publications)
        .WithOne()
        .HasForeignKey("ReversalIndex_PublicationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfReversalIndex>()
        .HasMany(e => e.HeaderFooterSets)
        .WithOne()
        .HasForeignKey("ReversalIndex_HeaderFooterSetsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfReversalIndex>()
        .HasOne(e => e.PartsOfSpeech)
        .WithOne()
        .HasForeignKey<LfReversalIndex>(e => e.PartsOfSpeechGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfReversalIndex>()
        .HasMany(e => e.Entries)
        .WithOne()
        .HasForeignKey("ReversalIndex_EntriesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfReversalIndexEntry>()
        .HasMany(e => e.Subentries)
        .WithOne()
        .HasForeignKey("ReversalIndexEntry_SubentriesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfReversalIndexEntry>()
        .HasOne(e => e.PartOfSpeech)
        .WithMany()
        .HasForeignKey(e => e.PartOfSpeechGuid);
        builder.Entity<LfReversalIndexEntry>()
        .HasMany(e => e.Senses)
        .WithMany()
        .UsingEntity(j => j.ToTable($"ReversalIndexEntry_Senses_LexSense"));
        builder.Entity<LfText>()
        .HasMany(e => e.Publications)
        .WithOne()
        .HasForeignKey("Text_PublicationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfText>()
        .HasMany(e => e.HeaderFooterSets)
        .WithOne()
        .HasForeignKey("Text_HeaderFooterSetsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfText>()
        .HasOne(e => e.Contents)
        .WithOne()
        .HasForeignKey<LfText>(e => e.ContentsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfText>()
        .HasMany(e => e.Genres)
        .WithMany()
        .UsingEntity(j => j.ToTable($"Text_Genres_Possibility"));
        builder.Entity<LfText>()
        .HasOne(e => e.MediaFiles)
        .WithOne()
        .HasForeignKey<LfText>(e => e.MediaFilesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfWfiAnalysis>()
        .HasOne(e => e.Category)
        .WithMany()
        .HasForeignKey(e => e.CategoryGuid);
        builder.Entity<LfWfiAnalysis>()
        .HasOne(e => e.MsFeatures)
        .WithOne()
        .HasForeignKey<LfWfiAnalysis>(e => e.MsFeaturesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfWfiAnalysis>()
        .HasMany(e => e.Stems)
        .WithMany()
        .UsingEntity(j => j.ToTable($"WfiAnalysis_Stems_LexEntry"));
        builder.Entity<LfWfiAnalysis>()
        .HasOne(e => e.Derivation)
        .WithOne()
        .HasForeignKey<LfWfiAnalysis>(e => e.DerivationGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfWfiAnalysis>()
        .HasMany(e => e.Meanings)
        .WithOne()
        .HasForeignKey("WfiAnalysis_MeaningsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfWfiAnalysis>()
        .HasMany(e => e.MorphBundles)
        .WithOne()
        .HasForeignKey("WfiAnalysis_MorphBundlesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfWfiAnalysis>()
        .HasMany(e => e.CompoundRuleApps)
        .WithMany()
        .UsingEntity(j => j.ToTable($"WfiAnalysis_CompoundRuleApps_MoCompoundRule"));
        builder.Entity<LfWfiAnalysis>()
        .HasMany(e => e.InflTemplateApps)
        .WithMany()
        .UsingEntity(j => j.ToTable($"WfiAnalysis_InflTemplateApps_MoInflAffixTemplate"));
        builder.Entity<LfWfiAnalysis>()
        .HasMany(e => e.Evaluations)
        .WithMany()
        .UsingEntity(j => j.ToTable($"WfiAnalysis_Evaluations_AgentEvaluation"));
        builder.Entity<LfWfiWordform>()
        .HasMany(e => e.Analyses)
        .WithOne()
        .HasForeignKey("WfiWordform_AnalysesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfWordFormLookup>()
        .HasMany(e => e.ThesaurusItems)
        .WithMany()
        .UsingEntity(j => j.ToTable($"WordFormLookup_ThesaurusItems_Possibility"));
        builder.Entity<LfWordFormLookup>()
        .HasMany(e => e.AnthroCodes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"WordFormLookup_AnthroCodes_Possibility"));
        builder.Entity<LfWordformLookupList>()
        .HasMany(e => e.Publications)
        .WithOne()
        .HasForeignKey("WordformLookupList_PublicationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfWordformLookupList>()
        .HasMany(e => e.HeaderFooterSets)
        .WithOne()
        .HasForeignKey("WordformLookupList_HeaderFooterSetsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfWordformLookupList>()
        .HasMany(e => e.Wordforms)
        .WithOne()
        .HasForeignKey("WordformLookupList_WordformsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoInsertPhones>()
        .HasMany(e => e.Content)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoInsertPhones_Content_PhTerminalUnit"));
        builder.Entity<LfMoInsertNC>()
        .HasOne(e => e.Content)
        .WithMany()
        .HasForeignKey(e => e.ContentGuid);
        builder.Entity<LfMoModifyFromInput>()
        .HasOne(e => e.Content)
        .WithMany()
        .HasForeignKey(e => e.ContentGuid);
        builder.Entity<LfMoModifyFromInput>()
        .HasOne(e => e.Modification)
        .WithMany()
        .HasForeignKey(e => e.ModificationGuid);
        builder.Entity<LfMoCompoundRuleApp>()
        .HasOne(e => e.LeftForm)
        .WithMany()
        .HasForeignKey(e => e.LeftFormGuid);
        builder.Entity<LfMoCompoundRuleApp>()
        .HasOne(e => e.RightForm)
        .WithMany()
        .HasForeignKey(e => e.RightFormGuid);
        builder.Entity<LfMoCompoundRuleApp>()
        .HasOne(e => e.Linker)
        .WithMany()
        .HasForeignKey(e => e.LinkerGuid);
        builder.Entity<LfMoDerivAffApp>()
        .HasOne(e => e.AffixForm)
        .WithMany()
        .HasForeignKey(e => e.AffixFormGuid);
        builder.Entity<LfMoDerivAffApp>()
        .HasOne(e => e.AffixMsa)
        .WithMany()
        .HasForeignKey(e => e.AffixMsaGuid);
        builder.Entity<LfMoDerivAffApp>()
        .HasOne(e => e.OutputMsa)
        .WithOne()
        .HasForeignKey<LfMoDerivAffApp>(e => e.OutputMsaGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoInflAffixSlotApp>()
        .HasOne(e => e.Slot)
        .WithMany()
        .HasForeignKey(e => e.SlotGuid);
        builder.Entity<LfMoInflAffixSlotApp>()
        .HasOne(e => e.AffixForm)
        .WithMany()
        .HasForeignKey(e => e.AffixFormGuid);
        builder.Entity<LfMoInflAffixSlotApp>()
        .HasOne(e => e.AffixMsa)
        .WithMany()
        .HasForeignKey(e => e.AffixMsaGuid);
        builder.Entity<LfMoInflTemplateApp>()
        .HasOne(e => e.Template)
        .WithMany()
        .HasForeignKey(e => e.TemplateGuid);
        builder.Entity<LfMoInflTemplateApp>()
        .HasMany(e => e.SlotApps)
        .WithOne()
        .HasForeignKey("MoDerivTrace_SlotAppsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoPhonolRuleApp>()
        .HasOne(e => e.Rule)
        .WithMany()
        .HasForeignKey(e => e.RuleGuid);
        builder.Entity<LfMoStratumApp>()
        .HasOne(e => e.Stratum)
        .WithMany()
        .HasForeignKey(e => e.StratumGuid);
        builder.Entity<LfMoStratumApp>()
        .HasMany(e => e.CompoundRuleApps)
        .WithOne()
        .HasForeignKey("MoDerivTrace_CompoundRuleAppsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoStratumApp>()
        .HasMany(e => e.DerivAffApp)
        .WithOne()
        .HasForeignKey("MoDerivTrace_DerivAffAppGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoStratumApp>()
        .HasOne(e => e.TemplateApp)
        .WithOne()
        .HasForeignKey<LfMoStratumApp>(e => e.TemplateAppGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoStratumApp>()
        .HasMany(e => e.PRuleApps)
        .WithOne()
        .HasForeignKey("MoDerivTrace_PRuleAppsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhPhonContext>()
        .HasOne(e => e.Description)
        .WithOne()
        .HasForeignKey<LfPhPhonContext>(e => e.DescriptionGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhIterationContext>()
        .HasOne(e => e.Member)
        .WithMany()
        .HasForeignKey(e => e.MemberGuid);
        builder.Entity<LfPhSequenceContext>()
        .HasMany(e => e.Members)
        .WithMany()
        .UsingEntity(j => j.ToTable($"PhSequenceContext_Members_PhContextOrVar"));
        builder.Entity<LfPhSimpleContextBdry>()
        .HasOne(e => e.FeatureStructure)
        .WithMany()
        .HasForeignKey(e => e.FeatureStructureGuid);
        builder.Entity<LfPhSimpleContextNC>()
        .HasOne(e => e.FeatureStructure)
        .WithMany()
        .HasForeignKey(e => e.FeatureStructureGuid);
        builder.Entity<LfPhSimpleContextNC>()
        .HasMany(e => e.PlusConstr)
        .WithMany()
        .UsingEntity(j => j.ToTable($"PhSimpleContextNC_PlusConstr_PhFeatureConstraint"));
        builder.Entity<LfPhSimpleContextNC>()
        .HasMany(e => e.MinusConstr)
        .WithMany()
        .UsingEntity(j => j.ToTable($"PhSimpleContextNC_MinusConstr_PhFeatureConstraint"));
        builder.Entity<LfPhSimpleContextSeg>()
        .HasOne(e => e.FeatureStructure)
        .WithMany()
        .HasForeignKey(e => e.FeatureStructureGuid);
        builder.Entity<LfPhPhonemeSet>()
        .HasMany(e => e.Phonemes)
        .WithOne()
        .HasForeignKey("PhPhonemeSet_PhonemesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhPhonemeSet>()
        .HasMany(e => e.BoundaryMarkers)
        .WithOne()
        .HasForeignKey("PhPhonemeSet_BoundaryMarkersGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhTerminalUnit>()
        .HasMany(e => e.Codes)
        .WithOne()
        .HasForeignKey("PhTerminalUnit_CodesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhPhoneme>()
        .HasOne(e => e.Features)
        .WithOne()
        .HasForeignKey<LfPhPhoneme>(e => e.FeaturesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhNCFeatures>()
        .HasOne(e => e.Features)
        .WithOne()
        .HasForeignKey<LfPhNCFeatures>(e => e.FeaturesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhNCSegments>()
        .HasMany(e => e.Segments)
        .WithMany()
        .UsingEntity(j => j.ToTable($"PhNCSegments_Segments_PhTerminalUnit"));
        builder.Entity<LfPhFeatureConstraint>()
        .HasOne(e => e.Feature)
        .WithMany()
        .HasForeignKey(e => e.FeatureGuid);
        builder.Entity<LfPhEnvironment>()
        .HasOne(e => e.LeftContext)
        .WithMany()
        .HasForeignKey(e => e.LeftContextGuid);
        builder.Entity<LfPhEnvironment>()
        .HasOne(e => e.RightContext)
        .WithMany()
        .HasForeignKey(e => e.RightContextGuid);
        builder.Entity<LfPhPhonData>()
        .HasMany(e => e.PhonemeSets)
        .WithOne()
        .HasForeignKey("PhPhonData_PhonemeSetsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhPhonData>()
        .HasMany(e => e.Environments)
        .WithOne()
        .HasForeignKey("PhPhonData_EnvironmentsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhPhonData>()
        .HasMany(e => e.NaturalClasses)
        .WithOne()
        .HasForeignKey("PhPhonData_NaturalClassesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhPhonData>()
        .HasMany(e => e.Contexts)
        .WithOne()
        .HasForeignKey("PhPhonData_ContextsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhPhonData>()
        .HasMany(e => e.FeatConstraints)
        .WithOne()
        .HasForeignKey("PhPhonData_FeatConstraintsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhPhonData>()
        .HasOne(e => e.PhonRuleFeats)
        .WithOne()
        .HasForeignKey<LfPhPhonData>(e => e.PhonRuleFeatsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhPhonData>()
        .HasMany(e => e.PhonRules)
        .WithOne()
        .HasForeignKey("PhPhonData_PhonRulesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoDeriv>()
        .HasOne(e => e.StemForm)
        .WithMany()
        .HasForeignKey(e => e.StemFormGuid);
        builder.Entity<LfMoDeriv>()
        .HasOne(e => e.StemMsa)
        .WithMany()
        .HasForeignKey(e => e.StemMsaGuid);
        builder.Entity<LfMoDeriv>()
        .HasOne(e => e.InflectionalFeats)
        .WithOne()
        .HasForeignKey<LfMoDeriv>(e => e.InflectionalFeatsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoDeriv>()
        .HasMany(e => e.StratumApps)
        .WithOne()
        .HasForeignKey("MoDeriv_StratumAppsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoAlloAdhocProhib>()
        .HasMany(e => e.Allomorphs)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoAlloAdhocProhib_Allomorphs_MoForm"));
        builder.Entity<LfMoAlloAdhocProhib>()
        .HasOne(e => e.FirstAllomorph)
        .WithMany()
        .HasForeignKey(e => e.FirstAllomorphGuid);
        builder.Entity<LfMoAlloAdhocProhib>()
        .HasMany(e => e.RestOfAllos)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoAlloAdhocProhib_RestOfAllos_MoForm"));
        builder.Entity<LfMoMorphAdhocProhib>()
        .HasMany(e => e.Morphemes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoMorphAdhocProhib_Morphemes_MoMorphSynAnalysis"));
        builder.Entity<LfMoMorphAdhocProhib>()
        .HasOne(e => e.FirstMorpheme)
        .WithMany()
        .HasForeignKey(e => e.FirstMorphemeGuid);
        builder.Entity<LfMoMorphAdhocProhib>()
        .HasMany(e => e.RestOfMorphs)
        .WithMany()
        .UsingEntity(j => j.ToTable($"MoMorphAdhocProhib_RestOfMorphs_MoMorphSynAnalysis"));
        builder.Entity<LfMoCopyFromInput>()
        .HasOne(e => e.Content)
        .WithMany()
        .HasForeignKey(e => e.ContentGuid);
        builder.Entity<LfWfiWordSet>()
        .HasMany(e => e.Cases)
        .WithMany()
        .UsingEntity(j => j.ToTable($"WfiWordSet_Cases_WfiWordform"));
        builder.Entity<LfMoBinaryCompoundRule>()
        .HasOne(e => e.LeftMsa)
        .WithOne()
        .HasForeignKey<LfMoBinaryCompoundRule>(e => e.LeftMsaGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoBinaryCompoundRule>()
        .HasOne(e => e.RightMsa)
        .WithOne()
        .HasForeignKey<LfMoBinaryCompoundRule>(e => e.RightMsaGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoBinaryCompoundRule>()
        .HasOne(e => e.Linker)
        .WithOne()
        .HasForeignKey<LfMoBinaryCompoundRule>(e => e.LinkerGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoGlossSystem>()
        .HasMany(e => e.Glosses)
        .WithOne()
        .HasForeignKey("MoGlossSystem_GlossesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoGlossItem>()
        .HasOne(e => e.FeatStructFrag)
        .WithOne()
        .HasForeignKey<LfMoGlossItem>(e => e.FeatStructFragGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoGlossItem>()
        .HasMany(e => e.GlossItems)
        .WithOne()
        .HasForeignKey("MoGlossItem_GlossItemsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfMoGlossItem>()
        .HasOne(e => e.Target)
        .WithMany()
        .HasForeignKey(e => e.TargetGuid);
        builder.Entity<LfMoAdhocProhibGr>()
        .HasMany(e => e.Members)
        .WithOne()
        .HasForeignKey("MoAdhocProhib_MembersGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfWfiMorphBundle>()
        .HasOne(e => e.Morph)
        .WithMany()
        .HasForeignKey(e => e.MorphGuid);
        builder.Entity<LfWfiMorphBundle>()
        .HasOne(e => e.Msa)
        .WithMany()
        .HasForeignKey(e => e.MsaGuid);
        builder.Entity<LfWfiMorphBundle>()
        .HasOne(e => e.Sense)
        .WithMany()
        .HasForeignKey(e => e.SenseGuid);
        builder.Entity<LfWfiMorphBundle>()
        .HasOne(e => e.InflType)
        .WithMany()
        .HasForeignKey(e => e.InflTypeGuid);
        builder.Entity<LfLexEtymology>()
        .HasMany(e => e.Language)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexEtymology_Language_Possibility"));
        builder.Entity<LfChkRef>()
        .HasOne(e => e.Rendering)
        .WithMany()
        .HasForeignKey(e => e.RenderingGuid);
        builder.Entity<LfMoUnclassifiedAffixMsa>()
        .HasOne(e => e.PartOfSpeech)
        .WithMany()
        .HasForeignKey(e => e.PartOfSpeechGuid);
        builder.Entity<LfLexRefType>()
        .HasMany(e => e.Members)
        .WithOne()
        .HasForeignKey("Possibility_MembersGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexReference>()
        .HasMany(e => e.Targets)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexReference_Targets_ObjectId"));
        builder.Entity<LfChkSense>()
        .HasOne(e => e.Sense)
        .WithMany()
        .HasForeignKey(e => e.SenseGuid);
        builder.Entity<LfDsChart>()
        .HasMany(e => e.Publications)
        .WithOne()
        .HasForeignKey("DsChart_PublicationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfDsChart>()
        .HasMany(e => e.HeaderFooterSets)
        .WithOne()
        .HasForeignKey("DsChart_HeaderFooterSetsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfDsChart>()
        .HasOne(e => e.Template)
        .WithMany()
        .HasForeignKey(e => e.TemplateGuid);
        builder.Entity<LfDsConstChart>()
        .HasOne(e => e.BasedOn)
        .WithMany()
        .HasForeignKey(e => e.BasedOnGuid);
        builder.Entity<LfDsConstChart>()
        .HasMany(e => e.Rows)
        .WithOne()
        .HasForeignKey("DsChart_RowsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfDsDiscourseData>()
        .HasOne(e => e.ConstChartTempl)
        .WithOne()
        .HasForeignKey<LfDsDiscourseData>(e => e.ConstChartTemplGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfDsDiscourseData>()
        .HasMany(e => e.Charts)
        .WithOne()
        .HasForeignKey("DsDiscourseData_ChartsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfDsDiscourseData>()
        .HasOne(e => e.ChartMarkers)
        .WithOne()
        .HasForeignKey<LfDsDiscourseData>(e => e.ChartMarkersGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfChkTerm>()
        .HasMany(e => e.Occurrences)
        .WithOne()
        .HasForeignKey("Possibility_OccurrencesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfChkTerm>()
        .HasMany(e => e.Renderings)
        .WithOne()
        .HasForeignKey("Possibility_RenderingsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfChkRendering>()
        .HasOne(e => e.SurfaceForm)
        .WithMany()
        .HasForeignKey(e => e.SurfaceFormGuid);
        builder.Entity<LfChkRendering>()
        .HasOne(e => e.Meaning)
        .WithMany()
        .HasForeignKey(e => e.MeaningGuid);
        builder.Entity<LfLexEntryRef>()
        .HasMany(e => e.VariantEntryTypes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexEntryRef_VariantEntryTypes_Possibility"));
        builder.Entity<LfLexEntryRef>()
        .HasMany(e => e.ComplexEntryTypes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexEntryRef_ComplexEntryTypes_Possibility"));
        builder.Entity<LfLexEntryRef>()
        .HasMany(e => e.PrimaryLexemes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexEntryRef_PrimaryLexemes_ObjectId"));
        builder.Entity<LfLexEntryRef>()
        .HasMany(e => e.ComponentLexemes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexEntryRef_ComponentLexemes_ObjectId"));
        builder.Entity<LfLexEntryRef>()
        .HasMany(e => e.ShowComplexFormsIn)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexEntryRef_ShowComplexFormsIn_ObjectId"));
        builder.Entity<LfPhSegmentRule>()
        .HasOne(e => e.InitialStratum)
        .WithMany()
        .HasForeignKey(e => e.InitialStratumGuid);
        builder.Entity<LfPhSegmentRule>()
        .HasOne(e => e.FinalStratum)
        .WithMany()
        .HasForeignKey(e => e.FinalStratumGuid);
        builder.Entity<LfPhSegmentRule>()
        .HasMany(e => e.StrucDesc)
        .WithOne()
        .HasForeignKey("PhSegmentRule_StrucDescGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhRegularRule>()
        .HasMany(e => e.RightHandSides)
        .WithOne()
        .HasForeignKey("PhSegmentRule_RightHandSidesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhSegRuleRHS>()
        .HasOne(e => e.LeftContext)
        .WithOne()
        .HasForeignKey<LfPhSegRuleRHS>(e => e.LeftContextGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhSegRuleRHS>()
        .HasOne(e => e.RightContext)
        .WithOne()
        .HasForeignKey<LfPhSegRuleRHS>(e => e.RightContextGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhSegRuleRHS>()
        .HasMany(e => e.StrucChange)
        .WithOne()
        .HasForeignKey("PhSegRuleRHS_StrucChangeGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfPhSegRuleRHS>()
        .HasMany(e => e.InputPOSes)
        .WithMany()
        .UsingEntity(j => j.ToTable($"PhSegRuleRHS_InputPOSes_Possibility"));
        builder.Entity<LfPhSegRuleRHS>()
        .HasMany(e => e.ExclRuleFeats)
        .WithMany()
        .UsingEntity(j => j.ToTable($"PhSegRuleRHS_ExclRuleFeats_Possibility"));
        builder.Entity<LfPhSegRuleRHS>()
        .HasMany(e => e.ReqRuleFeats)
        .WithMany()
        .UsingEntity(j => j.ToTable($"PhSegRuleRHS_ReqRuleFeats_Possibility"));
        builder.Entity<LfPhPhonRuleFeat>()
        .HasOne(e => e.Item)
        .WithMany()
        .HasForeignKey(e => e.ItemGuid);
        builder.Entity<LfLexEntryInflType>()
        .HasOne(e => e.InflFeats)
        .WithOne()
        .HasForeignKey<LfLexEntryInflType>(e => e.InflFeatsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLexEntryInflType>()
        .HasMany(e => e.Slots)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LexEntryInflType_Slots_MoInflAffixSlot"));
        builder.Entity<LfLexExtendedNote>()
        .HasOne(e => e.ExtendedNoteType)
        .WithMany()
        .HasForeignKey(e => e.ExtendedNoteTypeGuid);
        builder.Entity<LfLexExtendedNote>()
        .HasMany(e => e.Examples)
        .WithOne()
        .HasForeignKey("LexExtendedNote_ExamplesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.PartsOfSpeech)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.PartsOfSpeechGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.TranslationTags)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.TranslationTagsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.Thesaurus)
        .WithMany()
        .HasForeignKey(e => e.ThesaurusGuid);
        builder.Entity<LfLangProject>()
        .HasMany(e => e.WordformLookupLists)
        .WithMany()
        .UsingEntity(j => j.ToTable($"LangProject_WordformLookupLists_WordformLookupList"));
        builder.Entity<LfLangProject>()
        .HasOne(e => e.AnthroList)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.AnthroListGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.LexDb)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.LexDbGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.ResearchNotebook)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.ResearchNotebookGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.MsFeatureSystem)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.MsFeatureSystemGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.MorphologicalData)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.MorphologicalDataGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasMany(e => e.Styles)
        .WithOne()
        .HasForeignKey("Project_StylesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasMany(e => e.Filters)
        .WithOne()
        .HasForeignKey("Project_FiltersGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.ConfidenceLevels)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.ConfidenceLevelsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.Restrictions)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.RestrictionsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.Roles)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.RolesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.Status)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.StatusGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.Locations)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.LocationsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.People)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.PeopleGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.Education)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.EducationGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.TimeOfDay)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.TimeOfDayGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.AffixCategories)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.AffixCategoriesGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.PhonologicalData)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.PhonologicalDataGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.Positions)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.PositionsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasMany(e => e.Overlays)
        .WithOne()
        .HasForeignKey("Project_OverlaysGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasMany(e => e.AnalyzingAgents)
        .WithOne()
        .HasForeignKey("Project_AnalyzingAgentsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.TranslatedScripture)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.TranslatedScriptureGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasMany(e => e.Annotations)
        .WithOne()
        .HasForeignKey("Project_AnnotationsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasMany(e => e.UserAccounts)
        .WithOne()
        .HasForeignKey("Project_UserAccountsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasMany(e => e.ActivatedFeatures)
        .WithOne()
        .HasForeignKey("Project_ActivatedFeaturesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.AnnotationDefs)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.AnnotationDefsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasMany(e => e.Pictures)
        .WithOne()
        .HasForeignKey("Project_PicturesGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.SemanticDomainList)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.SemanticDomainListGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasMany(e => e.CheckLists)
        .WithOne()
        .HasForeignKey("Project_CheckListsGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasMany(e => e.Media)
        .WithOne()
        .HasForeignKey("Project_MediaGuid")
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.GenreList)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.GenreListGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.DiscourseData)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.DiscourseDataGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.TextMarkupTags)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.TextMarkupTagsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.FilePathsInTsStrings)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.FilePathsInTsStringsGuid)
        .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<LfLangProject>()
        .HasOne(e => e.PhFeatureSystem)
        .WithOne()
        .HasForeignKey<LfLangProject>(e => e.PhFeatureSystemGuid)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
