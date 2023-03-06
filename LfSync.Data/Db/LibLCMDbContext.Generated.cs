using LfSync.Data.LCModel;
using Microsoft.EntityFrameworkCore;

namespace LfSync.Data.Db;

public partial class LibLCMDbContext : DbContext
{
    partial void OnModelCreating_Generated(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LfFolder>()
            .HasMany(e => e.SubFolders)
            .WithOne()
            .HasForeignKey($"FolderGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfFolder>()
            .HasMany(e => e.Files)
            .WithOne()
            .HasForeignKey($"FolderGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfFsComplexFeature>()
            .HasOne(e => e.Type)
            .WithMany()
            .HasForeignKey($"FsComplexFeatureGuid");
        modelBuilder.Entity<LfMajorObject>()
            .HasMany(e => e.Publications)
            .WithOne()
            .HasForeignKey($"Guid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMajorObject>()
            .HasMany(e => e.HeaderFooterSets)
            .WithOne()
            .HasForeignKey($"Guid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfSegment>()
            .HasMany(e => e.Notes)
            .WithOne()
            .HasForeignKey($"SegmentGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfSegment>()
            .HasMany(e => e.Analyses)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Segment.Analyses_Analysis"));
        modelBuilder.Entity<LfSegment>()
            .HasOne(e => e.MediaURI)
            .WithMany()
            .HasForeignKey($"SegmentGuid");
        modelBuilder.Entity<LfSegment>()
            .HasOne(e => e.Speaker)
            .WithMany()
            .HasForeignKey($"SegmentGuid");
        modelBuilder.Entity<LfPossibility>()
            .HasMany(e => e.SubPossibilities)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPossibility>()
            .HasMany(e => e.Restrictions)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Possibility.Restrictions_Possibility"));
        modelBuilder.Entity<LfPossibility>()
            .HasOne(e => e.Confidence)
            .WithMany()
            .HasForeignKey($"PossibilityGuid");
        modelBuilder.Entity<LfPossibility>()
            .HasOne(e => e.Status)
            .WithMany()
            .HasForeignKey($"PossibilityGuid");
        modelBuilder.Entity<LfPossibility>()
            .HasMany(e => e.Researchers)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Possibility.Researchers_Possibility"));
        modelBuilder.Entity<LfPossibilityList>()
            .HasMany(e => e.Possibilities)
            .WithOne()
            .HasForeignKey($"PossibilityListGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfFilter>()
            .HasMany(e => e.Rows)
            .WithOne()
            .HasForeignKey($"FilterGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfRow>()
            .HasMany(e => e.Cells)
            .WithOne()
            .HasForeignKey($"RowGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPerson>()
            .HasOne(e => e.PlaceOfBirth)
            .WithMany()
            .HasForeignKey($"PossibilityGuid");
        modelBuilder.Entity<LfPerson>()
            .HasMany(e => e.PlacesOfResidence)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Possibility.PlacesOfResidence_Possibility"));
        modelBuilder.Entity<LfPerson>()
            .HasOne(e => e.Education)
            .WithMany()
            .HasForeignKey($"PossibilityGuid");
        modelBuilder.Entity<LfPerson>()
            .HasMany(e => e.Positions)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Possibility.Positions_Possibility"));
        modelBuilder.Entity<LfStText>()
            .HasMany(e => e.Paragraphs)
            .WithOne()
            .HasForeignKey($"StTextGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfStText>()
            .HasMany(e => e.Tags)
            .WithOne()
            .HasForeignKey($"StTextGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfStTxtPara>()
            .HasMany(e => e.TextObjects)
            .WithMany()
            .UsingEntity(j => j.ToTable($"StPara.TextObjects_Object"));
        modelBuilder.Entity<LfStTxtPara>()
            .HasMany(e => e.AnalyzedTextObjects)
            .WithOne()
            .HasForeignKey($"StParaGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfStTxtPara>()
            .HasMany(e => e.Segments)
            .WithOne()
            .HasForeignKey($"StParaGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfStTxtPara>()
            .HasMany(e => e.Translations)
            .WithOne()
            .HasForeignKey($"StParaGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfStStyle>()
            .HasOne(e => e.BasedOn)
            .WithMany()
            .HasForeignKey($"StStyleGuid");
        modelBuilder.Entity<LfStStyle>()
            .HasOne(e => e.Next)
            .WithMany()
            .HasForeignKey($"StStyleGuid");
        modelBuilder.Entity<LfOverlay>()
            .HasOne(e => e.PossList)
            .WithMany()
            .HasForeignKey($"OverlayGuid");
        modelBuilder.Entity<LfOverlay>()
            .HasMany(e => e.PossItems)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Overlay.PossItems_Possibility"));
        modelBuilder.Entity<LfTextTag>()
            .HasOne(e => e.BeginSegment)
            .WithMany()
            .HasForeignKey($"TextTagGuid");
        modelBuilder.Entity<LfTextTag>()
            .HasOne(e => e.EndSegment)
            .WithMany()
            .HasForeignKey($"TextTagGuid");
        modelBuilder.Entity<LfTextTag>()
            .HasOne(e => e.Tag)
            .WithMany()
            .HasForeignKey($"TextTagGuid");
        modelBuilder.Entity<LfTranslation>()
            .HasOne(e => e.Type)
            .WithMany()
            .HasForeignKey($"TranslationGuid");
        modelBuilder.Entity<LfAnnotation>()
            .HasOne(e => e.AnnotationType)
            .WithMany()
            .HasForeignKey($"AnnotationGuid");
        modelBuilder.Entity<LfAnnotation>()
            .HasOne(e => e.Source)
            .WithMany()
            .HasForeignKey($"AnnotationGuid");
        modelBuilder.Entity<LfAnnotation>()
            .HasOne(e => e.InstanceOf)
            .WithMany()
            .HasForeignKey($"AnnotationGuid");
        modelBuilder.Entity<LfIndirectAnnotation>()
            .HasMany(e => e.AppliesTo)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Annotation.AppliesTo_Annotation"));
        modelBuilder.Entity<LfBaseAnnotation>()
            .HasOne(e => e.BeginObject)
            .WithMany()
            .HasForeignKey($"AnnotationGuid");
        modelBuilder.Entity<LfBaseAnnotation>()
            .HasOne(e => e.EndObject)
            .WithMany()
            .HasForeignKey($"AnnotationGuid");
        modelBuilder.Entity<LfBaseAnnotation>()
            .HasMany(e => e.OtherObjects)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Annotation.OtherObjects_Object"));
        modelBuilder.Entity<LfUserAppFeatAct>()
            .HasMany(e => e.UserConfigAcct)
            .WithMany()
            .UsingEntity(j => j.ToTable($"UserAppFeatAct.UserConfigAcct_UserConfigAcct"));
        modelBuilder.Entity<LfPublication>()
            .HasMany(e => e.Divisions)
            .WithOne()
            .HasForeignKey($"PublicationGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPicture>()
            .HasOne(e => e.PictureFile)
            .WithMany()
            .HasForeignKey($"PictureGuid");
        modelBuilder.Entity<LfPicture>()
            .HasMany(e => e.DoNotPublishIn)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Picture.DoNotPublishIn_Possibility"));
        modelBuilder.Entity<LfFsFeatureSystem>()
            .HasMany(e => e.Types)
            .WithOne()
            .HasForeignKey($"FsFeatureSystemGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfFsFeatureSystem>()
            .HasMany(e => e.Features)
            .WithOne()
            .HasForeignKey($"FsFeatureSystemGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfFsClosedFeature>()
            .HasMany(e => e.Values)
            .WithOne()
            .HasForeignKey($"FsClosedFeatureGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfFsClosedValue>()
            .HasOne(e => e.Value)
            .WithMany()
            .HasForeignKey($"FsClosedValueGuid");
        modelBuilder.Entity<LfFsDisjunctiveValue>()
            .HasMany(e => e.Value)
            .WithMany()
            .UsingEntity(j => j.ToTable($"FsDisjunctiveValue.Value_FsSymFeatVal"));
        modelBuilder.Entity<LfFsFeatureSpecification>()
            .HasOne(e => e.Feature)
            .WithMany()
            .HasForeignKey($"FsFeatureSpecificationGuid");
        modelBuilder.Entity<LfFsFeatStruc>()
            .HasMany(e => e.FeatureDisjunctions)
            .WithOne()
            .HasForeignKey($"FsFeatStrucGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfFsFeatStruc>()
            .HasMany(e => e.FeatureSpecs)
            .WithOne()
            .HasForeignKey($"FsFeatStrucGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfFsFeatStruc>()
            .HasOne(e => e.Type)
            .WithMany()
            .HasForeignKey($"FsFeatStrucGuid");
        modelBuilder.Entity<LfFsFeatStrucDisj>()
            .HasMany(e => e.Contents)
            .WithOne()
            .HasForeignKey($"FsFeatStrucDisjGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfFsFeatStrucType>()
            .HasMany(e => e.Features)
            .WithMany()
            .UsingEntity(j => j.ToTable($"FsFeatStrucType.Features_FsFeatDefn"));
        modelBuilder.Entity<LfFsNegatedValue>()
            .HasOne(e => e.Value)
            .WithMany()
            .HasForeignKey($"FsFeatureSpecificationGuid");
        modelBuilder.Entity<LfFsSharedValue>()
            .HasOne(e => e.Value)
            .WithMany()
            .HasForeignKey($"FsFeatureSpecificationGuid");
        modelBuilder.Entity<LfSemanticDomain>()
            .HasMany(e => e.OcmRefs)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Possibility.OcmRefs_Possibility"));
        modelBuilder.Entity<LfSemanticDomain>()
            .HasMany(e => e.RelatedDomains)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Possibility.RelatedDomains_Possibility"));
        modelBuilder.Entity<LfSemanticDomain>()
            .HasMany(e => e.Questions)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfStJournalText>()
            .HasOne(e => e.CreatedBy)
            .WithMany()
            .HasForeignKey($"StTextGuid");
        modelBuilder.Entity<LfStJournalText>()
            .HasOne(e => e.ModifiedBy)
            .WithMany()
            .HasForeignKey($"StTextGuid");
        modelBuilder.Entity<LfMedia>()
            .HasOne(e => e.MediaFile)
            .WithMany()
            .HasForeignKey($"MediaGuid");
        modelBuilder.Entity<LfVirtualOrdering>()
            .HasOne(e => e.Source)
            .WithMany()
            .HasForeignKey($"VirtualOrderingGuid");
        modelBuilder.Entity<LfVirtualOrdering>()
            .HasMany(e => e.Items)
            .WithMany()
            .UsingEntity(j => j.ToTable($"VirtualOrdering.Items_Object"));
        modelBuilder.Entity<LfMediaContainer>()
            .HasMany(e => e.MediaURIs)
            .WithOne()
            .HasForeignKey($"MediaContainerGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScripture>()
            .HasMany(e => e.ScriptureBooks)
            .WithOne()
            .HasForeignKey($"ScriptureGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScripture>()
            .HasMany(e => e.Styles)
            .WithOne()
            .HasForeignKey($"ScriptureGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScripture>()
            .HasMany(e => e.ImportSettings)
            .WithOne()
            .HasForeignKey($"ScriptureGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScripture>()
            .HasMany(e => e.ArchivedDrafts)
            .WithOne()
            .HasForeignKey($"ScriptureGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScripture>()
            .HasMany(e => e.BookAnnotations)
            .WithOne()
            .HasForeignKey($"ScriptureGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScripture>()
            .HasMany(e => e.Resources)
            .WithOne()
            .HasForeignKey($"ScriptureGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrBook>()
            .HasMany(e => e.Sections)
            .WithOne()
            .HasForeignKey($"ScrBookGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrBook>()
            .HasOne(e => e.BookId)
            .WithMany()
            .HasForeignKey($"ScrBookGuid");
        modelBuilder.Entity<LfScrBook>()
            .HasMany(e => e.Footnotes)
            .WithOne()
            .HasForeignKey($"ScrBookGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrBook>()
            .HasMany(e => e.Diffs)
            .WithOne()
            .HasForeignKey($"ScrBookGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrRefSystem>()
            .HasMany(e => e.Books)
            .WithOne()
            .HasForeignKey($"ScrRefSystemGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrImportSet>()
            .HasMany(e => e.ScriptureSources)
            .WithOne()
            .HasForeignKey($"ScrImportSetGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrImportSet>()
            .HasMany(e => e.BackTransSources)
            .WithOne()
            .HasForeignKey($"ScrImportSetGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrImportSet>()
            .HasMany(e => e.NoteSources)
            .WithOne()
            .HasForeignKey($"ScrImportSetGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrImportSet>()
            .HasMany(e => e.ScriptureMappings)
            .WithOne()
            .HasForeignKey($"ScrImportSetGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrImportSet>()
            .HasMany(e => e.NoteMappings)
            .WithOne()
            .HasForeignKey($"ScrImportSetGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrDraft>()
            .HasMany(e => e.Books)
            .WithOne()
            .HasForeignKey($"ScrDraftGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrDifference>()
            .HasOne(e => e.RevParagraph)
            .WithMany()
            .HasForeignKey($"ScrDifferenceGuid");
        modelBuilder.Entity<LfScrImportSource>()
            .HasOne(e => e.NoteType)
            .WithMany()
            .HasForeignKey($"ScrImportSourceGuid");
        modelBuilder.Entity<LfScrImportSFFiles>()
            .HasMany(e => e.Files)
            .WithOne()
            .HasForeignKey($"ScrImportSourceGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrMarkerMapping>()
            .HasOne(e => e.Style)
            .WithMany()
            .HasForeignKey($"ScrMarkerMappingGuid");
        modelBuilder.Entity<LfScrMarkerMapping>()
            .HasOne(e => e.NoteType)
            .WithMany()
            .HasForeignKey($"ScrMarkerMappingGuid");
        modelBuilder.Entity<LfScrBookAnnotations>()
            .HasMany(e => e.Notes)
            .WithOne()
            .HasForeignKey($"ScrBookAnnotationsGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrBookAnnotations>()
            .HasMany(e => e.ChkHistRecs)
            .WithOne()
            .HasForeignKey($"ScrBookAnnotationsGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrScriptureNote>()
            .HasMany(e => e.Categories)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Annotation.Categories_Possibility"));
        modelBuilder.Entity<LfScrScriptureNote>()
            .HasMany(e => e.Responses)
            .WithOne()
            .HasForeignKey($"AnnotationGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfScrFootnote>()
            .HasOne(e => e.ParaContainingOrc)
            .WithMany()
            .HasForeignKey($"StTextGuid");
        modelBuilder.Entity<LfRnResearchNbk>()
            .HasMany(e => e.Records)
            .WithOne()
            .HasForeignKey($"RnResearchNbkGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfRnResearchNbk>()
            .HasMany(e => e.Reminders)
            .WithOne()
            .HasForeignKey($"RnResearchNbkGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfRnResearchNbk>()
            .HasMany(e => e.CrossReferences)
            .WithOne()
            .HasForeignKey($"RnResearchNbkGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.Reminders)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.Reminders_Reminder"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.Researchers)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.Researchers_Possibility"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasOne(e => e.Confidence)
            .WithMany()
            .HasForeignKey($"RnGenericRecGuid");
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.Restrictions)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.Restrictions_Possibility"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.AnthroCodes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.AnthroCodes_Possibility"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.PhraseTags)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.PhraseTags_Possibility"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.SubRecords)
            .WithOne()
            .HasForeignKey($"RnGenericRecGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.CrossReferences)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.CrossReferences_CrossReference"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.SeeAlso)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.SeeAlso_RnGenericRec"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.CounterEvidence)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.CounterEvidence_RnGenericRec"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasOne(e => e.Status)
            .WithMany()
            .HasForeignKey($"RnGenericRecGuid");
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.SupersededBy)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.SupersededBy_RnGenericRec"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.SupportingEvidence)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.SupportingEvidence_RnGenericRec"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.Locations)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.Locations_Possibility"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.Sources)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.Sources_Possibility"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.TimeOfEvent)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnGenericRec.TimeOfEvent_Possibility"));
        modelBuilder.Entity<LfRnGenericRec>()
            .HasOne(e => e.Type)
            .WithMany()
            .HasForeignKey($"RnGenericRecGuid");
        modelBuilder.Entity<LfRnGenericRec>()
            .HasMany(e => e.Participants)
            .WithOne()
            .HasForeignKey($"RnGenericRecGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfRnGenericRec>()
            .HasOne(e => e.Text)
            .WithMany()
            .HasForeignKey($"RnGenericRecGuid");
        modelBuilder.Entity<LfRnRoledPartic>()
            .HasMany(e => e.Participants)
            .WithMany()
            .UsingEntity(j => j.ToTable($"RnRoledPartic.Participants_Possibility"));
        modelBuilder.Entity<LfRnRoledPartic>()
            .HasOne(e => e.Role)
            .WithMany()
            .HasForeignKey($"RnRoledParticGuid");
        modelBuilder.Entity<LfMoStemMsa>()
            .HasOne(e => e.PartOfSpeech)
            .WithMany()
            .HasForeignKey($"MoStemMsaGuid");
        modelBuilder.Entity<LfMoStemMsa>()
            .HasOne(e => e.InflectionClass)
            .WithMany()
            .HasForeignKey($"MoStemMsaGuid");
        modelBuilder.Entity<LfMoStemMsa>()
            .HasOne(e => e.Stratum)
            .WithMany()
            .HasForeignKey($"MoStemMsaGuid");
        modelBuilder.Entity<LfMoStemMsa>()
            .HasMany(e => e.ProdRestrict)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoStemMsa.ProdRestrict_Possibility"));
        modelBuilder.Entity<LfMoStemMsa>()
            .HasMany(e => e.FromPartsOfSpeech)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoStemMsa.FromPartsOfSpeech_Possibility"));
        modelBuilder.Entity<LfMoStemMsa>()
            .HasMany(e => e.Slots)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoStemMsa.Slots_MoInflAffixSlot"));
        modelBuilder.Entity<LfLexEntry>()
            .HasMany(e => e.MorphoSyntaxAnalyses)
            .WithOne()
            .HasForeignKey($"LexEntryGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexEntry>()
            .HasMany(e => e.Senses)
            .WithOne()
            .HasForeignKey($"LexEntryGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexEntry>()
            .HasMany(e => e.Etymology)
            .WithOne()
            .HasForeignKey($"LexEntryGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexEntry>()
            .HasMany(e => e.MainEntriesOrSenses)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexEntry.MainEntriesOrSenses_Object"));
        modelBuilder.Entity<LfLexEntry>()
            .HasMany(e => e.DoNotShowMainEntryIn)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexEntry.DoNotShowMainEntryIn_Possibility"));
        modelBuilder.Entity<LfLexEntry>()
            .HasMany(e => e.AlternateForms)
            .WithOne()
            .HasForeignKey($"LexEntryGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexEntry>()
            .HasMany(e => e.Pronunciations)
            .WithOne()
            .HasForeignKey($"LexEntryGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexEntry>()
            .HasMany(e => e.EntryRefs)
            .WithOne()
            .HasForeignKey($"LexEntryGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexEntry>()
            .HasMany(e => e.DoNotPublishIn)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexEntry.DoNotPublishIn_Possibility"));
        modelBuilder.Entity<LfLexEntry>()
            .HasMany(e => e.DialectLabels)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexEntry.DialectLabels_Possibility"));
        modelBuilder.Entity<LfConstChartRow>()
            .HasMany(e => e.Cells)
            .WithOne()
            .HasForeignKey($"ConstChartRowGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexExampleSentence>()
            .HasMany(e => e.Translations)
            .WithOne()
            .HasForeignKey($"LexExampleSentenceGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexExampleSentence>()
            .HasMany(e => e.DoNotPublishIn)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexExampleSentence.DoNotPublishIn_Possibility"));
        modelBuilder.Entity<LfLexDb>()
            .HasMany(e => e.Appendixes)
            .WithOne()
            .HasForeignKey($"LexDbGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexDb>()
            .HasMany(e => e.LexicalFormIndex)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexDb.LexicalFormIndex_LexEntry"));
        modelBuilder.Entity<LfLexDb>()
            .HasMany(e => e.AllomorphIndex)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexDb.AllomorphIndex_MoForm"));
        modelBuilder.Entity<LfLexDb>()
            .HasMany(e => e.ReversalIndexes)
            .WithOne()
            .HasForeignKey($"LexDbGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexDb>()
            .HasMany(e => e.Resources)
            .WithOne()
            .HasForeignKey($"LexDbGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfConstituentChartCellPart>()
            .HasOne(e => e.Column)
            .WithMany()
            .HasForeignKey($"ConstituentChartCellPartGuid");
        modelBuilder.Entity<LfConstChartWordGroup>()
            .HasOne(e => e.BeginSegment)
            .WithMany()
            .HasForeignKey($"ConstituentChartCellPartGuid");
        modelBuilder.Entity<LfConstChartWordGroup>()
            .HasOne(e => e.EndSegment)
            .WithMany()
            .HasForeignKey($"ConstituentChartCellPartGuid");
        modelBuilder.Entity<LfConstChartMovedTextMarker>()
            .HasOne(e => e.WordGroup)
            .WithMany()
            .HasForeignKey($"ConstituentChartCellPartGuid");
        modelBuilder.Entity<LfConstChartClauseMarker>()
            .HasMany(e => e.DependentClauses)
            .WithMany()
            .UsingEntity(j => j.ToTable($"ConstituentChartCellPart.DependentClauses_ConstChartRow"));
        modelBuilder.Entity<LfConstChartTag>()
            .HasOne(e => e.Tag)
            .WithMany()
            .HasForeignKey($"ConstituentChartCellPartGuid");
        modelBuilder.Entity<LfLexPronunciation>()
            .HasOne(e => e.Location)
            .WithMany()
            .HasForeignKey($"LexPronunciationGuid");
        modelBuilder.Entity<LfLexPronunciation>()
            .HasMany(e => e.MediaFiles)
            .WithOne()
            .HasForeignKey($"LexPronunciationGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexPronunciation>()
            .HasMany(e => e.DoNotPublishIn)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexPronunciation.DoNotPublishIn_Possibility"));
        modelBuilder.Entity<LfLexSense>()
            .HasOne(e => e.MorphoSyntaxAnalysis)
            .WithMany()
            .HasForeignKey($"LexSenseGuid");
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.AnthroCodes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexSense.AnthroCodes_Possibility"));
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.Senses)
            .WithOne()
            .HasForeignKey($"LexSenseGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.Appendixes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexSense.Appendixes_LexAppendix"));
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.DomainTypes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexSense.DomainTypes_Possibility"));
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.Examples)
            .WithOne()
            .HasForeignKey($"LexSenseGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexSense>()
            .HasOne(e => e.SenseType)
            .WithMany()
            .HasForeignKey($"LexSenseGuid");
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.ThesaurusItems)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexSense.ThesaurusItems_Possibility"));
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.UsageTypes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexSense.UsageTypes_Possibility"));
        modelBuilder.Entity<LfLexSense>()
            .HasOne(e => e.Status)
            .WithMany()
            .HasForeignKey($"LexSenseGuid");
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.SemanticDomains)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexSense.SemanticDomains_Possibility"));
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.Pictures)
            .WithOne()
            .HasForeignKey($"LexSenseGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.DoNotPublishIn)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexSense.DoNotPublishIn_Possibility"));
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.ExtendedNote)
            .WithOne()
            .HasForeignKey($"LexSenseGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexSense>()
            .HasMany(e => e.DialectLabels)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexSense.DialectLabels_Possibility"));
        modelBuilder.Entity<LfMoAffixAllomorph>()
            .HasMany(e => e.PhoneEnv)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoAffixAllomorph.PhoneEnv_PhEnvironment"));
        modelBuilder.Entity<LfMoAffixAllomorph>()
            .HasOne(e => e.MsEnvPartOfSpeech)
            .WithMany()
            .HasForeignKey($"MoAffixAllomorphGuid");
        modelBuilder.Entity<LfMoAffixAllomorph>()
            .HasMany(e => e.Position)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoAffixAllomorph.Position_PhEnvironment"));
        modelBuilder.Entity<LfMoAffixForm>()
            .HasMany(e => e.InflectionClasses)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoAffixForm.InflectionClasses_MoInflClass"));
        modelBuilder.Entity<LfMoAffixProcess>()
            .HasMany(e => e.Input)
            .WithOne()
            .HasForeignKey($"MoAffixFormGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoAffixProcess>()
            .HasMany(e => e.Output)
            .WithOne()
            .HasForeignKey($"MoAffixFormGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoCompoundRule>()
            .HasOne(e => e.Stratum)
            .WithMany()
            .HasForeignKey($"MoCompoundRuleGuid");
        modelBuilder.Entity<LfMoCompoundRule>()
            .HasMany(e => e.ToProdRestrict)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoCompoundRule.ToProdRestrict_Possibility"));
        modelBuilder.Entity<LfMoDerivAffMsa>()
            .HasOne(e => e.FromPartOfSpeech)
            .WithMany()
            .HasForeignKey($"MoDerivAffMsaGuid");
        modelBuilder.Entity<LfMoDerivAffMsa>()
            .HasOne(e => e.ToPartOfSpeech)
            .WithMany()
            .HasForeignKey($"MoDerivAffMsaGuid");
        modelBuilder.Entity<LfMoDerivAffMsa>()
            .HasOne(e => e.FromInflectionClass)
            .WithMany()
            .HasForeignKey($"MoDerivAffMsaGuid");
        modelBuilder.Entity<LfMoDerivAffMsa>()
            .HasOne(e => e.ToInflectionClass)
            .WithMany()
            .HasForeignKey($"MoDerivAffMsaGuid");
        modelBuilder.Entity<LfMoDerivAffMsa>()
            .HasOne(e => e.AffixCategory)
            .WithMany()
            .HasForeignKey($"MoDerivAffMsaGuid");
        modelBuilder.Entity<LfMoDerivAffMsa>()
            .HasOne(e => e.FromStemName)
            .WithMany()
            .HasForeignKey($"MoDerivAffMsaGuid");
        modelBuilder.Entity<LfMoDerivAffMsa>()
            .HasOne(e => e.Stratum)
            .WithMany()
            .HasForeignKey($"MoDerivAffMsaGuid");
        modelBuilder.Entity<LfMoDerivAffMsa>()
            .HasMany(e => e.FromProdRestrict)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoDerivAffMsa.FromProdRestrict_Possibility"));
        modelBuilder.Entity<LfMoDerivAffMsa>()
            .HasMany(e => e.ToProdRestrict)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoDerivAffMsa.ToProdRestrict_Possibility"));
        modelBuilder.Entity<LfMoDerivStepMsa>()
            .HasOne(e => e.PartOfSpeech)
            .WithMany()
            .HasForeignKey($"MoDerivStepMsaGuid");
        modelBuilder.Entity<LfMoDerivStepMsa>()
            .HasOne(e => e.InflectionClass)
            .WithMany()
            .HasForeignKey($"MoDerivStepMsaGuid");
        modelBuilder.Entity<LfMoDerivStepMsa>()
            .HasMany(e => e.ProdRestrict)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoDerivStepMsa.ProdRestrict_Possibility"));
        modelBuilder.Entity<LfMoForm>()
            .HasOne(e => e.MorphType)
            .WithMany()
            .HasForeignKey($"MoFormGuid");
        modelBuilder.Entity<LfMoInflAffixTemplate>()
            .HasMany(e => e.Slots)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoInflAffixTemplate.Slots_MoInflAffixSlot"));
        modelBuilder.Entity<LfMoInflAffixTemplate>()
            .HasOne(e => e.Stratum)
            .WithMany()
            .HasForeignKey($"MoInflAffixTemplateGuid");
        modelBuilder.Entity<LfMoInflAffixTemplate>()
            .HasMany(e => e.PrefixSlots)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoInflAffixTemplate.PrefixSlots_MoInflAffixSlot"));
        modelBuilder.Entity<LfMoInflAffixTemplate>()
            .HasMany(e => e.SuffixSlots)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoInflAffixTemplate.SuffixSlots_MoInflAffixSlot"));
        modelBuilder.Entity<LfMoInflAffixTemplate>()
            .HasMany(e => e.ProcliticSlots)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoInflAffixTemplate.ProcliticSlots_MoInflAffixSlot"));
        modelBuilder.Entity<LfMoInflAffixTemplate>()
            .HasMany(e => e.EncliticSlots)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoInflAffixTemplate.EncliticSlots_MoInflAffixSlot"));
        modelBuilder.Entity<LfMoInflAffMsa>()
            .HasOne(e => e.AffixCategory)
            .WithMany()
            .HasForeignKey($"MoInflAffMsaGuid");
        modelBuilder.Entity<LfMoInflAffMsa>()
            .HasOne(e => e.PartOfSpeech)
            .WithMany()
            .HasForeignKey($"MoInflAffMsaGuid");
        modelBuilder.Entity<LfMoInflAffMsa>()
            .HasMany(e => e.Slots)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoInflAffMsa.Slots_MoInflAffixSlot"));
        modelBuilder.Entity<LfMoInflAffMsa>()
            .HasMany(e => e.FromProdRestrict)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoInflAffMsa.FromProdRestrict_Possibility"));
        modelBuilder.Entity<LfMoInflClass>()
            .HasMany(e => e.Subclasses)
            .WithOne()
            .HasForeignKey($"MoInflClassGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoInflClass>()
            .HasMany(e => e.RulesOfReferral)
            .WithOne()
            .HasForeignKey($"MoInflClassGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoInflClass>()
            .HasMany(e => e.StemNames)
            .WithOne()
            .HasForeignKey($"MoInflClassGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoInflClass>()
            .HasMany(e => e.ReferenceForms)
            .WithOne()
            .HasForeignKey($"MoInflClassGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoMorphData>()
            .HasMany(e => e.Strata)
            .WithOne()
            .HasForeignKey($"MoMorphDataGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoMorphData>()
            .HasMany(e => e.CompoundRules)
            .WithOne()
            .HasForeignKey($"MoMorphDataGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoMorphData>()
            .HasMany(e => e.AdhocCoProhibitions)
            .WithOne()
            .HasForeignKey($"MoMorphDataGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoMorphData>()
            .HasMany(e => e.AnalyzingAgents)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoMorphData.AnalyzingAgents_Agent"));
        modelBuilder.Entity<LfMoMorphData>()
            .HasMany(e => e.TestSets)
            .WithOne()
            .HasForeignKey($"MoMorphDataGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoMorphSynAnalysis>()
            .HasMany(e => e.Components)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoMorphSynAnalysis.Components_MoMorphSynAnalysis"));
        modelBuilder.Entity<LfMoMorphSynAnalysis>()
            .HasMany(e => e.GlossBundle)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoMorphSynAnalysis.GlossBundle_MoGlossItem"));
        modelBuilder.Entity<LfMoStemAllomorph>()
            .HasMany(e => e.PhoneEnv)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoForm.PhoneEnv_PhEnvironment"));
        modelBuilder.Entity<LfMoStemAllomorph>()
            .HasOne(e => e.StemName)
            .WithMany()
            .HasForeignKey($"MoFormGuid");
        modelBuilder.Entity<LfMoStemName>()
            .HasMany(e => e.Regions)
            .WithOne()
            .HasForeignKey($"MoStemNameGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoStemName>()
            .HasOne(e => e.DefaultAffix)
            .WithMany()
            .HasForeignKey($"MoStemNameGuid");
        modelBuilder.Entity<LfMoStemName>()
            .HasOne(e => e.DefaultStem)
            .WithMany()
            .HasForeignKey($"MoStemNameGuid");
        modelBuilder.Entity<LfMoStratum>()
            .HasOne(e => e.Phonemes)
            .WithMany()
            .HasForeignKey($"MoStratumGuid");
        modelBuilder.Entity<LfPartOfSpeech>()
            .HasMany(e => e.EmptyParadigmCells)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPartOfSpeech>()
            .HasMany(e => e.RulesOfReferral)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPartOfSpeech>()
            .HasMany(e => e.InflectionClasses)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPartOfSpeech>()
            .HasMany(e => e.AffixTemplates)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPartOfSpeech>()
            .HasMany(e => e.AffixSlots)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPartOfSpeech>()
            .HasMany(e => e.StemNames)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPartOfSpeech>()
            .HasMany(e => e.BearableFeatures)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Possibility.BearableFeatures_FsFeatDefn"));
        modelBuilder.Entity<LfPartOfSpeech>()
            .HasMany(e => e.InflectableFeats)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Possibility.InflectableFeats_FsFeatDefn"));
        modelBuilder.Entity<LfPartOfSpeech>()
            .HasMany(e => e.ReferenceForms)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPartOfSpeech>()
            .HasOne(e => e.DefaultInflectionClass)
            .WithMany()
            .HasForeignKey($"PossibilityGuid");
        modelBuilder.Entity<LfReversalIndex>()
            .HasMany(e => e.Entries)
            .WithOne()
            .HasForeignKey($"ReversalIndexGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfReversalIndexEntry>()
            .HasMany(e => e.Subentries)
            .WithOne()
            .HasForeignKey($"ReversalIndexEntryGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfReversalIndexEntry>()
            .HasOne(e => e.PartOfSpeech)
            .WithMany()
            .HasForeignKey($"ReversalIndexEntryGuid");
        modelBuilder.Entity<LfReversalIndexEntry>()
            .HasMany(e => e.Senses)
            .WithMany()
            .UsingEntity(j => j.ToTable($"ReversalIndexEntry.Senses_LexSense"));
        modelBuilder.Entity<LfText>()
            .HasMany(e => e.Genres)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Text.Genres_Possibility"));
        modelBuilder.Entity<LfWfiAnalysis>()
            .HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey($"WfiAnalysisGuid");
        modelBuilder.Entity<LfWfiAnalysis>()
            .HasMany(e => e.Stems)
            .WithMany()
            .UsingEntity(j => j.ToTable($"WfiAnalysis.Stems_LexEntry"));
        modelBuilder.Entity<LfWfiAnalysis>()
            .HasMany(e => e.Meanings)
            .WithOne()
            .HasForeignKey($"WfiAnalysisGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfWfiAnalysis>()
            .HasMany(e => e.MorphBundles)
            .WithOne()
            .HasForeignKey($"WfiAnalysisGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfWfiAnalysis>()
            .HasMany(e => e.CompoundRuleApps)
            .WithMany()
            .UsingEntity(j => j.ToTable($"WfiAnalysis.CompoundRuleApps_MoCompoundRule"));
        modelBuilder.Entity<LfWfiAnalysis>()
            .HasMany(e => e.InflTemplateApps)
            .WithMany()
            .UsingEntity(j => j.ToTable($"WfiAnalysis.InflTemplateApps_MoInflAffixTemplate"));
        modelBuilder.Entity<LfWfiAnalysis>()
            .HasMany(e => e.Evaluations)
            .WithMany()
            .UsingEntity(j => j.ToTable($"WfiAnalysis.Evaluations_AgentEvaluation"));
        modelBuilder.Entity<LfWfiWordform>()
            .HasMany(e => e.Analyses)
            .WithOne()
            .HasForeignKey($"WfiWordformGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfWordFormLookup>()
            .HasMany(e => e.ThesaurusItems)
            .WithMany()
            .UsingEntity(j => j.ToTable($"WordFormLookup.ThesaurusItems_Possibility"));
        modelBuilder.Entity<LfWordFormLookup>()
            .HasMany(e => e.AnthroCodes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"WordFormLookup.AnthroCodes_Possibility"));
        modelBuilder.Entity<LfWordformLookupList>()
            .HasMany(e => e.Wordforms)
            .WithOne()
            .HasForeignKey($"WordformLookupListGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoInsertPhones>()
            .HasMany(e => e.Content)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoRuleMapping.Content_PhTerminalUnit"));
        modelBuilder.Entity<LfMoInsertNC>()
            .HasOne(e => e.Content)
            .WithMany()
            .HasForeignKey($"MoRuleMappingGuid");
        modelBuilder.Entity<LfMoModifyFromInput>()
            .HasOne(e => e.Content)
            .WithMany()
            .HasForeignKey($"MoRuleMappingGuid");
        modelBuilder.Entity<LfMoModifyFromInput>()
            .HasOne(e => e.Modification)
            .WithMany()
            .HasForeignKey($"MoRuleMappingGuid");
        modelBuilder.Entity<LfMoCompoundRuleApp>()
            .HasOne(e => e.LeftForm)
            .WithMany()
            .HasForeignKey($"MoDerivTraceGuid");
        modelBuilder.Entity<LfMoCompoundRuleApp>()
            .HasOne(e => e.RightForm)
            .WithMany()
            .HasForeignKey($"MoDerivTraceGuid");
        modelBuilder.Entity<LfMoCompoundRuleApp>()
            .HasOne(e => e.Linker)
            .WithMany()
            .HasForeignKey($"MoDerivTraceGuid");
        modelBuilder.Entity<LfMoDerivAffApp>()
            .HasOne(e => e.AffixForm)
            .WithMany()
            .HasForeignKey($"MoDerivTraceGuid");
        modelBuilder.Entity<LfMoDerivAffApp>()
            .HasOne(e => e.AffixMsa)
            .WithMany()
            .HasForeignKey($"MoDerivTraceGuid");
        modelBuilder.Entity<LfMoInflAffixSlotApp>()
            .HasOne(e => e.Slot)
            .WithMany()
            .HasForeignKey($"MoDerivTraceGuid");
        modelBuilder.Entity<LfMoInflAffixSlotApp>()
            .HasOne(e => e.AffixForm)
            .WithMany()
            .HasForeignKey($"MoDerivTraceGuid");
        modelBuilder.Entity<LfMoInflAffixSlotApp>()
            .HasOne(e => e.AffixMsa)
            .WithMany()
            .HasForeignKey($"MoDerivTraceGuid");
        modelBuilder.Entity<LfMoInflTemplateApp>()
            .HasOne(e => e.Template)
            .WithMany()
            .HasForeignKey($"MoDerivTraceGuid");
        modelBuilder.Entity<LfMoInflTemplateApp>()
            .HasMany(e => e.SlotApps)
            .WithOne()
            .HasForeignKey($"MoDerivTraceGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoPhonolRuleApp>()
            .HasOne(e => e.Rule)
            .WithMany()
            .HasForeignKey($"MoDerivTraceGuid");
        modelBuilder.Entity<LfMoStratumApp>()
            .HasOne(e => e.Stratum)
            .WithMany()
            .HasForeignKey($"MoDerivTraceGuid");
        modelBuilder.Entity<LfMoStratumApp>()
            .HasMany(e => e.CompoundRuleApps)
            .WithOne()
            .HasForeignKey($"MoDerivTraceGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoStratumApp>()
            .HasMany(e => e.DerivAffApp)
            .WithOne()
            .HasForeignKey($"MoDerivTraceGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoStratumApp>()
            .HasMany(e => e.PRuleApps)
            .WithOne()
            .HasForeignKey($"MoDerivTraceGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhIterationContext>()
            .HasOne(e => e.Member)
            .WithMany()
            .HasForeignKey($"PhContextOrVarGuid");
        modelBuilder.Entity<LfPhSequenceContext>()
            .HasMany(e => e.Members)
            .WithMany()
            .UsingEntity(j => j.ToTable($"PhContextOrVar.Members_PhContextOrVar"));
        modelBuilder.Entity<LfPhSimpleContextBdry>()
            .HasOne(e => e.FeatureStructure)
            .WithMany()
            .HasForeignKey($"PhContextOrVarGuid");
        modelBuilder.Entity<LfPhSimpleContextNC>()
            .HasOne(e => e.FeatureStructure)
            .WithMany()
            .HasForeignKey($"PhContextOrVarGuid");
        modelBuilder.Entity<LfPhSimpleContextNC>()
            .HasMany(e => e.PlusConstr)
            .WithMany()
            .UsingEntity(j => j.ToTable($"PhContextOrVar.PlusConstr_PhFeatureConstraint"));
        modelBuilder.Entity<LfPhSimpleContextNC>()
            .HasMany(e => e.MinusConstr)
            .WithMany()
            .UsingEntity(j => j.ToTable($"PhContextOrVar.MinusConstr_PhFeatureConstraint"));
        modelBuilder.Entity<LfPhSimpleContextSeg>()
            .HasOne(e => e.FeatureStructure)
            .WithMany()
            .HasForeignKey($"PhContextOrVarGuid");
        modelBuilder.Entity<LfPhPhonemeSet>()
            .HasMany(e => e.Phonemes)
            .WithOne()
            .HasForeignKey($"PhPhonemeSetGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhPhonemeSet>()
            .HasMany(e => e.BoundaryMarkers)
            .WithOne()
            .HasForeignKey($"PhPhonemeSetGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhTerminalUnit>()
            .HasMany(e => e.Codes)
            .WithOne()
            .HasForeignKey($"PhTerminalUnitGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhNCSegments>()
            .HasMany(e => e.Segments)
            .WithMany()
            .UsingEntity(j => j.ToTable($"PhNaturalClass.Segments_PhTerminalUnit"));
        modelBuilder.Entity<LfPhFeatureConstraint>()
            .HasOne(e => e.Feature)
            .WithMany()
            .HasForeignKey($"PhFeatureConstraintGuid");
        modelBuilder.Entity<LfPhEnvironment>()
            .HasOne(e => e.LeftContext)
            .WithMany()
            .HasForeignKey($"PhEnvironmentGuid");
        modelBuilder.Entity<LfPhEnvironment>()
            .HasOne(e => e.RightContext)
            .WithMany()
            .HasForeignKey($"PhEnvironmentGuid");
        modelBuilder.Entity<LfPhPhonData>()
            .HasMany(e => e.PhonemeSets)
            .WithOne()
            .HasForeignKey($"PhPhonDataGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhPhonData>()
            .HasMany(e => e.Environments)
            .WithOne()
            .HasForeignKey($"PhPhonDataGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhPhonData>()
            .HasMany(e => e.NaturalClasses)
            .WithOne()
            .HasForeignKey($"PhPhonDataGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhPhonData>()
            .HasMany(e => e.Contexts)
            .WithOne()
            .HasForeignKey($"PhPhonDataGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhPhonData>()
            .HasMany(e => e.FeatConstraints)
            .WithOne()
            .HasForeignKey($"PhPhonDataGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhPhonData>()
            .HasMany(e => e.PhonRules)
            .WithOne()
            .HasForeignKey($"PhPhonDataGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoDeriv>()
            .HasOne(e => e.StemForm)
            .WithMany()
            .HasForeignKey($"MoDerivGuid");
        modelBuilder.Entity<LfMoDeriv>()
            .HasOne(e => e.StemMsa)
            .WithMany()
            .HasForeignKey($"MoDerivGuid");
        modelBuilder.Entity<LfMoDeriv>()
            .HasMany(e => e.StratumApps)
            .WithOne()
            .HasForeignKey($"MoDerivGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoAlloAdhocProhib>()
            .HasMany(e => e.Allomorphs)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoAdhocProhib.Allomorphs_MoForm"));
        modelBuilder.Entity<LfMoAlloAdhocProhib>()
            .HasOne(e => e.FirstAllomorph)
            .WithMany()
            .HasForeignKey($"MoAdhocProhibGuid");
        modelBuilder.Entity<LfMoAlloAdhocProhib>()
            .HasMany(e => e.RestOfAllos)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoAdhocProhib.RestOfAllos_MoForm"));
        modelBuilder.Entity<LfMoMorphAdhocProhib>()
            .HasMany(e => e.Morphemes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoAdhocProhib.Morphemes_MoMorphSynAnalysis"));
        modelBuilder.Entity<LfMoMorphAdhocProhib>()
            .HasOne(e => e.FirstMorpheme)
            .WithMany()
            .HasForeignKey($"MoAdhocProhibGuid");
        modelBuilder.Entity<LfMoMorphAdhocProhib>()
            .HasMany(e => e.RestOfMorphs)
            .WithMany()
            .UsingEntity(j => j.ToTable($"MoAdhocProhib.RestOfMorphs_MoMorphSynAnalysis"));
        modelBuilder.Entity<LfMoCopyFromInput>()
            .HasOne(e => e.Content)
            .WithMany()
            .HasForeignKey($"MoRuleMappingGuid");
        modelBuilder.Entity<LfWfiWordSet>()
            .HasMany(e => e.Cases)
            .WithMany()
            .UsingEntity(j => j.ToTable($"WfiWordSet.Cases_WfiWordform"));
        modelBuilder.Entity<LfMoGlossSystem>()
            .HasMany(e => e.Glosses)
            .WithOne()
            .HasForeignKey($"MoGlossSystemGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoGlossItem>()
            .HasMany(e => e.GlossItems)
            .WithOne()
            .HasForeignKey($"MoGlossItemGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfMoGlossItem>()
            .HasOne(e => e.Target)
            .WithMany()
            .HasForeignKey($"MoGlossItemGuid");
        modelBuilder.Entity<LfMoAdhocProhibGr>()
            .HasMany(e => e.Members)
            .WithOne()
            .HasForeignKey($"MoAdhocProhibGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfWfiMorphBundle>()
            .HasOne(e => e.Morph)
            .WithMany()
            .HasForeignKey($"WfiMorphBundleGuid");
        modelBuilder.Entity<LfWfiMorphBundle>()
            .HasOne(e => e.Msa)
            .WithMany()
            .HasForeignKey($"WfiMorphBundleGuid");
        modelBuilder.Entity<LfWfiMorphBundle>()
            .HasOne(e => e.Sense)
            .WithMany()
            .HasForeignKey($"WfiMorphBundleGuid");
        modelBuilder.Entity<LfWfiMorphBundle>()
            .HasOne(e => e.InflType)
            .WithMany()
            .HasForeignKey($"WfiMorphBundleGuid");
        modelBuilder.Entity<LfLexEtymology>()
            .HasMany(e => e.Language)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexEtymology.Language_Possibility"));
        modelBuilder.Entity<LfChkRef>()
            .HasOne(e => e.Rendering)
            .WithMany()
            .HasForeignKey($"ChkRefGuid");
        modelBuilder.Entity<LfMoUnclassifiedAffixMsa>()
            .HasOne(e => e.PartOfSpeech)
            .WithMany()
            .HasForeignKey($"MoMorphSynAnalysisGuid");
        modelBuilder.Entity<LfLexRefType>()
            .HasMany(e => e.Members)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLexReference>()
            .HasMany(e => e.Targets)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexReference.Targets_Object"));
        modelBuilder.Entity<LfChkSense>()
            .HasOne(e => e.Sense)
            .WithMany()
            .HasForeignKey($"ChkSenseGuid");
        modelBuilder.Entity<LfDsChart>()
            .HasOne(e => e.Template)
            .WithMany()
            .HasForeignKey($"DsChartGuid");
        modelBuilder.Entity<LfDsConstChart>()
            .HasOne(e => e.BasedOn)
            .WithMany()
            .HasForeignKey($"DsChartGuid");
        modelBuilder.Entity<LfDsConstChart>()
            .HasMany(e => e.Rows)
            .WithOne()
            .HasForeignKey($"DsChartGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfDsDiscourseData>()
            .HasMany(e => e.Charts)
            .WithOne()
            .HasForeignKey($"DsDiscourseDataGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfChkTerm>()
            .HasMany(e => e.Occurrences)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfChkTerm>()
            .HasMany(e => e.Renderings)
            .WithOne()
            .HasForeignKey($"PossibilityGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfChkRendering>()
            .HasOne(e => e.SurfaceForm)
            .WithMany()
            .HasForeignKey($"ChkRenderingGuid");
        modelBuilder.Entity<LfChkRendering>()
            .HasOne(e => e.Meaning)
            .WithMany()
            .HasForeignKey($"ChkRenderingGuid");
        modelBuilder.Entity<LfLexEntryRef>()
            .HasMany(e => e.VariantEntryTypes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexEntryRef.VariantEntryTypes_Possibility"));
        modelBuilder.Entity<LfLexEntryRef>()
            .HasMany(e => e.ComplexEntryTypes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexEntryRef.ComplexEntryTypes_Possibility"));
        modelBuilder.Entity<LfLexEntryRef>()
            .HasMany(e => e.PrimaryLexemes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexEntryRef.PrimaryLexemes_Object"));
        modelBuilder.Entity<LfLexEntryRef>()
            .HasMany(e => e.ComponentLexemes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexEntryRef.ComponentLexemes_Object"));
        modelBuilder.Entity<LfLexEntryRef>()
            .HasMany(e => e.ShowComplexFormsIn)
            .WithMany()
            .UsingEntity(j => j.ToTable($"LexEntryRef.ShowComplexFormsIn_Object"));
        modelBuilder.Entity<LfPhSegmentRule>()
            .HasOne(e => e.InitialStratum)
            .WithMany()
            .HasForeignKey($"PhSegmentRuleGuid");
        modelBuilder.Entity<LfPhSegmentRule>()
            .HasOne(e => e.FinalStratum)
            .WithMany()
            .HasForeignKey($"PhSegmentRuleGuid");
        modelBuilder.Entity<LfPhSegmentRule>()
            .HasMany(e => e.StrucDesc)
            .WithOne()
            .HasForeignKey($"PhSegmentRuleGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhRegularRule>()
            .HasMany(e => e.RightHandSides)
            .WithOne()
            .HasForeignKey($"PhSegmentRuleGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhSegRuleRHS>()
            .HasMany(e => e.StrucChange)
            .WithOne()
            .HasForeignKey($"PhSegRuleRHSGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfPhSegRuleRHS>()
            .HasMany(e => e.InputPOSes)
            .WithMany()
            .UsingEntity(j => j.ToTable($"PhSegRuleRHS.InputPOSes_Possibility"));
        modelBuilder.Entity<LfPhSegRuleRHS>()
            .HasMany(e => e.ExclRuleFeats)
            .WithMany()
            .UsingEntity(j => j.ToTable($"PhSegRuleRHS.ExclRuleFeats_Possibility"));
        modelBuilder.Entity<LfPhSegRuleRHS>()
            .HasMany(e => e.ReqRuleFeats)
            .WithMany()
            .UsingEntity(j => j.ToTable($"PhSegRuleRHS.ReqRuleFeats_Possibility"));
        modelBuilder.Entity<LfPhPhonRuleFeat>()
            .HasOne(e => e.Item)
            .WithMany()
            .HasForeignKey($"PossibilityGuid");
        modelBuilder.Entity<LfLexEntryInflType>()
            .HasMany(e => e.Slots)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Possibility.Slots_MoInflAffixSlot"));
        modelBuilder.Entity<LfLexExtendedNote>()
            .HasOne(e => e.ExtendedNoteType)
            .WithMany()
            .HasForeignKey($"LexExtendedNoteGuid");
        modelBuilder.Entity<LfLexExtendedNote>()
            .HasMany(e => e.Examples)
            .WithOne()
            .HasForeignKey($"LexExtendedNoteGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLangProject>()
            .HasOne(e => e.Thesaurus)
            .WithMany()
            .HasForeignKey($"ProjectGuid");
        modelBuilder.Entity<LfLangProject>()
            .HasMany(e => e.WordformLookupLists)
            .WithMany()
            .UsingEntity(j => j.ToTable($"Project.WordformLookupLists_WordformLookupList"));
        modelBuilder.Entity<LfLangProject>()
            .HasMany(e => e.Styles)
            .WithOne()
            .HasForeignKey($"ProjectGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLangProject>()
            .HasMany(e => e.Filters)
            .WithOne()
            .HasForeignKey($"ProjectGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLangProject>()
            .HasMany(e => e.Overlays)
            .WithOne()
            .HasForeignKey($"ProjectGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLangProject>()
            .HasMany(e => e.AnalyzingAgents)
            .WithOne()
            .HasForeignKey($"ProjectGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLangProject>()
            .HasMany(e => e.Annotations)
            .WithOne()
            .HasForeignKey($"ProjectGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLangProject>()
            .HasMany(e => e.UserAccounts)
            .WithOne()
            .HasForeignKey($"ProjectGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLangProject>()
            .HasMany(e => e.ActivatedFeatures)
            .WithOne()
            .HasForeignKey($"ProjectGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLangProject>()
            .HasMany(e => e.Pictures)
            .WithOne()
            .HasForeignKey($"ProjectGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLangProject>()
            .HasMany(e => e.CheckLists)
            .WithOne()
            .HasForeignKey($"ProjectGuid")
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<LfLangProject>()
            .HasMany(e => e.Media)
            .WithOne()
            .HasForeignKey($"ProjectGuid")
            .OnDelete(DeleteBehavior.Cascade);
    }
}
