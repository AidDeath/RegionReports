using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class uncommentedFluentAPI3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReportUserSuggestedChanges_RelatedDistrictId",
                table: "ReportUserSuggestedChanges",
                column: "RelatedDistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportUserSuggestedChanges_Districts_RelatedDistrictId",
                table: "ReportUserSuggestedChanges",
                column: "RelatedDistrictId",
                principalTable: "Districts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportUserSuggestedChanges_Districts_RelatedDistrictId",
                table: "ReportUserSuggestedChanges");

            migrationBuilder.DropIndex(
                name: "IX_ReportUserSuggestedChanges_RelatedDistrictId",
                table: "ReportUserSuggestedChanges");
        }
    }
}
