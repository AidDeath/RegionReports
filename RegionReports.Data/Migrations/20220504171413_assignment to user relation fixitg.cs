using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class assignmenttouserrelationfixitg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReportAssignments_ReportUserId",
                table: "ReportAssignments");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignments_ReportUserId",
                table: "ReportAssignments",
                column: "ReportUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ReportAssignments_ReportUserId",
                table: "ReportAssignments");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignments_ReportUserId",
                table: "ReportAssignments",
                column: "ReportUserId",
                unique: true);
        }
    }
}
