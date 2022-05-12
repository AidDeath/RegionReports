using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class clearunholyFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportAssignmentId",
                table: "ReportsText");

            migrationBuilder.DropColumn(
                name: "ReportAssignmentId",
                table: "ReportsSurvey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportAssignmentId",
                table: "ReportsText",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportAssignmentId",
                table: "ReportsSurvey",
                type: "int",
                nullable: true);
        }
    }
}
