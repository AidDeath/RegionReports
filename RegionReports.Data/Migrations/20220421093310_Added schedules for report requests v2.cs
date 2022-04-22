using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class Addedschedulesforreportrequestsv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequestsText_ReportSchedule_ReportSheduleId",
                table: "ReportRequestsText");

            migrationBuilder.DropIndex(
                name: "IX_ReportRequestsText_ReportSheduleId",
                table: "ReportRequestsText");

            migrationBuilder.DropColumn(
                name: "ReportSheduleId",
                table: "ReportRequestsSurvey");

            migrationBuilder.RenameColumn(
                name: "ReportSheduleId",
                table: "ReportRequestsText",
                newName: "ReportScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestsText_ReportScheduleId",
                table: "ReportRequestsText",
                column: "ReportScheduleId",
                unique: true,
                filter: "[ReportScheduleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequestsText_ReportSchedule_ReportScheduleId",
                table: "ReportRequestsText",
                column: "ReportScheduleId",
                principalTable: "ReportSchedule",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequestsText_ReportSchedule_ReportScheduleId",
                table: "ReportRequestsText");

            migrationBuilder.DropIndex(
                name: "IX_ReportRequestsText_ReportScheduleId",
                table: "ReportRequestsText");

            migrationBuilder.RenameColumn(
                name: "ReportScheduleId",
                table: "ReportRequestsText",
                newName: "ReportSheduleId");

            migrationBuilder.AddColumn<int>(
                name: "ReportSheduleId",
                table: "ReportRequestsSurvey",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestsText_ReportSheduleId",
                table: "ReportRequestsText",
                column: "ReportSheduleId",
                unique: true,
                filter: "[ReportSheduleId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequestsText_ReportSchedule_ReportSheduleId",
                table: "ReportRequestsText",
                column: "ReportSheduleId",
                principalTable: "ReportSchedule",
                principalColumn: "Id");
        }
    }
}
