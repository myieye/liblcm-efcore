using System;
using System.Collections.Generic;
using LfSync.Data.LCModel;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LfSync.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    OriginalPath = table.Column<string>(type: "text", nullable: true),
                    InternalPath = table.Column<string>(type: "text", nullable: true),
                    Copyright = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "FsFeatStrucDisj",
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
                    table.PrimaryKey("PK_FsFeatStrucDisj", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "FsFeatStrucType",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    CatalogSourceId = table.Column<string>(type: "text", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsFeatStrucType", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "MediaURI",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaURI = table.Column<string>(type: "text", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaURI", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PhPhonemeSet",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhPhonemeSet", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PossibilityLists",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
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
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibilityLists", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PubHeader",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    InsideAlignedText = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    CenteredText = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    OutsideAlignedText = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PubHeader", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PubPageLayout",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<LfTsString>(type: "jsonb", nullable: true),
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
                    table.PrimaryKey("PK_PubPageLayout", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "StText",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RightToLeft = table.Column<bool>(type: "boolean", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StText", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "WfiWordform",
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
                    table.PrimaryKey("PK_WfiWordform", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "MoStratum",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    PhonemesRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoStratum", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoStratum_PhPhonemeSet_PhonemesRATempId2",
                        column: x => x.PhonemesRAGuid,
                        principalTable: "PhPhonemeSet",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "PhBdryMarker",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PhPhonemeSetGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhBdryMarker", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhBdryMarker_PhPhonemeSet_PhPhonemeSetTempId",
                        column: x => x.PhPhonemeSetGuid,
                        principalTable: "PhPhonemeSet",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "Publication",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<LfTsString>(type: "jsonb", nullable: true),
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
                    PossibilityListGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publication", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Publication_PossibilityLists_PossibilityListGuid",
                        column: x => x.PossibilityListGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "PubHFSet",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    DefaultHeaderOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultFooterOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FirstHeaderOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FirstFooterOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EvenHeaderOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EvenFooterOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PossibilityListGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PubHFSet", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PubHFSet_PossibilityLists_PossibilityListGuid",
                        column: x => x.PossibilityListGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PubHFSet_PubHeader_DefaultFooterOATempId",
                        column: x => x.DefaultFooterOAGuid,
                        principalTable: "PubHeader",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PubHFSet_PubHeader_DefaultHeaderOATempId1",
                        column: x => x.DefaultHeaderOAGuid,
                        principalTable: "PubHeader",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PubHFSet_PubHeader_EvenFooterOATempId2",
                        column: x => x.EvenFooterOAGuid,
                        principalTable: "PubHeader",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PubHFSet_PubHeader_EvenHeaderOATempId3",
                        column: x => x.EvenHeaderOAGuid,
                        principalTable: "PubHeader",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PubHFSet_PubHeader_FirstFooterOATempId4",
                        column: x => x.FirstFooterOAGuid,
                        principalTable: "PubHeader",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PubHFSet_PubHeader_FirstHeaderOATempId5",
                        column: x => x.FirstHeaderOAGuid,
                        principalTable: "PubHeader",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "PhPhonContext",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DescriptionOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhPhonContext", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhPhonContext_StText_DescriptionOATempId1",
                        column: x => x.DescriptionOAGuid,
                        principalTable: "StText",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "StPara",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    StyleRules = table.Column<List<TextProperty>>(type: "jsonb", nullable: true),
                    StTextGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StPara", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_StPara_StText_StTextTempId3",
                        column: x => x.StTextGuid,
                        principalTable: "StText",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "PubDivision",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    DifferentFirstHF = table.Column<bool>(type: "boolean", nullable: false),
                    DifferentEvenHF = table.Column<bool>(type: "boolean", nullable: false),
                    StartAt = table.Column<int>(type: "integer", nullable: false),
                    PageLayoutOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    HFSetOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    NumColumns = table.Column<int>(type: "integer", nullable: false),
                    PublicationGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PubDivision", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PubDivision_PubHFSet_HFSetOATempId",
                        column: x => x.HFSetOAGuid,
                        principalTable: "PubHFSet",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PubDivision_PubPageLayout_PageLayoutOATempId",
                        column: x => x.PageLayoutOAGuid,
                        principalTable: "PubPageLayout",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PubDivision_Publication_PublicationTempId",
                        column: x => x.PublicationGuid,
                        principalTable: "Publication",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "AgentEvaluation",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    WfiAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentEvaluation", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Analysis",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    WordformGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    HasWordform = table.Column<bool>(type: "boolean", nullable: false),
                    AnalysisGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    SegmentGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analysis", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Analysis_WfiWordform_WordformTempId1",
                        column: x => x.WordformGuid,
                        principalTable: "WfiWordform",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DomainQ",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Question = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ExampleWords = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ExampleSentences = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    SemanticDomainGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainQ", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
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
                    LexemeFormOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ImportResidue = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    WfiAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LexEntryRef",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    HideMinorEntry = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    RefType = table.Column<int>(type: "integer", nullable: false),
                    LexEntryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEntryRef", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LexEntryRef_Entries_LexEntryGuid",
                        column: x => x.LexEntryGuid,
                        principalTable: "Entries",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "LexEtymology",
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
                    LexEntryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexEtymology", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LexEtymology_Entries_LexEntryGuid",
                        column: x => x.LexEntryGuid,
                        principalTable: "Entries",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "ExampleSentences",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Example = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Reference = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    LexExtendedNoteGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexSenseGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleSentences", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "FsFeatDefn",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DefaultOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    GlossAbbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    RightGlossSep = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ShowInGloss = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayToRightOfValues = table.Column<bool>(type: "boolean", nullable: false),
                    CatalogSourceId = table.Column<string>(type: "text", nullable: true),
                    FsFeatStrucTypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PartOfSpeechGuid1 = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsFeatDefn", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_FsFeatDefn_FsFeatStrucType_FsFeatStrucTypeTempId",
                        column: x => x.FsFeatStrucTypeGuid,
                        principalTable: "FsFeatStrucType",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "FsFeatStruc",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflClassGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoStemNameGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PartOfSpeechGuid1 = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsFeatStruc", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_FsFeatStruc_FsFeatStrucType_TypeRATempId1",
                        column: x => x.TypeRAGuid,
                        principalTable: "FsFeatStrucType",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "FsFeatStrucFsFeatStrucDisj",
                columns: table => new
                {
                    ContentsOCGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureDisjunctionsOCGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsFeatStrucFsFeatStrucDisj", x => new { x.ContentsOCGuid, x.FeatureDisjunctionsOCGuid });
                    table.ForeignKey(
                        name: "FK_FsFeatStrucFsFeatStrucDisj_FsFeatStrucDisj_FeatureDisjuncti~",
                        column: x => x.FeatureDisjunctionsOCGuid,
                        principalTable: "FsFeatStrucDisj",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FsFeatStrucFsFeatStrucDisj_FsFeatStruc_ContentsOCTempId",
                        column: x => x.ContentsOCGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FsFeatureSpecification",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    RefNumber = table.Column<int>(type: "integer", nullable: false),
                    ValueState = table.Column<int>(type: "integer", nullable: false),
                    FeatureRAGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    FsFeatStrucGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FsFeatureSpecification", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_FsFeatureSpecification_FsFeatDefn_FeatureRAGuid",
                        column: x => x.FeatureRAGuid,
                        principalTable: "FsFeatDefn",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FsFeatureSpecification_FsFeatStruc_FsFeatStrucGuid",
                        column: x => x.FsFeatStrucGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "PhPhoneme",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    BasicIPASymbol = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    FeaturesOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PhPhonemeSetGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhPhoneme", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhPhoneme_FsFeatStruc_FeaturesOAGuid",
                        column: x => x.FeaturesOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PhPhoneme_PhPhonemeSet_PhPhonemeSetTempId1",
                        column: x => x.PhPhonemeSetGuid,
                        principalTable: "PhPhonemeSet",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "PhCode",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Representation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    PhBdryMarkerGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PhPhonemeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhCode", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhCode_PhBdryMarker_PhBdryMarkerGuid",
                        column: x => x.PhBdryMarkerGuid,
                        principalTable: "PhBdryMarker",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PhCode_PhPhoneme_PhPhonemeTempId",
                        column: x => x.PhPhonemeGuid,
                        principalTable: "PhPhoneme",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "LexAppendix",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ContentsOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexSenseGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexAppendix", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LexAppendix_StText_ContentsOATempId",
                        column: x => x.ContentsOAGuid,
                        principalTable: "StText",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "LexExtendedNote",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ExtendedNoteTypeRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Discussion = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LexSenseGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexExtendedNote", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LexPronunciation",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Form = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LocationRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    CVPattern = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    Tone = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    LexEntryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexPronunciation", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LexPronunciation_Entries_LexEntryGuid",
                        column: x => x.LexEntryGuid,
                        principalTable: "Entries",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Label = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MediaFileRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexPronunciationGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Media_File_MediaFileRAGuid",
                        column: x => x.MediaFileRAGuid,
                        principalTable: "File",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Media_LexPronunciation_LexPronunciationGuid",
                        column: x => x.LexPronunciationGuid,
                        principalTable: "LexPronunciation",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "LexReference",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Comment = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    LexRefTypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexReference", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LfLexExampleSentence_DoNotPublishInRC",
                columns: table => new
                {
                    DoNotPublishInRCGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    LexExampleSentenceGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LexExampleSentence_DoNotPublishInRC", x => new { x.DoNotPublishInRCGuid, x.LexExampleSentenceGuid });
                    table.ForeignKey(
                        name: "FK_LexExampleSentence_DoNotPublishInRC_ExampleSentences_LexE~",
                        column: x => x.LexExampleSentenceGuid,
                        principalTable: "ExampleSentences",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LfPerson_PositionsRC",
                columns: table => new
                {
                    Person1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionsRCGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person_PositionsRC", x => new { x.Person1Guid, x.PositionsRCGuid });
                });

            migrationBuilder.CreateTable(
                name: "LfPossibility_ResearchersRC",
                columns: table => new
                {
                    Possibility1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ResearchersRCGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possibility_ResearchersRC", x => new { x.Possibility1Guid, x.ResearchersRCGuid });
                });

            migrationBuilder.CreateTable(
                name: "LfPossibility_RestrictionsRC",
                columns: table => new
                {
                    PossibilityGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    RestrictionsRCGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possibility_RestrictionsRC", x => new { x.PossibilityGuid, x.RestrictionsRCGuid });
                });

            migrationBuilder.CreateTable(
                name: "LocationPerson",
                columns: table => new
                {
                    PersonGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PlacesOfResidenceRCGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationPerson", x => new { x.PersonGuid, x.PlacesOfResidenceRCGuid });
                });

            migrationBuilder.CreateTable(
                name: "MoCompoundRule",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    StratumRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Disabled = table.Column<bool>(type: "boolean", nullable: false),
                    WfiAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoCompoundRule", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoCompoundRule_MoStratum_StratumRATempId",
                        column: x => x.StratumRAGuid,
                        principalTable: "MoStratum",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoCompoundRuleApp",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    LeftFormRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RightFormRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LinkerRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoStratumAppGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false),
                    OutputForm = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoCompoundRuleApp", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "MoDeriv",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    StemFormRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StemMsaRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    InflectionalFeatsOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoDeriv", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoDeriv_FsFeatStruc_InflectionalFeatsOAGuid",
                        column: x => x.InflectionalFeatsOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoDerivAffApp",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    AffixFormRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AffixMsaRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    OutputMsaOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoStratumAppGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false),
                    OutputForm = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoDerivAffApp", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "MoForm",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Form = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MorphTypeRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsAbstract = table.Column<bool>(type: "boolean", nullable: false),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    LexEntryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MsEnvFeaturesOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MsEnvPartOfSpeechRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StemNameRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoForm", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoForm_Entries_LexEntryGuid",
                        column: x => x.LexEntryGuid,
                        principalTable: "Entries",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoForm_FsFeatStruc_MsEnvFeaturesOATempId12",
                        column: x => x.MsEnvFeaturesOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "PhEnvironment",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LeftContextRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RightContextRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AMPLEStringSegment = table.Column<string>(type: "text", nullable: true),
                    StringRepresentation = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    MoAffixAllomorphGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoAffixAllomorphGuid1 = table.Column<Guid>(type: "uuid", nullable: true),
                    MoStemAllomorphGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhEnvironment", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_PhEnvironment_MoForm_MoAffixAllomorphGuid",
                        column: x => x.MoAffixAllomorphGuid,
                        principalTable: "MoForm",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PhEnvironment_MoForm_MoAffixAllomorphGuid1",
                        column: x => x.MoAffixAllomorphGuid1,
                        principalTable: "MoForm",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PhEnvironment_MoForm_MoStemAllomorphGuid",
                        column: x => x.MoStemAllomorphGuid,
                        principalTable: "MoForm",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PhEnvironment_PhPhonContext_LeftContextRATempId",
                        column: x => x.LeftContextRAGuid,
                        principalTable: "PhPhonContext",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_PhEnvironment_PhPhonContext_RightContextRATempId1",
                        column: x => x.RightContextRAGuid,
                        principalTable: "PhPhonContext",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoGlossItem",
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
                    FeatStructFragOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TargetRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EticID = table.Column<string>(type: "text", nullable: true),
                    MoMorphSynAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoGlossItem", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoGlossItem_FsFeatStruc_FeatStructFragOAGuid",
                        column: x => x.FeatStructFragOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoGlossItem_MoGlossItem_TargetRAGuid",
                        column: x => x.TargetRAGuid,
                        principalTable: "MoGlossItem",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffixSlot",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Optional = table.Column<bool>(type: "boolean", nullable: false),
                    LexEntryInflTypeGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflAffMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflAffixTemplateGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflAffixTemplateGuid1 = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflAffixTemplateGuid2 = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflAffixTemplateGuid3 = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflAffixTemplateGuid4 = table.Column<Guid>(type: "uuid", nullable: true),
                    MoStemMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffixSlot", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffixSlotApp",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    SlotRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AffixFormRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AffixMsaRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflTemplateAppGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false),
                    OutputForm = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffixSlotApp", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoInflAffixSlotApp_MoForm_AffixFormRAGuid",
                        column: x => x.AffixFormRAGuid,
                        principalTable: "MoForm",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoInflAffixSlotApp_MoInflAffixSlot_SlotRAGuid",
                        column: x => x.SlotRAGuid,
                        principalTable: "MoInflAffixSlot",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoInflAffixTemplate",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    StratumRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    RegionOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Final = table.Column<bool>(type: "boolean", nullable: false),
                    Disabled = table.Column<bool>(type: "boolean", nullable: false),
                    PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    WfiAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflAffixTemplate", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoInflAffixTemplate_FsFeatStruc_RegionOAGuid",
                        column: x => x.RegionOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoInflAffixTemplate_MoStratum_StratumRATempId2",
                        column: x => x.StratumRAGuid,
                        principalTable: "MoStratum",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoInflTemplateApp",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    TemplateRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false),
                    OutputForm = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflTemplateApp", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoInflTemplateApp_MoInflAffixTemplate_TemplateRAGuid",
                        column: x => x.TemplateRAGuid,
                        principalTable: "MoInflAffixTemplate",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoStratumApp",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    StratumRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    TemplateAppOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoDerivGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false),
                    OutputForm = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoStratumApp", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoStratumApp_MoDeriv_MoDerivGuid",
                        column: x => x.MoDerivGuid,
                        principalTable: "MoDeriv",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoStratumApp_MoInflTemplateApp_TemplateAppOAGuid",
                        column: x => x.TemplateAppOAGuid,
                        principalTable: "MoInflTemplateApp",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoStratumApp_MoStratum_StratumRAGuid",
                        column: x => x.StratumRAGuid,
                        principalTable: "MoStratum",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoPhonolRuleApp",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    VacuousApp = table.Column<bool>(type: "boolean", nullable: false),
                    MoStratumAppGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false),
                    OutputForm = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoPhonolRuleApp", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoPhonolRuleApp_MoStratumApp_MoStratumAppTempId2",
                        column: x => x.MoStratumAppGuid,
                        principalTable: "MoStratumApp",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoInflClass",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MoAffixFormGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflClassGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoInflClass", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoInflClass_MoForm_MoAffixFormGuid",
                        column: x => x.MoAffixFormGuid,
                        principalTable: "MoForm",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoInflClass_MoInflClass_MoInflClassGuid",
                        column: x => x.MoInflClassGuid,
                        principalTable: "MoInflClass",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoMorphSynAnalysis",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    GlossString = table.Column<string>(type: "text", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    LexEntryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoMorphSynAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FromMsFeaturesOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ToMsFeaturesOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FromPartOfSpeechRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ToPartOfSpeechRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FromInflectionClassRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ToInflectionClassRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoDerivAffMsa_AffixCategoryRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    FromStemNameRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StratumRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoDerivStepMsa_PartOfSpeechRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MsFeaturesOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoDerivStepMsa_InflFeatsOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    InflectionClassRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    InflFeatsOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    AffixCategoryRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PartOfSpeechRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoStemMsa_MsFeaturesOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoStemMsa_PartOfSpeechRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoStemMsa_InflectionClassRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoStemMsa_StratumRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoMorphSynAnalysis", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_Entries_LexEntryGuid",
                        column: x => x.LexEntryGuid,
                        principalTable: "Entries",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_FsFeatStruc_FromMsFeaturesOATempId4",
                        column: x => x.FromMsFeaturesOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_FsFeatStruc_InflFeatsOATempId6",
                        column: x => x.MoDerivStepMsa_InflFeatsOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_FsFeatStruc_InflFeatsOATempId7",
                        column: x => x.InflFeatsOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_FsFeatStruc_MsFeaturesOATempId13",
                        column: x => x.MsFeaturesOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_FsFeatStruc_MsFeaturesOATempId14",
                        column: x => x.MoStemMsa_MsFeaturesOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_FsFeatStruc_ToMsFeaturesOATempId18",
                        column: x => x.ToMsFeaturesOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_MoInflClass_FromInflectionClassRATempI~",
                        column: x => x.FromInflectionClassRAGuid,
                        principalTable: "MoInflClass",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_MoInflClass_InflectionClassRATempId2",
                        column: x => x.InflectionClassRAGuid,
                        principalTable: "MoInflClass",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_MoInflClass_InflectionClassRATempId3",
                        column: x => x.MoStemMsa_InflectionClassRAGuid,
                        principalTable: "MoInflClass",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_MoInflClass_ToInflectionClassRATempId8",
                        column: x => x.ToInflectionClassRAGuid,
                        principalTable: "MoInflClass",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_MoMorphSynAnalysis_MoMorphSynAnalysisG~",
                        column: x => x.MoMorphSynAnalysisGuid,
                        principalTable: "MoMorphSynAnalysis",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_MoStratum_StratumRATempId1",
                        column: x => x.StratumRAGuid,
                        principalTable: "MoStratum",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoMorphSynAnalysis_MoStratum_StratumRATempId3",
                        column: x => x.MoStemMsa_StratumRAGuid,
                        principalTable: "MoStratum",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoReferralRule",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    InputOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    OutputOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflClassGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoReferralRule", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoReferralRule_FsFeatStruc_InputOAGuid",
                        column: x => x.InputOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoReferralRule_FsFeatStruc_OutputOAGuid",
                        column: x => x.OutputOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoReferralRule_MoInflClass_MoInflClassGuid",
                        column: x => x.MoInflClassGuid,
                        principalTable: "MoInflClass",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "MoStemName",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    DefaultAffixRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultStemRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflClassGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PartOfSpeechGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoStemName", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_MoStemName_MoInflClass_MoInflClassGuid",
                        column: x => x.MoInflClassGuid,
                        principalTable: "MoInflClass",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoStemName_MoMorphSynAnalysis_DefaultAffixRAGuid",
                        column: x => x.DefaultAffixRAGuid,
                        principalTable: "MoMorphSynAnalysis",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_MoStemName_MoStemName_DefaultStemRAGuid",
                        column: x => x.DefaultStemRAGuid,
                        principalTable: "MoStemName",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Content = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    SegmentGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PictureFileRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Caption = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LayoutPos = table.Column<int>(type: "integer", nullable: false),
                    ScaleFactor = table.Column<int>(type: "integer", nullable: false),
                    LocationRangeType = table.Column<int>(type: "integer", nullable: false),
                    LocationMin = table.Column<int>(type: "integer", nullable: false),
                    LocationMax = table.Column<int>(type: "integer", nullable: false),
                    LexSenseGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Picture_File_PictureFileRAGuid",
                        column: x => x.PictureFileRAGuid,
                        principalTable: "File",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "Possibilities",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    SortSpec = table.Column<int>(type: "integer", nullable: false),
                    ConfidenceRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StatusRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiscussionOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    HelpId = table.Column<string>(type: "text", nullable: true),
                    ForeColor = table.Column<int>(type: "integer", nullable: false),
                    BackColor = table.Column<int>(type: "integer", nullable: false),
                    UnderColor = table.Column<int>(type: "integer", nullable: false),
                    UnderStyle = table.Column<int>(type: "integer", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsProtected = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    LexEntryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexEntryGuid1 = table.Column<Guid>(type: "uuid", nullable: true),
                    LexEntryGuid2 = table.Column<Guid>(type: "uuid", nullable: true),
                    LexEtymologyGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexPronunciationGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexSenseGuid1 = table.Column<Guid>(type: "uuid", nullable: true),
                    LexSenseGuid2 = table.Column<Guid>(type: "uuid", nullable: true),
                    LexSenseGuid3 = table.Column<Guid>(type: "uuid", nullable: true),
                    LexSenseGuid4 = table.Column<Guid>(type: "uuid", nullable: true),
                    LexSenseGuid5 = table.Column<Guid>(type: "uuid", nullable: true),
                    MoCompoundRuleGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoDerivAffMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoDerivAffMsaGuid1 = table.Column<Guid>(type: "uuid", nullable: true),
                    MoDerivStepMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoInflAffMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MoStemMsaGuid1 = table.Column<Guid>(type: "uuid", nullable: true),
                    PictureGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentPossibilityGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    PossibilityListGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexSenseGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    SemanticDomainGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ReverseAbbr = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LexEntryType_ReverseName = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LexEntryRefGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexEntryRefGuid1 = table.Column<Guid>(type: "uuid", nullable: true),
                    GlossPrepend = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    GlossAppend = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    InflFeatsOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ReverseAbbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MappingType = table.Column<int>(type: "integer", nullable: true),
                    ReverseName = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Location_Alias = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Postfix = table.Column<string>(type: "text", nullable: true),
                    Prefix = table.Column<string>(type: "text", nullable: true),
                    SecondaryOrder = table.Column<int>(type: "integer", nullable: true),
                    InherFeatValOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultFeaturesOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DefaultInflectionClassRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    CatalogSourceId = table.Column<string>(type: "text", nullable: true),
                    MoStemMsaGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Alias = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: true),
                    DateOfBirth = table.Column<GenDate>(type: "jsonb", nullable: true),
                    PlaceOfBirthRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsResearcher = table.Column<bool>(type: "boolean", nullable: true),
                    EducationRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DateOfDeath = table.Column<GenDate>(type: "jsonb", nullable: true),
                    LouwNidaCodes = table.Column<string>(type: "text", nullable: true),
                    OcmCodes = table.Column<string>(type: "text", nullable: true),
                    SemanticDomain_LexSenseGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    SemanticDomain_SemanticDomainGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possibilities", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Possibilities_Entries_LexEntryGuid",
                        column: x => x.LexEntryGuid,
                        principalTable: "Entries",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_Entries_LexEntryGuid1",
                        column: x => x.LexEntryGuid1,
                        principalTable: "Entries",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_Entries_LexEntryGuid2",
                        column: x => x.LexEntryGuid2,
                        principalTable: "Entries",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_LexEtymology_LexEtymologyGuid",
                        column: x => x.LexEtymologyGuid,
                        principalTable: "LexEtymology",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_LexPronunciation_LexPronunciationGuid",
                        column: x => x.LexPronunciationGuid,
                        principalTable: "LexPronunciation",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_MoCompoundRule_MoCompoundRuleGuid",
                        column: x => x.MoCompoundRuleGuid,
                        principalTable: "MoCompoundRule",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_MoMorphSynAnalysis_MoDerivAffMsaGuid",
                        column: x => x.MoDerivAffMsaGuid,
                        principalTable: "MoMorphSynAnalysis",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_MoMorphSynAnalysis_MoDerivAffMsaGuid1",
                        column: x => x.MoDerivAffMsaGuid1,
                        principalTable: "MoMorphSynAnalysis",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_MoMorphSynAnalysis_MoDerivStepMsaGuid",
                        column: x => x.MoDerivStepMsaGuid,
                        principalTable: "MoMorphSynAnalysis",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_MoMorphSynAnalysis_MoInflAffMsaGuid",
                        column: x => x.MoInflAffMsaGuid,
                        principalTable: "MoMorphSynAnalysis",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_MoMorphSynAnalysis_MoStemMsaGuid1",
                        column: x => x.MoStemMsaGuid1,
                        principalTable: "MoMorphSynAnalysis",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_Picture_PictureGuid",
                        column: x => x.PictureGuid,
                        principalTable: "Picture",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_Possibilities_ConfidenceRAGuid",
                        column: x => x.ConfidenceRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_Possibilities_EducationRAGuid",
                        column: x => x.EducationRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_Possibilities_PlaceOfBirthRAGuid",
                        column: x => x.PlaceOfBirthRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_Possibilities_PossibilityGuid",
                        column: x => x.ParentPossibilityGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_Possibilities_SemanticDomainTempId17",
                        column: x => x.SemanticDomainGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_Possibilities_SemanticDomainTempId19",
                        column: x => x.SemanticDomain_SemanticDomainGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_Possibilities_StatusRAGuid",
                        column: x => x.StatusRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_PossibilityLists_PossibilityListTempId",
                        column: x => x.PossibilityListGuid,
                        principalTable: "PossibilityLists",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_StText_DiscussionOATempId2",
                        column: x => x.DiscussionOAGuid,
                        principalTable: "StText",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibility_FsFeatStruc_DefaultFeaturesOATempId1",
                        column: x => x.DefaultFeaturesOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibility_FsFeatStruc_InflFeatsOATempId5",
                        column: x => x.InflFeatsOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibility_FsFeatStruc_InherFeatValOATempId9",
                        column: x => x.InherFeatValOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibility_LexEntryRef_LexEntryRefTempId",
                        column: x => x.LexEntryRefGuid,
                        principalTable: "LexEntryRef",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibility_LexEntryRef_LexEntryRefTempId1",
                        column: x => x.LexEntryRefGuid1,
                        principalTable: "LexEntryRef",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibility_MoInflClass_DefaultInflectionClassRATempId",
                        column: x => x.DefaultInflectionClassRAGuid,
                        principalTable: "MoInflClass",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibility_MoMorphSynAnalysis_MoStemMsaTempId11",
                        column: x => x.MoStemMsaGuid,
                        principalTable: "MoMorphSynAnalysis",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "Segment",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    BeginOffset = table.Column<int>(type: "integer", nullable: false),
                    FreeTranslation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LiteralTranslation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Reference = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    MediaURIRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    BeginTimeOffset = table.Column<string>(type: "text", nullable: true),
                    EndTimeOffset = table.Column<string>(type: "text", nullable: true),
                    SpeakerRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segment", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Segment_MediaURI_MediaURIRAGuid",
                        column: x => x.MediaURIRAGuid,
                        principalTable: "MediaURI",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Segment_Possibilities_SpeakerRAGuid",
                        column: x => x.SpeakerRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "Senses",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    MorphoSyntaxAnalysisRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Definition = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Gloss = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    ScientificName = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    SenseTypeRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
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
                    Source = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    StatusRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ImportResidue = table.Column<LfTsString>(type: "jsonb", nullable: true),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    Exemplar = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    UsageNote = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LexEntryGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LexSenseGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Senses", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Senses_Entries_LexEntryGuid",
                        column: x => x.LexEntryGuid,
                        principalTable: "Entries",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Senses_MoMorphSynAnalysis_MorphoSyntaxAnalysisRATempId13",
                        column: x => x.MorphoSyntaxAnalysisRAGuid,
                        principalTable: "MoMorphSynAnalysis",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Senses_Possibilities_SenseTypeRATempId26",
                        column: x => x.SenseTypeRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Senses_Possibilities_StatusRATempId28",
                        column: x => x.StatusRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Senses_Senses_LexSenseGuid",
                        column: x => x.LexSenseGuid,
                        principalTable: "Senses",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "Translation",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Translation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    TypeRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    LexExampleSentenceGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translation", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Translation_ExampleSentences_LexExampleSentenceGuid",
                        column: x => x.LexExampleSentenceGuid,
                        principalTable: "ExampleSentences",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Translation_Possibilities_TypeRAGuid",
                        column: x => x.TypeRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "WfiAnalysis",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MsFeaturesOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DerivationOAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    WfiWordformGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiAnalysis", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_FsFeatStruc_MsFeaturesOAGuid",
                        column: x => x.MsFeaturesOAGuid,
                        principalTable: "FsFeatStruc",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_MoDeriv_DerivationOAGuid",
                        column: x => x.DerivationOAGuid,
                        principalTable: "MoDeriv",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_Possibilities_CategoryRAGuid",
                        column: x => x.CategoryRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiAnalysis_WfiWordform_WfiWordformTempId",
                        column: x => x.WfiWordformGuid,
                        principalTable: "WfiWordform",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "TextTag",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    BeginSegmentRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    EndSegmentRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    BeginAnalysisIndex = table.Column<int>(type: "integer", nullable: false),
                    EndAnalysisIndex = table.Column<int>(type: "integer", nullable: false),
                    TagRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StTextGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextTag", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_TextTag_Possibilities_TagRAGuid",
                        column: x => x.TagRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_TextTag_Segment_BeginSegmentRAGuid",
                        column: x => x.BeginSegmentRAGuid,
                        principalTable: "Segment",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_TextTag_Segment_EndSegmentRAGuid",
                        column: x => x.EndSegmentRAGuid,
                        principalTable: "Segment",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_TextTag_StText_StTextGuid",
                        column: x => x.StTextGuid,
                        principalTable: "StText",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "WfiGloss",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Form = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    WfiAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiGloss", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_WfiGloss_WfiAnalysis_WfiAnalysisGuid",
                        column: x => x.WfiAnalysisGuid,
                        principalTable: "WfiAnalysis",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "WfiMorphBundle",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Form = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    MorphRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    MsaRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    SenseRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    InflTypeRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    WfiAnalysisGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: true),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfiMorphBundle", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_WfiMorphBundle_MoForm_MorphRAGuid",
                        column: x => x.MorphRAGuid,
                        principalTable: "MoForm",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiMorphBundle_MoMorphSynAnalysis_MsaRAGuid",
                        column: x => x.MsaRAGuid,
                        principalTable: "MoMorphSynAnalysis",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiMorphBundle_Possibilities_InflTypeRAGuid",
                        column: x => x.InflTypeRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiMorphBundle_Senses_SenseRAGuid",
                        column: x => x.SenseRAGuid,
                        principalTable: "Senses",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_WfiMorphBundle_WfiAnalysis_WfiAnalysisGuid",
                        column: x => x.WfiAnalysisGuid,
                        principalTable: "WfiAnalysis",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentEvaluation_WfiAnalysisGuid",
                table: "AgentEvaluation",
                column: "WfiAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Analysis_AnalysisGuid",
                table: "Analysis",
                column: "AnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Analysis_SegmentGuid",
                table: "Analysis",
                column: "SegmentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Analysis_WordformGuid",
                table: "Analysis",
                column: "WordformGuid");

            migrationBuilder.CreateIndex(
                name: "IX_DomainQ_SemanticDomainGuid",
                table: "DomainQ",
                column: "SemanticDomainGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_LexemeFormOAGuid",
                table: "Entries",
                column: "LexemeFormOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_WfiAnalysisGuid",
                table: "Entries",
                column: "WfiAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleSentences_LexExtendedNoteGuid",
                table: "ExampleSentences",
                column: "LexExtendedNoteGuid");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleSentences_LexSenseGuid",
                table: "ExampleSentences",
                column: "LexSenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatDefn_DefaultOAGuid",
                table: "FsFeatDefn",
                column: "DefaultOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatDefn_FsFeatStrucTypeGuid",
                table: "FsFeatDefn",
                column: "FsFeatStrucTypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatDefn_PartOfSpeechGuid",
                table: "FsFeatDefn",
                column: "PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatDefn_PartOfSpeechGuid1",
                table: "FsFeatDefn",
                column: "PartOfSpeechGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatStruc_MoInflClassGuid",
                table: "FsFeatStruc",
                column: "MoInflClassGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatStruc_MoStemNameGuid",
                table: "FsFeatStruc",
                column: "MoStemNameGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatStruc_PartOfSpeechGuid",
                table: "FsFeatStruc",
                column: "PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatStruc_PartOfSpeechGuid1",
                table: "FsFeatStruc",
                column: "PartOfSpeechGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatStruc_TypeRAGuid",
                table: "FsFeatStruc",
                column: "TypeRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatStrucFsFeatStrucDisj_FeatureDisjunctionsOCGuid",
                table: "FsFeatStrucFsFeatStrucDisj",
                column: "FeatureDisjunctionsOCGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatureSpecification_FeatureRAGuid",
                table: "FsFeatureSpecification",
                column: "FeatureRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_FsFeatureSpecification_FsFeatStrucGuid",
                table: "FsFeatureSpecification",
                column: "FsFeatStrucGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexAppendix_ContentsOAGuid",
                table: "LexAppendix",
                column: "ContentsOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexAppendix_LexSenseGuid",
                table: "LexAppendix",
                column: "LexSenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEntryRef_LexEntryGuid",
                table: "LexEntryRef",
                column: "LexEntryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexEtymology_LexEntryGuid",
                table: "LexEtymology",
                column: "LexEntryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexExtendedNote_ExtendedNoteTypeRAGuid",
                table: "LexExtendedNote",
                column: "ExtendedNoteTypeRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexExtendedNote_LexSenseGuid",
                table: "LexExtendedNote",
                column: "LexSenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexPronunciation_LexEntryGuid",
                table: "LexPronunciation",
                column: "LexEntryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexPronunciation_LocationRAGuid",
                table: "LexPronunciation",
                column: "LocationRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexReference_LexRefTypeGuid",
                table: "LexReference",
                column: "LexRefTypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LexExampleSentence_DoNotPublishInRC_LexExampleSentenceGuid",
                table: "LfLexExampleSentence_DoNotPublishInRC",
                column: "LexExampleSentenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PositionsRC_PositionsRCGuid",
                table: "LfPerson_PositionsRC",
                column: "PositionsRCGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibility_ResearchersRC_ResearchersRCGuid",
                table: "LfPossibility_ResearchersRC",
                column: "ResearchersRCGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibility_RestrictionsRC_RestrictionsRCGuid",
                table: "LfPossibility_RestrictionsRC",
                column: "RestrictionsRCGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LocationPerson_PlacesOfResidenceRCGuid",
                table: "LocationPerson",
                column: "PlacesOfResidenceRCGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Media_LexPronunciationGuid",
                table: "Media",
                column: "LexPronunciationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Media_MediaFileRAGuid",
                table: "Media",
                column: "MediaFileRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRule_StratumRAGuid",
                table: "MoCompoundRule",
                column: "StratumRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRule_WfiAnalysisGuid",
                table: "MoCompoundRule",
                column: "WfiAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRuleApp_LeftFormRAGuid",
                table: "MoCompoundRuleApp",
                column: "LeftFormRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRuleApp_LinkerRAGuid",
                table: "MoCompoundRuleApp",
                column: "LinkerRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRuleApp_MoStratumAppGuid",
                table: "MoCompoundRuleApp",
                column: "MoStratumAppGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoCompoundRuleApp_RightFormRAGuid",
                table: "MoCompoundRuleApp",
                column: "RightFormRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDeriv_InflectionalFeatsOAGuid",
                table: "MoDeriv",
                column: "InflectionalFeatsOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDeriv_StemFormRAGuid",
                table: "MoDeriv",
                column: "StemFormRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDeriv_StemMsaRAGuid",
                table: "MoDeriv",
                column: "StemMsaRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivAffApp_AffixFormRAGuid",
                table: "MoDerivAffApp",
                column: "AffixFormRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivAffApp_AffixMsaRAGuid",
                table: "MoDerivAffApp",
                column: "AffixMsaRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivAffApp_MoStratumAppGuid",
                table: "MoDerivAffApp",
                column: "MoStratumAppGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoDerivAffApp_OutputMsaOAGuid",
                table: "MoDerivAffApp",
                column: "OutputMsaOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoForm_LexEntryGuid",
                table: "MoForm",
                column: "LexEntryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoForm_MorphTypeRAGuid",
                table: "MoForm",
                column: "MorphTypeRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoForm_MsEnvFeaturesOAGuid",
                table: "MoForm",
                column: "MsEnvFeaturesOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoForm_MsEnvPartOfSpeechRAGuid",
                table: "MoForm",
                column: "MsEnvPartOfSpeechRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoForm_StemNameRAGuid",
                table: "MoForm",
                column: "StemNameRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoGlossItem_FeatStructFragOAGuid",
                table: "MoGlossItem",
                column: "FeatStructFragOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoGlossItem_MoMorphSynAnalysisGuid",
                table: "MoGlossItem",
                column: "MoMorphSynAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoGlossItem_TargetRAGuid",
                table: "MoGlossItem",
                column: "TargetRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlot_LexEntryInflTypeGuid",
                table: "MoInflAffixSlot",
                column: "LexEntryInflTypeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlot_MoInflAffixTemplateGuid",
                table: "MoInflAffixSlot",
                column: "MoInflAffixTemplateGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlot_MoInflAffixTemplateGuid1",
                table: "MoInflAffixSlot",
                column: "MoInflAffixTemplateGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlot_MoInflAffixTemplateGuid2",
                table: "MoInflAffixSlot",
                column: "MoInflAffixTemplateGuid2");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlot_MoInflAffixTemplateGuid3",
                table: "MoInflAffixSlot",
                column: "MoInflAffixTemplateGuid3");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlot_MoInflAffixTemplateGuid4",
                table: "MoInflAffixSlot",
                column: "MoInflAffixTemplateGuid4");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlot_MoInflAffMsaGuid",
                table: "MoInflAffixSlot",
                column: "MoInflAffMsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlot_MoStemMsaGuid",
                table: "MoInflAffixSlot",
                column: "MoStemMsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlot_PartOfSpeechGuid",
                table: "MoInflAffixSlot",
                column: "PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlotApp_AffixFormRAGuid",
                table: "MoInflAffixSlotApp",
                column: "AffixFormRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlotApp_AffixMsaRAGuid",
                table: "MoInflAffixSlotApp",
                column: "AffixMsaRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlotApp_MoInflTemplateAppGuid",
                table: "MoInflAffixSlotApp",
                column: "MoInflTemplateAppGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixSlotApp_SlotRAGuid",
                table: "MoInflAffixSlotApp",
                column: "SlotRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplate_PartOfSpeechGuid",
                table: "MoInflAffixTemplate",
                column: "PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplate_RegionOAGuid",
                table: "MoInflAffixTemplate",
                column: "RegionOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplate_StratumRAGuid",
                table: "MoInflAffixTemplate",
                column: "StratumRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflAffixTemplate_WfiAnalysisGuid",
                table: "MoInflAffixTemplate",
                column: "WfiAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflClass_MoAffixFormGuid",
                table: "MoInflClass",
                column: "MoAffixFormGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflClass_MoInflClassGuid",
                table: "MoInflClass",
                column: "MoInflClassGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflClass_PartOfSpeechGuid",
                table: "MoInflClass",
                column: "PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoInflTemplateApp_TemplateRAGuid",
                table: "MoInflTemplateApp",
                column: "TemplateRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_AffixCategoryRAGuid",
                table: "MoMorphSynAnalysis",
                column: "AffixCategoryRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_AffixCategoryRAGuid1",
                table: "MoMorphSynAnalysis",
                column: "MoDerivAffMsa_AffixCategoryRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_FromInflectionClassRAGuid",
                table: "MoMorphSynAnalysis",
                column: "FromInflectionClassRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_FromMsFeaturesOAGuid",
                table: "MoMorphSynAnalysis",
                column: "FromMsFeaturesOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_FromPartOfSpeechRAGuid",
                table: "MoMorphSynAnalysis",
                column: "FromPartOfSpeechRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_FromStemNameRAGuid",
                table: "MoMorphSynAnalysis",
                column: "FromStemNameRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_InflectionClassRAGuid",
                table: "MoMorphSynAnalysis",
                column: "InflectionClassRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_InflectionClassRAGuid1",
                table: "MoMorphSynAnalysis",
                column: "MoStemMsa_InflectionClassRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_InflFeatsOAGuid",
                table: "MoMorphSynAnalysis",
                column: "InflFeatsOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_InflFeatsOAGuid1",
                table: "MoMorphSynAnalysis",
                column: "MoDerivStepMsa_InflFeatsOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_LexEntryGuid",
                table: "MoMorphSynAnalysis",
                column: "LexEntryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_MoMorphSynAnalysisGuid",
                table: "MoMorphSynAnalysis",
                column: "MoMorphSynAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_MsFeaturesOAGuid",
                table: "MoMorphSynAnalysis",
                column: "MsFeaturesOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_MsFeaturesOAGuid1",
                table: "MoMorphSynAnalysis",
                column: "MoStemMsa_MsFeaturesOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_PartOfSpeechRAGuid",
                table: "MoMorphSynAnalysis",
                column: "PartOfSpeechRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_PartOfSpeechRAGuid1",
                table: "MoMorphSynAnalysis",
                column: "MoDerivStepMsa_PartOfSpeechRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_PartOfSpeechRAGuid2",
                table: "MoMorphSynAnalysis",
                column: "MoStemMsa_PartOfSpeechRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_StratumRAGuid",
                table: "MoMorphSynAnalysis",
                column: "StratumRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_StratumRAGuid1",
                table: "MoMorphSynAnalysis",
                column: "MoStemMsa_StratumRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_ToInflectionClassRAGuid",
                table: "MoMorphSynAnalysis",
                column: "ToInflectionClassRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_ToMsFeaturesOAGuid",
                table: "MoMorphSynAnalysis",
                column: "ToMsFeaturesOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoMorphSynAnalysis_ToPartOfSpeechRAGuid",
                table: "MoMorphSynAnalysis",
                column: "ToPartOfSpeechRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoPhonolRuleApp_MoStratumAppGuid",
                table: "MoPhonolRuleApp",
                column: "MoStratumAppGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoReferralRule_InputOAGuid",
                table: "MoReferralRule",
                column: "InputOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoReferralRule_MoInflClassGuid",
                table: "MoReferralRule",
                column: "MoInflClassGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoReferralRule_OutputOAGuid",
                table: "MoReferralRule",
                column: "OutputOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoReferralRule_PartOfSpeechGuid",
                table: "MoReferralRule",
                column: "PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemName_DefaultAffixRAGuid",
                table: "MoStemName",
                column: "DefaultAffixRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemName_DefaultStemRAGuid",
                table: "MoStemName",
                column: "DefaultStemRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemName_MoInflClassGuid",
                table: "MoStemName",
                column: "MoInflClassGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStemName_PartOfSpeechGuid",
                table: "MoStemName",
                column: "PartOfSpeechGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStratum_PhonemesRAGuid",
                table: "MoStratum",
                column: "PhonemesRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStratumApp_MoDerivGuid",
                table: "MoStratumApp",
                column: "MoDerivGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStratumApp_StratumRAGuid",
                table: "MoStratumApp",
                column: "StratumRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_MoStratumApp_TemplateAppOAGuid",
                table: "MoStratumApp",
                column: "TemplateAppOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Note_SegmentGuid",
                table: "Note",
                column: "SegmentGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhBdryMarker_PhPhonemeSetGuid",
                table: "PhBdryMarker",
                column: "PhPhonemeSetGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhCode_PhBdryMarkerGuid",
                table: "PhCode",
                column: "PhBdryMarkerGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhCode_PhPhonemeGuid",
                table: "PhCode",
                column: "PhPhonemeGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhEnvironment_LeftContextRAGuid",
                table: "PhEnvironment",
                column: "LeftContextRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhEnvironment_MoAffixAllomorphGuid",
                table: "PhEnvironment",
                column: "MoAffixAllomorphGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhEnvironment_MoAffixAllomorphGuid1",
                table: "PhEnvironment",
                column: "MoAffixAllomorphGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_PhEnvironment_MoStemAllomorphGuid",
                table: "PhEnvironment",
                column: "MoStemAllomorphGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhEnvironment_RightContextRAGuid",
                table: "PhEnvironment",
                column: "RightContextRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhPhonContext_DescriptionOAGuid",
                table: "PhPhonContext",
                column: "DescriptionOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhPhoneme_FeaturesOAGuid",
                table: "PhPhoneme",
                column: "FeaturesOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PhPhoneme_PhPhonemeSetGuid",
                table: "PhPhoneme",
                column: "PhPhonemeSetGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_LexSenseGuid",
                table: "Picture",
                column: "LexSenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_PictureFileRAGuid",
                table: "Picture",
                column: "PictureFileRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_ConfidenceRAGuid",
                table: "Possibilities",
                column: "ConfidenceRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_DefaultFeaturesOAGuid",
                table: "Possibilities",
                column: "DefaultFeaturesOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_DefaultInflectionClassRAGuid",
                table: "Possibilities",
                column: "DefaultInflectionClassRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_DiscussionOAGuid",
                table: "Possibilities",
                column: "DiscussionOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_EducationRAGuid",
                table: "Possibilities",
                column: "EducationRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_InflFeatsOAGuid",
                table: "Possibilities",
                column: "InflFeatsOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_InherFeatValOAGuid",
                table: "Possibilities",
                column: "InherFeatValOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexEntryGuid",
                table: "Possibilities",
                column: "LexEntryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexEntryGuid1",
                table: "Possibilities",
                column: "LexEntryGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexEntryGuid2",
                table: "Possibilities",
                column: "LexEntryGuid2");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexEntryRefGuid",
                table: "Possibilities",
                column: "LexEntryRefGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexEntryRefGuid1",
                table: "Possibilities",
                column: "LexEntryRefGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexEtymologyGuid",
                table: "Possibilities",
                column: "LexEtymologyGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexPronunciationGuid",
                table: "Possibilities",
                column: "LexPronunciationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexSenseGuid",
                table: "Possibilities",
                column: "LexSenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexSenseGuid1",
                table: "Possibilities",
                column: "LexSenseGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexSenseGuid2",
                table: "Possibilities",
                column: "LexSenseGuid2");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexSenseGuid3",
                table: "Possibilities",
                column: "LexSenseGuid3");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexSenseGuid4",
                table: "Possibilities",
                column: "LexSenseGuid4");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexSenseGuid5",
                table: "Possibilities",
                column: "LexSenseGuid5");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LexSenseGuid6",
                table: "Possibilities",
                column: "SemanticDomain_LexSenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_MoCompoundRuleGuid",
                table: "Possibilities",
                column: "MoCompoundRuleGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_MoDerivAffMsaGuid",
                table: "Possibilities",
                column: "MoDerivAffMsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_MoDerivAffMsaGuid1",
                table: "Possibilities",
                column: "MoDerivAffMsaGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_MoDerivStepMsaGuid",
                table: "Possibilities",
                column: "MoDerivStepMsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_MoInflAffMsaGuid",
                table: "Possibilities",
                column: "MoInflAffMsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_MoStemMsaGuid",
                table: "Possibilities",
                column: "MoStemMsaGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_MoStemMsaGuid1",
                table: "Possibilities",
                column: "MoStemMsaGuid1");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_ParentPossibilityGuid",
                table: "Possibilities",
                column: "ParentPossibilityGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_PictureGuid",
                table: "Possibilities",
                column: "PictureGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_PlaceOfBirthRAGuid",
                table: "Possibilities",
                column: "PlaceOfBirthRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_PossibilityListGuid",
                table: "Possibilities",
                column: "PossibilityListGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_SemanticDomainGuid",
                table: "Possibilities",
                column: "SemanticDomainGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_SemanticDomainGuid1",
                table: "Possibilities",
                column: "SemanticDomain_SemanticDomainGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_StatusRAGuid",
                table: "Possibilities",
                column: "StatusRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubDivision_HFSetOAGuid",
                table: "PubDivision",
                column: "HFSetOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubDivision_PageLayoutOAGuid",
                table: "PubDivision",
                column: "PageLayoutOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubDivision_PublicationGuid",
                table: "PubDivision",
                column: "PublicationGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSet_DefaultFooterOAGuid",
                table: "PubHFSet",
                column: "DefaultFooterOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSet_DefaultHeaderOAGuid",
                table: "PubHFSet",
                column: "DefaultHeaderOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSet_EvenFooterOAGuid",
                table: "PubHFSet",
                column: "EvenFooterOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSet_EvenHeaderOAGuid",
                table: "PubHFSet",
                column: "EvenHeaderOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSet_FirstFooterOAGuid",
                table: "PubHFSet",
                column: "FirstFooterOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSet_FirstHeaderOAGuid",
                table: "PubHFSet",
                column: "FirstHeaderOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_PubHFSet_PossibilityListGuid",
                table: "PubHFSet",
                column: "PossibilityListGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Publication_PossibilityListGuid",
                table: "Publication",
                column: "PossibilityListGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Segment_MediaURIRAGuid",
                table: "Segment",
                column: "MediaURIRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Segment_SpeakerRAGuid",
                table: "Segment",
                column: "SpeakerRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Senses_LexEntryGuid",
                table: "Senses",
                column: "LexEntryGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Senses_LexSenseGuid",
                table: "Senses",
                column: "LexSenseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Senses_MorphoSyntaxAnalysisRAGuid",
                table: "Senses",
                column: "MorphoSyntaxAnalysisRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Senses_SenseTypeRAGuid",
                table: "Senses",
                column: "SenseTypeRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Senses_StatusRAGuid",
                table: "Senses",
                column: "StatusRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_StPara_StTextGuid",
                table: "StPara",
                column: "StTextGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TextTag_BeginSegmentRAGuid",
                table: "TextTag",
                column: "BeginSegmentRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TextTag_EndSegmentRAGuid",
                table: "TextTag",
                column: "EndSegmentRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TextTag_StTextGuid",
                table: "TextTag",
                column: "StTextGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TextTag_TagRAGuid",
                table: "TextTag",
                column: "TagRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_LexExampleSentenceGuid",
                table: "Translation",
                column: "LexExampleSentenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Translation_TypeRAGuid",
                table: "Translation",
                column: "TypeRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysis_CategoryRAGuid",
                table: "WfiAnalysis",
                column: "CategoryRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysis_DerivationOAGuid",
                table: "WfiAnalysis",
                column: "DerivationOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysis_MsFeaturesOAGuid",
                table: "WfiAnalysis",
                column: "MsFeaturesOAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiAnalysis_WfiWordformGuid",
                table: "WfiAnalysis",
                column: "WfiWordformGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiGloss_WfiAnalysisGuid",
                table: "WfiGloss",
                column: "WfiAnalysisGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiMorphBundle_InflTypeRAGuid",
                table: "WfiMorphBundle",
                column: "InflTypeRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiMorphBundle_MorphRAGuid",
                table: "WfiMorphBundle",
                column: "MorphRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiMorphBundle_MsaRAGuid",
                table: "WfiMorphBundle",
                column: "MsaRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiMorphBundle_SenseRAGuid",
                table: "WfiMorphBundle",
                column: "SenseRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_WfiMorphBundle_WfiAnalysisGuid",
                table: "WfiMorphBundle",
                column: "WfiAnalysisGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_AgentEvaluation_WfiAnalysis_WfiAnalysisTempId1",
                table: "AgentEvaluation",
                column: "WfiAnalysisGuid",
                principalTable: "WfiAnalysis",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Analysis_Segment_SegmentTempId2",
                table: "Analysis",
                column: "SegmentGuid",
                principalTable: "Segment",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Analysis_WfiAnalysis_AnalysisTempId",
                table: "Analysis",
                column: "AnalysisGuid",
                principalTable: "WfiAnalysis",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DomainQ_Possibilities_SemanticDomainTempId18",
                table: "DomainQ",
                column: "SemanticDomainGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_MoForm_LexemeFormOATempId3",
                table: "Entries",
                column: "LexemeFormOAGuid",
                principalTable: "MoForm",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_WfiAnalysis_WfiAnalysisTempId2",
                table: "Entries",
                column: "WfiAnalysisGuid",
                principalTable: "WfiAnalysis",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_ExampleSentences_LexExtendedNote_LexExtendedNoteTempId",
                table: "ExampleSentences",
                column: "LexExtendedNoteGuid",
                principalTable: "LexExtendedNote",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_ExampleSentences_Senses_LexSenseTempId2",
                table: "ExampleSentences",
                column: "LexSenseGuid",
                principalTable: "Senses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_FsFeatDefn_FsFeatureSpecification_DefaultOAGuid",
                table: "FsFeatDefn",
                column: "DefaultOAGuid",
                principalTable: "FsFeatureSpecification",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_FsFeatDefn_Possibilities_PartOfSpeechTempId15",
                table: "FsFeatDefn",
                column: "PartOfSpeechGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_FsFeatDefn_Possibilities_PartOfSpeechTempId8",
                table: "FsFeatDefn",
                column: "PartOfSpeechGuid1",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_FsFeatStruc_MoInflClass_MoInflClassTempId4",
                table: "FsFeatStruc",
                column: "MoInflClassGuid",
                principalTable: "MoInflClass",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_FsFeatStruc_MoStemName_MoStemNameTempId2",
                table: "FsFeatStruc",
                column: "MoStemNameGuid",
                principalTable: "MoStemName",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_FsFeatStruc_Possibilities_PartOfSpeechTempId16",
                table: "FsFeatStruc",
                column: "PartOfSpeechGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_FsFeatStruc_Possibilities_PartOfSpeechTempId9",
                table: "FsFeatStruc",
                column: "PartOfSpeechGuid1",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_LexAppendix_Senses_LexSenseTempId1",
                table: "LexAppendix",
                column: "LexSenseGuid",
                principalTable: "Senses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_LexExtendedNote_Possibilities_ExtendedNoteTypeRATempId3",
                table: "LexExtendedNote",
                column: "ExtendedNoteTypeRAGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_LexExtendedNote_Senses_LexSenseTempId3",
                table: "LexExtendedNote",
                column: "LexSenseGuid",
                principalTable: "Senses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_LexPronunciation_Possibilities_LocationRATempId20",
                table: "LexPronunciation",
                column: "LocationRAGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_LexReference_Possibilities_LexRefTypeTempId7",
                table: "LexReference",
                column: "LexRefTypeGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_LexExampleSentence_DoNotPublishInRC_Possibilities_DoNotPu~",
                table: "LfLexExampleSentence_DoNotPublishInRC",
                column: "DoNotPublishInRCGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PositionsRC_Possibilities_Person1Guid",
                table: "LfPerson_PositionsRC",
                column: "Person1Guid",
                principalTable: "Possibilities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_PositionsRC_Possibilities_PositionsRCGuid",
                table: "LfPerson_PositionsRC",
                column: "PositionsRCGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_ResearchersRC_Possibilities_Possibility1Guid",
                table: "LfPossibility_ResearchersRC",
                column: "Possibility1Guid",
                principalTable: "Possibilities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_ResearchersRC_Possibilities_ResearchersRCGuid",
                table: "LfPossibility_ResearchersRC",
                column: "ResearchersRCGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_RestrictionsRC_Possibilities_PossibilityGuid",
                table: "LfPossibility_RestrictionsRC",
                column: "PossibilityGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_RestrictionsRC_Possibilities_RestrictionsRCGu~",
                table: "LfPossibility_RestrictionsRC",
                column: "RestrictionsRCGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationPerson_Possibilities_PersonGuid",
                table: "LocationPerson",
                column: "PersonGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LocationPerson_Possibilities_PlacesOfResidenceRCGuid",
                table: "LocationPerson",
                column: "PlacesOfResidenceRCGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRule_WfiAnalysis_WfiAnalysisTempId3",
                table: "MoCompoundRule",
                column: "WfiAnalysisGuid",
                principalTable: "WfiAnalysis",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRuleApp_MoForm_LeftFormRATempId2",
                table: "MoCompoundRuleApp",
                column: "LeftFormRAGuid",
                principalTable: "MoForm",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRuleApp_MoForm_LinkerRATempId8",
                table: "MoCompoundRuleApp",
                column: "LinkerRAGuid",
                principalTable: "MoForm",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRuleApp_MoForm_RightFormRATempId10",
                table: "MoCompoundRuleApp",
                column: "RightFormRAGuid",
                principalTable: "MoForm",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoCompoundRuleApp_MoStratumApp_MoStratumAppTempId",
                table: "MoCompoundRuleApp",
                column: "MoStratumAppGuid",
                principalTable: "MoStratumApp",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDeriv_MoForm_StemFormRATempId11",
                table: "MoDeriv",
                column: "StemFormRAGuid",
                principalTable: "MoForm",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDeriv_MoMorphSynAnalysis_StemMsaRATempId16",
                table: "MoDeriv",
                column: "StemMsaRAGuid",
                principalTable: "MoMorphSynAnalysis",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivAffApp_MoForm_AffixFormRATempId",
                table: "MoDerivAffApp",
                column: "AffixFormRAGuid",
                principalTable: "MoForm",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivAffApp_MoMorphSynAnalysis_AffixMsaRATempId",
                table: "MoDerivAffApp",
                column: "AffixMsaRAGuid",
                principalTable: "MoMorphSynAnalysis",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivAffApp_MoMorphSynAnalysis_OutputMsaOATempId15",
                table: "MoDerivAffApp",
                column: "OutputMsaOAGuid",
                principalTable: "MoMorphSynAnalysis",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoDerivAffApp_MoStratumApp_MoStratumAppTempId1",
                table: "MoDerivAffApp",
                column: "MoStratumAppGuid",
                principalTable: "MoStratumApp",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoForm_MoStemName_StemNameRATempId3",
                table: "MoForm",
                column: "StemNameRAGuid",
                principalTable: "MoStemName",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoForm_Possibilities_MorphTypeRATempId21",
                table: "MoForm",
                column: "MorphTypeRAGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoForm_Possibilities_MsEnvPartOfSpeechRATempId22",
                table: "MoForm",
                column: "MsEnvPartOfSpeechRAGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoGlossItem_MoMorphSynAnalysis_MoMorphSynAnalysisTempId8",
                table: "MoGlossItem",
                column: "MoMorphSynAnalysisGuid",
                principalTable: "MoMorphSynAnalysis",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlot_MoInflAffixTemplate_MoInflAffixTemplateTemp~",
                table: "MoInflAffixSlot",
                column: "MoInflAffixTemplateGuid",
                principalTable: "MoInflAffixTemplate",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlot_MoInflAffixTemplate_MoInflAffixTemplateTem~1",
                table: "MoInflAffixSlot",
                column: "MoInflAffixTemplateGuid1",
                principalTable: "MoInflAffixTemplate",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlot_MoInflAffixTemplate_MoInflAffixTemplateTem~2",
                table: "MoInflAffixSlot",
                column: "MoInflAffixTemplateGuid2",
                principalTable: "MoInflAffixTemplate",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlot_MoInflAffixTemplate_MoInflAffixTemplateTem~3",
                table: "MoInflAffixSlot",
                column: "MoInflAffixTemplateGuid3",
                principalTable: "MoInflAffixTemplate",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlot_MoInflAffixTemplate_MoInflAffixTemplateTem~4",
                table: "MoInflAffixSlot",
                column: "MoInflAffixTemplateGuid4",
                principalTable: "MoInflAffixTemplate",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlot_MoMorphSynAnalysis_MoInflAffMsaTempId6",
                table: "MoInflAffixSlot",
                column: "MoInflAffMsaGuid",
                principalTable: "MoMorphSynAnalysis",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlot_MoMorphSynAnalysis_MoStemMsaTempId10",
                table: "MoInflAffixSlot",
                column: "MoStemMsaGuid",
                principalTable: "MoMorphSynAnalysis",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlot_Possibilities_LexEntryInflTypeTempId6",
                table: "MoInflAffixSlot",
                column: "LexEntryInflTypeGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlot_Possibilities_PartOfSpeechTempId10",
                table: "MoInflAffixSlot",
                column: "PartOfSpeechGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlotApp_MoInflTemplateApp_MoInflTemplateAppTempId",
                table: "MoInflAffixSlotApp",
                column: "MoInflTemplateAppGuid",
                principalTable: "MoInflTemplateApp",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixSlotApp_MoMorphSynAnalysis_AffixMsaRATempId1",
                table: "MoInflAffixSlotApp",
                column: "AffixMsaRAGuid",
                principalTable: "MoMorphSynAnalysis",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixTemplate_Possibilities_PartOfSpeechTempId11",
                table: "MoInflAffixTemplate",
                column: "PartOfSpeechGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflAffixTemplate_WfiAnalysis_WfiAnalysisTempId4",
                table: "MoInflAffixTemplate",
                column: "WfiAnalysisGuid",
                principalTable: "WfiAnalysis",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoInflClass_Possibilities_PartOfSpeechTempId12",
                table: "MoInflClass",
                column: "PartOfSpeechGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysis_MoStemName_FromStemNameRATempId1",
                table: "MoMorphSynAnalysis",
                column: "FromStemNameRAGuid",
                principalTable: "MoStemName",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_AffixCategoryRATempId",
                table: "MoMorphSynAnalysis",
                column: "MoDerivAffMsa_AffixCategoryRAGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_AffixCategoryRATempId1",
                table: "MoMorphSynAnalysis",
                column: "AffixCategoryRAGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_FromPartOfSpeechRATempId4",
                table: "MoMorphSynAnalysis",
                column: "FromPartOfSpeechRAGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_PartOfSpeechRATempId23",
                table: "MoMorphSynAnalysis",
                column: "MoDerivStepMsa_PartOfSpeechRAGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_PartOfSpeechRATempId24",
                table: "MoMorphSynAnalysis",
                column: "PartOfSpeechRAGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_PartOfSpeechRATempId25",
                table: "MoMorphSynAnalysis",
                column: "MoStemMsa_PartOfSpeechRAGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_ToPartOfSpeechRATempId30",
                table: "MoMorphSynAnalysis",
                column: "ToPartOfSpeechRAGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoReferralRule_Possibilities_PartOfSpeechTempId13",
                table: "MoReferralRule",
                column: "PartOfSpeechGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_MoStemName_Possibilities_PartOfSpeechTempId14",
                table: "MoStemName",
                column: "PartOfSpeechGuid",
                principalTable: "Possibilities",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Segment_SegmentTempId3",
                table: "Note",
                column: "SegmentGuid",
                principalTable: "Segment",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Senses_LexSenseGuid",
                table: "Picture",
                column: "LexSenseGuid",
                principalTable: "Senses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Possibilities_Senses_LexSenseGuid1",
                table: "Possibilities",
                column: "LexSenseGuid1",
                principalTable: "Senses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Possibilities_Senses_LexSenseGuid2",
                table: "Possibilities",
                column: "LexSenseGuid2",
                principalTable: "Senses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Possibilities_Senses_LexSenseGuid3",
                table: "Possibilities",
                column: "LexSenseGuid3",
                principalTable: "Senses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Possibilities_Senses_LexSenseGuid4",
                table: "Possibilities",
                column: "LexSenseGuid4",
                principalTable: "Senses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Possibilities_Senses_LexSenseGuid5",
                table: "Possibilities",
                column: "LexSenseGuid5",
                principalTable: "Senses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_Senses_LexSenseTempId",
                table: "Possibilities",
                column: "LexSenseGuid",
                principalTable: "Senses",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Possibility_Senses_LexSenseTempId6",
                table: "Possibilities",
                column: "SemanticDomain_LexSenseGuid",
                principalTable: "Senses",
                principalColumn: "Guid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_WfiAnalysis_WfiAnalysisTempId2",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_MoCompoundRule_WfiAnalysis_WfiAnalysisTempId3",
                table: "MoCompoundRule");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatDefn_Possibilities_PartOfSpeechTempId15",
                table: "FsFeatDefn");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatDefn_Possibilities_PartOfSpeechTempId8",
                table: "FsFeatDefn");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatStruc_Possibilities_PartOfSpeechTempId16",
                table: "FsFeatStruc");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatStruc_Possibilities_PartOfSpeechTempId9",
                table: "FsFeatStruc");

            migrationBuilder.DropForeignKey(
                name: "FK_LexPronunciation_Possibilities_LocationRATempId20",
                table: "LexPronunciation");

            migrationBuilder.DropForeignKey(
                name: "FK_MoForm_Possibilities_MorphTypeRATempId21",
                table: "MoForm");

            migrationBuilder.DropForeignKey(
                name: "FK_MoForm_Possibilities_MsEnvPartOfSpeechRATempId22",
                table: "MoForm");

            migrationBuilder.DropForeignKey(
                name: "FK_MoInflClass_Possibilities_PartOfSpeechTempId12",
                table: "MoInflClass");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_AffixCategoryRATempId",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_AffixCategoryRATempId1",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_FromPartOfSpeechRATempId4",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_PartOfSpeechRATempId23",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_PartOfSpeechRATempId24",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_PartOfSpeechRATempId25",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_Possibilities_ToPartOfSpeechRATempId30",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_MoStemName_Possibilities_PartOfSpeechTempId14",
                table: "MoStemName");

            migrationBuilder.DropForeignKey(
                name: "FK_Senses_Possibilities_SenseTypeRATempId26",
                table: "Senses");

            migrationBuilder.DropForeignKey(
                name: "FK_Senses_Possibilities_StatusRATempId28",
                table: "Senses");

            migrationBuilder.DropForeignKey(
                name: "FK_Entries_MoForm_LexemeFormOATempId3",
                table: "Entries");

            migrationBuilder.DropForeignKey(
                name: "FK_MoInflClass_MoForm_MoAffixFormGuid",
                table: "MoInflClass");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatDefn_FsFeatStrucType_FsFeatStrucTypeTempId",
                table: "FsFeatDefn");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatStruc_FsFeatStrucType_TypeRATempId1",
                table: "FsFeatStruc");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatDefn_FsFeatureSpecification_DefaultOAGuid",
                table: "FsFeatDefn");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatStruc_MoInflClass_MoInflClassTempId4",
                table: "FsFeatStruc");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_MoInflClass_FromInflectionClassRATempI~",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_MoInflClass_InflectionClassRATempId2",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_MoInflClass_InflectionClassRATempId3",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_MoInflClass_ToInflectionClassRATempId8",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropForeignKey(
                name: "FK_MoStemName_MoInflClass_MoInflClassGuid",
                table: "MoStemName");

            migrationBuilder.DropForeignKey(
                name: "FK_FsFeatStruc_MoStemName_MoStemNameTempId2",
                table: "FsFeatStruc");

            migrationBuilder.DropForeignKey(
                name: "FK_MoMorphSynAnalysis_MoStemName_FromStemNameRATempId1",
                table: "MoMorphSynAnalysis");

            migrationBuilder.DropTable(
                name: "AgentEvaluation");

            migrationBuilder.DropTable(
                name: "Analysis");

            migrationBuilder.DropTable(
                name: "DomainQ");

            migrationBuilder.DropTable(
                name: "FsFeatStrucFsFeatStrucDisj");

            migrationBuilder.DropTable(
                name: "LexAppendix");

            migrationBuilder.DropTable(
                name: "LexReference");

            migrationBuilder.DropTable(
                name: "LfLexExampleSentence_DoNotPublishInRC");

            migrationBuilder.DropTable(
                name: "LfPerson_PositionsRC");

            migrationBuilder.DropTable(
                name: "LfPossibility_ResearchersRC");

            migrationBuilder.DropTable(
                name: "LfPossibility_RestrictionsRC");

            migrationBuilder.DropTable(
                name: "LocationPerson");

            migrationBuilder.DropTable(
                name: "Media");

            migrationBuilder.DropTable(
                name: "MoCompoundRuleApp");

            migrationBuilder.DropTable(
                name: "MoDerivAffApp");

            migrationBuilder.DropTable(
                name: "MoGlossItem");

            migrationBuilder.DropTable(
                name: "MoInflAffixSlotApp");

            migrationBuilder.DropTable(
                name: "MoPhonolRuleApp");

            migrationBuilder.DropTable(
                name: "MoReferralRule");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "PhCode");

            migrationBuilder.DropTable(
                name: "PhEnvironment");

            migrationBuilder.DropTable(
                name: "PubDivision");

            migrationBuilder.DropTable(
                name: "StPara");

            migrationBuilder.DropTable(
                name: "TextTag");

            migrationBuilder.DropTable(
                name: "Translation");

            migrationBuilder.DropTable(
                name: "WfiGloss");

            migrationBuilder.DropTable(
                name: "WfiMorphBundle");

            migrationBuilder.DropTable(
                name: "FsFeatStrucDisj");

            migrationBuilder.DropTable(
                name: "MoInflAffixSlot");

            migrationBuilder.DropTable(
                name: "MoStratumApp");

            migrationBuilder.DropTable(
                name: "PhBdryMarker");

            migrationBuilder.DropTable(
                name: "PhPhoneme");

            migrationBuilder.DropTable(
                name: "PhPhonContext");

            migrationBuilder.DropTable(
                name: "PubHFSet");

            migrationBuilder.DropTable(
                name: "PubPageLayout");

            migrationBuilder.DropTable(
                name: "Publication");

            migrationBuilder.DropTable(
                name: "Segment");

            migrationBuilder.DropTable(
                name: "ExampleSentences");

            migrationBuilder.DropTable(
                name: "MoInflTemplateApp");

            migrationBuilder.DropTable(
                name: "PubHeader");

            migrationBuilder.DropTable(
                name: "MediaURI");

            migrationBuilder.DropTable(
                name: "LexExtendedNote");

            migrationBuilder.DropTable(
                name: "MoInflAffixTemplate");

            migrationBuilder.DropTable(
                name: "WfiAnalysis");

            migrationBuilder.DropTable(
                name: "MoDeriv");

            migrationBuilder.DropTable(
                name: "WfiWordform");

            migrationBuilder.DropTable(
                name: "Possibilities");

            migrationBuilder.DropTable(
                name: "LexEtymology");

            migrationBuilder.DropTable(
                name: "LexPronunciation");

            migrationBuilder.DropTable(
                name: "MoCompoundRule");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "PossibilityLists");

            migrationBuilder.DropTable(
                name: "StText");

            migrationBuilder.DropTable(
                name: "LexEntryRef");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Senses");

            migrationBuilder.DropTable(
                name: "MoForm");

            migrationBuilder.DropTable(
                name: "FsFeatStrucType");

            migrationBuilder.DropTable(
                name: "FsFeatureSpecification");

            migrationBuilder.DropTable(
                name: "FsFeatDefn");

            migrationBuilder.DropTable(
                name: "MoInflClass");

            migrationBuilder.DropTable(
                name: "MoStemName");

            migrationBuilder.DropTable(
                name: "MoMorphSynAnalysis");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "FsFeatStruc");

            migrationBuilder.DropTable(
                name: "MoStratum");

            migrationBuilder.DropTable(
                name: "PhPhonemeSet");
        }
    }
}
