using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class addedrolestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessRoles",
                columns: table => new
                {
                    WindowsRoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdministrator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessRoles");
        }
    }
}