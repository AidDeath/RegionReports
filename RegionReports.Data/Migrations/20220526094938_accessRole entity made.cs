using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class accessRoleentitymade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AccessRoles",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccessRoles",
                table: "AccessRoles",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AccessRoles",
                columns: new[] { "Id", "IsAdministrator", "WindowsRoleName" },
                values: new object[] { 1, true, "Everyone" });

            migrationBuilder.InsertData(
                table: "AccessRoles",
                columns: new[] { "Id", "IsAdministrator", "WindowsRoleName" },
                values: new object[] { 2, true, "Все" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AccessRoles",
                table: "AccessRoles");

            migrationBuilder.DeleteData(
                table: "AccessRoles",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccessRoles",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AccessRoles");
        }
    }
}