using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class reporttoassignmentrelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignment_ReportRequestsSurvey_ReportRequestSurveyId",
                table: "ReportAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignment_ReportRequestsText_ReportRequestTextId",
                table: "ReportAssignment");

            migrationBuilder.AddColumn<int>(
                name: "ReportAssignmentId",
                table: "ReportsSurvey",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReportRequestTextId",
                table: "ReportAssignment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReportRequestSurveyId",
                table: "ReportAssignment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ReportSurveyId",
                table: "ReportAssignment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignment_ReportSurveyId",
                table: "ReportAssignment",
                column: "ReportSurveyId",
                unique: true,
                filter: "[ReportSurveyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignment_ReportRequestsSurvey_ReportRequestSurveyId",
                table: "ReportAssignment",
                column: "ReportRequestSurveyId",
                principalTable: "ReportRequestsSurvey",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignment_ReportRequestsText_ReportRequestTextId",
                table: "ReportAssignment",
                column: "ReportRequestTextId",
                principalTable: "ReportRequestsText",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignment_ReportsSurvey_ReportSurveyId",
                table: "ReportAssignment",
                column: "ReportSurveyId",
                principalTable: "ReportsSurvey",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignment_ReportRequestsSurvey_ReportRequestSurveyId",
                table: "ReportAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignment_ReportRequestsText_ReportRequestTextId",
                table: "ReportAssignment");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignment_ReportsSurvey_ReportSurveyId",
                table: "ReportAssignment");

            migrationBuilder.DropIndex(
                name: "IX_ReportAssignment_ReportSurveyId",
                table: "ReportAssignment");

            migrationBuilder.DropColumn(
                name: "ReportAssignmentId",
                table: "ReportsSurvey");

            migrationBuilder.DropColumn(
                name: "ReportSurveyId",
                table: "ReportAssignment");

            migrationBuilder.AlterColumn<int>(
                name: "ReportRequestTextId",
                table: "ReportAssignment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReportRequestSurveyId",
                table: "ReportAssignment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignment_ReportRequestsSurvey_ReportRequestSurveyId",
                table: "ReportAssignment",
                column: "ReportRequestSurveyId",
                principalTable: "ReportRequestsSurvey",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignment_ReportRequestsText_ReportRequestTextId",
                table: "ReportAssignment",
                column: "ReportRequestTextId",
                principalTable: "ReportRequestsText",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
