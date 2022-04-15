using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class Addedtextreportentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportRequestsText",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequestsText", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportRequestFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileUniqueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportRequestTextId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequestFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportRequestFiles_ReportRequestsText_ReportRequestTextId",
                        column: x => x.ReportRequestTextId,
                        principalTable: "ReportRequestsText",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestFiles_ReportRequestTextId",
                table: "ReportRequestFiles",
                column: "ReportRequestTextId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportRequestFiles");

            migrationBuilder.DropTable(
                name: "ReportRequestsText");
        }
    }
}
