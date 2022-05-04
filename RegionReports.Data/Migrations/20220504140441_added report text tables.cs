using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class addedreporttexttables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReportTextId",
                table: "ReportAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReportsText",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepsonseString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportUserId = table.Column<int>(type: "int", nullable: false),
                    ReportAssignmentId = table.Column<int>(type: "int", nullable: false),
                    DateFilled = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsText", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportsText_ReportUsers_ReportUserId",
                        column: x => x.ReportUserId,
                        principalTable: "ReportUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignments_ReportTextId",
                table: "ReportAssignments",
                column: "ReportTextId",
                unique: true,
                filter: "[ReportTextId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsText_ReportUserId",
                table: "ReportsText",
                column: "ReportUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignments_ReportsText_ReportTextId",
                table: "ReportAssignments",
                column: "ReportTextId",
                principalTable: "ReportsText",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignments_ReportsText_ReportTextId",
                table: "ReportAssignments");

            migrationBuilder.DropTable(
                name: "ReportsText");

            migrationBuilder.DropIndex(
                name: "IX_ReportAssignments_ReportTextId",
                table: "ReportAssignments");

            migrationBuilder.DropColumn(
                name: "ReportTextId",
                table: "ReportAssignments");
        }
    }
}
