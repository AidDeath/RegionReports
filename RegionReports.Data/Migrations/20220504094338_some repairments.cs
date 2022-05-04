using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class somerepairments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignment_ReportUsers_ReportUserId",
                table: "ReportAssignment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportAssignment",
                table: "ReportAssignment");

            migrationBuilder.RenameTable(
                name: "ReportAssignment",
                newName: "ReportAssignments");

            migrationBuilder.RenameIndex(
                name: "IX_ReportAssignment_ReportUserId",
                table: "ReportAssignments",
                newName: "IX_ReportAssignments_ReportUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportAssignment_ReportSurveyId",
                table: "ReportAssignments",
                newName: "IX_ReportAssignments_ReportSurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportAssignment_ReportRequestTextId",
                table: "ReportAssignments",
                newName: "IX_ReportAssignments_ReportRequestTextId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportAssignment_ReportRequestSurveyId",
                table: "ReportAssignments",
                newName: "IX_ReportAssignments_ReportRequestSurveyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportAssignments",
                table: "ReportAssignments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignments_ReportRequestsSurvey_ReportRequestSurveyId",
                table: "ReportAssignments",
                column: "ReportRequestSurveyId",
                principalTable: "ReportRequestsSurvey",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignments_ReportRequestsText_ReportRequestTextId",
                table: "ReportAssignments",
                column: "ReportRequestTextId",
                principalTable: "ReportRequestsText",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignments_ReportsSurvey_ReportSurveyId",
                table: "ReportAssignments",
                column: "ReportSurveyId",
                principalTable: "ReportsSurvey",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignments_ReportUsers_ReportUserId",
                table: "ReportAssignments",
                column: "ReportUserId",
                principalTable: "ReportUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignments_ReportRequestsSurvey_ReportRequestSurveyId",
                table: "ReportAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignments_ReportRequestsText_ReportRequestTextId",
                table: "ReportAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignments_ReportsSurvey_ReportSurveyId",
                table: "ReportAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignments_ReportUsers_ReportUserId",
                table: "ReportAssignments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportAssignments",
                table: "ReportAssignments");

            migrationBuilder.RenameTable(
                name: "ReportAssignments",
                newName: "ReportAssignment");

            migrationBuilder.RenameIndex(
                name: "IX_ReportAssignments_ReportUserId",
                table: "ReportAssignment",
                newName: "IX_ReportAssignment_ReportUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportAssignments_ReportSurveyId",
                table: "ReportAssignment",
                newName: "IX_ReportAssignment_ReportSurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportAssignments_ReportRequestTextId",
                table: "ReportAssignment",
                newName: "IX_ReportAssignment_ReportRequestTextId");

            migrationBuilder.RenameIndex(
                name: "IX_ReportAssignments_ReportRequestSurveyId",
                table: "ReportAssignment",
                newName: "IX_ReportAssignment_ReportRequestSurveyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportAssignment",
                table: "ReportAssignment",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAssignment_ReportUsers_ReportUserId",
                table: "ReportAssignment",
                column: "ReportUserId",
                principalTable: "ReportUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
