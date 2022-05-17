using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class fixedrelationasnGrouptoRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssignmentGroups_ReportRequestSurveyId",
                table: "AssignmentGroups");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentGroups_ReportRequestTextId",
                table: "AssignmentGroups");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGroups_ReportRequestSurveyId",
                table: "AssignmentGroups",
                column: "ReportRequestSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGroups_ReportRequestTextId",
                table: "AssignmentGroups",
                column: "ReportRequestTextId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AssignmentGroups_ReportRequestSurveyId",
                table: "AssignmentGroups");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentGroups_ReportRequestTextId",
                table: "AssignmentGroups");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGroups_ReportRequestSurveyId",
                table: "AssignmentGroups",
                column: "ReportRequestSurveyId",
                unique: true,
                filter: "[ReportRequestSurveyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGroups_ReportRequestTextId",
                table: "AssignmentGroups",
                column: "ReportRequestTextId",
                unique: true,
                filter: "[ReportRequestTextId] IS NOT NULL");
        }
    }
}
