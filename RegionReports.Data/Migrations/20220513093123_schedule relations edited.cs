using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class schedulerelationsedited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReportRequestsSurvey_ReportScheduleId",
                table: "ReportRequestsSurvey");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestsSurvey_ReportScheduleId",
                table: "ReportRequestsSurvey",
                column: "ReportScheduleId",
                unique: true,
                filter: "[ReportScheduleId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReportRequestsSurvey_ReportScheduleId",
                table: "ReportRequestsSurvey");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestsSurvey_ReportScheduleId",
                table: "ReportRequestsSurvey",
                column: "ReportScheduleId");
        }
    }
}
