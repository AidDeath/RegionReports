using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class movedpropertiesfromassignmenttoasnGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignments_ReportRequestsSurvey_ReportRequestSurveyId",
                table: "ReportAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAssignments_ReportRequestsText_ReportRequestTextId",
                table: "ReportAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ReportAssignments_ReportRequestSurveyId",
                table: "ReportAssignments");

            migrationBuilder.DropIndex(
                name: "IX_ReportAssignments_ReportRequestTextId",
                table: "ReportAssignments");

            migrationBuilder.DropColumn(
                name: "ActualDeadline",
                table: "ReportAssignments");

            migrationBuilder.DropColumn(
                name: "DateAssigned",
                table: "ReportAssignments");

            migrationBuilder.DropColumn(
                name: "IsCancelledByOverDue",
                table: "ReportAssignments");

            migrationBuilder.DropColumn(
                name: "ReportRequestSurveyId",
                table: "ReportAssignments");

            migrationBuilder.DropColumn(
                name: "ReportRequestTextId",
                table: "ReportAssignments");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualDeadline",
                table: "AssignmentGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAssigned",
                table: "AssignmentGroups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsOverdued",
                table: "AssignmentGroups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ReportRequestSurveyId",
                table: "AssignmentGroups",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportRequestTextId",
                table: "AssignmentGroups",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGroups_ReportRequestSurveyId",
                table: "AssignmentGroups",
                column: "ReportRequestSurveyId",
                unique: true,
                filter: "[ReportRequestSurveyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGroups_ReportRequestTextId",
                table: "AssignmentGroups",
                column: "ReportRequestTextId",
                unique: true,
                filter: "[ReportRequestTextId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentGroups_ReportRequestsSurvey_ReportRequestSurveyId",
                table: "AssignmentGroups",
                column: "ReportRequestSurveyId",
                principalTable: "ReportRequestsSurvey",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AssignmentGroups_ReportRequestsText_ReportRequestTextId",
                table: "AssignmentGroups",
                column: "ReportRequestTextId",
                principalTable: "ReportRequestsText",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentGroups_ReportRequestsSurvey_ReportRequestSurveyId",
                table: "AssignmentGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_AssignmentGroups_ReportRequestsText_ReportRequestTextId",
                table: "AssignmentGroups");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentGroups_ReportRequestSurveyId",
                table: "AssignmentGroups");

            migrationBuilder.DropIndex(
                name: "IX_AssignmentGroups_ReportRequestTextId",
                table: "AssignmentGroups");

            migrationBuilder.DropColumn(
                name: "ActualDeadline",
                table: "AssignmentGroups");

            migrationBuilder.DropColumn(
                name: "DateAssigned",
                table: "AssignmentGroups");

            migrationBuilder.DropColumn(
                name: "IsOverdued",
                table: "AssignmentGroups");

            migrationBuilder.DropColumn(
                name: "ReportRequestSurveyId",
                table: "AssignmentGroups");

            migrationBuilder.DropColumn(
                name: "ReportRequestTextId",
                table: "AssignmentGroups");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualDeadline",
                table: "ReportAssignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAssigned",
                table: "ReportAssignments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelledByOverDue",
                table: "ReportAssignments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ReportRequestSurveyId",
                table: "ReportAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportRequestTextId",
                table: "ReportAssignments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignments_ReportRequestSurveyId",
                table: "ReportAssignments",
                column: "ReportRequestSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignments_ReportRequestTextId",
                table: "ReportAssignments",
                column: "ReportRequestTextId");

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
        }
    }
}
