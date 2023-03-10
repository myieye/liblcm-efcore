using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SIL.LCModel.Core.Cellar;
using SIL.LCModel.EFCore.Model;

#nullable disable

namespace SIL.LCModel.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentEvaluations",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentEvaluations", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FsFeatureSystems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsFeatureSystems", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "MediaContainers",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    OffsetType = table.Column<string>(type: "text", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaContainers", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "MoGlossSystems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoGlossSystems", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PubHeaders",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    InsideAlignedText = table.Column<string>(type: "text", nullable: true),
                    CenteredText = table.Column<string>(type: "text", nullable: true),
                    OutsideAlignedText = table.Column<string>(type: "text", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PubHeaders", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PubPageLayouts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MarginTop = table.Column<int>(type: "integer", nullable: false),
                    MarginBottom = table.Column<int>(type: "integer", nullable: false),
                    MarginInside = table.Column<int>(type: "integer", nullable: false),
                    MarginOutside = table.Column<int>(type: "integer", nullable: false),
                    PosHeader = table.Column<int>(type: "integer", nullable: false),
                    PosFooter = table.Column<int>(type: "integer", nullable: false),
                    IsBuiltIn = table.Column<bool>(type: "boolean", nullable: false),
                    IsModified = table.Column<bool>(type: "boolean", nullable: false),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PubPageLayouts", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PunctuationForms",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Form = table.Column<string>(type: "text", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PunctuationForms", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ScrRefSystems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrRefSystems", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "WfiWordforms",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Form = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    SpellingStatus = table.Column<int>(type: "integer", nullable: false),
                    Checksum = table.Column<int>(type: "integer", nullable: false),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiWordforms", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "WordformLookupLists",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    WritingSystem = table.Column<string>(type: "text", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordformLookupLists", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "WritingSystems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    LanguageTag = table.Column<string>(type: "text", nullable: false),
                    Abbreviation = table.Column<string>(type: "text", nullable: false),
                    LanguageName = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    IcuLocale = table.Column<string>(type: "text", nullable: false),
                    IsRightToLeft = table.Column<bool>(type: "boolean", nullable: false),
                    IsVoice = table.Column<bool>(type: "boolean", nullable: false),
                    IpaType = table.Column<int>(type: "integer", nullable: false),
                    CharacterSet = table.Column<List<CharacterSet>>(type: "jsonb", nullable: false),
                    DefaultFontName = table.Column<string>(type: "text", nullable: false),
                    IsVernacular = table.Column<bool>(type: "boolean", nullable: false),
                    IsAnalysis = table.Column<bool>(type: "boolean", nullable: false),
                    IsHidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritingSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FsFeatStrucTypes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    CatalogSourceId = table.Column<string>(type: "text", nullable: true),
                    FsFeatureSystem_TypesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsFeatStrucTypes", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_FsFeatStrucTypes_FsFeatureSystems_FsFeatureSystem_TypesGuid",
                        column: x => x.FsFeatureSystem_TypesGuid,
                        principalTable: "FsFeatureSystems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaURIs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaURI = table.Column<string>(type: "text", nullable: true),
                    MediaContainer_MediaURIsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaURIs", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MediaURIs_MediaContainers_MediaContainer_MediaURIsGuid",
                        column: x => x.MediaContainer_MediaURIsGuid,
                        principalTable: "MediaContainers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrBookRefs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    BookName = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    BookAbbrev = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    BookNameAlt = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ScrRefSystem_BooksGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrBookRefs", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ScrBookRefs_ScrRefSystems_ScrRefSystem_BooksGuid",
                        column: x => x.ScrRefSystem_BooksGuid,
                        principalTable: "ScrRefSystems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordFormLookups",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Form = table.Column<string>(type: "text", nullable: true),
                    ThesaurusCentral = table.Column<int>(type: "integer", nullable: false),
                    AnthroCentral = table.Column<int>(type: "integer", nullable: false),
                    WordformLookupList_WordformsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordFormLookups", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_WordFormLookups_WordformLookupLists_WordformLookupList_Word~",
                        column: x => x.WordformLookupList_WordformsGuid,
                        principalTable: "WordformLookupLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    StateInformation = table.Column<string>(type: "text", nullable: true),
                    Human = table.Column<bool>(type: "boolean", nullable: false),
                    NotesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Version = table.Column<string>(type: "text", nullable: true),
                    ApprovesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DisapprovesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Project_AnalyzingAgentsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Agents_AgentEvaluations_ApprovesGuid",
                        column: x => x.ApprovesGuid,
                        principalTable: "AgentEvaluations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Agents_AgentEvaluations_DisapprovesGuid",
                        column: x => x.DisapprovesGuid,
                        principalTable: "AgentEvaluations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Analysiss",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    WordformGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    HasWordform = table.Column<bool>(type: "boolean", nullable: false),
                    AnalysisGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analysiss", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Analysiss_WfiWordforms_WordformGuid",
                        column: x => x.WordformGuid,
                        principalTable: "WfiWordforms",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "Annotations",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CompDetails = table.Column<string>(type: "text", nullable: true),
                    Comment = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    AnnotationTypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    SourceGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    InstanceOfGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TextGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    Project_AnnotationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    BeginOffset = table.Column<int>(type: "integer", nullable: true),
                    Flid = table.Column<int>(type: "integer", nullable: true),
                    EndOffset = table.Column<int>(type: "integer", nullable: true),
                    BeginObjectGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EndObjectGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    WritingSystem = table.Column<string>(type: "text", nullable: true),
                    WsSelector = table.Column<int>(type: "integer", nullable: true),
                    BeginRef = table.Column<int>(type: "integer", nullable: true),
                    EndRef = table.Column<int>(type: "integer", nullable: true),
                    ResolutionStatus = table.Column<int>(type: "integer", nullable: true),
                    QuoteGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DiscussionGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RecommendationGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ResolutionGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DateResolved = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ScrBookAnnotations_NotesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annotations", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Annotations_Agents_SourceGuid",
                        column: x => x.SourceGuid,
                        principalTable: "Agents",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "IndirectAnnotation_AppliesTo_Annotation",
                columns: table => new
                {
                    AppliesToGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfIndirectAnnotationGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndirectAnnotation_AppliesTo_Annotation", x => new { x.AppliesToGuid, x.LfIndirectAnnotationGuid });
                    table.ForeignKey(
                        name: "FK_IndirectAnnotation_AppliesTo_Annotation_Annotations_Applies~",
                        column: x => x.AppliesToGuid,
                        principalTable: "Annotations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IndirectAnnotation_AppliesTo_Annotation_Annotations_LfIndir~",
                        column: x => x.LfIndirectAnnotationGuid,
                        principalTable: "Annotations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaseAnnotation_OtherObjects_ObjectId",
                columns: table => new
                {
                    LfBaseAnnotationGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    OtherObjectsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAnnotation_OtherObjects_ObjectId", x => new { x.LfBaseAnnotationGuid, x.OtherObjectsGuid });
                    table.ForeignKey(
                        name: "FK_BaseAnnotation_OtherObjects_ObjectId_Annotations_LfBaseAnno~",
                        column: x => x.LfBaseAnnotationGuid,
                        principalTable: "Annotations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cells",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Contents = table.Column<string>(type: "text", nullable: true),
                    Row_CellsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cells", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ChkRefs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Ref = table.Column<int>(type: "integer", nullable: false),
                    KeyWord = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    RenderingGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Location = table.Column<int>(type: "integer", nullable: false),
                    Possibility_OccurrencesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChkRefs", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ChkRefs_WfiWordforms_RenderingGuid",
                        column: x => x.RenderingGuid,
                        principalTable: "WfiWordforms",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "ChkRenderings",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    SurfaceFormGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MeaningGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Explanation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Possibility_RenderingsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChkRenderings", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ChkRenderings_WfiWordforms_SurfaceFormGuid",
                        column: x => x.SurfaceFormGuid,
                        principalTable: "WfiWordforms",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "ChkSenses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Explanation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    SenseGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChkSenses", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ConstChartClauseMarker_DependentClauses_ConstChartRow",
                columns: table => new
                {
                    DependentClausesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfConstChartClauseMarkerGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstChartClauseMarker_DependentClauses_ConstChartRow", x => new { x.DependentClausesGuid, x.LfConstChartClauseMarkerGuid });
                });

            migrationBuilder.CreateTable(
                name: "ConstChartRows",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ClauseType = table.Column<int>(type: "integer", nullable: false),
                    EndParagraph = table.Column<bool>(type: "boolean", nullable: false),
                    EndSentence = table.Column<bool>(type: "boolean", nullable: false),
                    StartDependentClauseGroup = table.Column<bool>(type: "boolean", nullable: false),
                    EndDependentClauseGroup = table.Column<bool>(type: "boolean", nullable: false),
                    Label = table.Column<string>(type: "text", nullable: true),
                    DsChart_RowsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstChartRows", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ConstituentChartCellParts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ColumnGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MergesAfter = table.Column<bool>(type: "boolean", nullable: false),
                    MergesBefore = table.Column<bool>(type: "boolean", nullable: false),
                    ConstChartRow_CellsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    WordGroupGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Preposed = table.Column<bool>(type: "boolean", nullable: true),
                    TagGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    BeginSegmentGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EndSegmentGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    BeginAnalysisIndex = table.Column<int>(type: "integer", nullable: true),
                    EndAnalysisIndex = table.Column<int>(type: "integer", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstituentChartCellParts", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ConstituentChartCellParts_ConstChartRows_ConstChartRow_Cell~",
                        column: x => x.ConstChartRow_CellsGuid,
                        principalTable: "ConstChartRows",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstituentChartCellParts_ConstituentChartCellParts_WordGro~",
                        column: x => x.WordGroupGuid,
                        principalTable: "ConstituentChartCellParts",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "CrossReferences",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Comment = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    RnResearchNbk_CrossReferencesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossReferences", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "CustomFieldValues",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ConfigId = table.Column<int>(type: "integer", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    LfLexEntryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfLexExampleSentenceGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfLexSenseGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoFormGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Value = table.Column<string>(type: "jsonb", nullable: true),
                    PossibilityGuid_Value = table.Column<Guid>(type: "uuid", nullable: true),
                    StTextGuid_Value = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomFieldValues", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_CustomFieldValues_CustomFieldConfigs_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "CustomFieldConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainQs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Question = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ExampleWords = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ExampleSentences = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Possibility_QuestionsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainQs", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "DsCharts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    TemplateGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    DsDiscourseData_ChartsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    BasedOnGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsCharts", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "DsDiscourseDatas",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ConstChartTemplGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ChartMarkersGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DsDiscourseDatas", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    OriginalPath = table.Column<string>(type: "text", nullable: true),
                    InternalPath = table.Column<string>(type: "text", nullable: true),
                    Copyright = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Folder_FilesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ScrImportSource_FilesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Filters",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    FieldId = table.Column<int>(type: "integer", nullable: false),
                    FieldInfo = table.Column<string>(type: "text", nullable: true),
                    App = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ColumnInfo = table.Column<string>(type: "text", nullable: true),
                    ShowPrompt = table.Column<int>(type: "integer", nullable: false),
                    PromptText = table.Column<string>(type: "text", nullable: true),
                    Project_FiltersGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filters", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Rows",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Filter_RowsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rows", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Rows_Filters_Filter_RowsGuid",
                        column: x => x.Filter_RowsGuid,
                        principalTable: "Filters",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Folder_SubFoldersGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Project_MediaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Project_PicturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_Folder_SubFoldersGuid",
                        column: x => x.Folder_SubFoldersGuid,
                        principalTable: "Folders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FsAbstractStructures",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    TypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FsAbsStruc_ContentsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflClass_ReferenceFormsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoStemName_RegionsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Possibility_EmptyParadigmCellsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Possibility_ReferenceFormsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FsAbsStruc_FeatureDisjunctionsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsAbstractStructures", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_FsAbstractStructures_FsAbstractStructures_FsAbsStruc_Conten~",
                        column: x => x.FsAbsStruc_ContentsGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FsAbstractStructures_FsAbstractStructures_FsAbsStruc_Featur~",
                        column: x => x.FsAbsStruc_FeatureDisjunctionsGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FsAbstractStructures_FsFeatStrucTypes_TypeGuid",
                        column: x => x.TypeGuid,
                        principalTable: "FsFeatStrucTypes",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoGlossItems",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    AfterSeparator = table.Column<string>(type: "text", nullable: true),
                    ComplexNameSeparator = table.Column<string>(type: "text", nullable: true),
                    ComplexNameFirst = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    FeatStructFragGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TargetGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EticID = table.Column<string>(type: "text", nullable: true),
                    MoGlossItem_GlossItemsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoGlossSystem_GlossesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoGlossItems", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoGlossItems_FsAbstractStructures_FeatStructFragGuid",
                        column: x => x.FeatStructFragGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoGlossItems_MoGlossItems_MoGlossItem_GlossItemsGuid",
                        column: x => x.MoGlossItem_GlossItemsGuid,
                        principalTable: "MoGlossItems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoGlossItems_MoGlossItems_TargetGuid",
                        column: x => x.TargetGuid,
                        principalTable: "MoGlossItems",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoGlossItems_MoGlossSystems_MoGlossSystem_GlossesGuid",
                        column: x => x.MoGlossSystem_GlossesGuid,
                        principalTable: "MoGlossSystems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FsDisjunctiveValue_Value_FsSymFeatVal",
                columns: table => new
                {
                    LfFsDisjunctiveValueGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ValueGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsDisjunctiveValue_Value_FsSymFeatVal", x => new { x.LfFsDisjunctiveValueGuid, x.ValueGuid });
                });

            migrationBuilder.CreateTable(
                name: "FsFeatDefns",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DefaultGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    GlossAbbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    RightGlossSep = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ShowInGloss = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayToRightOfValues = table.Column<bool>(type: "boolean", nullable: false),
                    CatalogSourceId = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    FsFeatureSystem_FeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    WritingSystem = table.Column<string>(type: "text", nullable: true),
                    WsSelector = table.Column<int>(type: "integer", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsFeatDefns", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_FsFeatDefns_FsFeatStrucTypes_TypeGuid",
                        column: x => x.TypeGuid,
                        principalTable: "FsFeatStrucTypes",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_FsFeatDefns_FsFeatureSystems_FsFeatureSystem_FeaturesGuid",
                        column: x => x.FsFeatureSystem_FeaturesGuid,
                        principalTable: "FsFeatureSystems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FsFeatStrucType_Features_FsFeatDefn",
                columns: table => new
                {
                    FeaturesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfFsFeatStrucTypeGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsFeatStrucType_Features_FsFeatDefn", x => new { x.FeaturesGuid, x.LfFsFeatStrucTypeGuid });
                    table.ForeignKey(
                        name: "FK_FsFeatStrucType_Features_FsFeatDefn_FsFeatDefns_FeaturesGuid",
                        column: x => x.FeaturesGuid,
                        principalTable: "FsFeatDefns",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FsFeatStrucType_Features_FsFeatDefn_FsFeatStrucTypes_LfFsFe~",
                        column: x => x.LfFsFeatStrucTypeGuid,
                        principalTable: "FsFeatStrucTypes",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FsSymFeatVals",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    GlossAbbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    RightGlossSep = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ShowInGloss = table.Column<bool>(type: "boolean", nullable: false),
                    CatalogSourceId = table.Column<string>(type: "text", nullable: true),
                    FsFeatDefn_ValuesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsSymFeatVals", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_FsSymFeatVals_FsFeatDefns_FsFeatDefn_ValuesGuid",
                        column: x => x.FsFeatDefn_ValuesGuid,
                        principalTable: "FsFeatDefns",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FsFeatureSpecifications",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RefNumber = table.Column<int>(type: "integer", nullable: false),
                    ValueState = table.Column<int>(type: "integer", nullable: false),
                    FeatureGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    FsAbsStruc_FeatureSpecsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfFsClosedValue_ValueGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ValueGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfFsNegatedValue_ValueGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Value = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LfFsSharedValue_ValueGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsFeatureSpecifications", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_FsFeatureSpecifications_FsAbstractStructures_FsAbsStruc_Fea~",
                        column: x => x.FsAbsStruc_FeatureSpecsGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FsFeatureSpecifications_FsAbstractStructures_ValueGuid",
                        column: x => x.ValueGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FsFeatureSpecifications_FsFeatDefns_FeatureGuid",
                        column: x => x.FeatureGuid,
                        principalTable: "FsFeatDefns",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_FsFeatureSpecifications_FsFeatureSpecifications_LfFsSharedV~",
                        column: x => x.LfFsSharedValue_ValueGuid,
                        principalTable: "FsFeatureSpecifications",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_FsFeatureSpecifications_FsSymFeatVals_LfFsClosedValue_Value~",
                        column: x => x.LfFsClosedValue_ValueGuid,
                        principalTable: "FsSymFeatVals",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_FsFeatureSpecifications_FsSymFeatVals_LfFsNegatedValue_Valu~",
                        column: x => x.LfFsNegatedValue_ValueGuid,
                        principalTable: "FsSymFeatVals",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "LangProject_WordformLookupLists_WordformLookupList",
                columns: table => new
                {
                    LfLangProjectGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    WordformLookupListsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LangProject_WordformLookupLists_WordformLookupList", x => new { x.LfLangProjectGuid, x.WordformLookupListsGuid });
                    table.ForeignKey(
                        name: "FK_LangProject_WordformLookupLists_WordformLookupList_Wordform~",
                        column: x => x.WordformLookupListsGuid,
                        principalTable: "WordformLookupLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LexAppendixs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexDb_AppendixesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexAppendixs", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LexDb_AllomorphIndex_MoForm",
                columns: table => new
                {
                    AllomorphIndexGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexDbGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexDb_AllomorphIndex_MoForm", x => new { x.AllomorphIndexGuid, x.LfLexDbGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexDb_LexicalFormIndex_LexEntry",
                columns: table => new
                {
                    LexicalFormIndexGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexDbGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexDb_LexicalFormIndex_LexEntry", x => new { x.LexicalFormIndexGuid, x.LfLexDbGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexDbs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    SenseTypesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    UsageTypesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DomainTypesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MorphTypesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IntroductionGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsHeadwordCitationForm = table.Column<bool>(type: "boolean", nullable: false),
                    IsBodyInSeparateSubentry = table.Column<bool>(type: "boolean", nullable: false),
                    ReferencesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    VariantEntryTypesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ComplexEntryTypesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PublicationTypesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtendedNoteTypesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LanguagesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DialectLabelsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexDbs", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LexEntry_DialectLabels_Possibility",
                columns: table => new
                {
                    DialectLabelsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexEntry2Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntry_DialectLabels_Possibility", x => new { x.DialectLabelsGuid, x.LfLexEntry2Guid });
                });

            migrationBuilder.CreateTable(
                name: "LexEntry_DoNotPublishIn_Possibility",
                columns: table => new
                {
                    DoNotPublishInGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexEntry1Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntry_DoNotPublishIn_Possibility", x => new { x.DoNotPublishInGuid, x.LfLexEntry1Guid });
                });

            migrationBuilder.CreateTable(
                name: "LexEntry_DoNotShowMainEntryIn_Possibility",
                columns: table => new
                {
                    DoNotShowMainEntryInGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexEntryGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntry_DoNotShowMainEntryIn_Possibility", x => new { x.DoNotShowMainEntryInGuid, x.LfLexEntryGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexEntry_MainEntriesOrSenses_ObjectId",
                columns: table => new
                {
                    LfLexEntryGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    MainEntriesOrSensesGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntry_MainEntriesOrSenses_ObjectId", x => new { x.LfLexEntryGuid, x.MainEntriesOrSensesGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexEntryInflType_Slots_MoInflAffixSlot",
                columns: table => new
                {
                    LfLexEntryInflTypeGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SlotsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntryInflType_Slots_MoInflAffixSlot", x => new { x.LfLexEntryInflTypeGuid, x.SlotsGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexEntryRef_ComplexEntryTypes_Possibility",
                columns: table => new
                {
                    ComplexEntryTypesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexEntryRef1Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntryRef_ComplexEntryTypes_Possibility", x => new { x.ComplexEntryTypesGuid, x.LfLexEntryRef1Guid });
                });

            migrationBuilder.CreateTable(
                name: "LexEntryRef_ComponentLexemes_ObjectId",
                columns: table => new
                {
                    ComponentLexemesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexEntryRef1Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntryRef_ComponentLexemes_ObjectId", x => new { x.ComponentLexemesGuid, x.LfLexEntryRef1Guid });
                });

            migrationBuilder.CreateTable(
                name: "LexEntryRef_PrimaryLexemes_ObjectId",
                columns: table => new
                {
                    LfLexEntryRefGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PrimaryLexemesGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntryRef_PrimaryLexemes_ObjectId", x => new { x.LfLexEntryRefGuid, x.PrimaryLexemesGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexEntryRef_ShowComplexFormsIn_ObjectId",
                columns: table => new
                {
                    LfLexEntryRef2Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ShowComplexFormsInGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntryRef_ShowComplexFormsIn_ObjectId", x => new { x.LfLexEntryRef2Guid, x.ShowComplexFormsInGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexEntryRef_VariantEntryTypes_Possibility",
                columns: table => new
                {
                    LfLexEntryRefGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    VariantEntryTypesGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntryRef_VariantEntryTypes_Possibility", x => new { x.LfLexEntryRefGuid, x.VariantEntryTypesGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexEntryRefs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    HideMinorEntry = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    RefType = table.Column<int>(type: "integer", nullable: false),
                    LexEntry_EntryRefsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntryRefs", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LexEntrys",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    HomographNumber = table.Column<int>(type: "integer", nullable: false),
                    CitationForm = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Bibliography = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Restrictions = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    SummaryDefinition = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LiteralMeaning = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Comment = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DoNotUseForParsing = table.Column<bool>(type: "boolean", nullable: false),
                    LexemeFormGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ImportResidue = table.Column<string>(type: "text", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntrys", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LexEtymologys",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Comment = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Form = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Gloss = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    PrecComment = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Note = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Bibliography = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LanguageNotes = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LexEntry_EtymologyGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEtymologys", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LexEtymologys_LexEntrys_LexEntry_EtymologyGuid",
                        column: x => x.LexEntry_EtymologyGuid,
                        principalTable: "LexEntrys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LexEtymology_Language_Possibility",
                columns: table => new
                {
                    LanguageGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexEtymologyGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEtymology_Language_Possibility", x => new { x.LanguageGuid, x.LfLexEtymologyGuid });
                    table.ForeignKey(
                        name: "FK_LexEtymology_Language_Possibility_LexEtymologys_LfLexEtymol~",
                        column: x => x.LfLexEtymologyGuid,
                        principalTable: "LexEtymologys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LexExampleSentence_DoNotPublishIn_Possibility",
                columns: table => new
                {
                    DoNotPublishInGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexExampleSentenceGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexExampleSentence_DoNotPublishIn_Possibility", x => new { x.DoNotPublishInGuid, x.LfLexExampleSentenceGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexExampleSentences",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Example = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    LexExtendedNote_ExamplesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexSense_ExamplesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexExampleSentences", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LexExtendedNotes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtendedNoteTypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Discussion = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LexSense_ExtendedNoteGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexExtendedNotes", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LexPronunciation_DoNotPublishIn_Possibility",
                columns: table => new
                {
                    DoNotPublishInGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexPronunciationGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexPronunciation_DoNotPublishIn_Possibility", x => new { x.DoNotPublishInGuid, x.LfLexPronunciationGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexPronunciations",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Form = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LocationGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    CVPattern = table.Column<string>(type: "text", nullable: true),
                    Tone = table.Column<string>(type: "text", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    LexEntry_PronunciationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexPronunciations", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LexPronunciations_LexEntrys_LexEntry_PronunciationsGuid",
                        column: x => x.LexEntry_PronunciationsGuid,
                        principalTable: "LexEntrys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Label = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MediaFileGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexPronunciation_MediaFilesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Medias_Files_MediaFileGuid",
                        column: x => x.MediaFileGuid,
                        principalTable: "Files",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Medias_LexPronunciations_LexPronunciation_MediaFilesGuid",
                        column: x => x.LexPronunciation_MediaFilesGuid,
                        principalTable: "LexPronunciations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LexReference_Targets_ObjectId",
                columns: table => new
                {
                    LfLexReferenceGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    TargetsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexReference_Targets_ObjectId", x => new { x.LfLexReferenceGuid, x.TargetsGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexReferences",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Comment = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    Possibility_MembersGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexReferences", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LexSense_AnthroCodes_Possibility",
                columns: table => new
                {
                    AnthroCodesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexSenseGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexSense_AnthroCodes_Possibility", x => new { x.AnthroCodesGuid, x.LfLexSenseGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexSense_Appendixes_LexAppendix",
                columns: table => new
                {
                    AppendixesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexSenseGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexSense_Appendixes_LexAppendix", x => new { x.AppendixesGuid, x.LfLexSenseGuid });
                    table.ForeignKey(
                        name: "FK_LexSense_Appendixes_LexAppendix_LexAppendixs_AppendixesGuid",
                        column: x => x.AppendixesGuid,
                        principalTable: "LexAppendixs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LexSense_DialectLabels_Possibility",
                columns: table => new
                {
                    DialectLabelsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexSense5Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexSense_DialectLabels_Possibility", x => new { x.DialectLabelsGuid, x.LfLexSense5Guid });
                });

            migrationBuilder.CreateTable(
                name: "LexSense_DomainTypes_Possibility",
                columns: table => new
                {
                    DomainTypesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexSense1Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexSense_DomainTypes_Possibility", x => new { x.DomainTypesGuid, x.LfLexSense1Guid });
                });

            migrationBuilder.CreateTable(
                name: "LexSense_DoNotPublishIn_Possibility",
                columns: table => new
                {
                    DoNotPublishInGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfLexSense4Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexSense_DoNotPublishIn_Possibility", x => new { x.DoNotPublishInGuid, x.LfLexSense4Guid });
                });

            migrationBuilder.CreateTable(
                name: "LexSense_SemanticDomains_Possibility",
                columns: table => new
                {
                    LfLexSenseGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SemanticDomainsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexSense_SemanticDomains_Possibility", x => new { x.LfLexSenseGuid, x.SemanticDomainsGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexSense_ThesaurusItems_Possibility",
                columns: table => new
                {
                    LfLexSense2Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ThesaurusItemsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexSense_ThesaurusItems_Possibility", x => new { x.LfLexSense2Guid, x.ThesaurusItemsGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexSense_UsageTypes_Possibility",
                columns: table => new
                {
                    LfLexSense3Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    UsageTypesGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexSense_UsageTypes_Possibility", x => new { x.LfLexSense3Guid, x.UsageTypesGuid });
                });

            migrationBuilder.CreateTable(
                name: "LexSenses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    MorphoSyntaxAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Definition = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Gloss = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ScientificName = table.Column<string>(type: "text", nullable: true),
                    SenseTypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AnthroNote = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Bibliography = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DiscourseNote = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    EncyclopedicInfo = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    GeneralNote = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    GrammarNote = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    PhonologyNote = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Restrictions = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    SemanticsNote = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    SocioLinguisticsNote = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Source = table.Column<string>(type: "text", nullable: true),
                    StatusGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ImportResidue = table.Column<string>(type: "text", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    Exemplar = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    UsageNote = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LexEntry_SensesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexSense_SensesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexSenses", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LexSenses_LexEntrys_LexEntry_SensesGuid",
                        column: x => x.LexEntry_SensesGuid,
                        principalTable: "LexEntrys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LexSenses_LexSenses_LexSense_SensesGuid",
                        column: x => x.LexSense_SensesGuid,
                        principalTable: "LexSenses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PictureFileGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Caption = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LayoutPos = table.Column<int>(type: "integer", nullable: false),
                    ScaleFactor = table.Column<int>(type: "integer", nullable: false),
                    LocationRangeType = table.Column<int>(type: "integer", nullable: false),
                    LocationMin = table.Column<int>(type: "integer", nullable: false),
                    LocationMax = table.Column<int>(type: "integer", nullable: false),
                    LexSense_PicturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Pictures_Files_PictureFileGuid",
                        column: x => x.PictureFileGuid,
                        principalTable: "Files",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Pictures_LexSenses_LexSense_PicturesGuid",
                        column: x => x.LexSense_PicturesGuid,
                        principalTable: "LexSenses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoAdhocProhibs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Adjacency = table.Column<int>(type: "integer", nullable: false),
                    Disabled = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    MoAdhocProhib_MembersGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoMorphData_AdhocCoProhibitionsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    FirstAllomorphGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FirstMorphemeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoAdhocProhibs", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoAdhocProhibs_MoAdhocProhibs_MoAdhocProhib_MembersGuid",
                        column: x => x.MoAdhocProhib_MembersGuid,
                        principalTable: "MoAdhocProhibs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoAffixAllomorph_PhoneEnv_PhEnvironment",
                columns: table => new
                {
                    LfMoAffixAllomorphGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneEnvGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoAffixAllomorph_PhoneEnv_PhEnvironment", x => new { x.LfMoAffixAllomorphGuid, x.PhoneEnvGuid });
                });

            migrationBuilder.CreateTable(
                name: "MoAffixAllomorph_Position_PhEnvironment",
                columns: table => new
                {
                    LfMoAffixAllomorph1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoAffixAllomorph_Position_PhEnvironment", x => new { x.LfMoAffixAllomorph1Guid, x.PositionGuid });
                });

            migrationBuilder.CreateTable(
                name: "MoAffixForm_InflectionClasses_MoInflClass",
                columns: table => new
                {
                    InflectionClassesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfMoAffixFormGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoAffixForm_InflectionClasses_MoInflClass", x => new { x.InflectionClassesGuid, x.LfMoAffixFormGuid });
                });

            migrationBuilder.CreateTable(
                name: "MoAlloAdhocProhib_Allomorphs_MoForm",
                columns: table => new
                {
                    AllomorphsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfMoAlloAdhocProhibGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoAlloAdhocProhib_Allomorphs_MoForm", x => new { x.AllomorphsGuid, x.LfMoAlloAdhocProhibGuid });
                    table.ForeignKey(
                        name: "FK_MoAlloAdhocProhib_Allomorphs_MoForm_MoAdhocProhibs_LfMoAllo~",
                        column: x => x.LfMoAlloAdhocProhibGuid,
                        principalTable: "MoAdhocProhibs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoAlloAdhocProhib_RestOfAllos_MoForm",
                columns: table => new
                {
                    LfMoAlloAdhocProhib1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RestOfAllosGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoAlloAdhocProhib_RestOfAllos_MoForm", x => new { x.LfMoAlloAdhocProhib1Guid, x.RestOfAllosGuid });
                    table.ForeignKey(
                        name: "FK_MoAlloAdhocProhib_RestOfAllos_MoForm_MoAdhocProhibs_LfMoAll~",
                        column: x => x.LfMoAlloAdhocProhib1Guid,
                        principalTable: "MoAdhocProhibs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoCompoundRule_ToProdRestrict_Possibility",
                columns: table => new
                {
                    LfMoCompoundRuleGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ToProdRestrictGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoCompoundRule_ToProdRestrict_Possibility", x => new { x.LfMoCompoundRuleGuid, x.ToProdRestrictGuid });
                });

            migrationBuilder.CreateTable(
                name: "MoCompoundRules",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    StratumGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Disabled = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    MoMorphData_CompoundRulesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LeftMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RightMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LinkerGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    HeadLast = table.Column<bool>(type: "boolean", nullable: true),
                    OverridingMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ToMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoCompoundRules", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "MoDerivAffMsa_FromProdRestrict_Possibility",
                columns: table => new
                {
                    FromProdRestrictGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfMoDerivAffMsaGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoDerivAffMsa_FromProdRestrict_Possibility", x => new { x.FromProdRestrictGuid, x.LfMoDerivAffMsaGuid });
                });

            migrationBuilder.CreateTable(
                name: "MoDerivAffMsa_ToProdRestrict_Possibility",
                columns: table => new
                {
                    LfMoDerivAffMsa1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ToProdRestrictGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoDerivAffMsa_ToProdRestrict_Possibility", x => new { x.LfMoDerivAffMsa1Guid, x.ToProdRestrictGuid });
                });

            migrationBuilder.CreateTable(
                name: "MoDerivs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    StemFormGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StemMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    InflectionalFeatsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoDerivs", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoDerivs_FsAbstractStructures_InflectionalFeatsGuid",
                        column: x => x.InflectionalFeatsGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoDerivStepMsa_ProdRestrict_Possibility",
                columns: table => new
                {
                    LfMoDerivStepMsaGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdRestrictGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoDerivStepMsa_ProdRestrict_Possibility", x => new { x.LfMoDerivStepMsaGuid, x.ProdRestrictGuid });
                });

            migrationBuilder.CreateTable(
                name: "MoDerivTraces",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    OutputForm = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    LeftFormGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RightFormGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LinkerGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoDerivTrace_CompoundRuleAppsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AffixFormGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AffixMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    OutputMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoDerivTrace_DerivAffAppGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    SlotGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoInflAffixSlotApp_AffixFormGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoInflAffixSlotApp_AffixMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoDerivTrace_SlotAppsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TemplateGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RuleGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    VacuousApp = table.Column<bool>(type: "boolean", nullable: true),
                    MoDerivTrace_PRuleAppsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StratumGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TemplateAppGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoDeriv_StratumAppsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoDerivTraces", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoDerivTraces_MoDerivTraces_MoDerivTrace_CompoundRuleAppsGu~",
                        column: x => x.MoDerivTrace_CompoundRuleAppsGuid,
                        principalTable: "MoDerivTraces",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoDerivTraces_MoDerivTraces_MoDerivTrace_DerivAffAppGuid",
                        column: x => x.MoDerivTrace_DerivAffAppGuid,
                        principalTable: "MoDerivTraces",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoDerivTraces_MoDerivTraces_MoDerivTrace_PRuleAppsGuid",
                        column: x => x.MoDerivTrace_PRuleAppsGuid,
                        principalTable: "MoDerivTraces",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoDerivTraces_MoDerivTraces_MoDerivTrace_SlotAppsGuid",
                        column: x => x.MoDerivTrace_SlotAppsGuid,
                        principalTable: "MoDerivTraces",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoDerivTraces_MoDerivTraces_TemplateAppGuid",
                        column: x => x.TemplateAppGuid,
                        principalTable: "MoDerivTraces",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoDerivTraces_MoDerivs_MoDeriv_StratumAppsGuid",
                        column: x => x.MoDeriv_StratumAppsGuid,
                        principalTable: "MoDerivs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoForms",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Form = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MorphTypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsAbstract = table.Column<bool>(type: "boolean", nullable: false),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    LexEntry_AlternateFormsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MsEnvFeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MsEnvPartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StemNameGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoForms", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoForms_FsAbstractStructures_MsEnvFeaturesGuid",
                        column: x => x.MsEnvFeaturesGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoForms_LexEntrys_LexEntry_AlternateFormsGuid",
                        column: x => x.LexEntry_AlternateFormsGuid,
                        principalTable: "LexEntrys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffixSlots",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Optional = table.Column<bool>(type: "boolean", nullable: false),
                    Possibility_AffixSlotsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffixSlots", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffixTemplate_EncliticSlots_MoInflAffixSlot",
                columns: table => new
                {
                    EncliticSlotsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfMoInflAffixTemplate4Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffixTemplate_EncliticSlots_MoInflAffixSlot", x => new { x.EncliticSlotsGuid, x.LfMoInflAffixTemplate4Guid });
                    table.ForeignKey(
                        name: "FK_MoInflAffixTemplate_EncliticSlots_MoInflAffixSlot_MoInflAff~",
                        column: x => x.EncliticSlotsGuid,
                        principalTable: "MoInflAffixSlots",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffixTemplate_PrefixSlots_MoInflAffixSlot",
                columns: table => new
                {
                    LfMoInflAffixTemplate1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PrefixSlotsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffixTemplate_PrefixSlots_MoInflAffixSlot", x => new { x.LfMoInflAffixTemplate1Guid, x.PrefixSlotsGuid });
                    table.ForeignKey(
                        name: "FK_MoInflAffixTemplate_PrefixSlots_MoInflAffixSlot_MoInflAffi~1",
                        column: x => x.PrefixSlotsGuid,
                        principalTable: "MoInflAffixSlots",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffixTemplate_ProcliticSlots_MoInflAffixSlot",
                columns: table => new
                {
                    LfMoInflAffixTemplate3Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcliticSlotsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffixTemplate_ProcliticSlots_MoInflAffixSlot", x => new { x.LfMoInflAffixTemplate3Guid, x.ProcliticSlotsGuid });
                    table.ForeignKey(
                        name: "FK_MoInflAffixTemplate_ProcliticSlots_MoInflAffixSlot_MoInflA~1",
                        column: x => x.ProcliticSlotsGuid,
                        principalTable: "MoInflAffixSlots",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffixTemplate_Slots_MoInflAffixSlot",
                columns: table => new
                {
                    LfMoInflAffixTemplateGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SlotsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffixTemplate_Slots_MoInflAffixSlot", x => new { x.LfMoInflAffixTemplateGuid, x.SlotsGuid });
                    table.ForeignKey(
                        name: "FK_MoInflAffixTemplate_Slots_MoInflAffixSlot_MoInflAffixSlots_~",
                        column: x => x.SlotsGuid,
                        principalTable: "MoInflAffixSlots",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffixTemplate_SuffixSlots_MoInflAffixSlot",
                columns: table => new
                {
                    LfMoInflAffixTemplate2Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    SuffixSlotsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffixTemplate_SuffixSlots_MoInflAffixSlot", x => new { x.LfMoInflAffixTemplate2Guid, x.SuffixSlotsGuid });
                    table.ForeignKey(
                        name: "FK_MoInflAffixTemplate_SuffixSlots_MoInflAffixSlot_MoInflAffi~1",
                        column: x => x.SuffixSlotsGuid,
                        principalTable: "MoInflAffixSlots",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffixTemplates",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    StratumGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RegionGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Final = table.Column<bool>(type: "boolean", nullable: false),
                    Disabled = table.Column<bool>(type: "boolean", nullable: false),
                    Possibility_AffixTemplatesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffixTemplates", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoInflAffixTemplates_FsAbstractStructures_RegionGuid",
                        column: x => x.RegionGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffMsa_FromProdRestrict_Possibility",
                columns: table => new
                {
                    FromProdRestrictGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfMoInflAffMsaGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffMsa_FromProdRestrict_Possibility", x => new { x.FromProdRestrictGuid, x.LfMoInflAffMsaGuid });
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffMsa_Slots_MoInflAffixSlot",
                columns: table => new
                {
                    LfMoInflAffMsaGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SlotsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffMsa_Slots_MoInflAffixSlot", x => new { x.LfMoInflAffMsaGuid, x.SlotsGuid });
                    table.ForeignKey(
                        name: "FK_MoInflAffMsa_Slots_MoInflAffixSlot_MoInflAffixSlots_SlotsGu~",
                        column: x => x.SlotsGuid,
                        principalTable: "MoInflAffixSlots",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoInflClasss",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MoInflClass_SubclassesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Possibility_InflectionClassesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflClasss", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoInflClasss_MoInflClasss_MoInflClass_SubclassesGuid",
                        column: x => x.MoInflClass_SubclassesGuid,
                        principalTable: "MoInflClasss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoInsertPhones_Content_PhTerminalUnit",
                columns: table => new
                {
                    ContentGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfMoInsertPhonesGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInsertPhones_Content_PhTerminalUnit", x => new { x.ContentGuid, x.LfMoInsertPhonesGuid });
                });

            migrationBuilder.CreateTable(
                name: "MoMorphAdhocProhib_Morphemes_MoMorphSynAnalysis",
                columns: table => new
                {
                    LfMoMorphAdhocProhibGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    MorphemesGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoMorphAdhocProhib_Morphemes_MoMorphSynAnalysis", x => new { x.LfMoMorphAdhocProhibGuid, x.MorphemesGuid });
                    table.ForeignKey(
                        name: "FK_MoMorphAdhocProhib_Morphemes_MoMorphSynAnalysis_MoAdhocProh~",
                        column: x => x.LfMoMorphAdhocProhibGuid,
                        principalTable: "MoAdhocProhibs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoMorphAdhocProhib_RestOfMorphs_MoMorphSynAnalysis",
                columns: table => new
                {
                    LfMoMorphAdhocProhib1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RestOfMorphsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoMorphAdhocProhib_RestOfMorphs_MoMorphSynAnalysis", x => new { x.LfMoMorphAdhocProhib1Guid, x.RestOfMorphsGuid });
                    table.ForeignKey(
                        name: "FK_MoMorphAdhocProhib_RestOfMorphs_MoMorphSynAnalysis_MoAdhocP~",
                        column: x => x.LfMoMorphAdhocProhib1Guid,
                        principalTable: "MoAdhocProhibs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoMorphData_AnalyzingAgents_Agent",
                columns: table => new
                {
                    AnalyzingAgentsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfMoMorphDataGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoMorphData_AnalyzingAgents_Agent", x => new { x.AnalyzingAgentsGuid, x.LfMoMorphDataGuid });
                    table.ForeignKey(
                        name: "FK_MoMorphData_AnalyzingAgents_Agent_Agents_AnalyzingAgentsGuid",
                        column: x => x.AnalyzingAgentsGuid,
                        principalTable: "Agents",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoMorphDatas",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    GlossSystemGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ParserParameters = table.Column<string>(type: "text", nullable: true),
                    ProdRestrictGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoMorphDatas", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoMorphDatas_MoGlossSystems_GlossSystemGuid",
                        column: x => x.GlossSystemGuid,
                        principalTable: "MoGlossSystems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WfiWordSets",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MoMorphData_TestSetsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiWordSets", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_WfiWordSets_MoMorphDatas_MoMorphData_TestSetsGuid",
                        column: x => x.MoMorphData_TestSetsGuid,
                        principalTable: "MoMorphDatas",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WfiWordSet_Cases_WfiWordform",
                columns: table => new
                {
                    CasesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfWfiWordSetGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiWordSet_Cases_WfiWordform", x => new { x.CasesGuid, x.LfWfiWordSetGuid });
                    table.ForeignKey(
                        name: "FK_WfiWordSet_Cases_WfiWordform_WfiWordSets_LfWfiWordSetGuid",
                        column: x => x.LfWfiWordSetGuid,
                        principalTable: "WfiWordSets",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WfiWordSet_Cases_WfiWordform_WfiWordforms_CasesGuid",
                        column: x => x.CasesGuid,
                        principalTable: "WfiWordforms",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoMorphSynAnalysis_Components_MoMorphSynAnalysis",
                columns: table => new
                {
                    ComponentsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfMoMorphSynAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoMorphSynAnalysis_Components_MoMorphSynAnalysis", x => new { x.ComponentsGuid, x.LfMoMorphSynAnalysisGuid });
                });

            migrationBuilder.CreateTable(
                name: "MoMorphSynAnalysis_GlossBundle_MoGlossItem",
                columns: table => new
                {
                    GlossBundleGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfMoMorphSynAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoMorphSynAnalysis_GlossBundle_MoGlossItem", x => new { x.GlossBundleGuid, x.LfMoMorphSynAnalysisGuid });
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_GlossBundle_MoGlossItem_MoGlossItems_Glo~",
                        column: x => x.GlossBundleGuid,
                        principalTable: "MoGlossItems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoMorphSynAnalysiss",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    GlossString = table.Column<string>(type: "text", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    LexEntry_MorphoSyntaxAnalysesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FromMsFeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ToMsFeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FromPartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ToPartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FromInflectionClassGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ToInflectionClassGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoDerivAffMsa_AffixCategoryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FromStemNameGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StratumGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoDerivStepMsa_PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MsFeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoDerivStepMsa_InflFeatsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    InflectionClassGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    InflFeatsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AffixCategoryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoStemMsa_MsFeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoStemMsa_PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoStemMsa_InflectionClassGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoStemMsa_StratumGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoUnclassifiedAffixMsa_PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoMorphSynAnalysiss", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_FromMsFeaturesGuid",
                        column: x => x.FromMsFeaturesGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_InflFeatsGuid",
                        column: x => x.InflFeatsGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_LfMoDerivStepMsa_I~",
                        column: x => x.LfMoDerivStepMsa_InflFeatsGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_LfMoStemMsa_MsFeat~",
                        column: x => x.LfMoStemMsa_MsFeaturesGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_MsFeaturesGuid",
                        column: x => x.MsFeaturesGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_ToMsFeaturesGuid",
                        column: x => x.ToMsFeaturesGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysiss_LexEntrys_LexEntry_MorphoSyntaxAnalyses~",
                        column: x => x.LexEntry_MorphoSyntaxAnalysesGuid,
                        principalTable: "LexEntrys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysiss_MoInflClasss_FromInflectionClassGuid",
                        column: x => x.FromInflectionClassGuid,
                        principalTable: "MoInflClasss",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysiss_MoInflClasss_InflectionClassGuid",
                        column: x => x.InflectionClassGuid,
                        principalTable: "MoInflClasss",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysiss_MoInflClasss_LfMoStemMsa_InflectionClas~",
                        column: x => x.LfMoStemMsa_InflectionClassGuid,
                        principalTable: "MoInflClasss",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysiss_MoInflClasss_ToInflectionClassGuid",
                        column: x => x.ToInflectionClassGuid,
                        principalTable: "MoInflClasss",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoStemMsa_Slots_MoInflAffixSlot",
                columns: table => new
                {
                    LfMoStemMsaGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SlotsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoStemMsa_Slots_MoInflAffixSlot", x => new { x.LfMoStemMsaGuid, x.SlotsGuid });
                    table.ForeignKey(
                        name: "FK_MoStemMsa_Slots_MoInflAffixSlot_MoInflAffixSlots_SlotsGuid",
                        column: x => x.SlotsGuid,
                        principalTable: "MoInflAffixSlots",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoStemMsa_Slots_MoInflAffixSlot_MoMorphSynAnalysiss_LfMoSte~",
                        column: x => x.LfMoStemMsaGuid,
                        principalTable: "MoMorphSynAnalysiss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoReferralRules",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    InputGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    OutputGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflClass_RulesOfReferralGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Possibility_RulesOfReferralGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoReferralRules", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoReferralRules_FsAbstractStructures_InputGuid",
                        column: x => x.InputGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoReferralRules_FsAbstractStructures_OutputGuid",
                        column: x => x.OutputGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoReferralRules_MoInflClasss_MoInflClass_RulesOfReferralGuid",
                        column: x => x.MoInflClass_RulesOfReferralGuid,
                        principalTable: "MoInflClasss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoRuleMappings",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    MoForm_OutputGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoCopyFromInput_ContentGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfMoInsertNC_ContentGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ContentGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ModificationGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoRuleMappings", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoRuleMappings_MoForms_MoForm_OutputGuid",
                        column: x => x.MoForm_OutputGuid,
                        principalTable: "MoForms",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoStemAllomorph_PhoneEnv_PhEnvironment",
                columns: table => new
                {
                    LfMoStemAllomorphGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneEnvGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoStemAllomorph_PhoneEnv_PhEnvironment", x => new { x.LfMoStemAllomorphGuid, x.PhoneEnvGuid });
                    table.ForeignKey(
                        name: "FK_MoStemAllomorph_PhoneEnv_PhEnvironment_MoForms_LfMoStemAllo~",
                        column: x => x.LfMoStemAllomorphGuid,
                        principalTable: "MoForms",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoStemMsa_FromPartsOfSpeech_Possibility",
                columns: table => new
                {
                    FromPartsOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfMoStemMsa1Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoStemMsa_FromPartsOfSpeech_Possibility", x => new { x.FromPartsOfSpeechGuid, x.LfMoStemMsa1Guid });
                    table.ForeignKey(
                        name: "FK_MoStemMsa_FromPartsOfSpeech_Possibility_MoMorphSynAnalysiss~",
                        column: x => x.LfMoStemMsa1Guid,
                        principalTable: "MoMorphSynAnalysiss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoStemMsa_ProdRestrict_Possibility",
                columns: table => new
                {
                    LfMoStemMsaGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdRestrictGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoStemMsa_ProdRestrict_Possibility", x => new { x.LfMoStemMsaGuid, x.ProdRestrictGuid });
                    table.ForeignKey(
                        name: "FK_MoStemMsa_ProdRestrict_Possibility_MoMorphSynAnalysiss_LfMo~",
                        column: x => x.LfMoStemMsaGuid,
                        principalTable: "MoMorphSynAnalysiss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoStemNames",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DefaultAffixGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultStemGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflClass_StemNamesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Possibility_StemNamesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoStemNames", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoStemNames_MoInflClasss_MoInflClass_StemNamesGuid",
                        column: x => x.MoInflClass_StemNamesGuid,
                        principalTable: "MoInflClasss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoStemNames_MoMorphSynAnalysiss_DefaultAffixGuid",
                        column: x => x.DefaultAffixGuid,
                        principalTable: "MoMorphSynAnalysiss",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoStemNames_MoStemNames_DefaultStemGuid",
                        column: x => x.DefaultStemGuid,
                        principalTable: "MoStemNames",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoStratums",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    PhonemesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoMorphData_StrataGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoStratums", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoStratums_MoMorphDatas_MoMorphData_StrataGuid",
                        column: x => x.MoMorphData_StrataGuid,
                        principalTable: "MoMorphDatas",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Segment_NotesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ObjectIds",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    StPara_AnalyzedTextObjectsGuid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectIds", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "VirtualOrderings",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Field = table.Column<string>(type: "text", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualOrderings", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_VirtualOrderings_ObjectIds_SourceGuid",
                        column: x => x.SourceGuid,
                        principalTable: "ObjectIds",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "VirtualOrdering_Items_ObjectId",
                columns: table => new
                {
                    ItemsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfVirtualOrderingGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VirtualOrdering_Items_ObjectId", x => new { x.ItemsGuid, x.LfVirtualOrderingGuid });
                    table.ForeignKey(
                        name: "FK_VirtualOrdering_Items_ObjectId_ObjectIds_ItemsGuid",
                        column: x => x.ItemsGuid,
                        principalTable: "ObjectIds",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VirtualOrdering_Items_ObjectId_VirtualOrderings_LfVirtualOr~",
                        column: x => x.LfVirtualOrderingGuid,
                        principalTable: "VirtualOrderings",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Overlay_PossItems_Possibility",
                columns: table => new
                {
                    LfOverlayGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PossItemsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overlay_PossItems_Possibility", x => new { x.LfOverlayGuid, x.PossItemsGuid });
                });

            migrationBuilder.CreateTable(
                name: "Overlays",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    PossListGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Project_OverlaysGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Overlays", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PartOfSpeech_BearableFeatures_FsFeatDefn",
                columns: table => new
                {
                    BearableFeaturesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfPartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOfSpeech_BearableFeatures_FsFeatDefn", x => new { x.BearableFeaturesGuid, x.LfPartOfSpeechGuid });
                    table.ForeignKey(
                        name: "FK_PartOfSpeech_BearableFeatures_FsFeatDefn_FsFeatDefns_Bearab~",
                        column: x => x.BearableFeaturesGuid,
                        principalTable: "FsFeatDefns",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartOfSpeech_InflectableFeats_FsFeatDefn",
                columns: table => new
                {
                    InflectableFeatsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfPartOfSpeech1Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartOfSpeech_InflectableFeats_FsFeatDefn", x => new { x.InflectableFeatsGuid, x.LfPartOfSpeech1Guid });
                    table.ForeignKey(
                        name: "FK_PartOfSpeech_InflectableFeats_FsFeatDefn_FsFeatDefns_Inflec~",
                        column: x => x.InflectableFeatsGuid,
                        principalTable: "FsFeatDefns",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Person_PlacesOfResidence_Possibility",
                columns: table => new
                {
                    LfPersonGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PlacesOfResidenceGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_PlacesOfResidence_Possibility", x => new { x.LfPersonGuid, x.PlacesOfResidenceGuid });
                });

            migrationBuilder.CreateTable(
                name: "Person_Positions_Possibility",
                columns: table => new
                {
                    LfPerson1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_Positions_Possibility", x => new { x.LfPerson1Guid, x.PositionsGuid });
                });

            migrationBuilder.CreateTable(
                name: "PhCodes",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Representation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    PhTerminalUnit_CodesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhCodes", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PhContextOrVars",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    MoForm_InputGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PhPhonData_ContextsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DescriptionGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Minimum = table.Column<int>(type: "integer", nullable: true),
                    Maximum = table.Column<int>(type: "integer", nullable: true),
                    MemberGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PhSegRuleRHS_StrucChangeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PhSegmentRule_StrucDescGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FeatureStructureGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfPhSimpleContextNC_FeatureStructureGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfPhSimpleContextSeg_FeatureStructureGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhContextOrVars", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhContextOrVars_MoForms_MoForm_InputGuid",
                        column: x => x.MoForm_InputGuid,
                        principalTable: "MoForms",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhContextOrVars_PhContextOrVars_MemberGuid",
                        column: x => x.MemberGuid,
                        principalTable: "PhContextOrVars",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "PhSequenceContext_Members_PhContextOrVar",
                columns: table => new
                {
                    LfPhSequenceContextGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    MembersGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhSequenceContext_Members_PhContextOrVar", x => new { x.LfPhSequenceContextGuid, x.MembersGuid });
                    table.ForeignKey(
                        name: "FK_PhSequenceContext_Members_PhContextOrVar_PhContextOrVars_Lf~",
                        column: x => x.LfPhSequenceContextGuid,
                        principalTable: "PhContextOrVars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhSequenceContext_Members_PhContextOrVar_PhContextOrVars_Me~",
                        column: x => x.MembersGuid,
                        principalTable: "PhContextOrVars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhEnvironments",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LeftContextGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RightContextGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AMPLEStringSegment = table.Column<string>(type: "text", nullable: true),
                    StringRepresentation = table.Column<string>(type: "text", nullable: true),
                    PhPhonData_EnvironmentsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhEnvironments", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhEnvironments_PhContextOrVars_LeftContextGuid",
                        column: x => x.LeftContextGuid,
                        principalTable: "PhContextOrVars",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PhEnvironments_PhContextOrVars_RightContextGuid",
                        column: x => x.RightContextGuid,
                        principalTable: "PhContextOrVars",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "PhFeatureConstraints",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PhPhonData_FeatConstraintsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhFeatureConstraints", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhFeatureConstraints_FsFeatDefns_FeatureGuid",
                        column: x => x.FeatureGuid,
                        principalTable: "FsFeatDefns",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "PhSimpleContextNC_MinusConstr_PhFeatureConstraint",
                columns: table => new
                {
                    LfPhSimpleContextNC1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    MinusConstrGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhSimpleContextNC_MinusConstr_PhFeatureConstraint", x => new { x.LfPhSimpleContextNC1Guid, x.MinusConstrGuid });
                    table.ForeignKey(
                        name: "FK_PhSimpleContextNC_MinusConstr_PhFeatureConstraint_PhContext~",
                        column: x => x.LfPhSimpleContextNC1Guid,
                        principalTable: "PhContextOrVars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhSimpleContextNC_MinusConstr_PhFeatureConstraint_PhFeature~",
                        column: x => x.MinusConstrGuid,
                        principalTable: "PhFeatureConstraints",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhSimpleContextNC_PlusConstr_PhFeatureConstraint",
                columns: table => new
                {
                    LfPhSimpleContextNCGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PlusConstrGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhSimpleContextNC_PlusConstr_PhFeatureConstraint", x => new { x.LfPhSimpleContextNCGuid, x.PlusConstrGuid });
                    table.ForeignKey(
                        name: "FK_PhSimpleContextNC_PlusConstr_PhFeatureConstraint_PhContextO~",
                        column: x => x.LfPhSimpleContextNCGuid,
                        principalTable: "PhContextOrVars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhSimpleContextNC_PlusConstr_PhFeatureConstraint_PhFeatureC~",
                        column: x => x.PlusConstrGuid,
                        principalTable: "PhFeatureConstraints",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhNaturalClasss",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    PhPhonData_NaturalClassesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhNaturalClasss", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhNaturalClasss_FsAbstractStructures_FeaturesGuid",
                        column: x => x.FeaturesGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhNCSegments_Segments_PhTerminalUnit",
                columns: table => new
                {
                    LfPhNCSegmentsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SegmentsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhNCSegments_Segments_PhTerminalUnit", x => new { x.LfPhNCSegmentsGuid, x.SegmentsGuid });
                    table.ForeignKey(
                        name: "FK_PhNCSegments_Segments_PhTerminalUnit_PhNaturalClasss_LfPhNC~",
                        column: x => x.LfPhNCSegmentsGuid,
                        principalTable: "PhNaturalClasss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhPhonDatas",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PhonRuleFeatsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhPhonDatas", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PhPhonemeSets",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    PhPhonData_PhonemeSetsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhPhonemeSets", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhPhonemeSets_PhPhonDatas_PhPhonData_PhonemeSetsGuid",
                        column: x => x.PhPhonData_PhonemeSetsGuid,
                        principalTable: "PhPhonDatas",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhSegmentRules",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Direction = table.Column<int>(type: "integer", nullable: false),
                    InitialStratumGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FinalStratumGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Disabled = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    PhPhonData_PhonRulesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StrucChange = table.Column<string>(type: "text", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhSegmentRules", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhSegmentRules_MoStratums_FinalStratumGuid",
                        column: x => x.FinalStratumGuid,
                        principalTable: "MoStratums",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PhSegmentRules_MoStratums_InitialStratumGuid",
                        column: x => x.InitialStratumGuid,
                        principalTable: "MoStratums",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PhSegmentRules_PhPhonDatas_PhPhonData_PhonRulesGuid",
                        column: x => x.PhPhonData_PhonRulesGuid,
                        principalTable: "PhPhonDatas",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhTerminalUnits",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    PhPhonemeSet_BoundaryMarkersGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    BasicIPASymbol = table.Column<string>(type: "text", nullable: true),
                    FeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PhPhonemeSet_PhonemesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhTerminalUnits", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhTerminalUnits_FsAbstractStructures_FeaturesGuid",
                        column: x => x.FeaturesGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhTerminalUnits_PhPhonemeSets_PhPhonemeSet_BoundaryMarkersG~",
                        column: x => x.PhPhonemeSet_BoundaryMarkersGuid,
                        principalTable: "PhPhonemeSets",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhTerminalUnits_PhPhonemeSets_PhPhonemeSet_PhonemesGuid",
                        column: x => x.PhPhonemeSet_PhonemesGuid,
                        principalTable: "PhPhonemeSets",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhSegRuleRHSs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    LeftContextGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RightContextGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PhSegmentRule_RightHandSidesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhSegRuleRHSs", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhSegRuleRHSs_PhContextOrVars_LeftContextGuid",
                        column: x => x.LeftContextGuid,
                        principalTable: "PhContextOrVars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhSegRuleRHSs_PhContextOrVars_RightContextGuid",
                        column: x => x.RightContextGuid,
                        principalTable: "PhContextOrVars",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhSegRuleRHSs_PhSegmentRules_PhSegmentRule_RightHandSidesGu~",
                        column: x => x.PhSegmentRule_RightHandSidesGuid,
                        principalTable: "PhSegmentRules",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhSegRuleRHS_ExclRuleFeats_Possibility",
                columns: table => new
                {
                    ExclRuleFeatsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfPhSegRuleRHSGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhSegRuleRHS_ExclRuleFeats_Possibility", x => new { x.ExclRuleFeatsGuid, x.LfPhSegRuleRHSGuid });
                    table.ForeignKey(
                        name: "FK_PhSegRuleRHS_ExclRuleFeats_Possibility_PhSegRuleRHSs_LfPhSe~",
                        column: x => x.LfPhSegRuleRHSGuid,
                        principalTable: "PhSegRuleRHSs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhSegRuleRHS_InputPOSes_Possibility",
                columns: table => new
                {
                    InputPOSesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfPhSegRuleRHSGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhSegRuleRHS_InputPOSes_Possibility", x => new { x.InputPOSesGuid, x.LfPhSegRuleRHSGuid });
                    table.ForeignKey(
                        name: "FK_PhSegRuleRHS_InputPOSes_Possibility_PhSegRuleRHSs_LfPhSegRu~",
                        column: x => x.LfPhSegRuleRHSGuid,
                        principalTable: "PhSegRuleRHSs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhSegRuleRHS_ReqRuleFeats_Possibility",
                columns: table => new
                {
                    LfPhSegRuleRHS1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ReqRuleFeatsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhSegRuleRHS_ReqRuleFeats_Possibility", x => new { x.LfPhSegRuleRHS1Guid, x.ReqRuleFeatsGuid });
                    table.ForeignKey(
                        name: "FK_PhSegRuleRHS_ReqRuleFeats_Possibility_PhSegRuleRHSs_LfPhSeg~",
                        column: x => x.LfPhSegRuleRHS1Guid,
                        principalTable: "PhSegRuleRHSs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Picture_DoNotPublishIn_Possibility",
                columns: table => new
                {
                    DoNotPublishInGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfPictureGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture_DoNotPublishIn_Possibility", x => new { x.DoNotPublishInGuid, x.LfPictureGuid });
                    table.ForeignKey(
                        name: "FK_Picture_DoNotPublishIn_Possibility_Pictures_LfPictureGuid",
                        column: x => x.LfPictureGuid,
                        principalTable: "Pictures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Possibility_Researchers_Possibility",
                columns: table => new
                {
                    LfPossibility1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ResearchersGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possibility_Researchers_Possibility", x => new { x.LfPossibility1Guid, x.ResearchersGuid });
                });

            migrationBuilder.CreateTable(
                name: "Possibility_Restrictions_Possibility",
                columns: table => new
                {
                    LfPossibilityGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    RestrictionsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possibility_Restrictions_Possibility", x => new { x.LfPossibilityGuid, x.RestrictionsGuid });
                });

            migrationBuilder.CreateTable(
                name: "PossibilityListCustomFieldValue_Value_Possibility",
                columns: table => new
                {
                    PossibilityListCustomFieldValueGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ValueGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibilityListCustomFieldValue_Value_Possibility", x => new { x.PossibilityListCustomFieldValueGuid, x.ValueGuid });
                    table.ForeignKey(
                        name: "FK_PossibilityListCustomFieldValue_Value_Possibility_CustomFie~",
                        column: x => x.PossibilityListCustomFieldValueGuid,
                        principalTable: "CustomFieldValues",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PossibilityLists",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Depth = table.Column<int>(type: "integer", nullable: false),
                    PreventChoiceAboveLevel = table.Column<int>(type: "integer", nullable: false),
                    IsSorted = table.Column<bool>(type: "boolean", nullable: false),
                    IsClosed = table.Column<bool>(type: "boolean", nullable: false),
                    PreventDuplicates = table.Column<bool>(type: "boolean", nullable: false),
                    PreventNodeChoices = table.Column<bool>(type: "boolean", nullable: false),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    HelpFile = table.Column<string>(type: "text", nullable: true),
                    UseExtendedFields = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOption = table.Column<int>(type: "integer", nullable: false),
                    ItemClsid = table.Column<int>(type: "integer", nullable: false),
                    IsVernacular = table.Column<bool>(type: "boolean", nullable: false),
                    WritingSystem = table.Column<string>(type: "text", nullable: true),
                    WsSelector = table.Column<int>(type: "integer", nullable: false),
                    ListVersion = table.Column<Guid>(type: "uuid", nullable: false),
                    Project_CheckListsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibilityLists", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "ReversalIndexs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    PartsOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    WritingSystem = table.Column<string>(type: "text", nullable: true),
                    LexDb_ReversalIndexesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReversalIndexs", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ReversalIndexs_LexDbs_LexDb_ReversalIndexesGuid",
                        column: x => x.LexDb_ReversalIndexesGuid,
                        principalTable: "LexDbs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReversalIndexs_PossibilityLists_PartsOfSpeechGuid",
                        column: x => x.PartsOfSpeechGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnResearchNbks",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    RecTypesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnResearchNbks", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_RnResearchNbks_PossibilityLists_RecTypesGuid",
                        column: x => x.RecTypesGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scriptures",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    RefSepr = table.Column<string>(type: "text", nullable: true),
                    ChapterVerseSepr = table.Column<string>(type: "text", nullable: true),
                    VerseSepr = table.Column<string>(type: "text", nullable: true),
                    Bridge = table.Column<string>(type: "text", nullable: true),
                    FootnoteMarkerSymbol = table.Column<string>(type: "text", nullable: true),
                    DisplayFootnoteReference = table.Column<bool>(type: "boolean", nullable: false),
                    RestartFootnoteSequence = table.Column<bool>(type: "boolean", nullable: false),
                    RestartFootnoteBoundary = table.Column<int>(type: "integer", nullable: false),
                    UseScriptDigits = table.Column<bool>(type: "boolean", nullable: false),
                    ScriptDigitZero = table.Column<int>(type: "integer", nullable: false),
                    ConvertCVDigitsOnExport = table.Column<bool>(type: "boolean", nullable: false),
                    Versification = table.Column<int>(type: "integer", nullable: false),
                    VersePunct = table.Column<string>(type: "text", nullable: true),
                    ChapterLabel = table.Column<string>(type: "text", nullable: true),
                    PsalmLabel = table.Column<string>(type: "text", nullable: true),
                    NoteCategoriesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FootnoteMarkerType = table.Column<int>(type: "integer", nullable: false),
                    DisplayCrossRefReference = table.Column<bool>(type: "boolean", nullable: false),
                    CrossRefMarkerSymbol = table.Column<string>(type: "text", nullable: true),
                    CrossRefMarkerType = table.Column<int>(type: "integer", nullable: false),
                    CrossRefsCombinedWithFootnotes = table.Column<bool>(type: "boolean", nullable: false),
                    DisplaySymbolInFootnote = table.Column<bool>(type: "boolean", nullable: false),
                    DisplaySymbolInCrossRef = table.Column<bool>(type: "boolean", nullable: false),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scriptures", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Scriptures_PossibilityLists_NoteCategoriesGuid",
                        column: x => x.NoteCategoriesGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<GenDate>(type: "jsonb", nullable: false),
                    RnResearchNbk_RemindersGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Reminders_RnResearchNbks_RnResearchNbk_RemindersGuid",
                        column: x => x.RnResearchNbk_RemindersGuid,
                        principalTable: "RnResearchNbks",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    EthnologueCode = table.Column<string>(type: "text", nullable: true),
                    WorldRegion = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MainCountry = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    FieldWorkLocation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    PartsOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TranslationTagsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ThesaurusGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AnthroListGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexDbGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ResearchNotebookGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AnalysisWss = table.Column<string>(type: "text", nullable: true),
                    CurVernWss = table.Column<string>(type: "text", nullable: true),
                    CurAnalysisWss = table.Column<string>(type: "text", nullable: true),
                    CurPronunWss = table.Column<string>(type: "text", nullable: true),
                    MsFeatureSystemGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MorphologicalDataGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ConfidenceLevelsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RestrictionsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RolesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StatusGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PeopleGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EducationGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TimeOfDayGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AffixCategoriesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PhonologicalDataGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PositionsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TranslatedScriptureGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    VernWss = table.Column<string>(type: "text", nullable: true),
                    LinkedFilesRootDir = table.Column<string>(type: "text", nullable: true),
                    AnnotationDefsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    SemanticDomainListGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    GenreListGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DiscourseDataGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TextMarkupTagsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FilePathsInTsStringsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    HomographWs = table.Column<string>(type: "text", nullable: true),
                    PhFeatureSystemGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Projects_DsDiscourseDatas_DiscourseDataGuid",
                        column: x => x.DiscourseDataGuid,
                        principalTable: "DsDiscourseDatas",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Folders_FilePathsInTsStringsGuid",
                        column: x => x.FilePathsInTsStringsGuid,
                        principalTable: "Folders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_FsFeatureSystems_MsFeatureSystemGuid",
                        column: x => x.MsFeatureSystemGuid,
                        principalTable: "FsFeatureSystems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_FsFeatureSystems_PhFeatureSystemGuid",
                        column: x => x.PhFeatureSystemGuid,
                        principalTable: "FsFeatureSystems",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_LexDbs_LexDbGuid",
                        column: x => x.LexDbGuid,
                        principalTable: "LexDbs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_MoMorphDatas_MorphologicalDataGuid",
                        column: x => x.MorphologicalDataGuid,
                        principalTable: "MoMorphDatas",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PhPhonDatas_PhonologicalDataGuid",
                        column: x => x.PhonologicalDataGuid,
                        principalTable: "PhPhonDatas",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_AffixCategoriesGuid",
                        column: x => x.AffixCategoriesGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_AnnotationDefsGuid",
                        column: x => x.AnnotationDefsGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_AnthroListGuid",
                        column: x => x.AnthroListGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_ConfidenceLevelsGuid",
                        column: x => x.ConfidenceLevelsGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_EducationGuid",
                        column: x => x.EducationGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_GenreListGuid",
                        column: x => x.GenreListGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_LocationsGuid",
                        column: x => x.LocationsGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_PartsOfSpeechGuid",
                        column: x => x.PartsOfSpeechGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_PeopleGuid",
                        column: x => x.PeopleGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_PositionsGuid",
                        column: x => x.PositionsGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_RestrictionsGuid",
                        column: x => x.RestrictionsGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_RolesGuid",
                        column: x => x.RolesGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_SemanticDomainListGuid",
                        column: x => x.SemanticDomainListGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_StatusGuid",
                        column: x => x.StatusGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_TextMarkupTagsGuid",
                        column: x => x.TextMarkupTagsGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_ThesaurusGuid",
                        column: x => x.ThesaurusGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_TimeOfDayGuid",
                        column: x => x.TimeOfDayGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_PossibilityLists_TranslationTagsGuid",
                        column: x => x.TranslationTagsGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_RnResearchNbks_ResearchNotebookGuid",
                        column: x => x.ResearchNotebookGuid,
                        principalTable: "RnResearchNbks",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Scriptures_TranslatedScriptureGuid",
                        column: x => x.TranslatedScriptureGuid,
                        principalTable: "Scriptures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<Guid>(type: "uuid", nullable: false),
                    LexDb_ResourcesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Scripture_ResourcesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Resources_LexDbs_LexDb_ResourcesGuid",
                        column: x => x.LexDb_ResourcesGuid,
                        principalTable: "LexDbs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resources_Scriptures_Scripture_ResourcesGuid",
                        column: x => x.Scripture_ResourcesGuid,
                        principalTable: "Scriptures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrBookAnnotationss",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Scripture_BookAnnotationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrBookAnnotationss", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ScrBookAnnotationss_Scriptures_Scripture_BookAnnotationsGuid",
                        column: x => x.Scripture_BookAnnotationsGuid,
                        principalTable: "Scriptures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrDrafts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Protected = table.Column<bool>(type: "boolean", nullable: false),
                    Scripture_ArchivedDraftsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrDrafts", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ScrDrafts_Scriptures_Scripture_ArchivedDraftsGuid",
                        column: x => x.Scripture_ArchivedDraftsGuid,
                        principalTable: "Scriptures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrImportSets",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ImportType = table.Column<int>(type: "integer", nullable: false),
                    ImportProjToken = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Scripture_ImportSettingsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrImportSets", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ScrImportSets_Scriptures_Scripture_ImportSettingsGuid",
                        column: x => x.Scripture_ImportSettingsGuid,
                        principalTable: "Scriptures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StStyles",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BasedOnGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    NextGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Rules = table.Column<List<TextProperty>>(type: "jsonb", nullable: true),
                    IsPublishedTextStyle = table.Column<bool>(type: "boolean", nullable: false),
                    IsBuiltIn = table.Column<bool>(type: "boolean", nullable: false),
                    IsModified = table.Column<bool>(type: "boolean", nullable: false),
                    UserLevel = table.Column<int>(type: "integer", nullable: false),
                    Context = table.Column<int>(type: "integer", nullable: false),
                    Structure = table.Column<int>(type: "integer", nullable: false),
                    Function = table.Column<int>(type: "integer", nullable: false),
                    Usage = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Project_StylesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Scripture_StylesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StStyles", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_StStyles_Projects_Project_StylesGuid",
                        column: x => x.Project_StylesGuid,
                        principalTable: "Projects",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StStyles_Scriptures_Scripture_StylesGuid",
                        column: x => x.Scripture_StylesGuid,
                        principalTable: "Scriptures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StStyles_StStyles_BasedOnGuid",
                        column: x => x.BasedOnGuid,
                        principalTable: "StStyles",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_StStyles_StStyles_NextGuid",
                        column: x => x.NextGuid,
                        principalTable: "StStyles",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "UserAppFeatActs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ApplicationId = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureId = table.Column<int>(type: "integer", nullable: false),
                    ActivatedLevel = table.Column<int>(type: "integer", nullable: false),
                    Project_ActivatedFeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAppFeatActs", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_UserAppFeatActs_Projects_Project_ActivatedFeaturesGuid",
                        column: x => x.Project_ActivatedFeaturesGuid,
                        principalTable: "Projects",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserConfigAccts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Sid = table.Column<byte[]>(type: "bytea", nullable: true),
                    UserLevel = table.Column<int>(type: "integer", nullable: false),
                    HasMaintenance = table.Column<bool>(type: "boolean", nullable: false),
                    Project_UserAccountsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConfigAccts", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_UserConfigAccts_Projects_Project_UserAccountsGuid",
                        column: x => x.Project_UserAccountsGuid,
                        principalTable: "Projects",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrCheckRuns",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CheckId = table.Column<Guid>(type: "uuid", nullable: false),
                    RunDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Result = table.Column<int>(type: "integer", nullable: false),
                    ScrBookAnnotations_ChkHistRecsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrCheckRuns", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ScrCheckRuns_ScrBookAnnotationss_ScrBookAnnotations_ChkHist~",
                        column: x => x.ScrBookAnnotations_ChkHistRecsGuid,
                        principalTable: "ScrBookAnnotationss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAppFeatAct_UserConfigAcct_UserConfigAcct",
                columns: table => new
                {
                    LfUserAppFeatActGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    UserConfigAcctGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAppFeatAct_UserConfigAcct_UserConfigAcct", x => new { x.LfUserAppFeatActGuid, x.UserConfigAcctGuid });
                    table.ForeignKey(
                        name: "FK_UserAppFeatAct_UserConfigAcct_UserConfigAcct_UserAppFeatAct~",
                        column: x => x.LfUserAppFeatActGuid,
                        principalTable: "UserAppFeatActs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAppFeatAct_UserConfigAcct_UserConfigAcct_UserConfigAcct~",
                        column: x => x.UserConfigAcctGuid,
                        principalTable: "UserConfigAccts",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Possibilitys",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    SortSpec = table.Column<int>(type: "integer", nullable: false),
                    ConfidenceGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StatusGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiscussionGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    HelpId = table.Column<string>(type: "text", nullable: true),
                    ForeColor = table.Column<int>(type: "integer", nullable: false),
                    BackColor = table.Column<int>(type: "integer", nullable: false),
                    UnderColor = table.Column<int>(type: "integer", nullable: false),
                    UnderStyle = table.Column<int>(type: "integer", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsProtected = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    PossibilityList_PossibilitiesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Possibility_SubPossibilitiesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AllowsComment = table.Column<bool>(type: "boolean", nullable: true),
                    AllowsFeatureStructure = table.Column<bool>(type: "boolean", nullable: true),
                    AllowsInstanceOf = table.Column<bool>(type: "boolean", nullable: true),
                    InstanceOfSignature = table.Column<int>(type: "integer", nullable: true),
                    UserCanCreate = table.Column<bool>(type: "boolean", nullable: true),
                    CanCreateOrphan = table.Column<bool>(type: "boolean", nullable: true),
                    PromptUser = table.Column<bool>(type: "boolean", nullable: true),
                    CopyCutPastable = table.Column<bool>(type: "boolean", nullable: true),
                    ZeroWidth = table.Column<bool>(type: "boolean", nullable: true),
                    Multi = table.Column<bool>(type: "boolean", nullable: true),
                    Severity = table.Column<int>(type: "integer", nullable: true),
                    MaxDupOccur = table.Column<int>(type: "integer", nullable: true),
                    SeeAlso = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    TermId = table.Column<int>(type: "integer", nullable: true),
                    ReverseAbbr = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LfLexEntryType_ReverseName = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    GlossPrepend = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    GlossAppend = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    InflFeatsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ReverseAbbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MappingType = table.Column<int>(type: "integer", nullable: true),
                    ReverseName = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LfLocation_Alias = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Postfix = table.Column<string>(type: "text", nullable: true),
                    Prefix = table.Column<string>(type: "text", nullable: true),
                    SecondaryOrder = table.Column<int>(type: "integer", nullable: true),
                    InherFeatValGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultFeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultInflectionClassGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    CatalogSourceId = table.Column<string>(type: "text", nullable: true),
                    Alias = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: true),
                    DateOfBirth = table.Column<GenDate>(type: "jsonb", nullable: true),
                    PlaceOfBirthGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsResearcher = table.Column<bool>(type: "boolean", nullable: true),
                    EducationGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DateOfDeath = table.Column<GenDate>(type: "jsonb", nullable: true),
                    ItemGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LouwNidaCodes = table.Column<string>(type: "text", nullable: true),
                    OcmCodes = table.Column<string>(type: "text", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possibilitys", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Possibilitys_FsAbstractStructures_DefaultFeaturesGuid",
                        column: x => x.DefaultFeaturesGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Possibilitys_FsAbstractStructures_InflFeatsGuid",
                        column: x => x.InflFeatsGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Possibilitys_FsAbstractStructures_InherFeatValGuid",
                        column: x => x.InherFeatValGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Possibilitys_MoInflClasss_DefaultInflectionClassGuid",
                        column: x => x.DefaultInflectionClassGuid,
                        principalTable: "MoInflClasss",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilitys_ObjectIds_ItemGuid",
                        column: x => x.ItemGuid,
                        principalTable: "ObjectIds",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilitys_PossibilityLists_PossibilityList_Possibilities~",
                        column: x => x.PossibilityList_PossibilitiesGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Possibilitys_Possibilitys_ConfidenceGuid",
                        column: x => x.ConfidenceGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilitys_Possibilitys_EducationGuid",
                        column: x => x.EducationGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilitys_Possibilitys_PlaceOfBirthGuid",
                        column: x => x.PlaceOfBirthGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilitys_Possibilitys_Possibility_SubPossibilitiesGuid",
                        column: x => x.Possibility_SubPossibilitiesGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Possibilitys_Possibilitys_StatusGuid",
                        column: x => x.StatusGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "ReversalIndexEntrys",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ReversalForm = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ReversalIndexEntry_SubentriesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ReversalIndex_EntriesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReversalIndexEntrys", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ReversalIndexEntrys_Possibilitys_PartOfSpeechGuid",
                        column: x => x.PartOfSpeechGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_ReversalIndexEntrys_ReversalIndexEntrys_ReversalIndexEntry_~",
                        column: x => x.ReversalIndexEntry_SubentriesGuid,
                        principalTable: "ReversalIndexEntrys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReversalIndexEntrys_ReversalIndexs_ReversalIndex_EntriesGuid",
                        column: x => x.ReversalIndex_EntriesGuid,
                        principalTable: "ReversalIndexs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrImportSources",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    WritingSystem = table.Column<string>(type: "text", nullable: true),
                    NoteTypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    ScrImportSet_BackTransSourcesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ScrImportSet_NoteSourcesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ScrImportSet_ScriptureSourcesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ParatextID = table.Column<string>(type: "text", nullable: true),
                    FileFormat = table.Column<int>(type: "integer", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrImportSources", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ScrImportSources_Possibilitys_NoteTypeGuid",
                        column: x => x.NoteTypeGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_ScrImportSources_ScrImportSets_ScrImportSet_BackTransSource~",
                        column: x => x.ScrImportSet_BackTransSourcesGuid,
                        principalTable: "ScrImportSets",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrImportSources_ScrImportSets_ScrImportSet_NoteSourcesGuid",
                        column: x => x.ScrImportSet_NoteSourcesGuid,
                        principalTable: "ScrImportSets",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrImportSources_ScrImportSets_ScrImportSet_ScriptureSource~",
                        column: x => x.ScrImportSet_ScriptureSourcesGuid,
                        principalTable: "ScrImportSets",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrMarkerMappings",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    BeginMarker = table.Column<string>(type: "text", nullable: true),
                    EndMarker = table.Column<string>(type: "text", nullable: true),
                    Excluded = table.Column<bool>(type: "boolean", nullable: false),
                    Target = table.Column<int>(type: "integer", nullable: false),
                    Domain = table.Column<int>(type: "integer", nullable: false),
                    WritingSystem = table.Column<string>(type: "text", nullable: true),
                    StyleGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    NoteTypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ScrImportSet_NoteMappingsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ScrImportSet_ScriptureMappingsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrMarkerMappings", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ScrMarkerMappings_Possibilitys_NoteTypeGuid",
                        column: x => x.NoteTypeGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_ScrMarkerMappings_ScrImportSets_ScrImportSet_NoteMappingsGu~",
                        column: x => x.ScrImportSet_NoteMappingsGuid,
                        principalTable: "ScrImportSets",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrMarkerMappings_ScrImportSets_ScrImportSet_ScriptureMappi~",
                        column: x => x.ScrImportSet_ScriptureMappingsGuid,
                        principalTable: "ScrImportSets",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrMarkerMappings_StStyles_StyleGuid",
                        column: x => x.StyleGuid,
                        principalTable: "StStyles",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "ScrScriptureNote_Categories_Possibility",
                columns: table => new
                {
                    CategoriesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfScrScriptureNoteGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrScriptureNote_Categories_Possibility", x => new { x.CategoriesGuid, x.LfScrScriptureNoteGuid });
                    table.ForeignKey(
                        name: "FK_ScrScriptureNote_Categories_Possibility_Annotations_LfScrSc~",
                        column: x => x.LfScrScriptureNoteGuid,
                        principalTable: "Annotations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrScriptureNote_Categories_Possibility_Possibilitys_Catego~",
                        column: x => x.CategoriesGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SemanticDomain_OcmRefs_Possibility",
                columns: table => new
                {
                    LfSemanticDomainGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    OcmRefsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemanticDomain_OcmRefs_Possibility", x => new { x.LfSemanticDomainGuid, x.OcmRefsGuid });
                    table.ForeignKey(
                        name: "FK_SemanticDomain_OcmRefs_Possibility_Possibilitys_LfSemanticD~",
                        column: x => x.LfSemanticDomainGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemanticDomain_OcmRefs_Possibility_Possibilitys_OcmRefsGuid",
                        column: x => x.OcmRefsGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SemanticDomain_RelatedDomains_Possibility",
                columns: table => new
                {
                    LfSemanticDomainGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    RelatedDomainsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemanticDomain_RelatedDomains_Possibility", x => new { x.LfSemanticDomainGuid, x.RelatedDomainsGuid });
                    table.ForeignKey(
                        name: "FK_SemanticDomain_RelatedDomains_Possibility_Possibilitys_LfSe~",
                        column: x => x.LfSemanticDomainGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemanticDomain_RelatedDomains_Possibility_Possibilitys_Rela~",
                        column: x => x.RelatedDomainsGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WfiAnalysiss",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MsFeaturesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DerivationGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    WfiWordform_AnalysesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiAnalysiss", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_WfiAnalysiss_FsAbstractStructures_MsFeaturesGuid",
                        column: x => x.MsFeaturesGuid,
                        principalTable: "FsAbstractStructures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WfiAnalysiss_MoDerivs_DerivationGuid",
                        column: x => x.DerivationGuid,
                        principalTable: "MoDerivs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WfiAnalysiss_Possibilitys_CategoryGuid",
                        column: x => x.CategoryGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiAnalysiss_WfiWordforms_WfiWordform_AnalysesGuid",
                        column: x => x.WfiWordform_AnalysesGuid,
                        principalTable: "WfiWordforms",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordFormLookup_AnthroCodes_Possibility",
                columns: table => new
                {
                    AnthroCodesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfWordFormLookup1Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordFormLookup_AnthroCodes_Possibility", x => new { x.AnthroCodesGuid, x.LfWordFormLookup1Guid });
                    table.ForeignKey(
                        name: "FK_WordFormLookup_AnthroCodes_Possibility_Possibilitys_AnthroC~",
                        column: x => x.AnthroCodesGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordFormLookup_AnthroCodes_Possibility_WordFormLookups_LfWo~",
                        column: x => x.LfWordFormLookup1Guid,
                        principalTable: "WordFormLookups",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WordFormLookup_ThesaurusItems_Possibility",
                columns: table => new
                {
                    LfWordFormLookupGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ThesaurusItemsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordFormLookup_ThesaurusItems_Possibility", x => new { x.LfWordFormLookupGuid, x.ThesaurusItemsGuid });
                    table.ForeignKey(
                        name: "FK_WordFormLookup_ThesaurusItems_Possibility_Possibilitys_Thes~",
                        column: x => x.ThesaurusItemsGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WordFormLookup_ThesaurusItems_Possibility_WordFormLookups_L~",
                        column: x => x.LfWordFormLookupGuid,
                        principalTable: "WordFormLookups",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReversalIndexEntry_Senses_LexSense",
                columns: table => new
                {
                    LfReversalIndexEntryGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SensesGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReversalIndexEntry_Senses_LexSense", x => new { x.LfReversalIndexEntryGuid, x.SensesGuid });
                    table.ForeignKey(
                        name: "FK_ReversalIndexEntry_Senses_LexSense_LexSenses_SensesGuid",
                        column: x => x.SensesGuid,
                        principalTable: "LexSenses",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReversalIndexEntry_Senses_LexSense_ReversalIndexEntrys_LfRe~",
                        column: x => x.LfReversalIndexEntryGuid,
                        principalTable: "ReversalIndexEntrys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WfiAnalysis_CompoundRuleApps_MoCompoundRule",
                columns: table => new
                {
                    CompoundRuleAppsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfWfiAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiAnalysis_CompoundRuleApps_MoCompoundRule", x => new { x.CompoundRuleAppsGuid, x.LfWfiAnalysisGuid });
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_CompoundRuleApps_MoCompoundRule_MoCompoundRules~",
                        column: x => x.CompoundRuleAppsGuid,
                        principalTable: "MoCompoundRules",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_CompoundRuleApps_MoCompoundRule_WfiAnalysiss_Lf~",
                        column: x => x.LfWfiAnalysisGuid,
                        principalTable: "WfiAnalysiss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WfiAnalysis_Evaluations_AgentEvaluation",
                columns: table => new
                {
                    EvaluationsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfWfiAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiAnalysis_Evaluations_AgentEvaluation", x => new { x.EvaluationsGuid, x.LfWfiAnalysisGuid });
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_Evaluations_AgentEvaluation_AgentEvaluations_Ev~",
                        column: x => x.EvaluationsGuid,
                        principalTable: "AgentEvaluations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_Evaluations_AgentEvaluation_WfiAnalysiss_LfWfiA~",
                        column: x => x.LfWfiAnalysisGuid,
                        principalTable: "WfiAnalysiss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WfiAnalysis_InflTemplateApps_MoInflAffixTemplate",
                columns: table => new
                {
                    InflTemplateAppsGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfWfiAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiAnalysis_InflTemplateApps_MoInflAffixTemplate", x => new { x.InflTemplateAppsGuid, x.LfWfiAnalysisGuid });
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_InflTemplateApps_MoInflAffixTemplate_MoInflAffi~",
                        column: x => x.InflTemplateAppsGuid,
                        principalTable: "MoInflAffixTemplates",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_InflTemplateApps_MoInflAffixTemplate_WfiAnalysi~",
                        column: x => x.LfWfiAnalysisGuid,
                        principalTable: "WfiAnalysiss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WfiAnalysis_Stems_LexEntry",
                columns: table => new
                {
                    LfWfiAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    StemsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiAnalysis_Stems_LexEntry", x => new { x.LfWfiAnalysisGuid, x.StemsGuid });
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_Stems_LexEntry_LexEntrys_StemsGuid",
                        column: x => x.StemsGuid,
                        principalTable: "LexEntrys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_Stems_LexEntry_WfiAnalysiss_LfWfiAnalysisGuid",
                        column: x => x.LfWfiAnalysisGuid,
                        principalTable: "WfiAnalysiss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WfiGlosss",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Form = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    WfiAnalysis_MeaningsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiGlosss", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_WfiGlosss_WfiAnalysiss_WfiAnalysis_MeaningsGuid",
                        column: x => x.WfiAnalysis_MeaningsGuid,
                        principalTable: "WfiAnalysiss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WfiMorphBundles",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Form = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MorphGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    SenseGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    InflTypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    WfiAnalysis_MorphBundlesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiMorphBundles", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_WfiMorphBundles_LexSenses_SenseGuid",
                        column: x => x.SenseGuid,
                        principalTable: "LexSenses",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiMorphBundles_MoForms_MorphGuid",
                        column: x => x.MorphGuid,
                        principalTable: "MoForms",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiMorphBundles_MoMorphSynAnalysiss_MsaGuid",
                        column: x => x.MsaGuid,
                        principalTable: "MoMorphSynAnalysiss",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiMorphBundles_Possibilitys_InflTypeGuid",
                        column: x => x.InflTypeGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiMorphBundles_WfiAnalysiss_WfiAnalysis_MorphBundlesGuid",
                        column: x => x.WfiAnalysis_MorphBundlesGuid,
                        principalTable: "WfiAnalysiss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PubDivisions",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DifferentFirstHF = table.Column<bool>(type: "boolean", nullable: false),
                    DifferentEvenHF = table.Column<bool>(type: "boolean", nullable: false),
                    StartAt = table.Column<int>(type: "integer", nullable: false),
                    PageLayoutGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    HFSetGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    NumColumns = table.Column<int>(type: "integer", nullable: false),
                    Publication_DivisionsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PubDivisions", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PubDivisions_PubPageLayouts_PageLayoutGuid",
                        column: x => x.PageLayoutGuid,
                        principalTable: "PubPageLayouts",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PubHFSets",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DefaultHeaderGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultFooterGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FirstHeaderGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FirstFooterGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EvenHeaderGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EvenFooterGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DsChart_HeaderFooterSetsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexDb_HeaderFooterSetsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PossibilityList_HeaderFooterSetsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ReversalIndex_HeaderFooterSetsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RnResearchNbk_HeaderFooterSetsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Scripture_HeaderFooterSetsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Text_HeaderFooterSetsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    WordformLookupList_HeaderFooterSetsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PubHFSets", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PubHFSets_DsCharts_DsChart_HeaderFooterSetsGuid",
                        column: x => x.DsChart_HeaderFooterSetsGuid,
                        principalTable: "DsCharts",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_LexDbs_LexDb_HeaderFooterSetsGuid",
                        column: x => x.LexDb_HeaderFooterSetsGuid,
                        principalTable: "LexDbs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_PossibilityLists_PossibilityList_HeaderFooterSets~",
                        column: x => x.PossibilityList_HeaderFooterSetsGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_PubHeaders_DefaultFooterGuid",
                        column: x => x.DefaultFooterGuid,
                        principalTable: "PubHeaders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_PubHeaders_DefaultHeaderGuid",
                        column: x => x.DefaultHeaderGuid,
                        principalTable: "PubHeaders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_PubHeaders_EvenFooterGuid",
                        column: x => x.EvenFooterGuid,
                        principalTable: "PubHeaders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_PubHeaders_EvenHeaderGuid",
                        column: x => x.EvenHeaderGuid,
                        principalTable: "PubHeaders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_PubHeaders_FirstFooterGuid",
                        column: x => x.FirstFooterGuid,
                        principalTable: "PubHeaders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_PubHeaders_FirstHeaderGuid",
                        column: x => x.FirstHeaderGuid,
                        principalTable: "PubHeaders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_ReversalIndexs_ReversalIndex_HeaderFooterSetsGuid",
                        column: x => x.ReversalIndex_HeaderFooterSetsGuid,
                        principalTable: "ReversalIndexs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_RnResearchNbks_RnResearchNbk_HeaderFooterSetsGuid",
                        column: x => x.RnResearchNbk_HeaderFooterSetsGuid,
                        principalTable: "RnResearchNbks",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_Scriptures_Scripture_HeaderFooterSetsGuid",
                        column: x => x.Scripture_HeaderFooterSetsGuid,
                        principalTable: "Scriptures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PubHFSets_WordformLookupLists_WordformLookupList_HeaderFoot~",
                        column: x => x.WordformLookupList_HeaderFooterSetsGuid,
                        principalTable: "WordformLookupLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PageHeight = table.Column<int>(type: "integer", nullable: false),
                    PageWidth = table.Column<int>(type: "integer", nullable: false),
                    IsLandscape = table.Column<bool>(type: "boolean", nullable: false),
                    GutterMargin = table.Column<int>(type: "integer", nullable: false),
                    GutterLoc = table.Column<int>(type: "integer", nullable: false),
                    FootnoteSepWidth = table.Column<int>(type: "integer", nullable: false),
                    PaperHeight = table.Column<int>(type: "integer", nullable: false),
                    PaperWidth = table.Column<int>(type: "integer", nullable: false),
                    BindingEdge = table.Column<int>(type: "integer", nullable: false),
                    SheetLayout = table.Column<int>(type: "integer", nullable: false),
                    SheetsPerSig = table.Column<int>(type: "integer", nullable: false),
                    BaseFontSize = table.Column<int>(type: "integer", nullable: false),
                    BaseLineSpacing = table.Column<int>(type: "integer", nullable: false),
                    DsChart_PublicationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexDb_PublicationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PossibilityList_PublicationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ReversalIndex_PublicationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RnResearchNbk_PublicationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Scripture_PublicationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Text_PublicationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    WordformLookupList_PublicationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Publications_DsCharts_DsChart_PublicationsGuid",
                        column: x => x.DsChart_PublicationsGuid,
                        principalTable: "DsCharts",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_LexDbs_LexDb_PublicationsGuid",
                        column: x => x.LexDb_PublicationsGuid,
                        principalTable: "LexDbs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_PossibilityLists_PossibilityList_PublicationsG~",
                        column: x => x.PossibilityList_PublicationsGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_ReversalIndexs_ReversalIndex_PublicationsGuid",
                        column: x => x.ReversalIndex_PublicationsGuid,
                        principalTable: "ReversalIndexs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_RnResearchNbks_RnResearchNbk_PublicationsGuid",
                        column: x => x.RnResearchNbk_PublicationsGuid,
                        principalTable: "RnResearchNbks",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_Scriptures_Scripture_PublicationsGuid",
                        column: x => x.Scripture_PublicationsGuid,
                        principalTable: "Scriptures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Publications_WordformLookupLists_WordformLookupList_Publica~",
                        column: x => x.WordformLookupList_PublicationsGuid,
                        principalTable: "WordformLookupLists",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_AnthroCodes_Possibility",
                columns: table => new
                {
                    AnthroCodesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfRnGenericRecGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_AnthroCodes_Possibility", x => new { x.AnthroCodesGuid, x.LfRnGenericRecGuid });
                    table.ForeignKey(
                        name: "FK_RnGenericRec_AnthroCodes_Possibility_Possibilitys_AnthroCod~",
                        column: x => x.AnthroCodesGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_CounterEvidence_RnGenericRec",
                columns: table => new
                {
                    CounterEvidenceGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfRnGenericRec1Guid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_CounterEvidence_RnGenericRec", x => new { x.CounterEvidenceGuid, x.LfRnGenericRec1Guid });
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_CrossReferences_CrossReference",
                columns: table => new
                {
                    CrossReferencesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfRnGenericRecGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_CrossReferences_CrossReference", x => new { x.CrossReferencesGuid, x.LfRnGenericRecGuid });
                    table.ForeignKey(
                        name: "FK_RnGenericRec_CrossReferences_CrossReference_CrossReferences~",
                        column: x => x.CrossReferencesGuid,
                        principalTable: "CrossReferences",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_Locations_Possibility",
                columns: table => new
                {
                    LfRnGenericRecGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LocationsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_Locations_Possibility", x => new { x.LfRnGenericRecGuid, x.LocationsGuid });
                    table.ForeignKey(
                        name: "FK_RnGenericRec_Locations_Possibility_Possibilitys_LocationsGu~",
                        column: x => x.LocationsGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_PhraseTags_Possibility",
                columns: table => new
                {
                    LfRnGenericRec2Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PhraseTagsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_PhraseTags_Possibility", x => new { x.LfRnGenericRec2Guid, x.PhraseTagsGuid });
                    table.ForeignKey(
                        name: "FK_RnGenericRec_PhraseTags_Possibility_Possibilitys_PhraseTags~",
                        column: x => x.PhraseTagsGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_Reminders_Reminder",
                columns: table => new
                {
                    LfRnGenericRecGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    RemindersGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_Reminders_Reminder", x => new { x.LfRnGenericRecGuid, x.RemindersGuid });
                    table.ForeignKey(
                        name: "FK_RnGenericRec_Reminders_Reminder_Reminders_RemindersGuid",
                        column: x => x.RemindersGuid,
                        principalTable: "Reminders",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_Researchers_Possibility",
                columns: table => new
                {
                    LfRnGenericRecGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ResearchersGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_Researchers_Possibility", x => new { x.LfRnGenericRecGuid, x.ResearchersGuid });
                    table.ForeignKey(
                        name: "FK_RnGenericRec_Researchers_Possibility_Possibilitys_Researche~",
                        column: x => x.ResearchersGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_Restrictions_Possibility",
                columns: table => new
                {
                    LfRnGenericRec1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RestrictionsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_Restrictions_Possibility", x => new { x.LfRnGenericRec1Guid, x.RestrictionsGuid });
                    table.ForeignKey(
                        name: "FK_RnGenericRec_Restrictions_Possibility_Possibilitys_Restrict~",
                        column: x => x.RestrictionsGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_SeeAlso_RnGenericRec",
                columns: table => new
                {
                    LfRnGenericRecGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SeeAlsoGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_SeeAlso_RnGenericRec", x => new { x.LfRnGenericRecGuid, x.SeeAlsoGuid });
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_Sources_Possibility",
                columns: table => new
                {
                    LfRnGenericRec3Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    SourcesGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_Sources_Possibility", x => new { x.LfRnGenericRec3Guid, x.SourcesGuid });
                    table.ForeignKey(
                        name: "FK_RnGenericRec_Sources_Possibility_Possibilitys_SourcesGuid",
                        column: x => x.SourcesGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_SupersededBy_RnGenericRec",
                columns: table => new
                {
                    LfRnGenericRec2Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    SupersededByGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_SupersededBy_RnGenericRec", x => new { x.LfRnGenericRec2Guid, x.SupersededByGuid });
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_SupportingEvidence_RnGenericRec",
                columns: table => new
                {
                    LfRnGenericRec3Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    SupportingEvidenceGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_SupportingEvidence_RnGenericRec", x => new { x.LfRnGenericRec3Guid, x.SupportingEvidenceGuid });
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRec_TimeOfEvent_Possibility",
                columns: table => new
                {
                    LfRnGenericRec4Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeOfEventGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRec_TimeOfEvent_Possibility", x => new { x.LfRnGenericRec4Guid, x.TimeOfEventGuid });
                    table.ForeignKey(
                        name: "FK_RnGenericRec_TimeOfEvent_Possibility_Possibilitys_TimeOfEve~",
                        column: x => x.TimeOfEventGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnGenericRecs",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    VersionHistoryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ConfidenceGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExternalMaterialsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FurtherQuestionsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DateOfEvent = table.Column<GenDate>(type: "jsonb", nullable: false),
                    StatusGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ConclusionsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    HypothesisGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ResearchPlanGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DescriptionGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PersonalNotesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DiscussionGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TextGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RnGenericRec_SubRecordsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RnResearchNbk_RecordsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnGenericRecs", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_RnGenericRecs_Possibilitys_ConfidenceGuid",
                        column: x => x.ConfidenceGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_RnGenericRecs_Possibilitys_StatusGuid",
                        column: x => x.StatusGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_RnGenericRecs_Possibilitys_TypeGuid",
                        column: x => x.TypeGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_RnGenericRecs_RnGenericRecs_RnGenericRec_SubRecordsGuid",
                        column: x => x.RnGenericRec_SubRecordsGuid,
                        principalTable: "RnGenericRecs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RnGenericRecs_RnResearchNbks_RnResearchNbk_RecordsGuid",
                        column: x => x.RnResearchNbk_RecordsGuid,
                        principalTable: "RnResearchNbks",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnRoledPartics",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RnGenericRec_ParticipantsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnRoledPartics", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_RnRoledPartics_Possibilitys_RoleGuid",
                        column: x => x.RoleGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_RnRoledPartics_RnGenericRecs_RnGenericRec_ParticipantsGuid",
                        column: x => x.RnGenericRec_ParticipantsGuid,
                        principalTable: "RnGenericRecs",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RnRoledPartic_Participants_Possibility",
                columns: table => new
                {
                    LfRnRoledParticGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    ParticipantsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RnRoledPartic_Participants_Possibility", x => new { x.LfRnRoledParticGuid, x.ParticipantsGuid });
                    table.ForeignKey(
                        name: "FK_RnRoledPartic_Participants_Possibility_Possibilitys_Partici~",
                        column: x => x.ParticipantsGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RnRoledPartic_Participants_Possibility_RnRoledPartics_LfRnR~",
                        column: x => x.LfRnRoledParticGuid,
                        principalTable: "RnRoledPartics",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrBooks",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    BookIdGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TitleGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Abbrev = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    IdText = table.Column<string>(type: "text", nullable: true),
                    UseChapterNumHeading = table.Column<bool>(type: "boolean", nullable: false),
                    CanonicalNum = table.Column<int>(type: "integer", nullable: false),
                    ImportedCheckSum = table.Column<string>(type: "text", nullable: true),
                    ImportedBtCheckSum = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ScrDraft_BooksGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Scripture_ScriptureBooksGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrBooks", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ScrBooks_ScrBookRefs_BookIdGuid",
                        column: x => x.BookIdGuid,
                        principalTable: "ScrBookRefs",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_ScrBooks_ScrDrafts_ScrDraft_BooksGuid",
                        column: x => x.ScrDraft_BooksGuid,
                        principalTable: "ScrDrafts",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScrBooks_Scriptures_Scripture_ScriptureBooksGuid",
                        column: x => x.Scripture_ScriptureBooksGuid,
                        principalTable: "Scriptures",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrDifferences",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RefStart = table.Column<int>(type: "integer", nullable: false),
                    RefEnd = table.Column<int>(type: "integer", nullable: false),
                    DiffType = table.Column<int>(type: "integer", nullable: false),
                    RevMin = table.Column<int>(type: "integer", nullable: false),
                    RevLim = table.Column<int>(type: "integer", nullable: false),
                    RevParagraphGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ScrBook_DiffsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrDifferences", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ScrDifferences_ScrBooks_ScrBook_DiffsGuid",
                        column: x => x.ScrBook_DiffsGuid,
                        principalTable: "ScrBooks",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScrSections",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    HeadingGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ContentGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    VerseRefStart = table.Column<int>(type: "integer", nullable: false),
                    VerseRefEnd = table.Column<int>(type: "integer", nullable: false),
                    VerseRefMin = table.Column<int>(type: "integer", nullable: false),
                    VerseRefMax = table.Column<int>(type: "integer", nullable: false),
                    ScrBook_SectionsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScrSections", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_ScrSections_ScrBooks_ScrBook_SectionsGuid",
                        column: x => x.ScrBook_SectionsGuid,
                        principalTable: "ScrBooks",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Segment_Analyses_Analysis",
                columns: table => new
                {
                    AnalysesGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfSegmentGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segment_Analyses_Analysis", x => new { x.AnalysesGuid, x.LfSegmentGuid });
                    table.ForeignKey(
                        name: "FK_Segment_Analyses_Analysis_Analysiss_AnalysesGuid",
                        column: x => x.AnalysesGuid,
                        principalTable: "Analysiss",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    BeginOffset = table.Column<int>(type: "integer", nullable: false),
                    FreeTranslation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LiteralTranslation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Reference = table.Column<string>(type: "text", nullable: true),
                    MediaURIGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    BeginTimeOffset = table.Column<string>(type: "text", nullable: true),
                    EndTimeOffset = table.Column<string>(type: "text", nullable: true),
                    SpeakerGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StPara_SegmentsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Segments_MediaURIs_MediaURIGuid",
                        column: x => x.MediaURIGuid,
                        principalTable: "MediaURIs",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Segments_Possibilitys_SpeakerGuid",
                        column: x => x.SpeakerGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "StParas",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    StyleRules = table.Column<List<TextProperty>>(type: "jsonb", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    StText_ParagraphsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Label = table.Column<string>(type: "text", nullable: true),
                    Contents = table.Column<string>(type: "text", nullable: true),
                    ParseIsCurrent = table.Column<bool>(type: "boolean", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StParas", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "StTexts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RightToLeft = table.Column<bool>(type: "boolean", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    FootnoteMarker = table.Column<string>(type: "text", nullable: true),
                    ParaContainingOrcGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ScrBook_FootnotesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedByGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedByGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Annotation_ResponsesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StTexts", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_StTexts_Annotations_Annotation_ResponsesGuid",
                        column: x => x.Annotation_ResponsesGuid,
                        principalTable: "Annotations",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StTexts_Possibilitys_CreatedByGuid",
                        column: x => x.CreatedByGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_StTexts_Possibilitys_ModifiedByGuid",
                        column: x => x.ModifiedByGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_StTexts_ScrBooks_ScrBook_FootnotesGuid",
                        column: x => x.ScrBook_FootnotesGuid,
                        principalTable: "ScrBooks",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StTexts_StParas_ParaContainingOrcGuid",
                        column: x => x.ParaContainingOrcGuid,
                        principalTable: "StParas",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "StTxtPara_TextObjects_ObjectId",
                columns: table => new
                {
                    LfStTxtParaGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    TextObjectsGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StTxtPara_TextObjects_ObjectId", x => new { x.LfStTxtParaGuid, x.TextObjectsGuid });
                    table.ForeignKey(
                        name: "FK_StTxtPara_TextObjects_ObjectId_ObjectIds_TextObjectsGuid",
                        column: x => x.TextObjectsGuid,
                        principalTable: "ObjectIds",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StTxtPara_TextObjects_ObjectId_StParas_LfStTxtParaGuid",
                        column: x => x.LfStTxtParaGuid,
                        principalTable: "StParas",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Translation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    TypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LexExampleSentence_TranslationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StPara_TranslationsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Translations_LexExampleSentences_LexExampleSentence_Transla~",
                        column: x => x.LexExampleSentence_TranslationsGuid,
                        principalTable: "LexExampleSentences",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Translations_Possibilitys_TypeGuid",
                        column: x => x.TypeGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Translations_StParas_StPara_TranslationsGuid",
                        column: x => x.StPara_TranslationsGuid,
                        principalTable: "StParas",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Texts",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Source = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ContentsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    IsTranslated = table.Column<bool>(type: "boolean", nullable: false),
                    MediaFilesGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texts", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Texts_MediaContainers_MediaFilesGuid",
                        column: x => x.MediaFilesGuid,
                        principalTable: "MediaContainers",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Texts_StTexts_ContentsGuid",
                        column: x => x.ContentsGuid,
                        principalTable: "StTexts",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextTags",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    BeginSegmentGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EndSegmentGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    BeginAnalysisIndex = table.Column<int>(type: "integer", nullable: false),
                    EndAnalysisIndex = table.Column<int>(type: "integer", nullable: false),
                    TagGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StText_TagsGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextTags", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_TextTags_Possibilitys_TagGuid",
                        column: x => x.TagGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_TextTags_Segments_BeginSegmentGuid",
                        column: x => x.BeginSegmentGuid,
                        principalTable: "Segments",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_TextTags_Segments_EndSegmentGuid",
                        column: x => x.EndSegmentGuid,
                        principalTable: "Segments",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_TextTags_StTexts_StText_TagsGuid",
                        column: x => x.StText_TagsGuid,
                        principalTable: "StTexts",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Text_Genres_Possibility",
                columns: table => new
                {
                    GenresGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LfTextGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Text_Genres_Possibility", x => new { x.GenresGuid, x.LfTextGuid });
                    table.ForeignKey(
                        name: "FK_Text_Genres_Possibility_Possibilitys_GenresGuid",
                        column: x => x.GenresGuid,
                        principalTable: "Possibilitys",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Text_Genres_Possibility_Texts_LfTextGuid",
                        column: x => x.LfTextGuid,
                        principalTable: "Texts",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agents_ApprovesGuid",
                table: "Agents",
                column: "ApprovesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_DisapprovesGuid",
                table: "Agents",
                column: "DisapprovesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_NotesGuid",
                table: "Agents",
                column: "NotesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agents_Project_AnalyzingAgentsGuid",
                table: "Agents",
                column: "Project_AnalyzingAgentsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Analysiss_AnalysisGuid",
                table: "Analysiss",
                column: "AnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Analysiss_WordformGuid",
                table: "Analysiss",
                column: "WordformGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_AnnotationTypeGuid",
                table: "Annotations",
                column: "AnnotationTypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_BeginObjectGuid",
                table: "Annotations",
                column: "BeginObjectGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_DiscussionGuid",
                table: "Annotations",
                column: "DiscussionGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_EndObjectGuid",
                table: "Annotations",
                column: "EndObjectGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_FeaturesGuid",
                table: "Annotations",
                column: "FeaturesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_InstanceOfGuid",
                table: "Annotations",
                column: "InstanceOfGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_Project_AnnotationsGuid",
                table: "Annotations",
                column: "Project_AnnotationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_QuoteGuid",
                table: "Annotations",
                column: "QuoteGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_RecommendationGuid",
                table: "Annotations",
                column: "RecommendationGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_ResolutionGuid",
                table: "Annotations",
                column: "ResolutionGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_ScrBookAnnotations_NotesGuid",
                table: "Annotations",
                column: "ScrBookAnnotations_NotesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_SourceGuid",
                table: "Annotations",
                column: "SourceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Annotations_TextGuid",
                table: "Annotations",
                column: "TextGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseAnnotation_OtherObjects_ObjectId_OtherObjectsGuid",
                table: "BaseAnnotation_OtherObjects_ObjectId",
                column: "OtherObjectsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Cells_Row_CellsGuid",
                table: "Cells",
                column: "Row_CellsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ChkRefs_Possibility_OccurrencesGuid",
                table: "ChkRefs",
                column: "Possibility_OccurrencesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ChkRefs_RenderingGuid",
                table: "ChkRefs",
                column: "RenderingGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ChkRenderings_MeaningGuid",
                table: "ChkRenderings",
                column: "MeaningGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ChkRenderings_Possibility_RenderingsGuid",
                table: "ChkRenderings",
                column: "Possibility_RenderingsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ChkRenderings_SurfaceFormGuid",
                table: "ChkRenderings",
                column: "SurfaceFormGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ChkSenses_SenseGuid",
                table: "ChkSenses",
                column: "SenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ConstChartClauseMarker_DependentClauses_ConstChartRow_LfCon~",
                table: "ConstChartClauseMarker_DependentClauses_ConstChartRow",
                column: "LfConstChartClauseMarkerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ConstChartRows_DsChart_RowsGuid",
                table: "ConstChartRows",
                column: "DsChart_RowsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituentChartCellParts_BeginSegmentGuid",
                table: "ConstituentChartCellParts",
                column: "BeginSegmentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituentChartCellParts_ColumnGuid",
                table: "ConstituentChartCellParts",
                column: "ColumnGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituentChartCellParts_ConstChartRow_CellsGuid",
                table: "ConstituentChartCellParts",
                column: "ConstChartRow_CellsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituentChartCellParts_EndSegmentGuid",
                table: "ConstituentChartCellParts",
                column: "EndSegmentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituentChartCellParts_TagGuid",
                table: "ConstituentChartCellParts",
                column: "TagGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ConstituentChartCellParts_WordGroupGuid",
                table: "ConstituentChartCellParts",
                column: "WordGroupGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CrossReferences_RnResearchNbk_CrossReferencesGuid",
                table: "CrossReferences",
                column: "RnResearchNbk_CrossReferencesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_ConfigId",
                table: "CustomFieldValues",
                column: "ConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_LfLexEntryGuid",
                table: "CustomFieldValues",
                column: "LfLexEntryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_LfLexExampleSentenceGuid",
                table: "CustomFieldValues",
                column: "LfLexExampleSentenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_LfLexSenseGuid",
                table: "CustomFieldValues",
                column: "LfLexSenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_LfMoFormGuid",
                table: "CustomFieldValues",
                column: "LfMoFormGuid");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_PossibilityGuid_Value",
                table: "CustomFieldValues",
                column: "PossibilityGuid_Value");

            migrationBuilder.CreateIndex(
                name: "IX_CustomFieldValues_StTextGuid_Value",
                table: "CustomFieldValues",
                column: "StTextGuid_Value");

            migrationBuilder.CreateIndex(
                name: "IX_DomainQs_Possibility_QuestionsGuid",
                table: "DomainQs",
                column: "Possibility_QuestionsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DsCharts_BasedOnGuid",
                table: "DsCharts",
                column: "BasedOnGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DsCharts_DsDiscourseData_ChartsGuid",
                table: "DsCharts",
                column: "DsDiscourseData_ChartsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DsCharts_TemplateGuid",
                table: "DsCharts",
                column: "TemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DsDiscourseDatas_ChartMarkersGuid",
                table: "DsDiscourseDatas",
                column: "ChartMarkersGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DsDiscourseDatas_ConstChartTemplGuid",
                table: "DsDiscourseDatas",
                column: "ConstChartTemplGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_Folder_FilesGuid",
                table: "Files",
                column: "Folder_FilesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ScrImportSource_FilesGuid",
                table: "Files",
                column: "ScrImportSource_FilesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Filters_Project_FiltersGuid",
                table: "Filters",
                column: "Project_FiltersGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_Folder_SubFoldersGuid",
                table: "Folders",
                column: "Folder_SubFoldersGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_Project_MediaGuid",
                table: "Folders",
                column: "Project_MediaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_Project_PicturesGuid",
                table: "Folders",
                column: "Project_PicturesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsAbstractStructures_FsAbsStruc_ContentsGuid",
                table: "FsAbstractStructures",
                column: "FsAbsStruc_ContentsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsAbstractStructures_FsAbsStruc_FeatureDisjunctionsGuid",
                table: "FsAbstractStructures",
                column: "FsAbsStruc_FeatureDisjunctionsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsAbstractStructures_MoInflClass_ReferenceFormsGuid",
                table: "FsAbstractStructures",
                column: "MoInflClass_ReferenceFormsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsAbstractStructures_MoStemName_RegionsGuid",
                table: "FsAbstractStructures",
                column: "MoStemName_RegionsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsAbstractStructures_Possibility_EmptyParadigmCellsGuid",
                table: "FsAbstractStructures",
                column: "Possibility_EmptyParadigmCellsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsAbstractStructures_Possibility_ReferenceFormsGuid",
                table: "FsAbstractStructures",
                column: "Possibility_ReferenceFormsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsAbstractStructures_TypeGuid",
                table: "FsAbstractStructures",
                column: "TypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsDisjunctiveValue_Value_FsSymFeatVal_ValueGuid",
                table: "FsDisjunctiveValue_Value_FsSymFeatVal",
                column: "ValueGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatDefns_DefaultGuid",
                table: "FsFeatDefns",
                column: "DefaultGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatDefns_FsFeatureSystem_FeaturesGuid",
                table: "FsFeatDefns",
                column: "FsFeatureSystem_FeaturesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatDefns_TypeGuid",
                table: "FsFeatDefns",
                column: "TypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatStrucType_Features_FsFeatDefn_LfFsFeatStrucTypeGuid",
                table: "FsFeatStrucType_Features_FsFeatDefn",
                column: "LfFsFeatStrucTypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatStrucTypes_FsFeatureSystem_TypesGuid",
                table: "FsFeatStrucTypes",
                column: "FsFeatureSystem_TypesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatureSpecifications_FeatureGuid",
                table: "FsFeatureSpecifications",
                column: "FeatureGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatureSpecifications_FsAbsStruc_FeatureSpecsGuid",
                table: "FsFeatureSpecifications",
                column: "FsAbsStruc_FeatureSpecsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatureSpecifications_LfFsClosedValue_ValueGuid",
                table: "FsFeatureSpecifications",
                column: "LfFsClosedValue_ValueGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatureSpecifications_LfFsNegatedValue_ValueGuid",
                table: "FsFeatureSpecifications",
                column: "LfFsNegatedValue_ValueGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatureSpecifications_LfFsSharedValue_ValueGuid",
                table: "FsFeatureSpecifications",
                column: "LfFsSharedValue_ValueGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatureSpecifications_ValueGuid",
                table: "FsFeatureSpecifications",
                column: "ValueGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FsSymFeatVals_FsFeatDefn_ValuesGuid",
                table: "FsSymFeatVals",
                column: "FsFeatDefn_ValuesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_IndirectAnnotation_AppliesTo_Annotation_LfIndirectAnnotatio~",
                table: "IndirectAnnotation_AppliesTo_Annotation",
                column: "LfIndirectAnnotationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LangProject_WordformLookupLists_WordformLookupList_Wordform~",
                table: "LangProject_WordformLookupLists_WordformLookupList",
                column: "WordformLookupListsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexAppendixs_ContentsGuid",
                table: "LexAppendixs",
                column: "ContentsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexAppendixs_LexDb_AppendixesGuid",
                table: "LexAppendixs",
                column: "LexDb_AppendixesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexDb_AllomorphIndex_MoForm_LfLexDbGuid",
                table: "LexDb_AllomorphIndex_MoForm",
                column: "LfLexDbGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexDb_LexicalFormIndex_LexEntry_LfLexDbGuid",
                table: "LexDb_LexicalFormIndex_LexEntry",
                column: "LfLexDbGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_ComplexEntryTypesGuid",
                table: "LexDbs",
                column: "ComplexEntryTypesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_DialectLabelsGuid",
                table: "LexDbs",
                column: "DialectLabelsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_DomainTypesGuid",
                table: "LexDbs",
                column: "DomainTypesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_ExtendedNoteTypesGuid",
                table: "LexDbs",
                column: "ExtendedNoteTypesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_IntroductionGuid",
                table: "LexDbs",
                column: "IntroductionGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_LanguagesGuid",
                table: "LexDbs",
                column: "LanguagesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_MorphTypesGuid",
                table: "LexDbs",
                column: "MorphTypesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_PublicationTypesGuid",
                table: "LexDbs",
                column: "PublicationTypesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_ReferencesGuid",
                table: "LexDbs",
                column: "ReferencesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_SenseTypesGuid",
                table: "LexDbs",
                column: "SenseTypesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_UsageTypesGuid",
                table: "LexDbs",
                column: "UsageTypesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexDbs_VariantEntryTypesGuid",
                table: "LexDbs",
                column: "VariantEntryTypesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexEntry_DialectLabels_Possibility_LfLexEntry2Guid",
                table: "LexEntry_DialectLabels_Possibility",
                column: "LfLexEntry2Guid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntry_DoNotPublishIn_Possibility_LfLexEntry1Guid",
                table: "LexEntry_DoNotPublishIn_Possibility",
                column: "LfLexEntry1Guid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntry_DoNotShowMainEntryIn_Possibility_LfLexEntryGuid",
                table: "LexEntry_DoNotShowMainEntryIn_Possibility",
                column: "LfLexEntryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntry_MainEntriesOrSenses_ObjectId_MainEntriesOrSensesGu~",
                table: "LexEntry_MainEntriesOrSenses_ObjectId",
                column: "MainEntriesOrSensesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntryInflType_Slots_MoInflAffixSlot_SlotsGuid",
                table: "LexEntryInflType_Slots_MoInflAffixSlot",
                column: "SlotsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntryRef_ComplexEntryTypes_Possibility_LfLexEntryRef1Guid",
                table: "LexEntryRef_ComplexEntryTypes_Possibility",
                column: "LfLexEntryRef1Guid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntryRef_ComponentLexemes_ObjectId_LfLexEntryRef1Guid",
                table: "LexEntryRef_ComponentLexemes_ObjectId",
                column: "LfLexEntryRef1Guid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntryRef_PrimaryLexemes_ObjectId_PrimaryLexemesGuid",
                table: "LexEntryRef_PrimaryLexemes_ObjectId",
                column: "PrimaryLexemesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntryRef_ShowComplexFormsIn_ObjectId_ShowComplexFormsInG~",
                table: "LexEntryRef_ShowComplexFormsIn_ObjectId",
                column: "ShowComplexFormsInGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntryRef_VariantEntryTypes_Possibility_VariantEntryTypes~",
                table: "LexEntryRef_VariantEntryTypes_Possibility",
                column: "VariantEntryTypesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntryRefs_LexEntry_EntryRefsGuid",
                table: "LexEntryRefs",
                column: "LexEntry_EntryRefsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntrys_LexemeFormGuid",
                table: "LexEntrys",
                column: "LexemeFormGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LexEtymology_Language_Possibility_LfLexEtymologyGuid",
                table: "LexEtymology_Language_Possibility",
                column: "LfLexEtymologyGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEtymologys_LexEntry_EtymologyGuid",
                table: "LexEtymologys",
                column: "LexEntry_EtymologyGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexExampleSentence_DoNotPublishIn_Possibility_LfLexExampleS~",
                table: "LexExampleSentence_DoNotPublishIn_Possibility",
                column: "LfLexExampleSentenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexExampleSentences_LexExtendedNote_ExamplesGuid",
                table: "LexExampleSentences",
                column: "LexExtendedNote_ExamplesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexExampleSentences_LexSense_ExamplesGuid",
                table: "LexExampleSentences",
                column: "LexSense_ExamplesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexExtendedNotes_ExtendedNoteTypeGuid",
                table: "LexExtendedNotes",
                column: "ExtendedNoteTypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexExtendedNotes_LexSense_ExtendedNoteGuid",
                table: "LexExtendedNotes",
                column: "LexSense_ExtendedNoteGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexPronunciation_DoNotPublishIn_Possibility_LfLexPronunciat~",
                table: "LexPronunciation_DoNotPublishIn_Possibility",
                column: "LfLexPronunciationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexPronunciations_LexEntry_PronunciationsGuid",
                table: "LexPronunciations",
                column: "LexEntry_PronunciationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexPronunciations_LocationGuid",
                table: "LexPronunciations",
                column: "LocationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexReference_Targets_ObjectId_TargetsGuid",
                table: "LexReference_Targets_ObjectId",
                column: "TargetsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexReferences_Possibility_MembersGuid",
                table: "LexReferences",
                column: "Possibility_MembersGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSense_AnthroCodes_Possibility_LfLexSenseGuid",
                table: "LexSense_AnthroCodes_Possibility",
                column: "LfLexSenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSense_Appendixes_LexAppendix_LfLexSenseGuid",
                table: "LexSense_Appendixes_LexAppendix",
                column: "LfLexSenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSense_DialectLabels_Possibility_LfLexSense5Guid",
                table: "LexSense_DialectLabels_Possibility",
                column: "LfLexSense5Guid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSense_DomainTypes_Possibility_LfLexSense1Guid",
                table: "LexSense_DomainTypes_Possibility",
                column: "LfLexSense1Guid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSense_DoNotPublishIn_Possibility_LfLexSense4Guid",
                table: "LexSense_DoNotPublishIn_Possibility",
                column: "LfLexSense4Guid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSense_SemanticDomains_Possibility_SemanticDomainsGuid",
                table: "LexSense_SemanticDomains_Possibility",
                column: "SemanticDomainsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSense_ThesaurusItems_Possibility_ThesaurusItemsGuid",
                table: "LexSense_ThesaurusItems_Possibility",
                column: "ThesaurusItemsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSense_UsageTypes_Possibility_UsageTypesGuid",
                table: "LexSense_UsageTypes_Possibility",
                column: "UsageTypesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSenses_LexEntry_SensesGuid",
                table: "LexSenses",
                column: "LexEntry_SensesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSenses_LexSense_SensesGuid",
                table: "LexSenses",
                column: "LexSense_SensesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSenses_MorphoSyntaxAnalysisGuid",
                table: "LexSenses",
                column: "MorphoSyntaxAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSenses_SenseTypeGuid",
                table: "LexSenses",
                column: "SenseTypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexSenses_StatusGuid",
                table: "LexSenses",
                column: "StatusGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_LexPronunciation_MediaFilesGuid",
                table: "Medias",
                column: "LexPronunciation_MediaFilesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_MediaFileGuid",
                table: "Medias",
                column: "MediaFileGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MediaURIs_MediaContainer_MediaURIsGuid",
                table: "MediaURIs",
                column: "MediaContainer_MediaURIsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoAdhocProhibs_FirstAllomorphGuid",
                table: "MoAdhocProhibs",
                column: "FirstAllomorphGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoAdhocProhibs_FirstMorphemeGuid",
                table: "MoAdhocProhibs",
                column: "FirstMorphemeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoAdhocProhibs_MoAdhocProhib_MembersGuid",
                table: "MoAdhocProhibs",
                column: "MoAdhocProhib_MembersGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoAdhocProhibs_MoMorphData_AdhocCoProhibitionsGuid",
                table: "MoAdhocProhibs",
                column: "MoMorphData_AdhocCoProhibitionsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoAffixAllomorph_PhoneEnv_PhEnvironment_PhoneEnvGuid",
                table: "MoAffixAllomorph_PhoneEnv_PhEnvironment",
                column: "PhoneEnvGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoAffixAllomorph_Position_PhEnvironment_PositionGuid",
                table: "MoAffixAllomorph_Position_PhEnvironment",
                column: "PositionGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoAffixForm_InflectionClasses_MoInflClass_LfMoAffixFormGuid",
                table: "MoAffixForm_InflectionClasses_MoInflClass",
                column: "LfMoAffixFormGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoAlloAdhocProhib_Allomorphs_MoForm_LfMoAlloAdhocProhibGuid",
                table: "MoAlloAdhocProhib_Allomorphs_MoForm",
                column: "LfMoAlloAdhocProhibGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoAlloAdhocProhib_RestOfAllos_MoForm_RestOfAllosGuid",
                table: "MoAlloAdhocProhib_RestOfAllos_MoForm",
                column: "RestOfAllosGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRule_ToProdRestrict_Possibility_ToProdRestrictGuid",
                table: "MoCompoundRule_ToProdRestrict_Possibility",
                column: "ToProdRestrictGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRules_LeftMsaGuid",
                table: "MoCompoundRules",
                column: "LeftMsaGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRules_LinkerGuid",
                table: "MoCompoundRules",
                column: "LinkerGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRules_MoMorphData_CompoundRulesGuid",
                table: "MoCompoundRules",
                column: "MoMorphData_CompoundRulesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRules_OverridingMsaGuid",
                table: "MoCompoundRules",
                column: "OverridingMsaGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRules_RightMsaGuid",
                table: "MoCompoundRules",
                column: "RightMsaGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRules_StratumGuid",
                table: "MoCompoundRules",
                column: "StratumGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRules_ToMsaGuid",
                table: "MoCompoundRules",
                column: "ToMsaGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivAffMsa_FromProdRestrict_Possibility_LfMoDerivAffMsaG~",
                table: "MoDerivAffMsa_FromProdRestrict_Possibility",
                column: "LfMoDerivAffMsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivAffMsa_ToProdRestrict_Possibility_ToProdRestrictGuid",
                table: "MoDerivAffMsa_ToProdRestrict_Possibility",
                column: "ToProdRestrictGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivs_InflectionalFeatsGuid",
                table: "MoDerivs",
                column: "InflectionalFeatsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivs_StemFormGuid",
                table: "MoDerivs",
                column: "StemFormGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivs_StemMsaGuid",
                table: "MoDerivs",
                column: "StemMsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivStepMsa_ProdRestrict_Possibility_ProdRestrictGuid",
                table: "MoDerivStepMsa_ProdRestrict_Possibility",
                column: "ProdRestrictGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_AffixFormGuid",
                table: "MoDerivTraces",
                column: "AffixFormGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_AffixMsaGuid",
                table: "MoDerivTraces",
                column: "AffixMsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_LeftFormGuid",
                table: "MoDerivTraces",
                column: "LeftFormGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_LfMoInflAffixSlotApp_AffixFormGuid",
                table: "MoDerivTraces",
                column: "LfMoInflAffixSlotApp_AffixFormGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_LfMoInflAffixSlotApp_AffixMsaGuid",
                table: "MoDerivTraces",
                column: "LfMoInflAffixSlotApp_AffixMsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_LinkerGuid",
                table: "MoDerivTraces",
                column: "LinkerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_MoDeriv_StratumAppsGuid",
                table: "MoDerivTraces",
                column: "MoDeriv_StratumAppsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_MoDerivTrace_CompoundRuleAppsGuid",
                table: "MoDerivTraces",
                column: "MoDerivTrace_CompoundRuleAppsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_MoDerivTrace_DerivAffAppGuid",
                table: "MoDerivTraces",
                column: "MoDerivTrace_DerivAffAppGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_MoDerivTrace_PRuleAppsGuid",
                table: "MoDerivTraces",
                column: "MoDerivTrace_PRuleAppsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_MoDerivTrace_SlotAppsGuid",
                table: "MoDerivTraces",
                column: "MoDerivTrace_SlotAppsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_OutputMsaGuid",
                table: "MoDerivTraces",
                column: "OutputMsaGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_RightFormGuid",
                table: "MoDerivTraces",
                column: "RightFormGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_RuleGuid",
                table: "MoDerivTraces",
                column: "RuleGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_SlotGuid",
                table: "MoDerivTraces",
                column: "SlotGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_StratumGuid",
                table: "MoDerivTraces",
                column: "StratumGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_TemplateAppGuid",
                table: "MoDerivTraces",
                column: "TemplateAppGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivTraces_TemplateGuid",
                table: "MoDerivTraces",
                column: "TemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoForms_LexEntry_AlternateFormsGuid",
                table: "MoForms",
                column: "LexEntry_AlternateFormsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoForms_MorphTypeGuid",
                table: "MoForms",
                column: "MorphTypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoForms_MsEnvFeaturesGuid",
                table: "MoForms",
                column: "MsEnvFeaturesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoForms_MsEnvPartOfSpeechGuid",
                table: "MoForms",
                column: "MsEnvPartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoForms_StemNameGuid",
                table: "MoForms",
                column: "StemNameGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoGlossItems_FeatStructFragGuid",
                table: "MoGlossItems",
                column: "FeatStructFragGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoGlossItems_MoGlossItem_GlossItemsGuid",
                table: "MoGlossItems",
                column: "MoGlossItem_GlossItemsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoGlossItems_MoGlossSystem_GlossesGuid",
                table: "MoGlossItems",
                column: "MoGlossSystem_GlossesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoGlossItems_TargetGuid",
                table: "MoGlossItems",
                column: "TargetGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlots_Possibility_AffixSlotsGuid",
                table: "MoInflAffixSlots",
                column: "Possibility_AffixSlotsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplate_EncliticSlots_MoInflAffixSlot_LfMoInflA~",
                table: "MoInflAffixTemplate_EncliticSlots_MoInflAffixSlot",
                column: "LfMoInflAffixTemplate4Guid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplate_PrefixSlots_MoInflAffixSlot_PrefixSlots~",
                table: "MoInflAffixTemplate_PrefixSlots_MoInflAffixSlot",
                column: "PrefixSlotsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplate_ProcliticSlots_MoInflAffixSlot_Procliti~",
                table: "MoInflAffixTemplate_ProcliticSlots_MoInflAffixSlot",
                column: "ProcliticSlotsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplate_Slots_MoInflAffixSlot_SlotsGuid",
                table: "MoInflAffixTemplate_Slots_MoInflAffixSlot",
                column: "SlotsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplate_SuffixSlots_MoInflAffixSlot_SuffixSlots~",
                table: "MoInflAffixTemplate_SuffixSlots_MoInflAffixSlot",
                column: "SuffixSlotsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplates_Possibility_AffixTemplatesGuid",
                table: "MoInflAffixTemplates",
                column: "Possibility_AffixTemplatesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplates_RegionGuid",
                table: "MoInflAffixTemplates",
                column: "RegionGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplates_StratumGuid",
                table: "MoInflAffixTemplates",
                column: "StratumGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffMsa_FromProdRestrict_Possibility_LfMoInflAffMsaGuid",
                table: "MoInflAffMsa_FromProdRestrict_Possibility",
                column: "LfMoInflAffMsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffMsa_Slots_MoInflAffixSlot_SlotsGuid",
                table: "MoInflAffMsa_Slots_MoInflAffixSlot",
                column: "SlotsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflClasss_MoInflClass_SubclassesGuid",
                table: "MoInflClasss",
                column: "MoInflClass_SubclassesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflClasss_Possibility_InflectionClassesGuid",
                table: "MoInflClasss",
                column: "Possibility_InflectionClassesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInsertPhones_Content_PhTerminalUnit_LfMoInsertPhonesGuid",
                table: "MoInsertPhones_Content_PhTerminalUnit",
                column: "LfMoInsertPhonesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphAdhocProhib_Morphemes_MoMorphSynAnalysis_MorphemesGu~",
                table: "MoMorphAdhocProhib_Morphemes_MoMorphSynAnalysis",
                column: "MorphemesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphAdhocProhib_RestOfMorphs_MoMorphSynAnalysis_RestOfMo~",
                table: "MoMorphAdhocProhib_RestOfMorphs_MoMorphSynAnalysis",
                column: "RestOfMorphsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphData_AnalyzingAgents_Agent_LfMoMorphDataGuid",
                table: "MoMorphData_AnalyzingAgents_Agent",
                column: "LfMoMorphDataGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphDatas_GlossSystemGuid",
                table: "MoMorphDatas",
                column: "GlossSystemGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphDatas_ProdRestrictGuid",
                table: "MoMorphDatas",
                column: "ProdRestrictGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_Components_MoMorphSynAnalysis_LfMoMorphS~",
                table: "MoMorphSynAnalysis_Components_MoMorphSynAnalysis",
                column: "LfMoMorphSynAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_GlossBundle_MoGlossItem_LfMoMorphSynAnal~",
                table: "MoMorphSynAnalysis_GlossBundle_MoGlossItem",
                column: "LfMoMorphSynAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_AffixCategoryGuid",
                table: "MoMorphSynAnalysiss",
                column: "AffixCategoryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_FromInflectionClassGuid",
                table: "MoMorphSynAnalysiss",
                column: "FromInflectionClassGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_FromMsFeaturesGuid",
                table: "MoMorphSynAnalysiss",
                column: "FromMsFeaturesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_FromPartOfSpeechGuid",
                table: "MoMorphSynAnalysiss",
                column: "FromPartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_FromStemNameGuid",
                table: "MoMorphSynAnalysiss",
                column: "FromStemNameGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_InflectionClassGuid",
                table: "MoMorphSynAnalysiss",
                column: "InflectionClassGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_InflFeatsGuid",
                table: "MoMorphSynAnalysiss",
                column: "InflFeatsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_LexEntry_MorphoSyntaxAnalysesGuid",
                table: "MoMorphSynAnalysiss",
                column: "LexEntry_MorphoSyntaxAnalysesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_LfMoDerivAffMsa_AffixCategoryGuid",
                table: "MoMorphSynAnalysiss",
                column: "LfMoDerivAffMsa_AffixCategoryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_LfMoDerivStepMsa_InflFeatsGuid",
                table: "MoMorphSynAnalysiss",
                column: "LfMoDerivStepMsa_InflFeatsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_LfMoDerivStepMsa_PartOfSpeechGuid",
                table: "MoMorphSynAnalysiss",
                column: "LfMoDerivStepMsa_PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_LfMoStemMsa_InflectionClassGuid",
                table: "MoMorphSynAnalysiss",
                column: "LfMoStemMsa_InflectionClassGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_LfMoStemMsa_MsFeaturesGuid",
                table: "MoMorphSynAnalysiss",
                column: "LfMoStemMsa_MsFeaturesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_LfMoStemMsa_PartOfSpeechGuid",
                table: "MoMorphSynAnalysiss",
                column: "LfMoStemMsa_PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_LfMoStemMsa_StratumGuid",
                table: "MoMorphSynAnalysiss",
                column: "LfMoStemMsa_StratumGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_LfMoUnclassifiedAffixMsa_PartOfSpeechGu~",
                table: "MoMorphSynAnalysiss",
                column: "LfMoUnclassifiedAffixMsa_PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_MsFeaturesGuid",
                table: "MoMorphSynAnalysiss",
                column: "MsFeaturesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_PartOfSpeechGuid",
                table: "MoMorphSynAnalysiss",
                column: "PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_StratumGuid",
                table: "MoMorphSynAnalysiss",
                column: "StratumGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_ToInflectionClassGuid",
                table: "MoMorphSynAnalysiss",
                column: "ToInflectionClassGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_ToMsFeaturesGuid",
                table: "MoMorphSynAnalysiss",
                column: "ToMsFeaturesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysiss_ToPartOfSpeechGuid",
                table: "MoMorphSynAnalysiss",
                column: "ToPartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoReferralRules_InputGuid",
                table: "MoReferralRules",
                column: "InputGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoReferralRules_MoInflClass_RulesOfReferralGuid",
                table: "MoReferralRules",
                column: "MoInflClass_RulesOfReferralGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoReferralRules_OutputGuid",
                table: "MoReferralRules",
                column: "OutputGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoReferralRules_Possibility_RulesOfReferralGuid",
                table: "MoReferralRules",
                column: "Possibility_RulesOfReferralGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoRuleMappings_ContentGuid",
                table: "MoRuleMappings",
                column: "ContentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoRuleMappings_LfMoCopyFromInput_ContentGuid",
                table: "MoRuleMappings",
                column: "LfMoCopyFromInput_ContentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoRuleMappings_LfMoInsertNC_ContentGuid",
                table: "MoRuleMappings",
                column: "LfMoInsertNC_ContentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoRuleMappings_ModificationGuid",
                table: "MoRuleMappings",
                column: "ModificationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoRuleMappings_MoForm_OutputGuid",
                table: "MoRuleMappings",
                column: "MoForm_OutputGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemAllomorph_PhoneEnv_PhEnvironment_PhoneEnvGuid",
                table: "MoStemAllomorph_PhoneEnv_PhEnvironment",
                column: "PhoneEnvGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemMsa_FromPartsOfSpeech_Possibility_LfMoStemMsa1Guid",
                table: "MoStemMsa_FromPartsOfSpeech_Possibility",
                column: "LfMoStemMsa1Guid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemMsa_ProdRestrict_Possibility_ProdRestrictGuid",
                table: "MoStemMsa_ProdRestrict_Possibility",
                column: "ProdRestrictGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemMsa_Slots_MoInflAffixSlot_SlotsGuid",
                table: "MoStemMsa_Slots_MoInflAffixSlot",
                column: "SlotsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemNames_DefaultAffixGuid",
                table: "MoStemNames",
                column: "DefaultAffixGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemNames_DefaultStemGuid",
                table: "MoStemNames",
                column: "DefaultStemGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemNames_MoInflClass_StemNamesGuid",
                table: "MoStemNames",
                column: "MoInflClass_StemNamesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemNames_Possibility_StemNamesGuid",
                table: "MoStemNames",
                column: "Possibility_StemNamesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStratums_MoMorphData_StrataGuid",
                table: "MoStratums",
                column: "MoMorphData_StrataGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStratums_PhonemesGuid",
                table: "MoStratums",
                column: "PhonemesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Segment_NotesGuid",
                table: "Notes",
                column: "Segment_NotesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectIds_StPara_AnalyzedTextObjectsGuid",
                table: "ObjectIds",
                column: "StPara_AnalyzedTextObjectsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Overlay_PossItems_Possibility_PossItemsGuid",
                table: "Overlay_PossItems_Possibility",
                column: "PossItemsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Overlays_PossListGuid",
                table: "Overlays",
                column: "PossListGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Overlays_Project_OverlaysGuid",
                table: "Overlays",
                column: "Project_OverlaysGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PartOfSpeech_BearableFeatures_FsFeatDefn_LfPartOfSpeechGuid",
                table: "PartOfSpeech_BearableFeatures_FsFeatDefn",
                column: "LfPartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PartOfSpeech_InflectableFeats_FsFeatDefn_LfPartOfSpeech1Guid",
                table: "PartOfSpeech_InflectableFeats_FsFeatDefn",
                column: "LfPartOfSpeech1Guid");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PlacesOfResidence_Possibility_PlacesOfResidenceGuid",
                table: "Person_PlacesOfResidence_Possibility",
                column: "PlacesOfResidenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Person_Positions_Possibility_PositionsGuid",
                table: "Person_Positions_Possibility",
                column: "PositionsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhCodes_PhTerminalUnit_CodesGuid",
                table: "PhCodes",
                column: "PhTerminalUnit_CodesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhContextOrVars_DescriptionGuid",
                table: "PhContextOrVars",
                column: "DescriptionGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhContextOrVars_FeatureStructureGuid",
                table: "PhContextOrVars",
                column: "FeatureStructureGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhContextOrVars_LfPhSimpleContextNC_FeatureStructureGuid",
                table: "PhContextOrVars",
                column: "LfPhSimpleContextNC_FeatureStructureGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhContextOrVars_LfPhSimpleContextSeg_FeatureStructureGuid",
                table: "PhContextOrVars",
                column: "LfPhSimpleContextSeg_FeatureStructureGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhContextOrVars_MemberGuid",
                table: "PhContextOrVars",
                column: "MemberGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhContextOrVars_MoForm_InputGuid",
                table: "PhContextOrVars",
                column: "MoForm_InputGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhContextOrVars_PhPhonData_ContextsGuid",
                table: "PhContextOrVars",
                column: "PhPhonData_ContextsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhContextOrVars_PhSegmentRule_StrucDescGuid",
                table: "PhContextOrVars",
                column: "PhSegmentRule_StrucDescGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhContextOrVars_PhSegRuleRHS_StrucChangeGuid",
                table: "PhContextOrVars",
                column: "PhSegRuleRHS_StrucChangeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhEnvironments_LeftContextGuid",
                table: "PhEnvironments",
                column: "LeftContextGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhEnvironments_PhPhonData_EnvironmentsGuid",
                table: "PhEnvironments",
                column: "PhPhonData_EnvironmentsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhEnvironments_RightContextGuid",
                table: "PhEnvironments",
                column: "RightContextGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhFeatureConstraints_FeatureGuid",
                table: "PhFeatureConstraints",
                column: "FeatureGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhFeatureConstraints_PhPhonData_FeatConstraintsGuid",
                table: "PhFeatureConstraints",
                column: "PhPhonData_FeatConstraintsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhNaturalClasss_FeaturesGuid",
                table: "PhNaturalClasss",
                column: "FeaturesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhNaturalClasss_PhPhonData_NaturalClassesGuid",
                table: "PhNaturalClasss",
                column: "PhPhonData_NaturalClassesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhNCSegments_Segments_PhTerminalUnit_SegmentsGuid",
                table: "PhNCSegments_Segments_PhTerminalUnit",
                column: "SegmentsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhPhonDatas_PhonRuleFeatsGuid",
                table: "PhPhonDatas",
                column: "PhonRuleFeatsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhPhonemeSets_PhPhonData_PhonemeSetsGuid",
                table: "PhPhonemeSets",
                column: "PhPhonData_PhonemeSetsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhSegmentRules_FinalStratumGuid",
                table: "PhSegmentRules",
                column: "FinalStratumGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhSegmentRules_InitialStratumGuid",
                table: "PhSegmentRules",
                column: "InitialStratumGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhSegmentRules_PhPhonData_PhonRulesGuid",
                table: "PhSegmentRules",
                column: "PhPhonData_PhonRulesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhSegRuleRHS_ExclRuleFeats_Possibility_LfPhSegRuleRHSGuid",
                table: "PhSegRuleRHS_ExclRuleFeats_Possibility",
                column: "LfPhSegRuleRHSGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhSegRuleRHS_InputPOSes_Possibility_LfPhSegRuleRHSGuid",
                table: "PhSegRuleRHS_InputPOSes_Possibility",
                column: "LfPhSegRuleRHSGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhSegRuleRHS_ReqRuleFeats_Possibility_ReqRuleFeatsGuid",
                table: "PhSegRuleRHS_ReqRuleFeats_Possibility",
                column: "ReqRuleFeatsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhSegRuleRHSs_LeftContextGuid",
                table: "PhSegRuleRHSs",
                column: "LeftContextGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhSegRuleRHSs_PhSegmentRule_RightHandSidesGuid",
                table: "PhSegRuleRHSs",
                column: "PhSegmentRule_RightHandSidesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhSegRuleRHSs_RightContextGuid",
                table: "PhSegRuleRHSs",
                column: "RightContextGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhSequenceContext_Members_PhContextOrVar_MembersGuid",
                table: "PhSequenceContext_Members_PhContextOrVar",
                column: "MembersGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhSimpleContextNC_MinusConstr_PhFeatureConstraint_MinusCons~",
                table: "PhSimpleContextNC_MinusConstr_PhFeatureConstraint",
                column: "MinusConstrGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhSimpleContextNC_PlusConstr_PhFeatureConstraint_PlusConstr~",
                table: "PhSimpleContextNC_PlusConstr_PhFeatureConstraint",
                column: "PlusConstrGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhTerminalUnits_FeaturesGuid",
                table: "PhTerminalUnits",
                column: "FeaturesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhTerminalUnits_PhPhonemeSet_BoundaryMarkersGuid",
                table: "PhTerminalUnits",
                column: "PhPhonemeSet_BoundaryMarkersGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhTerminalUnits_PhPhonemeSet_PhonemesGuid",
                table: "PhTerminalUnits",
                column: "PhPhonemeSet_PhonemesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_DoNotPublishIn_Possibility_LfPictureGuid",
                table: "Picture_DoNotPublishIn_Possibility",
                column: "LfPictureGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_LexSense_PicturesGuid",
                table: "Pictures",
                column: "LexSense_PicturesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PictureFileGuid",
                table: "Pictures",
                column: "PictureFileGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibility_Researchers_Possibility_ResearchersGuid",
                table: "Possibility_Researchers_Possibility",
                column: "ResearchersGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibility_Restrictions_Possibility_RestrictionsGuid",
                table: "Possibility_Restrictions_Possibility",
                column: "RestrictionsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PossibilityListCustomFieldValue_Value_Possibility_ValueGuid",
                table: "PossibilityListCustomFieldValue_Value_Possibility",
                column: "ValueGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PossibilityLists_Project_CheckListsGuid",
                table: "PossibilityLists",
                column: "Project_CheckListsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_ConfidenceGuid",
                table: "Possibilitys",
                column: "ConfidenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_DefaultFeaturesGuid",
                table: "Possibilitys",
                column: "DefaultFeaturesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_DefaultInflectionClassGuid",
                table: "Possibilitys",
                column: "DefaultInflectionClassGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_DiscussionGuid",
                table: "Possibilitys",
                column: "DiscussionGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_EducationGuid",
                table: "Possibilitys",
                column: "EducationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_InflFeatsGuid",
                table: "Possibilitys",
                column: "InflFeatsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_InherFeatValGuid",
                table: "Possibilitys",
                column: "InherFeatValGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_ItemGuid",
                table: "Possibilitys",
                column: "ItemGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_PlaceOfBirthGuid",
                table: "Possibilitys",
                column: "PlaceOfBirthGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_Possibility_SubPossibilitiesGuid",
                table: "Possibilitys",
                column: "Possibility_SubPossibilitiesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_PossibilityList_PossibilitiesGuid",
                table: "Possibilitys",
                column: "PossibilityList_PossibilitiesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilitys_StatusGuid",
                table: "Possibilitys",
                column: "StatusGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AffixCategoriesGuid",
                table: "Projects",
                column: "AffixCategoriesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AnnotationDefsGuid",
                table: "Projects",
                column: "AnnotationDefsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AnthroListGuid",
                table: "Projects",
                column: "AnthroListGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ConfidenceLevelsGuid",
                table: "Projects",
                column: "ConfidenceLevelsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DiscourseDataGuid",
                table: "Projects",
                column: "DiscourseDataGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_EducationGuid",
                table: "Projects",
                column: "EducationGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_FilePathsInTsStringsGuid",
                table: "Projects",
                column: "FilePathsInTsStringsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_GenreListGuid",
                table: "Projects",
                column: "GenreListGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LexDbGuid",
                table: "Projects",
                column: "LexDbGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_LocationsGuid",
                table: "Projects",
                column: "LocationsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_MorphologicalDataGuid",
                table: "Projects",
                column: "MorphologicalDataGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_MsFeatureSystemGuid",
                table: "Projects",
                column: "MsFeatureSystemGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PartsOfSpeechGuid",
                table: "Projects",
                column: "PartsOfSpeechGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PeopleGuid",
                table: "Projects",
                column: "PeopleGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PhFeatureSystemGuid",
                table: "Projects",
                column: "PhFeatureSystemGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PhonologicalDataGuid",
                table: "Projects",
                column: "PhonologicalDataGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_PositionsGuid",
                table: "Projects",
                column: "PositionsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ResearchNotebookGuid",
                table: "Projects",
                column: "ResearchNotebookGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_RestrictionsGuid",
                table: "Projects",
                column: "RestrictionsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_RolesGuid",
                table: "Projects",
                column: "RolesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_SemanticDomainListGuid",
                table: "Projects",
                column: "SemanticDomainListGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StatusGuid",
                table: "Projects",
                column: "StatusGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TextMarkupTagsGuid",
                table: "Projects",
                column: "TextMarkupTagsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ThesaurusGuid",
                table: "Projects",
                column: "ThesaurusGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TimeOfDayGuid",
                table: "Projects",
                column: "TimeOfDayGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TranslatedScriptureGuid",
                table: "Projects",
                column: "TranslatedScriptureGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TranslationTagsGuid",
                table: "Projects",
                column: "TranslationTagsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PubDivisions_HFSetGuid",
                table: "PubDivisions",
                column: "HFSetGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PubDivisions_PageLayoutGuid",
                table: "PubDivisions",
                column: "PageLayoutGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PubDivisions_Publication_DivisionsGuid",
                table: "PubDivisions",
                column: "Publication_DivisionsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_DefaultFooterGuid",
                table: "PubHFSets",
                column: "DefaultFooterGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_DefaultHeaderGuid",
                table: "PubHFSets",
                column: "DefaultHeaderGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_DsChart_HeaderFooterSetsGuid",
                table: "PubHFSets",
                column: "DsChart_HeaderFooterSetsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_EvenFooterGuid",
                table: "PubHFSets",
                column: "EvenFooterGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_EvenHeaderGuid",
                table: "PubHFSets",
                column: "EvenHeaderGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_FirstFooterGuid",
                table: "PubHFSets",
                column: "FirstFooterGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_FirstHeaderGuid",
                table: "PubHFSets",
                column: "FirstHeaderGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_LexDb_HeaderFooterSetsGuid",
                table: "PubHFSets",
                column: "LexDb_HeaderFooterSetsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_PossibilityList_HeaderFooterSetsGuid",
                table: "PubHFSets",
                column: "PossibilityList_HeaderFooterSetsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_ReversalIndex_HeaderFooterSetsGuid",
                table: "PubHFSets",
                column: "ReversalIndex_HeaderFooterSetsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_RnResearchNbk_HeaderFooterSetsGuid",
                table: "PubHFSets",
                column: "RnResearchNbk_HeaderFooterSetsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_Scripture_HeaderFooterSetsGuid",
                table: "PubHFSets",
                column: "Scripture_HeaderFooterSetsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_Text_HeaderFooterSetsGuid",
                table: "PubHFSets",
                column: "Text_HeaderFooterSetsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSets_WordformLookupList_HeaderFooterSetsGuid",
                table: "PubHFSets",
                column: "WordformLookupList_HeaderFooterSetsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_DsChart_PublicationsGuid",
                table: "Publications",
                column: "DsChart_PublicationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_LexDb_PublicationsGuid",
                table: "Publications",
                column: "LexDb_PublicationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_PossibilityList_PublicationsGuid",
                table: "Publications",
                column: "PossibilityList_PublicationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ReversalIndex_PublicationsGuid",
                table: "Publications",
                column: "ReversalIndex_PublicationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_RnResearchNbk_PublicationsGuid",
                table: "Publications",
                column: "RnResearchNbk_PublicationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_Scripture_PublicationsGuid",
                table: "Publications",
                column: "Scripture_PublicationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_Text_PublicationsGuid",
                table: "Publications",
                column: "Text_PublicationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_WordformLookupList_PublicationsGuid",
                table: "Publications",
                column: "WordformLookupList_PublicationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Reminders_RnResearchNbk_RemindersGuid",
                table: "Reminders",
                column: "RnResearchNbk_RemindersGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_LexDb_ResourcesGuid",
                table: "Resources",
                column: "LexDb_ResourcesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Scripture_ResourcesGuid",
                table: "Resources",
                column: "Scripture_ResourcesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ReversalIndexEntry_Senses_LexSense_SensesGuid",
                table: "ReversalIndexEntry_Senses_LexSense",
                column: "SensesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ReversalIndexEntrys_PartOfSpeechGuid",
                table: "ReversalIndexEntrys",
                column: "PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ReversalIndexEntrys_ReversalIndex_EntriesGuid",
                table: "ReversalIndexEntrys",
                column: "ReversalIndex_EntriesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ReversalIndexEntrys_ReversalIndexEntry_SubentriesGuid",
                table: "ReversalIndexEntrys",
                column: "ReversalIndexEntry_SubentriesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ReversalIndexs_LexDb_ReversalIndexesGuid",
                table: "ReversalIndexs",
                column: "LexDb_ReversalIndexesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ReversalIndexs_PartsOfSpeechGuid",
                table: "ReversalIndexs",
                column: "PartsOfSpeechGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_AnthroCodes_Possibility_LfRnGenericRecGuid",
                table: "RnGenericRec_AnthroCodes_Possibility",
                column: "LfRnGenericRecGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_CounterEvidence_RnGenericRec_LfRnGenericRec1Gu~",
                table: "RnGenericRec_CounterEvidence_RnGenericRec",
                column: "LfRnGenericRec1Guid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_CrossReferences_CrossReference_LfRnGenericRecG~",
                table: "RnGenericRec_CrossReferences_CrossReference",
                column: "LfRnGenericRecGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_Locations_Possibility_LocationsGuid",
                table: "RnGenericRec_Locations_Possibility",
                column: "LocationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_PhraseTags_Possibility_PhraseTagsGuid",
                table: "RnGenericRec_PhraseTags_Possibility",
                column: "PhraseTagsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_Reminders_Reminder_RemindersGuid",
                table: "RnGenericRec_Reminders_Reminder",
                column: "RemindersGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_Researchers_Possibility_ResearchersGuid",
                table: "RnGenericRec_Researchers_Possibility",
                column: "ResearchersGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_Restrictions_Possibility_RestrictionsGuid",
                table: "RnGenericRec_Restrictions_Possibility",
                column: "RestrictionsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_SeeAlso_RnGenericRec_SeeAlsoGuid",
                table: "RnGenericRec_SeeAlso_RnGenericRec",
                column: "SeeAlsoGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_Sources_Possibility_SourcesGuid",
                table: "RnGenericRec_Sources_Possibility",
                column: "SourcesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_SupersededBy_RnGenericRec_SupersededByGuid",
                table: "RnGenericRec_SupersededBy_RnGenericRec",
                column: "SupersededByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_SupportingEvidence_RnGenericRec_SupportingEvid~",
                table: "RnGenericRec_SupportingEvidence_RnGenericRec",
                column: "SupportingEvidenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRec_TimeOfEvent_Possibility_TimeOfEventGuid",
                table: "RnGenericRec_TimeOfEvent_Possibility",
                column: "TimeOfEventGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_ConclusionsGuid",
                table: "RnGenericRecs",
                column: "ConclusionsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_ConfidenceGuid",
                table: "RnGenericRecs",
                column: "ConfidenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_DescriptionGuid",
                table: "RnGenericRecs",
                column: "DescriptionGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_DiscussionGuid",
                table: "RnGenericRecs",
                column: "DiscussionGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_ExternalMaterialsGuid",
                table: "RnGenericRecs",
                column: "ExternalMaterialsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_FurtherQuestionsGuid",
                table: "RnGenericRecs",
                column: "FurtherQuestionsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_HypothesisGuid",
                table: "RnGenericRecs",
                column: "HypothesisGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_PersonalNotesGuid",
                table: "RnGenericRecs",
                column: "PersonalNotesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_ResearchPlanGuid",
                table: "RnGenericRecs",
                column: "ResearchPlanGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_RnGenericRec_SubRecordsGuid",
                table: "RnGenericRecs",
                column: "RnGenericRec_SubRecordsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_RnResearchNbk_RecordsGuid",
                table: "RnGenericRecs",
                column: "RnResearchNbk_RecordsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_StatusGuid",
                table: "RnGenericRecs",
                column: "StatusGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_TextGuid",
                table: "RnGenericRecs",
                column: "TextGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_TypeGuid",
                table: "RnGenericRecs",
                column: "TypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnGenericRecs_VersionHistoryGuid",
                table: "RnGenericRecs",
                column: "VersionHistoryGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RnResearchNbks_RecTypesGuid",
                table: "RnResearchNbks",
                column: "RecTypesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RnRoledPartic_Participants_Possibility_ParticipantsGuid",
                table: "RnRoledPartic_Participants_Possibility",
                column: "ParticipantsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnRoledPartics_RnGenericRec_ParticipantsGuid",
                table: "RnRoledPartics",
                column: "RnGenericRec_ParticipantsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_RnRoledPartics_RoleGuid",
                table: "RnRoledPartics",
                column: "RoleGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Rows_Filter_RowsGuid",
                table: "Rows",
                column: "Filter_RowsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrBookAnnotationss_Scripture_BookAnnotationsGuid",
                table: "ScrBookAnnotationss",
                column: "Scripture_BookAnnotationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrBookRefs_ScrRefSystem_BooksGuid",
                table: "ScrBookRefs",
                column: "ScrRefSystem_BooksGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrBooks_BookIdGuid",
                table: "ScrBooks",
                column: "BookIdGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrBooks_ScrDraft_BooksGuid",
                table: "ScrBooks",
                column: "ScrDraft_BooksGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrBooks_Scripture_ScriptureBooksGuid",
                table: "ScrBooks",
                column: "Scripture_ScriptureBooksGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrBooks_TitleGuid",
                table: "ScrBooks",
                column: "TitleGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScrCheckRuns_ScrBookAnnotations_ChkHistRecsGuid",
                table: "ScrCheckRuns",
                column: "ScrBookAnnotations_ChkHistRecsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrDifferences_RevParagraphGuid",
                table: "ScrDifferences",
                column: "RevParagraphGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrDifferences_ScrBook_DiffsGuid",
                table: "ScrDifferences",
                column: "ScrBook_DiffsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrDrafts_Scripture_ArchivedDraftsGuid",
                table: "ScrDrafts",
                column: "Scripture_ArchivedDraftsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrImportSets_Scripture_ImportSettingsGuid",
                table: "ScrImportSets",
                column: "Scripture_ImportSettingsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrImportSources_NoteTypeGuid",
                table: "ScrImportSources",
                column: "NoteTypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrImportSources_ScrImportSet_BackTransSourcesGuid",
                table: "ScrImportSources",
                column: "ScrImportSet_BackTransSourcesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrImportSources_ScrImportSet_NoteSourcesGuid",
                table: "ScrImportSources",
                column: "ScrImportSet_NoteSourcesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrImportSources_ScrImportSet_ScriptureSourcesGuid",
                table: "ScrImportSources",
                column: "ScrImportSet_ScriptureSourcesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Scriptures_NoteCategoriesGuid",
                table: "Scriptures",
                column: "NoteCategoriesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScrMarkerMappings_NoteTypeGuid",
                table: "ScrMarkerMappings",
                column: "NoteTypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrMarkerMappings_ScrImportSet_NoteMappingsGuid",
                table: "ScrMarkerMappings",
                column: "ScrImportSet_NoteMappingsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrMarkerMappings_ScrImportSet_ScriptureMappingsGuid",
                table: "ScrMarkerMappings",
                column: "ScrImportSet_ScriptureMappingsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrMarkerMappings_StyleGuid",
                table: "ScrMarkerMappings",
                column: "StyleGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrScriptureNote_Categories_Possibility_LfScrScriptureNoteG~",
                table: "ScrScriptureNote_Categories_Possibility",
                column: "LfScrScriptureNoteGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ScrSections_ContentGuid",
                table: "ScrSections",
                column: "ContentGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScrSections_HeadingGuid",
                table: "ScrSections",
                column: "HeadingGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScrSections_ScrBook_SectionsGuid",
                table: "ScrSections",
                column: "ScrBook_SectionsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Segment_Analyses_Analysis_LfSegmentGuid",
                table: "Segment_Analyses_Analysis",
                column: "LfSegmentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_MediaURIGuid",
                table: "Segments",
                column: "MediaURIGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_SpeakerGuid",
                table: "Segments",
                column: "SpeakerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_StPara_SegmentsGuid",
                table: "Segments",
                column: "StPara_SegmentsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_SemanticDomain_OcmRefs_Possibility_OcmRefsGuid",
                table: "SemanticDomain_OcmRefs_Possibility",
                column: "OcmRefsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_SemanticDomain_RelatedDomains_Possibility_RelatedDomainsGuid",
                table: "SemanticDomain_RelatedDomains_Possibility",
                column: "RelatedDomainsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StParas_StText_ParagraphsGuid",
                table: "StParas",
                column: "StText_ParagraphsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StStyles_BasedOnGuid",
                table: "StStyles",
                column: "BasedOnGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StStyles_NextGuid",
                table: "StStyles",
                column: "NextGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StStyles_Project_StylesGuid",
                table: "StStyles",
                column: "Project_StylesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StStyles_Scripture_StylesGuid",
                table: "StStyles",
                column: "Scripture_StylesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StTexts_Annotation_ResponsesGuid",
                table: "StTexts",
                column: "Annotation_ResponsesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StTexts_CreatedByGuid",
                table: "StTexts",
                column: "CreatedByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StTexts_ModifiedByGuid",
                table: "StTexts",
                column: "ModifiedByGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StTexts_ParaContainingOrcGuid",
                table: "StTexts",
                column: "ParaContainingOrcGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StTexts_ScrBook_FootnotesGuid",
                table: "StTexts",
                column: "ScrBook_FootnotesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StTxtPara_TextObjects_ObjectId_TextObjectsGuid",
                table: "StTxtPara_TextObjects_ObjectId",
                column: "TextObjectsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Text_Genres_Possibility_LfTextGuid",
                table: "Text_Genres_Possibility",
                column: "LfTextGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Texts_ContentsGuid",
                table: "Texts",
                column: "ContentsGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Texts_MediaFilesGuid",
                table: "Texts",
                column: "MediaFilesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextTags_BeginSegmentGuid",
                table: "TextTags",
                column: "BeginSegmentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TextTags_EndSegmentGuid",
                table: "TextTags",
                column: "EndSegmentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TextTags_StText_TagsGuid",
                table: "TextTags",
                column: "StText_TagsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TextTags_TagGuid",
                table: "TextTags",
                column: "TagGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_LexExampleSentence_TranslationsGuid",
                table: "Translations",
                column: "LexExampleSentence_TranslationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_StPara_TranslationsGuid",
                table: "Translations",
                column: "StPara_TranslationsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_TypeGuid",
                table: "Translations",
                column: "TypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_UserAppFeatAct_UserConfigAcct_UserConfigAcct_UserConfigAcct~",
                table: "UserAppFeatAct_UserConfigAcct_UserConfigAcct",
                column: "UserConfigAcctGuid");

            migrationBuilder.CreateIndex(
                name: "IX_UserAppFeatActs_Project_ActivatedFeaturesGuid",
                table: "UserAppFeatActs",
                column: "Project_ActivatedFeaturesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_UserConfigAccts_Project_UserAccountsGuid",
                table: "UserConfigAccts",
                column: "Project_UserAccountsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualOrdering_Items_ObjectId_LfVirtualOrderingGuid",
                table: "VirtualOrdering_Items_ObjectId",
                column: "LfVirtualOrderingGuid");

            migrationBuilder.CreateIndex(
                name: "IX_VirtualOrderings_SourceGuid",
                table: "VirtualOrderings",
                column: "SourceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysis_CompoundRuleApps_MoCompoundRule_LfWfiAnalysisGu~",
                table: "WfiAnalysis_CompoundRuleApps_MoCompoundRule",
                column: "LfWfiAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysis_Evaluations_AgentEvaluation_LfWfiAnalysisGuid",
                table: "WfiAnalysis_Evaluations_AgentEvaluation",
                column: "LfWfiAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysis_InflTemplateApps_MoInflAffixTemplate_LfWfiAnaly~",
                table: "WfiAnalysis_InflTemplateApps_MoInflAffixTemplate",
                column: "LfWfiAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysis_Stems_LexEntry_StemsGuid",
                table: "WfiAnalysis_Stems_LexEntry",
                column: "StemsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysiss_CategoryGuid",
                table: "WfiAnalysiss",
                column: "CategoryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysiss_DerivationGuid",
                table: "WfiAnalysiss",
                column: "DerivationGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysiss_MsFeaturesGuid",
                table: "WfiAnalysiss",
                column: "MsFeaturesGuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysiss_WfiWordform_AnalysesGuid",
                table: "WfiAnalysiss",
                column: "WfiWordform_AnalysesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiGlosss_WfiAnalysis_MeaningsGuid",
                table: "WfiGlosss",
                column: "WfiAnalysis_MeaningsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiMorphBundles_InflTypeGuid",
                table: "WfiMorphBundles",
                column: "InflTypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiMorphBundles_MorphGuid",
                table: "WfiMorphBundles",
                column: "MorphGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiMorphBundles_MsaGuid",
                table: "WfiMorphBundles",
                column: "MsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiMorphBundles_SenseGuid",
                table: "WfiMorphBundles",
                column: "SenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiMorphBundles_WfiAnalysis_MorphBundlesGuid",
                table: "WfiMorphBundles",
                column: "WfiAnalysis_MorphBundlesGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiWordSet_Cases_WfiWordform_LfWfiWordSetGuid",
                table: "WfiWordSet_Cases_WfiWordform",
                column: "LfWfiWordSetGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiWordSets_MoMorphData_TestSetsGuid",
                table: "WfiWordSets",
                column: "MoMorphData_TestSetsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WordFormLookup_AnthroCodes_Possibility_LfWordFormLookup1Guid",
                table: "WordFormLookup_AnthroCodes_Possibility",
                column: "LfWordFormLookup1Guid");

            migrationBuilder.CreateIndex(
                name: "IX_WordFormLookup_ThesaurusItems_Possibility_ThesaurusItemsGuid",
                table: "WordFormLookup_ThesaurusItems_Possibility",
                column: "ThesaurusItemsGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WordFormLookups_WordformLookupList_WordformsGuid",
                table: "WordFormLookups",
                column: "WordformLookupList_WordformsGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Projects_Project_AnalyzingAgentsGuid",
                table: "Agents",
                column: "Project_AnalyzingAgentsGuid",
                principalTable: "Projects",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_StTexts_NotesGuid",
                table: "Agents",
                column: "NotesGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Analysiss_WfiAnalysiss_AnalysisGuid",
                table: "Analysiss",
                column: "AnalysisGuid",
                principalTable: "WfiAnalysiss",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_FsAbstractStructures_FeaturesGuid",
                table: "Annotations",
                column: "FeaturesGuid",
                principalTable: "FsAbstractStructures",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_ObjectIds_BeginObjectGuid",
                table: "Annotations",
                column: "BeginObjectGuid",
                principalTable: "ObjectIds",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_ObjectIds_EndObjectGuid",
                table: "Annotations",
                column: "EndObjectGuid",
                principalTable: "ObjectIds",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_ObjectIds_InstanceOfGuid",
                table: "Annotations",
                column: "InstanceOfGuid",
                principalTable: "ObjectIds",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_Possibilitys_AnnotationTypeGuid",
                table: "Annotations",
                column: "AnnotationTypeGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_Projects_Project_AnnotationsGuid",
                table: "Annotations",
                column: "Project_AnnotationsGuid",
                principalTable: "Projects",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_ScrBookAnnotationss_ScrBookAnnotations_NotesGuid",
                table: "Annotations",
                column: "ScrBookAnnotations_NotesGuid",
                principalTable: "ScrBookAnnotationss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_StTexts_DiscussionGuid",
                table: "Annotations",
                column: "DiscussionGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_StTexts_QuoteGuid",
                table: "Annotations",
                column: "QuoteGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_StTexts_RecommendationGuid",
                table: "Annotations",
                column: "RecommendationGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_StTexts_ResolutionGuid",
                table: "Annotations",
                column: "ResolutionGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Annotations_StTexts_TextGuid",
                table: "Annotations",
                column: "TextGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseAnnotation_OtherObjects_ObjectId_ObjectIds_OtherObjects~",
                table: "BaseAnnotation_OtherObjects_ObjectId",
                column: "OtherObjectsGuid",
                principalTable: "ObjectIds",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cells_Rows_Row_CellsGuid",
                table: "Cells",
                column: "Row_CellsGuid",
                principalTable: "Rows",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChkRefs_Possibilitys_Possibility_OccurrencesGuid",
                table: "ChkRefs",
                column: "Possibility_OccurrencesGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChkRenderings_Possibilitys_Possibility_RenderingsGuid",
                table: "ChkRenderings",
                column: "Possibility_RenderingsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChkRenderings_WfiGlosss_MeaningGuid",
                table: "ChkRenderings",
                column: "MeaningGuid",
                principalTable: "WfiGlosss",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_ChkSenses_LexSenses_SenseGuid",
                table: "ChkSenses",
                column: "SenseGuid",
                principalTable: "LexSenses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstChartClauseMarker_DependentClauses_ConstChartRow_Const~",
                table: "ConstChartClauseMarker_DependentClauses_ConstChartRow",
                column: "DependentClausesGuid",
                principalTable: "ConstChartRows",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConstChartClauseMarker_DependentClauses_ConstChartRow_Cons~1",
                table: "ConstChartClauseMarker_DependentClauses_ConstChartRow",
                column: "LfConstChartClauseMarkerGuid",
                principalTable: "ConstituentChartCellParts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConstChartRows_DsCharts_DsChart_RowsGuid",
                table: "ConstChartRows",
                column: "DsChart_RowsGuid",
                principalTable: "DsCharts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConstituentChartCellParts_Possibilitys_ColumnGuid",
                table: "ConstituentChartCellParts",
                column: "ColumnGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstituentChartCellParts_Possibilitys_TagGuid",
                table: "ConstituentChartCellParts",
                column: "TagGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstituentChartCellParts_Segments_BeginSegmentGuid",
                table: "ConstituentChartCellParts",
                column: "BeginSegmentGuid",
                principalTable: "Segments",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstituentChartCellParts_Segments_EndSegmentGuid",
                table: "ConstituentChartCellParts",
                column: "EndSegmentGuid",
                principalTable: "Segments",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_CrossReferences_RnResearchNbks_RnResearchNbk_CrossReference~",
                table: "CrossReferences",
                column: "RnResearchNbk_CrossReferencesGuid",
                principalTable: "RnResearchNbks",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValues_LexEntrys_LfLexEntryGuid",
                table: "CustomFieldValues",
                column: "LfLexEntryGuid",
                principalTable: "LexEntrys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValues_LexExampleSentences_LfLexExampleSentenceG~",
                table: "CustomFieldValues",
                column: "LfLexExampleSentenceGuid",
                principalTable: "LexExampleSentences",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValues_LexSenses_LfLexSenseGuid",
                table: "CustomFieldValues",
                column: "LfLexSenseGuid",
                principalTable: "LexSenses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValues_MoForms_LfMoFormGuid",
                table: "CustomFieldValues",
                column: "LfMoFormGuid",
                principalTable: "MoForms",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValues_Possibilitys_PossibilityGuid_Value",
                table: "CustomFieldValues",
                column: "PossibilityGuid_Value",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomFieldValues_StTexts_StTextGuid_Value",
                table: "CustomFieldValues",
                column: "StTextGuid_Value",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DomainQs_Possibilitys_Possibility_QuestionsGuid",
                table: "DomainQs",
                column: "Possibility_QuestionsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DsCharts_DsDiscourseDatas_DsDiscourseData_ChartsGuid",
                table: "DsCharts",
                column: "DsDiscourseData_ChartsGuid",
                principalTable: "DsDiscourseDatas",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DsCharts_Possibilitys_TemplateGuid",
                table: "DsCharts",
                column: "TemplateGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_DsCharts_StTexts_BasedOnGuid",
                table: "DsCharts",
                column: "BasedOnGuid",
                principalTable: "StTexts",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_DsDiscourseDatas_PossibilityLists_ChartMarkersGuid",
                table: "DsDiscourseDatas",
                column: "ChartMarkersGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DsDiscourseDatas_PossibilityLists_ConstChartTemplGuid",
                table: "DsDiscourseDatas",
                column: "ConstChartTemplGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Folders_Folder_FilesGuid",
                table: "Files",
                column: "Folder_FilesGuid",
                principalTable: "Folders",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_ScrImportSources_ScrImportSource_FilesGuid",
                table: "Files",
                column: "ScrImportSource_FilesGuid",
                principalTable: "ScrImportSources",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_Projects_Project_FiltersGuid",
                table: "Filters",
                column: "Project_FiltersGuid",
                principalTable: "Projects",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Projects_Project_MediaGuid",
                table: "Folders",
                column: "Project_MediaGuid",
                principalTable: "Projects",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_Projects_Project_PicturesGuid",
                table: "Folders",
                column: "Project_PicturesGuid",
                principalTable: "Projects",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FsAbstractStructures_MoInflClasss_MoInflClass_ReferenceForm~",
                table: "FsAbstractStructures",
                column: "MoInflClass_ReferenceFormsGuid",
                principalTable: "MoInflClasss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FsAbstractStructures_MoStemNames_MoStemName_RegionsGuid",
                table: "FsAbstractStructures",
                column: "MoStemName_RegionsGuid",
                principalTable: "MoStemNames",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FsAbstractStructures_Possibilitys_Possibility_EmptyParadigm~",
                table: "FsAbstractStructures",
                column: "Possibility_EmptyParadigmCellsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FsAbstractStructures_Possibilitys_Possibility_ReferenceForm~",
                table: "FsAbstractStructures",
                column: "Possibility_ReferenceFormsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FsDisjunctiveValue_Value_FsSymFeatVal_FsFeatureSpecificatio~",
                table: "FsDisjunctiveValue_Value_FsSymFeatVal",
                column: "LfFsDisjunctiveValueGuid",
                principalTable: "FsFeatureSpecifications",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FsDisjunctiveValue_Value_FsSymFeatVal_FsSymFeatVals_ValueGu~",
                table: "FsDisjunctiveValue_Value_FsSymFeatVal",
                column: "ValueGuid",
                principalTable: "FsSymFeatVals",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FsFeatDefns_FsFeatureSpecifications_DefaultGuid",
                table: "FsFeatDefns",
                column: "DefaultGuid",
                principalTable: "FsFeatureSpecifications",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LangProject_WordformLookupLists_WordformLookupList_Projects~",
                table: "LangProject_WordformLookupLists_WordformLookupList",
                column: "LfLangProjectGuid",
                principalTable: "Projects",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexAppendixs_LexDbs_LexDb_AppendixesGuid",
                table: "LexAppendixs",
                column: "LexDb_AppendixesGuid",
                principalTable: "LexDbs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexAppendixs_StTexts_ContentsGuid",
                table: "LexAppendixs",
                column: "ContentsGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDb_AllomorphIndex_MoForm_LexDbs_LfLexDbGuid",
                table: "LexDb_AllomorphIndex_MoForm",
                column: "LfLexDbGuid",
                principalTable: "LexDbs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDb_AllomorphIndex_MoForm_MoForms_AllomorphIndexGuid",
                table: "LexDb_AllomorphIndex_MoForm",
                column: "AllomorphIndexGuid",
                principalTable: "MoForms",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDb_LexicalFormIndex_LexEntry_LexDbs_LfLexDbGuid",
                table: "LexDb_LexicalFormIndex_LexEntry",
                column: "LfLexDbGuid",
                principalTable: "LexDbs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDb_LexicalFormIndex_LexEntry_LexEntrys_LexicalFormIndexG~",
                table: "LexDb_LexicalFormIndex_LexEntry",
                column: "LexicalFormIndexGuid",
                principalTable: "LexEntrys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_PossibilityLists_ComplexEntryTypesGuid",
                table: "LexDbs",
                column: "ComplexEntryTypesGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_PossibilityLists_DialectLabelsGuid",
                table: "LexDbs",
                column: "DialectLabelsGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_PossibilityLists_DomainTypesGuid",
                table: "LexDbs",
                column: "DomainTypesGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_PossibilityLists_ExtendedNoteTypesGuid",
                table: "LexDbs",
                column: "ExtendedNoteTypesGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_PossibilityLists_LanguagesGuid",
                table: "LexDbs",
                column: "LanguagesGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_PossibilityLists_MorphTypesGuid",
                table: "LexDbs",
                column: "MorphTypesGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_PossibilityLists_PublicationTypesGuid",
                table: "LexDbs",
                column: "PublicationTypesGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_PossibilityLists_ReferencesGuid",
                table: "LexDbs",
                column: "ReferencesGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_PossibilityLists_SenseTypesGuid",
                table: "LexDbs",
                column: "SenseTypesGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_PossibilityLists_UsageTypesGuid",
                table: "LexDbs",
                column: "UsageTypesGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_PossibilityLists_VariantEntryTypesGuid",
                table: "LexDbs",
                column: "VariantEntryTypesGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexDbs_StTexts_IntroductionGuid",
                table: "LexDbs",
                column: "IntroductionGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntry_DialectLabels_Possibility_LexEntrys_LfLexEntry2Guid",
                table: "LexEntry_DialectLabels_Possibility",
                column: "LfLexEntry2Guid",
                principalTable: "LexEntrys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntry_DialectLabels_Possibility_Possibilitys_DialectLabe~",
                table: "LexEntry_DialectLabels_Possibility",
                column: "DialectLabelsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntry_DoNotPublishIn_Possibility_LexEntrys_LfLexEntry1Gu~",
                table: "LexEntry_DoNotPublishIn_Possibility",
                column: "LfLexEntry1Guid",
                principalTable: "LexEntrys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntry_DoNotPublishIn_Possibility_Possibilitys_DoNotPubli~",
                table: "LexEntry_DoNotPublishIn_Possibility",
                column: "DoNotPublishInGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntry_DoNotShowMainEntryIn_Possibility_LexEntrys_LfLexEn~",
                table: "LexEntry_DoNotShowMainEntryIn_Possibility",
                column: "LfLexEntryGuid",
                principalTable: "LexEntrys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntry_DoNotShowMainEntryIn_Possibility_Possibilitys_DoNo~",
                table: "LexEntry_DoNotShowMainEntryIn_Possibility",
                column: "DoNotShowMainEntryInGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntry_MainEntriesOrSenses_ObjectId_LexEntrys_LfLexEntryG~",
                table: "LexEntry_MainEntriesOrSenses_ObjectId",
                column: "LfLexEntryGuid",
                principalTable: "LexEntrys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntry_MainEntriesOrSenses_ObjectId_ObjectIds_MainEntries~",
                table: "LexEntry_MainEntriesOrSenses_ObjectId",
                column: "MainEntriesOrSensesGuid",
                principalTable: "ObjectIds",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryInflType_Slots_MoInflAffixSlot_MoInflAffixSlots_Slo~",
                table: "LexEntryInflType_Slots_MoInflAffixSlot",
                column: "SlotsGuid",
                principalTable: "MoInflAffixSlots",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryInflType_Slots_MoInflAffixSlot_Possibilitys_LfLexEn~",
                table: "LexEntryInflType_Slots_MoInflAffixSlot",
                column: "LfLexEntryInflTypeGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryRef_ComplexEntryTypes_Possibility_LexEntryRefs_LfLe~",
                table: "LexEntryRef_ComplexEntryTypes_Possibility",
                column: "LfLexEntryRef1Guid",
                principalTable: "LexEntryRefs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryRef_ComplexEntryTypes_Possibility_Possibilitys_Comp~",
                table: "LexEntryRef_ComplexEntryTypes_Possibility",
                column: "ComplexEntryTypesGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryRef_ComponentLexemes_ObjectId_LexEntryRefs_LfLexEnt~",
                table: "LexEntryRef_ComponentLexemes_ObjectId",
                column: "LfLexEntryRef1Guid",
                principalTable: "LexEntryRefs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryRef_ComponentLexemes_ObjectId_ObjectIds_ComponentLe~",
                table: "LexEntryRef_ComponentLexemes_ObjectId",
                column: "ComponentLexemesGuid",
                principalTable: "ObjectIds",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryRef_PrimaryLexemes_ObjectId_LexEntryRefs_LfLexEntry~",
                table: "LexEntryRef_PrimaryLexemes_ObjectId",
                column: "LfLexEntryRefGuid",
                principalTable: "LexEntryRefs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryRef_PrimaryLexemes_ObjectId_ObjectIds_PrimaryLexeme~",
                table: "LexEntryRef_PrimaryLexemes_ObjectId",
                column: "PrimaryLexemesGuid",
                principalTable: "ObjectIds",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryRef_ShowComplexFormsIn_ObjectId_LexEntryRefs_LfLexE~",
                table: "LexEntryRef_ShowComplexFormsIn_ObjectId",
                column: "LfLexEntryRef2Guid",
                principalTable: "LexEntryRefs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryRef_ShowComplexFormsIn_ObjectId_ObjectIds_ShowCompl~",
                table: "LexEntryRef_ShowComplexFormsIn_ObjectId",
                column: "ShowComplexFormsInGuid",
                principalTable: "ObjectIds",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryRef_VariantEntryTypes_Possibility_LexEntryRefs_LfLe~",
                table: "LexEntryRef_VariantEntryTypes_Possibility",
                column: "LfLexEntryRefGuid",
                principalTable: "LexEntryRefs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryRef_VariantEntryTypes_Possibility_Possibilitys_Vari~",
                table: "LexEntryRef_VariantEntryTypes_Possibility",
                column: "VariantEntryTypesGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntryRefs_LexEntrys_LexEntry_EntryRefsGuid",
                table: "LexEntryRefs",
                column: "LexEntry_EntryRefsGuid",
                principalTable: "LexEntrys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEntrys_MoForms_LexemeFormGuid",
                table: "LexEntrys",
                column: "LexemeFormGuid",
                principalTable: "MoForms",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexEtymology_Language_Possibility_Possibilitys_LanguageGuid",
                table: "LexEtymology_Language_Possibility",
                column: "LanguageGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexExampleSentence_DoNotPublishIn_Possibility_LexExampleSen~",
                table: "LexExampleSentence_DoNotPublishIn_Possibility",
                column: "LfLexExampleSentenceGuid",
                principalTable: "LexExampleSentences",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexExampleSentence_DoNotPublishIn_Possibility_Possibilitys_~",
                table: "LexExampleSentence_DoNotPublishIn_Possibility",
                column: "DoNotPublishInGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexExampleSentences_LexExtendedNotes_LexExtendedNote_Exampl~",
                table: "LexExampleSentences",
                column: "LexExtendedNote_ExamplesGuid",
                principalTable: "LexExtendedNotes",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexExampleSentences_LexSenses_LexSense_ExamplesGuid",
                table: "LexExampleSentences",
                column: "LexSense_ExamplesGuid",
                principalTable: "LexSenses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexExtendedNotes_LexSenses_LexSense_ExtendedNoteGuid",
                table: "LexExtendedNotes",
                column: "LexSense_ExtendedNoteGuid",
                principalTable: "LexSenses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexExtendedNotes_Possibilitys_ExtendedNoteTypeGuid",
                table: "LexExtendedNotes",
                column: "ExtendedNoteTypeGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_LexPronunciation_DoNotPublishIn_Possibility_LexPronunciatio~",
                table: "LexPronunciation_DoNotPublishIn_Possibility",
                column: "LfLexPronunciationGuid",
                principalTable: "LexPronunciations",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexPronunciation_DoNotPublishIn_Possibility_Possibilitys_Do~",
                table: "LexPronunciation_DoNotPublishIn_Possibility",
                column: "DoNotPublishInGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexPronunciations_Possibilitys_LocationGuid",
                table: "LexPronunciations",
                column: "LocationGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_LexReference_Targets_ObjectId_LexReferences_LfLexReferenceG~",
                table: "LexReference_Targets_ObjectId",
                column: "LfLexReferenceGuid",
                principalTable: "LexReferences",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexReference_Targets_ObjectId_ObjectIds_TargetsGuid",
                table: "LexReference_Targets_ObjectId",
                column: "TargetsGuid",
                principalTable: "ObjectIds",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexReferences_Possibilitys_Possibility_MembersGuid",
                table: "LexReferences",
                column: "Possibility_MembersGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_AnthroCodes_Possibility_LexSenses_LfLexSenseGuid",
                table: "LexSense_AnthroCodes_Possibility",
                column: "LfLexSenseGuid",
                principalTable: "LexSenses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_AnthroCodes_Possibility_Possibilitys_AnthroCodesGu~",
                table: "LexSense_AnthroCodes_Possibility",
                column: "AnthroCodesGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_Appendixes_LexAppendix_LexSenses_LfLexSenseGuid",
                table: "LexSense_Appendixes_LexAppendix",
                column: "LfLexSenseGuid",
                principalTable: "LexSenses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_DialectLabels_Possibility_LexSenses_LfLexSense5Guid",
                table: "LexSense_DialectLabels_Possibility",
                column: "LfLexSense5Guid",
                principalTable: "LexSenses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_DialectLabels_Possibility_Possibilitys_DialectLabe~",
                table: "LexSense_DialectLabels_Possibility",
                column: "DialectLabelsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_DomainTypes_Possibility_LexSenses_LfLexSense1Guid",
                table: "LexSense_DomainTypes_Possibility",
                column: "LfLexSense1Guid",
                principalTable: "LexSenses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_DomainTypes_Possibility_Possibilitys_DomainTypesGu~",
                table: "LexSense_DomainTypes_Possibility",
                column: "DomainTypesGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_DoNotPublishIn_Possibility_LexSenses_LfLexSense4Gu~",
                table: "LexSense_DoNotPublishIn_Possibility",
                column: "LfLexSense4Guid",
                principalTable: "LexSenses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_DoNotPublishIn_Possibility_Possibilitys_DoNotPubli~",
                table: "LexSense_DoNotPublishIn_Possibility",
                column: "DoNotPublishInGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_SemanticDomains_Possibility_LexSenses_LfLexSenseGu~",
                table: "LexSense_SemanticDomains_Possibility",
                column: "LfLexSenseGuid",
                principalTable: "LexSenses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_SemanticDomains_Possibility_Possibilitys_SemanticD~",
                table: "LexSense_SemanticDomains_Possibility",
                column: "SemanticDomainsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_ThesaurusItems_Possibility_LexSenses_LfLexSense2Gu~",
                table: "LexSense_ThesaurusItems_Possibility",
                column: "LfLexSense2Guid",
                principalTable: "LexSenses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_ThesaurusItems_Possibility_Possibilitys_ThesaurusI~",
                table: "LexSense_ThesaurusItems_Possibility",
                column: "ThesaurusItemsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_UsageTypes_Possibility_LexSenses_LfLexSense3Guid",
                table: "LexSense_UsageTypes_Possibility",
                column: "LfLexSense3Guid",
                principalTable: "LexSenses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSense_UsageTypes_Possibility_Possibilitys_UsageTypesGuid",
                table: "LexSense_UsageTypes_Possibility",
                column: "UsageTypesGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LexSenses_MoMorphSynAnalysiss_MorphoSyntaxAnalysisGuid",
                table: "LexSenses",
                column: "MorphoSyntaxAnalysisGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_LexSenses_Possibilitys_SenseTypeGuid",
                table: "LexSenses",
                column: "SenseTypeGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_LexSenses_Possibilitys_StatusGuid",
                table: "LexSenses",
                column: "StatusGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoAdhocProhibs_MoForms_FirstAllomorphGuid",
                table: "MoAdhocProhibs",
                column: "FirstAllomorphGuid",
                principalTable: "MoForms",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoAdhocProhibs_MoMorphDatas_MoMorphData_AdhocCoProhibitions~",
                table: "MoAdhocProhibs",
                column: "MoMorphData_AdhocCoProhibitionsGuid",
                principalTable: "MoMorphDatas",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoAdhocProhibs_MoMorphSynAnalysiss_FirstMorphemeGuid",
                table: "MoAdhocProhibs",
                column: "FirstMorphemeGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoAffixAllomorph_PhoneEnv_PhEnvironment_MoForms_LfMoAffixAl~",
                table: "MoAffixAllomorph_PhoneEnv_PhEnvironment",
                column: "LfMoAffixAllomorphGuid",
                principalTable: "MoForms",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoAffixAllomorph_PhoneEnv_PhEnvironment_PhEnvironments_Phon~",
                table: "MoAffixAllomorph_PhoneEnv_PhEnvironment",
                column: "PhoneEnvGuid",
                principalTable: "PhEnvironments",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoAffixAllomorph_Position_PhEnvironment_MoForms_LfMoAffixAl~",
                table: "MoAffixAllomorph_Position_PhEnvironment",
                column: "LfMoAffixAllomorph1Guid",
                principalTable: "MoForms",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoAffixAllomorph_Position_PhEnvironment_PhEnvironments_Posi~",
                table: "MoAffixAllomorph_Position_PhEnvironment",
                column: "PositionGuid",
                principalTable: "PhEnvironments",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoAffixForm_InflectionClasses_MoInflClass_MoForms_LfMoAffix~",
                table: "MoAffixForm_InflectionClasses_MoInflClass",
                column: "LfMoAffixFormGuid",
                principalTable: "MoForms",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoAffixForm_InflectionClasses_MoInflClass_MoInflClasss_Infl~",
                table: "MoAffixForm_InflectionClasses_MoInflClass",
                column: "InflectionClassesGuid",
                principalTable: "MoInflClasss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoAlloAdhocProhib_Allomorphs_MoForm_MoForms_AllomorphsGuid",
                table: "MoAlloAdhocProhib_Allomorphs_MoForm",
                column: "AllomorphsGuid",
                principalTable: "MoForms",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoAlloAdhocProhib_RestOfAllos_MoForm_MoForms_RestOfAllosGuid",
                table: "MoAlloAdhocProhib_RestOfAllos_MoForm",
                column: "RestOfAllosGuid",
                principalTable: "MoForms",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRule_ToProdRestrict_Possibility_MoCompoundRules_L~",
                table: "MoCompoundRule_ToProdRestrict_Possibility",
                column: "LfMoCompoundRuleGuid",
                principalTable: "MoCompoundRules",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRule_ToProdRestrict_Possibility_Possibilitys_ToPr~",
                table: "MoCompoundRule_ToProdRestrict_Possibility",
                column: "ToProdRestrictGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRules_MoForms_LinkerGuid",
                table: "MoCompoundRules",
                column: "LinkerGuid",
                principalTable: "MoForms",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRules_MoMorphDatas_MoMorphData_CompoundRulesGuid",
                table: "MoCompoundRules",
                column: "MoMorphData_CompoundRulesGuid",
                principalTable: "MoMorphDatas",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRules_MoMorphSynAnalysiss_LeftMsaGuid",
                table: "MoCompoundRules",
                column: "LeftMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRules_MoMorphSynAnalysiss_OverridingMsaGuid",
                table: "MoCompoundRules",
                column: "OverridingMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRules_MoMorphSynAnalysiss_RightMsaGuid",
                table: "MoCompoundRules",
                column: "RightMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRules_MoMorphSynAnalysiss_ToMsaGuid",
                table: "MoCompoundRules",
                column: "ToMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRules_MoStratums_StratumGuid",
                table: "MoCompoundRules",
                column: "StratumGuid",
                principalTable: "MoStratums",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivAffMsa_FromProdRestrict_Possibility_MoMorphSynAnalys~",
                table: "MoDerivAffMsa_FromProdRestrict_Possibility",
                column: "LfMoDerivAffMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivAffMsa_FromProdRestrict_Possibility_Possibilitys_Fro~",
                table: "MoDerivAffMsa_FromProdRestrict_Possibility",
                column: "FromProdRestrictGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivAffMsa_ToProdRestrict_Possibility_MoMorphSynAnalysis~",
                table: "MoDerivAffMsa_ToProdRestrict_Possibility",
                column: "LfMoDerivAffMsa1Guid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivAffMsa_ToProdRestrict_Possibility_Possibilitys_ToPro~",
                table: "MoDerivAffMsa_ToProdRestrict_Possibility",
                column: "ToProdRestrictGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivs_MoForms_StemFormGuid",
                table: "MoDerivs",
                column: "StemFormGuid",
                principalTable: "MoForms",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivs_MoMorphSynAnalysiss_StemMsaGuid",
                table: "MoDerivs",
                column: "StemMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivStepMsa_ProdRestrict_Possibility_MoMorphSynAnalysiss~",
                table: "MoDerivStepMsa_ProdRestrict_Possibility",
                column: "LfMoDerivStepMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivStepMsa_ProdRestrict_Possibility_Possibilitys_ProdRe~",
                table: "MoDerivStepMsa_ProdRestrict_Possibility",
                column: "ProdRestrictGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_MoForms_AffixFormGuid",
                table: "MoDerivTraces",
                column: "AffixFormGuid",
                principalTable: "MoForms",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_MoForms_LeftFormGuid",
                table: "MoDerivTraces",
                column: "LeftFormGuid",
                principalTable: "MoForms",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_MoForms_LfMoInflAffixSlotApp_AffixFormGuid",
                table: "MoDerivTraces",
                column: "LfMoInflAffixSlotApp_AffixFormGuid",
                principalTable: "MoForms",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_MoForms_LinkerGuid",
                table: "MoDerivTraces",
                column: "LinkerGuid",
                principalTable: "MoForms",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_MoForms_RightFormGuid",
                table: "MoDerivTraces",
                column: "RightFormGuid",
                principalTable: "MoForms",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_MoInflAffixSlots_SlotGuid",
                table: "MoDerivTraces",
                column: "SlotGuid",
                principalTable: "MoInflAffixSlots",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_MoInflAffixTemplates_TemplateGuid",
                table: "MoDerivTraces",
                column: "TemplateGuid",
                principalTable: "MoInflAffixTemplates",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_MoMorphSynAnalysiss_AffixMsaGuid",
                table: "MoDerivTraces",
                column: "AffixMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_MoMorphSynAnalysiss_LfMoInflAffixSlotApp_Affi~",
                table: "MoDerivTraces",
                column: "LfMoInflAffixSlotApp_AffixMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_MoMorphSynAnalysiss_OutputMsaGuid",
                table: "MoDerivTraces",
                column: "OutputMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_MoStratums_StratumGuid",
                table: "MoDerivTraces",
                column: "StratumGuid",
                principalTable: "MoStratums",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivTraces_ObjectIds_RuleGuid",
                table: "MoDerivTraces",
                column: "RuleGuid",
                principalTable: "ObjectIds",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoForms_MoStemNames_StemNameGuid",
                table: "MoForms",
                column: "StemNameGuid",
                principalTable: "MoStemNames",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoForms_Possibilitys_MorphTypeGuid",
                table: "MoForms",
                column: "MorphTypeGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoForms_Possibilitys_MsEnvPartOfSpeechGuid",
                table: "MoForms",
                column: "MsEnvPartOfSpeechGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlots_Possibilitys_Possibility_AffixSlotsGuid",
                table: "MoInflAffixSlots",
                column: "Possibility_AffixSlotsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixTemplate_EncliticSlots_MoInflAffixSlot_MoInflAf~1",
                table: "MoInflAffixTemplate_EncliticSlots_MoInflAffixSlot",
                column: "LfMoInflAffixTemplate4Guid",
                principalTable: "MoInflAffixTemplates",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixTemplate_PrefixSlots_MoInflAffixSlot_MoInflAffix~",
                table: "MoInflAffixTemplate_PrefixSlots_MoInflAffixSlot",
                column: "LfMoInflAffixTemplate1Guid",
                principalTable: "MoInflAffixTemplates",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixTemplate_ProcliticSlots_MoInflAffixSlot_MoInflAf~",
                table: "MoInflAffixTemplate_ProcliticSlots_MoInflAffixSlot",
                column: "LfMoInflAffixTemplate3Guid",
                principalTable: "MoInflAffixTemplates",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixTemplate_Slots_MoInflAffixSlot_MoInflAffixTempla~",
                table: "MoInflAffixTemplate_Slots_MoInflAffixSlot",
                column: "LfMoInflAffixTemplateGuid",
                principalTable: "MoInflAffixTemplates",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixTemplate_SuffixSlots_MoInflAffixSlot_MoInflAffix~",
                table: "MoInflAffixTemplate_SuffixSlots_MoInflAffixSlot",
                column: "LfMoInflAffixTemplate2Guid",
                principalTable: "MoInflAffixTemplates",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixTemplates_MoStratums_StratumGuid",
                table: "MoInflAffixTemplates",
                column: "StratumGuid",
                principalTable: "MoStratums",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixTemplates_Possibilitys_Possibility_AffixTemplate~",
                table: "MoInflAffixTemplates",
                column: "Possibility_AffixTemplatesGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffMsa_FromProdRestrict_Possibility_MoMorphSynAnalysi~",
                table: "MoInflAffMsa_FromProdRestrict_Possibility",
                column: "LfMoInflAffMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffMsa_FromProdRestrict_Possibility_Possibilitys_From~",
                table: "MoInflAffMsa_FromProdRestrict_Possibility",
                column: "FromProdRestrictGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffMsa_Slots_MoInflAffixSlot_MoMorphSynAnalysiss_LfMo~",
                table: "MoInflAffMsa_Slots_MoInflAffixSlot",
                column: "LfMoInflAffMsaGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflClasss_Possibilitys_Possibility_InflectionClassesGuid",
                table: "MoInflClasss",
                column: "Possibility_InflectionClassesGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInsertPhones_Content_PhTerminalUnit_MoRuleMappings_LfMoIn~",
                table: "MoInsertPhones_Content_PhTerminalUnit",
                column: "LfMoInsertPhonesGuid",
                principalTable: "MoRuleMappings",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoInsertPhones_Content_PhTerminalUnit_PhTerminalUnits_Conte~",
                table: "MoInsertPhones_Content_PhTerminalUnit",
                column: "ContentGuid",
                principalTable: "PhTerminalUnits",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphAdhocProhib_Morphemes_MoMorphSynAnalysis_MoMorphSynA~",
                table: "MoMorphAdhocProhib_Morphemes_MoMorphSynAnalysis",
                column: "MorphemesGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphAdhocProhib_RestOfMorphs_MoMorphSynAnalysis_MoMorphS~",
                table: "MoMorphAdhocProhib_RestOfMorphs_MoMorphSynAnalysis",
                column: "RestOfMorphsGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphData_AnalyzingAgents_Agent_MoMorphDatas_LfMoMorphDat~",
                table: "MoMorphData_AnalyzingAgents_Agent",
                column: "LfMoMorphDataGuid",
                principalTable: "MoMorphDatas",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphDatas_PossibilityLists_ProdRestrictGuid",
                table: "MoMorphDatas",
                column: "ProdRestrictGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysis_Components_MoMorphSynAnalysis_MoMorphSyn~",
                table: "MoMorphSynAnalysis_Components_MoMorphSynAnalysis",
                column: "ComponentsGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysis_Components_MoMorphSynAnalysis_MoMorphSy~1",
                table: "MoMorphSynAnalysis_Components_MoMorphSynAnalysis",
                column: "LfMoMorphSynAnalysisGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysis_GlossBundle_MoGlossItem_MoMorphSynAnalys~",
                table: "MoMorphSynAnalysis_GlossBundle_MoGlossItem",
                column: "LfMoMorphSynAnalysisGuid",
                principalTable: "MoMorphSynAnalysiss",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysiss_MoStemNames_FromStemNameGuid",
                table: "MoMorphSynAnalysiss",
                column: "FromStemNameGuid",
                principalTable: "MoStemNames",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysiss_MoStratums_LfMoStemMsa_StratumGuid",
                table: "MoMorphSynAnalysiss",
                column: "LfMoStemMsa_StratumGuid",
                principalTable: "MoStratums",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysiss_MoStratums_StratumGuid",
                table: "MoMorphSynAnalysiss",
                column: "StratumGuid",
                principalTable: "MoStratums",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_AffixCategoryGuid",
                table: "MoMorphSynAnalysiss",
                column: "AffixCategoryGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_FromPartOfSpeechGuid",
                table: "MoMorphSynAnalysiss",
                column: "FromPartOfSpeechGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_LfMoDerivAffMsa_AffixCateg~",
                table: "MoMorphSynAnalysiss",
                column: "LfMoDerivAffMsa_AffixCategoryGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_LfMoDerivStepMsa_PartOfSpe~",
                table: "MoMorphSynAnalysiss",
                column: "LfMoDerivStepMsa_PartOfSpeechGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_LfMoStemMsa_PartOfSpeechGu~",
                table: "MoMorphSynAnalysiss",
                column: "LfMoStemMsa_PartOfSpeechGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_LfMoUnclassifiedAffixMsa_P~",
                table: "MoMorphSynAnalysiss",
                column: "LfMoUnclassifiedAffixMsa_PartOfSpeechGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_PartOfSpeechGuid",
                table: "MoMorphSynAnalysiss",
                column: "PartOfSpeechGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_ToPartOfSpeechGuid",
                table: "MoMorphSynAnalysiss",
                column: "ToPartOfSpeechGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoReferralRules_Possibilitys_Possibility_RulesOfReferralGuid",
                table: "MoReferralRules",
                column: "Possibility_RulesOfReferralGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoRuleMappings_PhContextOrVars_ContentGuid",
                table: "MoRuleMappings",
                column: "ContentGuid",
                principalTable: "PhContextOrVars",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoRuleMappings_PhContextOrVars_LfMoCopyFromInput_ContentGuid",
                table: "MoRuleMappings",
                column: "LfMoCopyFromInput_ContentGuid",
                principalTable: "PhContextOrVars",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoRuleMappings_PhNaturalClasss_LfMoInsertNC_ContentGuid",
                table: "MoRuleMappings",
                column: "LfMoInsertNC_ContentGuid",
                principalTable: "PhNaturalClasss",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoRuleMappings_PhNaturalClasss_ModificationGuid",
                table: "MoRuleMappings",
                column: "ModificationGuid",
                principalTable: "PhNaturalClasss",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoStemAllomorph_PhoneEnv_PhEnvironment_PhEnvironments_Phone~",
                table: "MoStemAllomorph_PhoneEnv_PhEnvironment",
                column: "PhoneEnvGuid",
                principalTable: "PhEnvironments",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoStemMsa_FromPartsOfSpeech_Possibility_Possibilitys_FromPa~",
                table: "MoStemMsa_FromPartsOfSpeech_Possibility",
                column: "FromPartsOfSpeechGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoStemMsa_ProdRestrict_Possibility_Possibilitys_ProdRestric~",
                table: "MoStemMsa_ProdRestrict_Possibility",
                column: "ProdRestrictGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoStemNames_Possibilitys_Possibility_StemNamesGuid",
                table: "MoStemNames",
                column: "Possibility_StemNamesGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoStratums_PhPhonemeSets_PhonemesGuid",
                table: "MoStratums",
                column: "PhonemesGuid",
                principalTable: "PhPhonemeSets",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Segments_Segment_NotesGuid",
                table: "Notes",
                column: "Segment_NotesGuid",
                principalTable: "Segments",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectIds_StParas_StPara_AnalyzedTextObjectsGuid",
                table: "ObjectIds",
                column: "StPara_AnalyzedTextObjectsGuid",
                principalTable: "StParas",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Overlay_PossItems_Possibility_Overlays_LfOverlayGuid",
                table: "Overlay_PossItems_Possibility",
                column: "LfOverlayGuid",
                principalTable: "Overlays",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Overlay_PossItems_Possibility_Possibilitys_PossItemsGuid",
                table: "Overlay_PossItems_Possibility",
                column: "PossItemsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Overlays_PossibilityLists_PossListGuid",
                table: "Overlays",
                column: "PossListGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Overlays_Projects_Project_OverlaysGuid",
                table: "Overlays",
                column: "Project_OverlaysGuid",
                principalTable: "Projects",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOfSpeech_BearableFeatures_FsFeatDefn_Possibilitys_LfPar~",
                table: "PartOfSpeech_BearableFeatures_FsFeatDefn",
                column: "LfPartOfSpeechGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartOfSpeech_InflectableFeats_FsFeatDefn_Possibilitys_LfPar~",
                table: "PartOfSpeech_InflectableFeats_FsFeatDefn",
                column: "LfPartOfSpeech1Guid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PlacesOfResidence_Possibility_Possibilitys_LfPersonG~",
                table: "Person_PlacesOfResidence_Possibility",
                column: "LfPersonGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PlacesOfResidence_Possibility_Possibilitys_PlacesOfR~",
                table: "Person_PlacesOfResidence_Possibility",
                column: "PlacesOfResidenceGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Positions_Possibility_Possibilitys_LfPerson1Guid",
                table: "Person_Positions_Possibility",
                column: "LfPerson1Guid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Positions_Possibility_Possibilitys_PositionsGuid",
                table: "Person_Positions_Possibility",
                column: "PositionsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhCodes_PhTerminalUnits_PhTerminalUnit_CodesGuid",
                table: "PhCodes",
                column: "PhTerminalUnit_CodesGuid",
                principalTable: "PhTerminalUnits",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhContextOrVars_PhNaturalClasss_LfPhSimpleContextNC_Feature~",
                table: "PhContextOrVars",
                column: "LfPhSimpleContextNC_FeatureStructureGuid",
                principalTable: "PhNaturalClasss",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_PhContextOrVars_PhPhonDatas_PhPhonData_ContextsGuid",
                table: "PhContextOrVars",
                column: "PhPhonData_ContextsGuid",
                principalTable: "PhPhonDatas",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhContextOrVars_PhSegRuleRHSs_PhSegRuleRHS_StrucChangeGuid",
                table: "PhContextOrVars",
                column: "PhSegRuleRHS_StrucChangeGuid",
                principalTable: "PhSegRuleRHSs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhContextOrVars_PhSegmentRules_PhSegmentRule_StrucDescGuid",
                table: "PhContextOrVars",
                column: "PhSegmentRule_StrucDescGuid",
                principalTable: "PhSegmentRules",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhContextOrVars_PhTerminalUnits_FeatureStructureGuid",
                table: "PhContextOrVars",
                column: "FeatureStructureGuid",
                principalTable: "PhTerminalUnits",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_PhContextOrVars_PhTerminalUnits_LfPhSimpleContextSeg_Featur~",
                table: "PhContextOrVars",
                column: "LfPhSimpleContextSeg_FeatureStructureGuid",
                principalTable: "PhTerminalUnits",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_PhContextOrVars_StTexts_DescriptionGuid",
                table: "PhContextOrVars",
                column: "DescriptionGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhEnvironments_PhPhonDatas_PhPhonData_EnvironmentsGuid",
                table: "PhEnvironments",
                column: "PhPhonData_EnvironmentsGuid",
                principalTable: "PhPhonDatas",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhFeatureConstraints_PhPhonDatas_PhPhonData_FeatConstraints~",
                table: "PhFeatureConstraints",
                column: "PhPhonData_FeatConstraintsGuid",
                principalTable: "PhPhonDatas",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhNaturalClasss_PhPhonDatas_PhPhonData_NaturalClassesGuid",
                table: "PhNaturalClasss",
                column: "PhPhonData_NaturalClassesGuid",
                principalTable: "PhPhonDatas",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhNCSegments_Segments_PhTerminalUnit_PhTerminalUnits_Segmen~",
                table: "PhNCSegments_Segments_PhTerminalUnit",
                column: "SegmentsGuid",
                principalTable: "PhTerminalUnits",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhPhonDatas_PossibilityLists_PhonRuleFeatsGuid",
                table: "PhPhonDatas",
                column: "PhonRuleFeatsGuid",
                principalTable: "PossibilityLists",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhSegRuleRHS_ExclRuleFeats_Possibility_Possibilitys_ExclRul~",
                table: "PhSegRuleRHS_ExclRuleFeats_Possibility",
                column: "ExclRuleFeatsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhSegRuleRHS_InputPOSes_Possibility_Possibilitys_InputPOSes~",
                table: "PhSegRuleRHS_InputPOSes_Possibility",
                column: "InputPOSesGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhSegRuleRHS_ReqRuleFeats_Possibility_Possibilitys_ReqRuleF~",
                table: "PhSegRuleRHS_ReqRuleFeats_Possibility",
                column: "ReqRuleFeatsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_DoNotPublishIn_Possibility_Possibilitys_DoNotPublis~",
                table: "Picture_DoNotPublishIn_Possibility",
                column: "DoNotPublishInGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_Researchers_Possibility_Possibilitys_LfPossibil~",
                table: "Possibility_Researchers_Possibility",
                column: "LfPossibility1Guid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_Researchers_Possibility_Possibilitys_Researcher~",
                table: "Possibility_Researchers_Possibility",
                column: "ResearchersGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_Restrictions_Possibility_Possibilitys_LfPossibi~",
                table: "Possibility_Restrictions_Possibility",
                column: "LfPossibilityGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_Restrictions_Possibility_Possibilitys_Restricti~",
                table: "Possibility_Restrictions_Possibility",
                column: "RestrictionsGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PossibilityListCustomFieldValue_Value_Possibility_Possibili~",
                table: "PossibilityListCustomFieldValue_Value_Possibility",
                column: "ValueGuid",
                principalTable: "Possibilitys",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PossibilityLists_Projects_Project_CheckListsGuid",
                table: "PossibilityLists",
                column: "Project_CheckListsGuid",
                principalTable: "Projects",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Possibilitys_StTexts_DiscussionGuid",
                table: "Possibilitys",
                column: "DiscussionGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PubDivisions_PubHFSets_HFSetGuid",
                table: "PubDivisions",
                column: "HFSetGuid",
                principalTable: "PubHFSets",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PubDivisions_Publications_Publication_DivisionsGuid",
                table: "PubDivisions",
                column: "Publication_DivisionsGuid",
                principalTable: "Publications",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PubHFSets_Texts_Text_HeaderFooterSetsGuid",
                table: "PubHFSets",
                column: "Text_HeaderFooterSetsGuid",
                principalTable: "Texts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Texts_Text_PublicationsGuid",
                table: "Publications",
                column: "Text_PublicationsGuid",
                principalTable: "Texts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_AnthroCodes_Possibility_RnGenericRecs_LfRnGene~",
                table: "RnGenericRec_AnthroCodes_Possibility",
                column: "LfRnGenericRecGuid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_CounterEvidence_RnGenericRec_RnGenericRecs_Cou~",
                table: "RnGenericRec_CounterEvidence_RnGenericRec",
                column: "CounterEvidenceGuid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_CounterEvidence_RnGenericRec_RnGenericRecs_LfR~",
                table: "RnGenericRec_CounterEvidence_RnGenericRec",
                column: "LfRnGenericRec1Guid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_CrossReferences_CrossReference_RnGenericRecs_L~",
                table: "RnGenericRec_CrossReferences_CrossReference",
                column: "LfRnGenericRecGuid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_Locations_Possibility_RnGenericRecs_LfRnGeneri~",
                table: "RnGenericRec_Locations_Possibility",
                column: "LfRnGenericRecGuid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_PhraseTags_Possibility_RnGenericRecs_LfRnGener~",
                table: "RnGenericRec_PhraseTags_Possibility",
                column: "LfRnGenericRec2Guid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_Reminders_Reminder_RnGenericRecs_LfRnGenericRe~",
                table: "RnGenericRec_Reminders_Reminder",
                column: "LfRnGenericRecGuid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_Researchers_Possibility_RnGenericRecs_LfRnGene~",
                table: "RnGenericRec_Researchers_Possibility",
                column: "LfRnGenericRecGuid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_Restrictions_Possibility_RnGenericRecs_LfRnGen~",
                table: "RnGenericRec_Restrictions_Possibility",
                column: "LfRnGenericRec1Guid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_SeeAlso_RnGenericRec_RnGenericRecs_LfRnGeneric~",
                table: "RnGenericRec_SeeAlso_RnGenericRec",
                column: "LfRnGenericRecGuid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_SeeAlso_RnGenericRec_RnGenericRecs_SeeAlsoGuid",
                table: "RnGenericRec_SeeAlso_RnGenericRec",
                column: "SeeAlsoGuid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_Sources_Possibility_RnGenericRecs_LfRnGenericR~",
                table: "RnGenericRec_Sources_Possibility",
                column: "LfRnGenericRec3Guid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_SupersededBy_RnGenericRec_RnGenericRecs_LfRnGe~",
                table: "RnGenericRec_SupersededBy_RnGenericRec",
                column: "LfRnGenericRec2Guid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_SupersededBy_RnGenericRec_RnGenericRecs_Supers~",
                table: "RnGenericRec_SupersededBy_RnGenericRec",
                column: "SupersededByGuid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_SupportingEvidence_RnGenericRec_RnGenericRecs_~",
                table: "RnGenericRec_SupportingEvidence_RnGenericRec",
                column: "LfRnGenericRec3Guid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_SupportingEvidence_RnGenericRec_RnGenericRecs~1",
                table: "RnGenericRec_SupportingEvidence_RnGenericRec",
                column: "SupportingEvidenceGuid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRec_TimeOfEvent_Possibility_RnGenericRecs_LfRnGene~",
                table: "RnGenericRec_TimeOfEvent_Possibility",
                column: "LfRnGenericRec4Guid",
                principalTable: "RnGenericRecs",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRecs_StTexts_ConclusionsGuid",
                table: "RnGenericRecs",
                column: "ConclusionsGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRecs_StTexts_DescriptionGuid",
                table: "RnGenericRecs",
                column: "DescriptionGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRecs_StTexts_DiscussionGuid",
                table: "RnGenericRecs",
                column: "DiscussionGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRecs_StTexts_ExternalMaterialsGuid",
                table: "RnGenericRecs",
                column: "ExternalMaterialsGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRecs_StTexts_FurtherQuestionsGuid",
                table: "RnGenericRecs",
                column: "FurtherQuestionsGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRecs_StTexts_HypothesisGuid",
                table: "RnGenericRecs",
                column: "HypothesisGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRecs_StTexts_PersonalNotesGuid",
                table: "RnGenericRecs",
                column: "PersonalNotesGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRecs_StTexts_ResearchPlanGuid",
                table: "RnGenericRecs",
                column: "ResearchPlanGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRecs_StTexts_VersionHistoryGuid",
                table: "RnGenericRecs",
                column: "VersionHistoryGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RnGenericRecs_Texts_TextGuid",
                table: "RnGenericRecs",
                column: "TextGuid",
                principalTable: "Texts",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_ScrBooks_StTexts_TitleGuid",
                table: "ScrBooks",
                column: "TitleGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScrDifferences_StParas_RevParagraphGuid",
                table: "ScrDifferences",
                column: "RevParagraphGuid",
                principalTable: "StParas",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_ScrSections_StTexts_ContentGuid",
                table: "ScrSections",
                column: "ContentGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScrSections_StTexts_HeadingGuid",
                table: "ScrSections",
                column: "HeadingGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segment_Analyses_Analysis_Segments_LfSegmentGuid",
                table: "Segment_Analyses_Analysis",
                column: "LfSegmentGuid",
                principalTable: "Segments",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Segments_StParas_StPara_SegmentsGuid",
                table: "Segments",
                column: "StPara_SegmentsGuid",
                principalTable: "StParas",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StParas_StTexts_StText_ParagraphsGuid",
                table: "StParas",
                column: "StText_ParagraphsGuid",
                principalTable: "StTexts",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AgentEvaluations_ApprovesGuid",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_AgentEvaluations_DisapprovesGuid",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Projects_Project_AnalyzingAgentsGuid",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_Projects_Project_AnnotationsGuid",
                table: "Annotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Projects_Project_MediaGuid",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_Folders_Projects_Project_PicturesGuid",
                table: "Folders");

            migrationBuilder.DropForeignKey(
                name: "FK_PossibilityLists_Projects_Project_CheckListsGuid",
                table: "PossibilityLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_StTexts_NotesGuid",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_StTexts_DiscussionGuid",
                table: "Annotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_StTexts_QuoteGuid",
                table: "Annotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_StTexts_RecommendationGuid",
                table: "Annotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_StTexts_ResolutionGuid",
                table: "Annotations");

            migrationBuilder.DropForeignKey(
                name: "FK_Annotations_StTexts_TextGuid",
                table: "Annotations");

            migrationBuilder.DropForeignKey(
                name: "FK_PhContextOrVars_StTexts_DescriptionGuid",
                table: "PhContextOrVars");

            migrationBuilder.DropForeignKey(
                name: "FK_Possibilitys_StTexts_DiscussionGuid",
                table: "Possibilitys");

            migrationBuilder.DropForeignKey(
                name: "FK_ScrBooks_StTexts_TitleGuid",
                table: "ScrBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_StParas_StTexts_StText_ParagraphsGuid",
                table: "StParas");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatureSpecifications_FsAbstractStructures_FsAbsStruc_Fea~",
                table: "FsFeatureSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatureSpecifications_FsAbstractStructures_ValueGuid",
                table: "FsFeatureSpecifications");

            migrationBuilder.DropForeignKey(
                name: "FK_MoForms_FsAbstractStructures_MsEnvFeaturesGuid",
                table: "MoForms");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_FromMsFeaturesGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_InflFeatsGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_LfMoDerivStepMsa_I~",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_LfMoStemMsa_MsFeat~",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_MsFeaturesGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_FsAbstractStructures_ToMsFeaturesGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_PhNaturalClasss_FsAbstractStructures_FeaturesGuid",
                table: "PhNaturalClasss");

            migrationBuilder.DropForeignKey(
                name: "FK_PhTerminalUnits_FsAbstractStructures_FeaturesGuid",
                table: "PhTerminalUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Possibilitys_FsAbstractStructures_DefaultFeaturesGuid",
                table: "Possibilitys");

            migrationBuilder.DropForeignKey(
                name: "FK_Possibilitys_FsAbstractStructures_InflFeatsGuid",
                table: "Possibilitys");

            migrationBuilder.DropForeignKey(
                name: "FK_Possibilitys_FsAbstractStructures_InherFeatValGuid",
                table: "Possibilitys");

            migrationBuilder.DropForeignKey(
                name: "FK_Possibilitys_ObjectIds_ItemGuid",
                table: "Possibilitys");

            migrationBuilder.DropForeignKey(
                name: "FK_MoForms_Possibilitys_MorphTypeGuid",
                table: "MoForms");

            migrationBuilder.DropForeignKey(
                name: "FK_MoForms_Possibilitys_MsEnvPartOfSpeechGuid",
                table: "MoForms");

            migrationBuilder.DropForeignKey(
                name: "FK_MoInflClasss_Possibilitys_Possibility_InflectionClassesGuid",
                table: "MoInflClasss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_AffixCategoryGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_FromPartOfSpeechGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_LfMoDerivAffMsa_AffixCateg~",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_LfMoDerivStepMsa_PartOfSpe~",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_LfMoStemMsa_PartOfSpeechGu~",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_LfMoUnclassifiedAffixMsa_P~",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_PartOfSpeechGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_Possibilitys_ToPartOfSpeechGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoStemNames_Possibilitys_Possibility_StemNamesGuid",
                table: "MoStemNames");

            migrationBuilder.DropForeignKey(
                name: "FK_MoForms_LexEntrys_LexEntry_AlternateFormsGuid",
                table: "MoForms");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_LexEntrys_LexEntry_MorphoSyntaxAnalyses~",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_PhContextOrVars_MoForms_MoForm_InputGuid",
                table: "PhContextOrVars");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphDatas_PossibilityLists_ProdRestrictGuid",
                table: "MoMorphDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_PhPhonDatas_PossibilityLists_PhonRuleFeatsGuid",
                table: "PhPhonDatas");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatDefns_FsFeatStrucTypes_TypeGuid",
                table: "FsFeatDefns");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_MoInflClasss_FromInflectionClassGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_MoInflClasss_InflectionClassGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_MoInflClasss_LfMoStemMsa_InflectionClas~",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_MoInflClasss_ToInflectionClassGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_MoStemNames_MoInflClasss_MoInflClass_StemNamesGuid",
                table: "MoStemNames");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysiss_MoStemNames_FromStemNameGuid",
                table: "MoMorphSynAnalysiss");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatDefns_FsFeatureSpecifications_DefaultGuid",
                table: "FsFeatDefns");

            migrationBuilder.DropForeignKey(
                name: "FK_MoStratums_MoMorphDatas_MoMorphData_StrataGuid",
                table: "MoStratums");

            migrationBuilder.DropForeignKey(
                name: "FK_PhSegmentRules_MoStratums_FinalStratumGuid",
                table: "PhSegmentRules");

            migrationBuilder.DropForeignKey(
                name: "FK_PhSegmentRules_MoStratums_InitialStratumGuid",
                table: "PhSegmentRules");

            migrationBuilder.DropForeignKey(
                name: "FK_PhContextOrVars_PhTerminalUnits_FeatureStructureGuid",
                table: "PhContextOrVars");

            migrationBuilder.DropForeignKey(
                name: "FK_PhContextOrVars_PhTerminalUnits_LfPhSimpleContextSeg_Featur~",
                table: "PhContextOrVars");

            migrationBuilder.DropForeignKey(
                name: "FK_PhSegRuleRHSs_PhContextOrVars_LeftContextGuid",
                table: "PhSegRuleRHSs");

            migrationBuilder.DropForeignKey(
                name: "FK_PhSegRuleRHSs_PhContextOrVars_RightContextGuid",
                table: "PhSegRuleRHSs");

            migrationBuilder.DropTable(
                name: "BaseAnnotation_OtherObjects_ObjectId");

            migrationBuilder.DropTable(
                name: "Cells");

            migrationBuilder.DropTable(
                name: "ChkRefs");

            migrationBuilder.DropTable(
                name: "ChkRenderings");

            migrationBuilder.DropTable(
                name: "ChkSenses");

            migrationBuilder.DropTable(
                name: "ConstChartClauseMarker_DependentClauses_ConstChartRow");

            migrationBuilder.DropTable(
                name: "DomainQs");

            migrationBuilder.DropTable(
                name: "FsDisjunctiveValue_Value_FsSymFeatVal");

            migrationBuilder.DropTable(
                name: "FsFeatStrucType_Features_FsFeatDefn");

            migrationBuilder.DropTable(
                name: "IndirectAnnotation_AppliesTo_Annotation");

            migrationBuilder.DropTable(
                name: "LangProject_WordformLookupLists_WordformLookupList");

            migrationBuilder.DropTable(
                name: "LexDb_AllomorphIndex_MoForm");

            migrationBuilder.DropTable(
                name: "LexDb_LexicalFormIndex_LexEntry");

            migrationBuilder.DropTable(
                name: "LexEntry_DialectLabels_Possibility");

            migrationBuilder.DropTable(
                name: "LexEntry_DoNotPublishIn_Possibility");

            migrationBuilder.DropTable(
                name: "LexEntry_DoNotShowMainEntryIn_Possibility");

            migrationBuilder.DropTable(
                name: "LexEntry_MainEntriesOrSenses_ObjectId");

            migrationBuilder.DropTable(
                name: "LexEntryInflType_Slots_MoInflAffixSlot");

            migrationBuilder.DropTable(
                name: "LexEntryRef_ComplexEntryTypes_Possibility");

            migrationBuilder.DropTable(
                name: "LexEntryRef_ComponentLexemes_ObjectId");

            migrationBuilder.DropTable(
                name: "LexEntryRef_PrimaryLexemes_ObjectId");

            migrationBuilder.DropTable(
                name: "LexEntryRef_ShowComplexFormsIn_ObjectId");

            migrationBuilder.DropTable(
                name: "LexEntryRef_VariantEntryTypes_Possibility");

            migrationBuilder.DropTable(
                name: "LexEtymology_Language_Possibility");

            migrationBuilder.DropTable(
                name: "LexExampleSentence_DoNotPublishIn_Possibility");

            migrationBuilder.DropTable(
                name: "LexPronunciation_DoNotPublishIn_Possibility");

            migrationBuilder.DropTable(
                name: "LexReference_Targets_ObjectId");

            migrationBuilder.DropTable(
                name: "LexSense_AnthroCodes_Possibility");

            migrationBuilder.DropTable(
                name: "LexSense_Appendixes_LexAppendix");

            migrationBuilder.DropTable(
                name: "LexSense_DialectLabels_Possibility");

            migrationBuilder.DropTable(
                name: "LexSense_DomainTypes_Possibility");

            migrationBuilder.DropTable(
                name: "LexSense_DoNotPublishIn_Possibility");

            migrationBuilder.DropTable(
                name: "LexSense_SemanticDomains_Possibility");

            migrationBuilder.DropTable(
                name: "LexSense_ThesaurusItems_Possibility");

            migrationBuilder.DropTable(
                name: "LexSense_UsageTypes_Possibility");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "MoAffixAllomorph_PhoneEnv_PhEnvironment");

            migrationBuilder.DropTable(
                name: "MoAffixAllomorph_Position_PhEnvironment");

            migrationBuilder.DropTable(
                name: "MoAffixForm_InflectionClasses_MoInflClass");

            migrationBuilder.DropTable(
                name: "MoAlloAdhocProhib_Allomorphs_MoForm");

            migrationBuilder.DropTable(
                name: "MoAlloAdhocProhib_RestOfAllos_MoForm");

            migrationBuilder.DropTable(
                name: "MoCompoundRule_ToProdRestrict_Possibility");

            migrationBuilder.DropTable(
                name: "MoDerivAffMsa_FromProdRestrict_Possibility");

            migrationBuilder.DropTable(
                name: "MoDerivAffMsa_ToProdRestrict_Possibility");

            migrationBuilder.DropTable(
                name: "MoDerivStepMsa_ProdRestrict_Possibility");

            migrationBuilder.DropTable(
                name: "MoDerivTraces");

            migrationBuilder.DropTable(
                name: "MoInflAffixTemplate_EncliticSlots_MoInflAffixSlot");

            migrationBuilder.DropTable(
                name: "MoInflAffixTemplate_PrefixSlots_MoInflAffixSlot");

            migrationBuilder.DropTable(
                name: "MoInflAffixTemplate_ProcliticSlots_MoInflAffixSlot");

            migrationBuilder.DropTable(
                name: "MoInflAffixTemplate_Slots_MoInflAffixSlot");

            migrationBuilder.DropTable(
                name: "MoInflAffixTemplate_SuffixSlots_MoInflAffixSlot");

            migrationBuilder.DropTable(
                name: "MoInflAffMsa_FromProdRestrict_Possibility");

            migrationBuilder.DropTable(
                name: "MoInflAffMsa_Slots_MoInflAffixSlot");

            migrationBuilder.DropTable(
                name: "MoInsertPhones_Content_PhTerminalUnit");

            migrationBuilder.DropTable(
                name: "MoMorphAdhocProhib_Morphemes_MoMorphSynAnalysis");

            migrationBuilder.DropTable(
                name: "MoMorphAdhocProhib_RestOfMorphs_MoMorphSynAnalysis");

            migrationBuilder.DropTable(
                name: "MoMorphData_AnalyzingAgents_Agent");

            migrationBuilder.DropTable(
                name: "MoMorphSynAnalysis_Components_MoMorphSynAnalysis");

            migrationBuilder.DropTable(
                name: "MoMorphSynAnalysis_GlossBundle_MoGlossItem");

            migrationBuilder.DropTable(
                name: "MoReferralRules");

            migrationBuilder.DropTable(
                name: "MoStemAllomorph_PhoneEnv_PhEnvironment");

            migrationBuilder.DropTable(
                name: "MoStemMsa_FromPartsOfSpeech_Possibility");

            migrationBuilder.DropTable(
                name: "MoStemMsa_ProdRestrict_Possibility");

            migrationBuilder.DropTable(
                name: "MoStemMsa_Slots_MoInflAffixSlot");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Overlay_PossItems_Possibility");

            migrationBuilder.DropTable(
                name: "PartOfSpeech_BearableFeatures_FsFeatDefn");

            migrationBuilder.DropTable(
                name: "PartOfSpeech_InflectableFeats_FsFeatDefn");

            migrationBuilder.DropTable(
                name: "Person_PlacesOfResidence_Possibility");

            migrationBuilder.DropTable(
                name: "Person_Positions_Possibility");

            migrationBuilder.DropTable(
                name: "PhCodes");

            migrationBuilder.DropTable(
                name: "PhNCSegments_Segments_PhTerminalUnit");

            migrationBuilder.DropTable(
                name: "PhSegRuleRHS_ExclRuleFeats_Possibility");

            migrationBuilder.DropTable(
                name: "PhSegRuleRHS_InputPOSes_Possibility");

            migrationBuilder.DropTable(
                name: "PhSegRuleRHS_ReqRuleFeats_Possibility");

            migrationBuilder.DropTable(
                name: "PhSequenceContext_Members_PhContextOrVar");

            migrationBuilder.DropTable(
                name: "PhSimpleContextNC_MinusConstr_PhFeatureConstraint");

            migrationBuilder.DropTable(
                name: "PhSimpleContextNC_PlusConstr_PhFeatureConstraint");

            migrationBuilder.DropTable(
                name: "Picture_DoNotPublishIn_Possibility");

            migrationBuilder.DropTable(
                name: "Possibility_Researchers_Possibility");

            migrationBuilder.DropTable(
                name: "Possibility_Restrictions_Possibility");

            migrationBuilder.DropTable(
                name: "PossibilityListCustomFieldValue_Value_Possibility");

            migrationBuilder.DropTable(
                name: "PubDivisions");

            migrationBuilder.DropTable(
                name: "PunctuationForms");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "ReversalIndexEntry_Senses_LexSense");

            migrationBuilder.DropTable(
                name: "RnGenericRec_AnthroCodes_Possibility");

            migrationBuilder.DropTable(
                name: "RnGenericRec_CounterEvidence_RnGenericRec");

            migrationBuilder.DropTable(
                name: "RnGenericRec_CrossReferences_CrossReference");

            migrationBuilder.DropTable(
                name: "RnGenericRec_Locations_Possibility");

            migrationBuilder.DropTable(
                name: "RnGenericRec_PhraseTags_Possibility");

            migrationBuilder.DropTable(
                name: "RnGenericRec_Reminders_Reminder");

            migrationBuilder.DropTable(
                name: "RnGenericRec_Researchers_Possibility");

            migrationBuilder.DropTable(
                name: "RnGenericRec_Restrictions_Possibility");

            migrationBuilder.DropTable(
                name: "RnGenericRec_SeeAlso_RnGenericRec");

            migrationBuilder.DropTable(
                name: "RnGenericRec_Sources_Possibility");

            migrationBuilder.DropTable(
                name: "RnGenericRec_SupersededBy_RnGenericRec");

            migrationBuilder.DropTable(
                name: "RnGenericRec_SupportingEvidence_RnGenericRec");

            migrationBuilder.DropTable(
                name: "RnGenericRec_TimeOfEvent_Possibility");

            migrationBuilder.DropTable(
                name: "RnRoledPartic_Participants_Possibility");

            migrationBuilder.DropTable(
                name: "ScrCheckRuns");

            migrationBuilder.DropTable(
                name: "ScrDifferences");

            migrationBuilder.DropTable(
                name: "ScrMarkerMappings");

            migrationBuilder.DropTable(
                name: "ScrScriptureNote_Categories_Possibility");

            migrationBuilder.DropTable(
                name: "ScrSections");

            migrationBuilder.DropTable(
                name: "Segment_Analyses_Analysis");

            migrationBuilder.DropTable(
                name: "SemanticDomain_OcmRefs_Possibility");

            migrationBuilder.DropTable(
                name: "SemanticDomain_RelatedDomains_Possibility");

            migrationBuilder.DropTable(
                name: "StTxtPara_TextObjects_ObjectId");

            migrationBuilder.DropTable(
                name: "Text_Genres_Possibility");

            migrationBuilder.DropTable(
                name: "TextTags");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "UserAppFeatAct_UserConfigAcct_UserConfigAcct");

            migrationBuilder.DropTable(
                name: "VirtualOrdering_Items_ObjectId");

            migrationBuilder.DropTable(
                name: "WfiAnalysis_CompoundRuleApps_MoCompoundRule");

            migrationBuilder.DropTable(
                name: "WfiAnalysis_Evaluations_AgentEvaluation");

            migrationBuilder.DropTable(
                name: "WfiAnalysis_InflTemplateApps_MoInflAffixTemplate");

            migrationBuilder.DropTable(
                name: "WfiAnalysis_Stems_LexEntry");

            migrationBuilder.DropTable(
                name: "WfiMorphBundles");

            migrationBuilder.DropTable(
                name: "WfiWordSet_Cases_WfiWordform");

            migrationBuilder.DropTable(
                name: "WordFormLookup_AnthroCodes_Possibility");

            migrationBuilder.DropTable(
                name: "WordFormLookup_ThesaurusItems_Possibility");

            migrationBuilder.DropTable(
                name: "WritingSystems");

            migrationBuilder.DropTable(
                name: "Rows");

            migrationBuilder.DropTable(
                name: "WfiGlosss");

            migrationBuilder.DropTable(
                name: "ConstituentChartCellParts");

            migrationBuilder.DropTable(
                name: "LexEntryRefs");

            migrationBuilder.DropTable(
                name: "LexEtymologys");

            migrationBuilder.DropTable(
                name: "LexReferences");

            migrationBuilder.DropTable(
                name: "LexAppendixs");

            migrationBuilder.DropTable(
                name: "LexPronunciations");

            migrationBuilder.DropTable(
                name: "MoRuleMappings");

            migrationBuilder.DropTable(
                name: "MoAdhocProhibs");

            migrationBuilder.DropTable(
                name: "MoGlossItems");

            migrationBuilder.DropTable(
                name: "PhEnvironments");

            migrationBuilder.DropTable(
                name: "MoInflAffixSlots");

            migrationBuilder.DropTable(
                name: "Overlays");

            migrationBuilder.DropTable(
                name: "PhFeatureConstraints");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "CustomFieldValues");

            migrationBuilder.DropTable(
                name: "PubHFSets");

            migrationBuilder.DropTable(
                name: "PubPageLayouts");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "ReversalIndexEntrys");

            migrationBuilder.DropTable(
                name: "CrossReferences");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "RnRoledPartics");

            migrationBuilder.DropTable(
                name: "StStyles");

            migrationBuilder.DropTable(
                name: "Analysiss");

            migrationBuilder.DropTable(
                name: "UserAppFeatActs");

            migrationBuilder.DropTable(
                name: "UserConfigAccts");

            migrationBuilder.DropTable(
                name: "VirtualOrderings");

            migrationBuilder.DropTable(
                name: "MoCompoundRules");

            migrationBuilder.DropTable(
                name: "MoInflAffixTemplates");

            migrationBuilder.DropTable(
                name: "WfiWordSets");

            migrationBuilder.DropTable(
                name: "WordFormLookups");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "ConstChartRows");

            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "CustomFieldConfigs");

            migrationBuilder.DropTable(
                name: "LexExampleSentences");

            migrationBuilder.DropTable(
                name: "PubHeaders");

            migrationBuilder.DropTable(
                name: "ReversalIndexs");

            migrationBuilder.DropTable(
                name: "RnGenericRecs");

            migrationBuilder.DropTable(
                name: "WfiAnalysiss");

            migrationBuilder.DropTable(
                name: "WordformLookupLists");

            migrationBuilder.DropTable(
                name: "DsCharts");

            migrationBuilder.DropTable(
                name: "MediaURIs");

            migrationBuilder.DropTable(
                name: "ScrImportSources");

            migrationBuilder.DropTable(
                name: "LexExtendedNotes");

            migrationBuilder.DropTable(
                name: "Texts");

            migrationBuilder.DropTable(
                name: "MoDerivs");

            migrationBuilder.DropTable(
                name: "WfiWordforms");

            migrationBuilder.DropTable(
                name: "ScrImportSets");

            migrationBuilder.DropTable(
                name: "LexSenses");

            migrationBuilder.DropTable(
                name: "MediaContainers");

            migrationBuilder.DropTable(
                name: "AgentEvaluations");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "DsDiscourseDatas");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "LexDbs");

            migrationBuilder.DropTable(
                name: "RnResearchNbks");

            migrationBuilder.DropTable(
                name: "StTexts");

            migrationBuilder.DropTable(
                name: "Annotations");

            migrationBuilder.DropTable(
                name: "ScrBooks");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "ScrBookAnnotationss");

            migrationBuilder.DropTable(
                name: "ScrBookRefs");

            migrationBuilder.DropTable(
                name: "ScrDrafts");

            migrationBuilder.DropTable(
                name: "ScrRefSystems");

            migrationBuilder.DropTable(
                name: "Scriptures");

            migrationBuilder.DropTable(
                name: "FsAbstractStructures");

            migrationBuilder.DropTable(
                name: "ObjectIds");

            migrationBuilder.DropTable(
                name: "StParas");

            migrationBuilder.DropTable(
                name: "Possibilitys");

            migrationBuilder.DropTable(
                name: "LexEntrys");

            migrationBuilder.DropTable(
                name: "MoForms");

            migrationBuilder.DropTable(
                name: "PossibilityLists");

            migrationBuilder.DropTable(
                name: "FsFeatStrucTypes");

            migrationBuilder.DropTable(
                name: "MoInflClasss");

            migrationBuilder.DropTable(
                name: "MoStemNames");

            migrationBuilder.DropTable(
                name: "MoMorphSynAnalysiss");

            migrationBuilder.DropTable(
                name: "FsFeatureSpecifications");

            migrationBuilder.DropTable(
                name: "FsSymFeatVals");

            migrationBuilder.DropTable(
                name: "FsFeatDefns");

            migrationBuilder.DropTable(
                name: "FsFeatureSystems");

            migrationBuilder.DropTable(
                name: "MoMorphDatas");

            migrationBuilder.DropTable(
                name: "MoGlossSystems");

            migrationBuilder.DropTable(
                name: "MoStratums");

            migrationBuilder.DropTable(
                name: "PhTerminalUnits");

            migrationBuilder.DropTable(
                name: "PhPhonemeSets");

            migrationBuilder.DropTable(
                name: "PhContextOrVars");

            migrationBuilder.DropTable(
                name: "PhNaturalClasss");

            migrationBuilder.DropTable(
                name: "PhSegRuleRHSs");

            migrationBuilder.DropTable(
                name: "PhSegmentRules");

            migrationBuilder.DropTable(
                name: "PhPhonDatas");
        }
    }
}
