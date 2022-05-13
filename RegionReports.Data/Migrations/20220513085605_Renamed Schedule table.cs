using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class RenamedScheduletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequestsSurvey_ReportSchedule_ReportScheduleId",
                table: "ReportRequestsSurvey");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequestsText_ReportSchedule_ReportScheduleId",
                table: "ReportRequestsText");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportSchedule",
                table: "ReportSchedule");

            migrationBuilder.RenameTable(
                name: "ReportSchedule",
                newName: "ReportSchedules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportSchedules",
                table: "ReportSchedules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequestsSurvey_ReportSchedules_ReportScheduleId",
                table: "ReportRequestsSurvey",
                column: "ReportScheduleId",
                principalTable: "ReportSchedules",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequestsText_ReportSchedules_ReportScheduleId",
                table: "ReportRequestsText",
                column: "ReportScheduleId",
                principalTable: "ReportSchedules",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequestsSurvey_ReportSchedules_ReportScheduleId",
                table: "ReportRequestsSurvey");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequestsText_ReportSchedules_ReportScheduleId",
                table: "ReportRequestsText");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportSchedules",
                table: "ReportSchedules");

            migrationBuilder.RenameTable(
                name: "ReportSchedules",
                newName: "ReportSchedule");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportSchedule",
                table: "ReportSchedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequestsSurvey_ReportSchedule_ReportScheduleId",
                table: "ReportRequestsSurvey",
                column: "ReportScheduleId",
                principalTable: "ReportSchedule",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequestsText_ReportSchedule_ReportScheduleId",
                table: "ReportRequestsText",
                column: "ReportScheduleId",
                principalTable: "ReportSchedule",
                principalColumn: "Id");
        }
    }
}
