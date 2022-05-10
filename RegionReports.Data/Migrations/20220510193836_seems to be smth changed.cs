using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class seemstobesmthchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportSurveySelectedOptions_ReportRequestSurveyOptions_ReportRequestSurveyOptionId",
                table: "ReportSurveySelectedOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportSurveySelectedOptions_ReportsSurvey_ReportSurveyId",
                table: "ReportSurveySelectedOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportSurveySelectedOptions",
                table: "ReportSurveySelectedOptions");

            migrationBuilder.RenameTable(
                name: "ReportSurveySelectedOptions",
                newName: "ReportSurveySelectableOptions");

            migrationBuilder.RenameIndex(
                name: "IX_ReportSurveySelectedOptions_ReportSurveyId",
                table: "ReportSurveySelectableOptions",
                newName: "IX_ReportSurveySelectableOptions_ReportSurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportSurveySelectedOptions_ReportRequestSurveyOptionId",
                table: "ReportSurveySelectableOptions",
                newName: "IX_ReportSurveySelectableOptions_ReportRequestSurveyOptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportSurveySelectableOptions",
                table: "ReportSurveySelectableOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportSurveySelectableOptions_ReportRequestSurveyOptions_ReportRequestSurveyOptionId",
                table: "ReportSurveySelectableOptions",
                column: "ReportRequestSurveyOptionId",
                principalTable: "ReportRequestSurveyOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportSurveySelectableOptions_ReportsSurvey_ReportSurveyId",
                table: "ReportSurveySelectableOptions",
                column: "ReportSurveyId",
                principalTable: "ReportsSurvey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportSurveySelectableOptions_ReportRequestSurveyOptions_ReportRequestSurveyOptionId",
                table: "ReportSurveySelectableOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportSurveySelectableOptions_ReportsSurvey_ReportSurveyId",
                table: "ReportSurveySelectableOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportSurveySelectableOptions",
                table: "ReportSurveySelectableOptions");

            migrationBuilder.RenameTable(
                name: "ReportSurveySelectableOptions",
                newName: "ReportSurveySelectedOptions");

            migrationBuilder.RenameIndex(
                name: "IX_ReportSurveySelectableOptions_ReportSurveyId",
                table: "ReportSurveySelectedOptions",
                newName: "IX_ReportSurveySelectedOptions_ReportSurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportSurveySelectableOptions_ReportRequestSurveyOptionId",
                table: "ReportSurveySelectedOptions",
                newName: "IX_ReportSurveySelectedOptions_ReportRequestSurveyOptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportSurveySelectedOptions",
                table: "ReportSurveySelectedOptions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportSurveySelectedOptions_ReportRequestSurveyOptions_ReportRequestSurveyOptionId",
                table: "ReportSurveySelectedOptions",
                column: "ReportRequestSurveyOptionId",
                principalTable: "ReportRequestSurveyOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportSurveySelectedOptions_ReportsSurvey_ReportSurveyId",
                table: "ReportSurveySelectedOptions",
                column: "ReportSurveyId",
                principalTable: "ReportsSurvey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
