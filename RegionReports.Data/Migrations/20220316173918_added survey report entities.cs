using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class addedsurveyreportentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportRequestsSurvey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MultipleChoises = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequestsSurvey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportsSurvey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportUserId = table.Column<int>(type: "int", nullable: false),
                    DateFilled = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsSurvey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportsSurvey_ReportUsers_ReportUserId",
                        column: x => x.ReportUserId,
                        principalTable: "ReportUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportRequestSurveyOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportRequestSurveyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequestSurveyOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportRequestSurveyOptions_ReportRequestsSurvey_ReportRequestSurveyId",
                        column: x => x.ReportRequestSurveyId,
                        principalTable: "ReportRequestsSurvey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportSurveySelectedOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportSurveyId = table.Column<int>(type: "int", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false),
                    ReportRequestSurveyOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSurveySelectedOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportSurveySelectedOptions_ReportRequestSurveyOptions_ReportRequestSurveyOptionId",
                        column: x => x.ReportRequestSurveyOptionId,
                        principalTable: "ReportRequestSurveyOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportSurveySelectedOptions_ReportsSurvey_ReportSurveyId",
                        column: x => x.ReportSurveyId,
                        principalTable: "ReportsSurvey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestSurveyOptions_ReportRequestSurveyId",
                table: "ReportRequestSurveyOptions",
                column: "ReportRequestSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsSurvey_ReportUserId",
                table: "ReportsSurvey",
                column: "ReportUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSurveySelectedOptions_ReportRequestSurveyOptionId",
                table: "ReportSurveySelectedOptions",
                column: "ReportRequestSurveyOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSurveySelectedOptions_ReportSurveyId",
                table: "ReportSurveySelectedOptions",
                column: "ReportSurveyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportSurveySelectedOptions");

            migrationBuilder.DropTable(
                name: "ReportRequestSurveyOptions");

            migrationBuilder.DropTable(
                name: "ReportsSurvey");

            migrationBuilder.DropTable(
                name: "ReportRequestsSurvey");
        }
    }
}
