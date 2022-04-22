using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class Addedschedulesforreportrequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSchedulledRequest",
                table: "ReportRequestsText",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NonScheduledDeadline",
                table: "ReportRequestsText",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportSheduleId",
                table: "ReportRequestsText",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSchedulledRequest",
                table: "ReportRequestsSurvey",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "NonScheduledDeadline",
                table: "ReportRequestsSurvey",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportScheduleId",
                table: "ReportRequestsSurvey",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportSheduleId",
                table: "ReportRequestsSurvey",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReportSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleType = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayOfWeek = table.Column<short>(type: "smallint", nullable: false),
                    DayOfMonth = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSchedule", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestsText_ReportSheduleId",
                table: "ReportRequestsText",
                column: "ReportSheduleId",
                unique: true,
                filter: "[ReportSheduleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestsSurvey_ReportScheduleId",
                table: "ReportRequestsSurvey",
                column: "ReportScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequestsSurvey_ReportSchedule_ReportScheduleId",
                table: "ReportRequestsSurvey",
                column: "ReportScheduleId",
                principalTable: "ReportSchedule",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportRequestsText_ReportSchedule_ReportSheduleId",
                table: "ReportRequestsText",
                column: "ReportSheduleId",
                principalTable: "ReportSchedule",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequestsSurvey_ReportSchedule_ReportScheduleId",
                table: "ReportRequestsSurvey");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportRequestsText_ReportSchedule_ReportSheduleId",
                table: "ReportRequestsText");

            migrationBuilder.DropTable(
                name: "ReportSchedule");

            migrationBuilder.DropIndex(
                name: "IX_ReportRequestsText_ReportSheduleId",
                table: "ReportRequestsText");

            migrationBuilder.DropIndex(
                name: "IX_ReportRequestsSurvey_ReportScheduleId",
                table: "ReportRequestsSurvey");

            migrationBuilder.DropColumn(
                name: "IsSchedulledRequest",
                table: "ReportRequestsText");

            migrationBuilder.DropColumn(
                name: "NonScheduledDeadline",
                table: "ReportRequestsText");

            migrationBuilder.DropColumn(
                name: "ReportSheduleId",
                table: "ReportRequestsText");

            migrationBuilder.DropColumn(
                name: "IsSchedulledRequest",
                table: "ReportRequestsSurvey");

            migrationBuilder.DropColumn(
                name: "NonScheduledDeadline",
                table: "ReportRequestsSurvey");

            migrationBuilder.DropColumn(
                name: "ReportScheduleId",
                table: "ReportRequestsSurvey");

            migrationBuilder.DropColumn(
                name: "ReportSheduleId",
                table: "ReportRequestsSurvey");
        }
    }
}
