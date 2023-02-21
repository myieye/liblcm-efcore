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
                name: "ExampleSentences",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Example = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: false),
                    Reference = table.Column<LfTsString>(type: "jsonb", nullable: false),
                    LiftResidue = table.Column<string>(type: "text", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: false),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleSentences", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "LfTsString",
                columns: table => new
                {
                    Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Possibilities",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: false),
                    Abbreviation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: false),
                    Description = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: false),
                    SortSpec = table.Column<int>(type: "integer", nullable: false),
                    ConfidenceRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    StatusRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HelpId = table.Column<string>(type: "text", nullable: true),
                    ForeColor = table.Column<int>(type: "integer", nullable: false),
                    BackColor = table.Column<int>(type: "integer", nullable: false),
                    UnderColor = table.Column<int>(type: "integer", nullable: false),
                    UnderStyle = table.Column<int>(type: "integer", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsProtected = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    LfLexExampleSentenceGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentPossibilityGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    LfCmLocation_Alias = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Alias = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: true),
                    PlaceOfBirthRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    IsResearcher = table.Column<bool>(type: "boolean", nullable: true),
                    EducationRAGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: false),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possibilities", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Possibilities_ExampleSentences_LfLexExampleSentenceGuid",
                        column: x => x.LfLexExampleSentenceGuid,
                        principalTable: "ExampleSentences",
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
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Possibilities_Possibilities_ParentPossibilityGuid",
                        column: x => x.ParentPossibilityGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_Possibilities_Possibilities_PlaceOfBirthRAGuid",
                        column: x => x.PlaceOfBirthRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Possibilities_Possibilities_StatusRAGuid",
                        column: x => x.StatusRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "LfCmPerson_PlacesOfResidenceRC",
                columns: table => new
                {
                    LfCmPersonGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    PlacesOfResidenceRCGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LfCmPerson_PlacesOfResidenceRC", x => new { x.LfCmPersonGuid, x.PlacesOfResidenceRCGuid });
                    table.ForeignKey(
                        name: "FK_LfCmPerson_PlacesOfResidenceRC_Possibilities_LfCmPersonGuid",
                        column: x => x.LfCmPersonGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LfCmPerson_PlacesOfResidenceRC_Possibilities_PlacesOfReside~",
                        column: x => x.PlacesOfResidenceRCGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LfCmPerson_PositionsRC",
                columns: table => new
                {
                    LfCmPerson1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    PositionsRCGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LfCmPerson_PositionsRC", x => new { x.LfCmPerson1Guid, x.PositionsRCGuid });
                    table.ForeignKey(
                        name: "FK_LfCmPerson_PositionsRC_Possibilities_LfCmPerson1Guid",
                        column: x => x.LfCmPerson1Guid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LfCmPerson_PositionsRC_Possibilities_PositionsRCGuid",
                        column: x => x.PositionsRCGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LfCmPossibility_ResearchersRC",
                columns: table => new
                {
                    LfCmPossibility1Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    ResearchersRCGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LfCmPossibility_ResearchersRC", x => new { x.LfCmPossibility1Guid, x.ResearchersRCGuid });
                    table.ForeignKey(
                        name: "FK_LfCmPossibility_ResearchersRC_Possibilities_LfCmPossibility~",
                        column: x => x.LfCmPossibility1Guid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LfCmPossibility_ResearchersRC_Possibilities_ResearchersRCGu~",
                        column: x => x.ResearchersRCGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LfCmPossibility_RestrictionsRC",
                columns: table => new
                {
                    LfCmPossibilityGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    RestrictionsRCGuid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LfCmPossibility_RestrictionsRC", x => new { x.LfCmPossibilityGuid, x.RestrictionsRCGuid });
                    table.ForeignKey(
                        name: "FK_LfCmPossibility_RestrictionsRC_Possibilities_LfCmPossibilit~",
                        column: x => x.LfCmPossibilityGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LfCmPossibility_RestrictionsRC_Possibilities_RestrictionsRC~",
                        column: x => x.RestrictionsRCGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LfCmTranslation",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uuid", nullable: false),
                    Translation = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: false),
                    TypeRAGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<List<LfWsTsString>>(type: "jsonb", nullable: false),
                    LfLexExampleSentenceGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    Hvo = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<Guid>(type: "uuid", nullable: false),
                    OwningFlid = table.Column<int>(type: "integer", nullable: false),
                    OwnOrd = table.Column<int>(type: "integer", nullable: false),
                    ClassID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LfCmTranslation", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LfCmTranslation_ExampleSentences_LfLexExampleSentenceGuid",
                        column: x => x.LfLexExampleSentenceGuid,
                        principalTable: "ExampleSentences",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_LfCmTranslation_Possibilities_TypeRAGuid",
                        column: x => x.TypeRAGuid,
                        principalTable: "Possibilities",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LfCmPerson_PlacesOfResidenceRC_PlacesOfResidenceRCGuid",
                table: "LfCmPerson_PlacesOfResidenceRC",
                column: "PlacesOfResidenceRCGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LfCmPerson_PositionsRC_PositionsRCGuid",
                table: "LfCmPerson_PositionsRC",
                column: "PositionsRCGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LfCmPossibility_ResearchersRC_ResearchersRCGuid",
                table: "LfCmPossibility_ResearchersRC",
                column: "ResearchersRCGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LfCmPossibility_RestrictionsRC_RestrictionsRCGuid",
                table: "LfCmPossibility_RestrictionsRC",
                column: "RestrictionsRCGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LfCmTranslation_LfLexExampleSentenceGuid",
                table: "LfCmTranslation",
                column: "LfLexExampleSentenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LfCmTranslation_TypeRAGuid",
                table: "LfCmTranslation",
                column: "TypeRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_ConfidenceRAGuid",
                table: "Possibilities",
                column: "ConfidenceRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_EducationRAGuid",
                table: "Possibilities",
                column: "EducationRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_LfLexExampleSentenceGuid",
                table: "Possibilities",
                column: "LfLexExampleSentenceGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_ParentPossibilityGuid",
                table: "Possibilities",
                column: "ParentPossibilityGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_PlaceOfBirthRAGuid",
                table: "Possibilities",
                column: "PlaceOfBirthRAGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Possibilities_StatusRAGuid",
                table: "Possibilities",
                column: "StatusRAGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LfCmPerson_PlacesOfResidenceRC");

            migrationBuilder.DropTable(
                name: "LfCmPerson_PositionsRC");

            migrationBuilder.DropTable(
                name: "LfCmPossibility_ResearchersRC");

            migrationBuilder.DropTable(
                name: "LfCmPossibility_RestrictionsRC");

            migrationBuilder.DropTable(
                name: "LfCmTranslation");

            migrationBuilder.DropTable(
                name: "LfTsString");

            migrationBuilder.DropTable(
                name: "Possibilities");

            migrationBuilder.DropTable(
                name: "ExampleSentences");
        }
    }
}
