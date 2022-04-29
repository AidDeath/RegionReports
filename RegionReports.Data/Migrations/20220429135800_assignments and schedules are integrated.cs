using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class assignmentsandschedulesareintegrated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportUserId = table.Column<int>(type: "int", nullable: false),
                    DateAssigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportRequestTextId = table.Column<int>(type: "int", nullable: false),
                    ReportRequestSurveyId = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportAssignment_ReportRequestsSurvey_ReportRequestSurveyId",
                        column: x => x.ReportRequestSurveyId,
                        principalTable: "ReportRequestsSurvey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportAssignment_ReportRequestsText_ReportRequestTextId",
                        column: x => x.ReportRequestTextId,
                        principalTable: "ReportRequestsText",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportAssignment_ReportUsers_ReportUserId",
                        column: x => x.ReportUserId,
                        principalTable: "ReportUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignment_ReportRequestSurveyId",
                table: "ReportAssignment",
                column: "ReportRequestSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignment_ReportRequestTextId",
                table: "ReportAssignment",
                column: "ReportRequestTextId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignment_ReportUserId",
                table: "ReportAssignment",
                column: "ReportUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportAssignment");
        }
    }
}
