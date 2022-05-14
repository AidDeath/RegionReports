using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class nonScheduledDeadlinedeletedfronreport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NonScheduledDeadline",
                table: "ReportRequestsText");

            migrationBuilder.DropColumn(
                name: "NonScheduledDeadline",
                table: "ReportRequestsSurvey");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualDeadline",
                table: "ReportAssignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualDeadline",
                table: "ReportAssignments");

            migrationBuilder.AddColumn<DateTime>(
                name: "NonScheduledDeadline",
                table: "ReportRequestsText",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NonScheduledDeadline",
                table: "ReportRequestsSurvey",
                type: "datetime2",
                nullable: true);
        }
    }
}
