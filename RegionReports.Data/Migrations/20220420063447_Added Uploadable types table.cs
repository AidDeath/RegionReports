using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class AddedUploadabletypestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileOriginalName",
                table: "ReportRequestFiles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "ReportRequestFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AlowedUploadFileTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlowedMimeType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlowedUploadFileTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AlowedUploadFileTypes",
                columns: new[] { "Id", "AlowedMimeType" },
                values: new object[,]
                {
                    { 1, "application/msword" },
                    { 2, "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
                    { 3, "application/vnd.ms-excel" },
                    { 4, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                    { 5, "application/pdf" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlowedUploadFileTypes");

            migrationBuilder.DropColumn(
                name: "FileOriginalName",
                table: "ReportRequestFiles");

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "ReportRequestFiles");
        }
    }
}
