using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class Seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DistrictName",
                table: "Districts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "RegionName" },
                values: new object[] { 1, "Брестская область" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "RegionName" },
                values: new object[] { 2, "Гродненская область" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "RegionName" },
                values: new object[] { 3, "Витебская область" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "RegionName" },
                values: new object[] { 4, "Могилевская область" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "RegionName" },
                values: new object[] { 5, "Гомельская область" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "RegionName" },
                values: new object[] { 6, "Минская область" });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 1, "Березино", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 2, "Борисов", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 3, "Вилейка", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 4, "Воложин", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 5, "Дзержинск", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 6, "Жодино", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 7, "Клецк", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 8, "Копыль", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 9, "Крупки", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 10, "Логойск", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 11, "Любань", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 12, "Минск", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 13, "Молодечно", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 14, "Мядель", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 15, "Несвиж", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 16, "Пуховичи", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 17, "Слуцк", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 18, "Смолевичи", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 19, "Солигорск", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 20, "Старые Дороги", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 21, "Столбцы", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 22, "Узда", 6 });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId" },
                values: new object[] { 23, "Червень", 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Districts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "DistrictName",
                table: "Districts");
        }
    }
}
