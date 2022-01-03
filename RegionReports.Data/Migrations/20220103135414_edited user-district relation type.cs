using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class editeduserdistrictrelationtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportUsers_Districts_DistrictId",
                table: "ReportUsers");

            migrationBuilder.DropIndex(
                name: "IX_ReportUsers_DistrictId",
                table: "ReportUsers");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "ReportUsers");

            migrationBuilder.AddColumn<int>(
                name: "ReportUserId",
                table: "Districts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Districts_ReportUserId",
                table: "Districts",
                column: "ReportUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_ReportUsers_ReportUserId",
                table: "Districts",
                column: "ReportUserId",
                principalTable: "ReportUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Districts_ReportUsers_ReportUserId",
                table: "Districts");

            migrationBuilder.DropIndex(
                name: "IX_Districts_ReportUserId",
                table: "Districts");

            migrationBuilder.DropColumn(
                name: "ReportUserId",
                table: "Districts");

            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "ReportUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReportUsers_DistrictId",
                table: "ReportUsers",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportUsers_Districts_DistrictId",
                table: "ReportUsers",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
