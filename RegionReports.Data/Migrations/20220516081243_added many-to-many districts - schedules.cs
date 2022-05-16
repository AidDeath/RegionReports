using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class addedmanytomanydistrictsschedules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DistrictReportSchedule",
                columns: table => new
                {
                    DistrictsId = table.Column<int>(type: "int", nullable: false),
                    SchedulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictReportSchedule", x => new { x.DistrictsId, x.SchedulesId });
                    table.ForeignKey(
                        name: "FK_DistrictReportSchedule_Districts_DistrictsId",
                        column: x => x.DistrictsId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistrictReportSchedule_ReportSchedules_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "ReportSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistrictReportSchedule_SchedulesId",
                table: "DistrictReportSchedule",
                column: "SchedulesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistrictReportSchedule");
        }
    }
}
