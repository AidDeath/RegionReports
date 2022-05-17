using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class Assignmentscoupledtoagroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportAssignmentGroupId",
                table: "ReportAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AssignmentGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignments_ReportAssignmentGroupId",
                table: "ReportAssignments",
                column: "ReportAssignmentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignments_AssignmentGroups_ReportAssignmentGroupId",
                table: "ReportAssignments",
                column: "ReportAssignmentGroupId",
                principalTable: "AssignmentGroups",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignments_AssignmentGroups_ReportAssignmentGroupId",
                table: "ReportAssignments");

            migrationBuilder.DropTable(
                name: "AssignmentGroups");

            migrationBuilder.DropIndex(
                name: "IX_ReportAssignments_ReportAssignmentGroupId",
                table: "ReportAssignments");

            migrationBuilder.DropColumn(
                name: "ReportAssignmentGroupId",
                table: "ReportAssignments");
        }
    }
}
