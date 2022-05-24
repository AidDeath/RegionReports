using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class Allmigrationsrebuilt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportRequestTemplateFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileUniqueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileOriginalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequestTemplateFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleType = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayOfWeek = table.Column<short>(type: "smallint", nullable: true),
                    DayOfMonth = table.Column<short>(type: "smallint", nullable: true),
                    IsScheduleActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DaysBeforeAutoAssignment = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserDomain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WindowsUserName = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "False"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    PreviousApprovalState = table.Column<bool>(type: "bit", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastChangesDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponseFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileUniqueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileOriginalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseFile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportRequestsSurvey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MultipleChoises = table.Column<bool>(type: "bit", nullable: false),
                    RequestTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSchedulledRequest = table.Column<bool>(type: "bit", nullable: false),
                    ReportScheduleId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequestsSurvey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportRequestsSurvey_ReportSchedules_ReportScheduleId",
                        column: x => x.ReportScheduleId,
                        principalTable: "ReportSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReportRequestsText",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSchedulledRequest = table.Column<bool>(type: "bit", nullable: false),
                    ReportScheduleId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequestsText", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportRequestsText_ReportSchedules_ReportScheduleId",
                        column: x => x.ReportScheduleId,
                        principalTable: "ReportSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReportRequestsWithFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportRequestFileId = table.Column<int>(type: "int", nullable: false),
                    RequestTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSchedulledRequest = table.Column<bool>(type: "bit", nullable: false),
                    ReportScheduleId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequestsWithFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportRequestsWithFile_ReportRequestTemplateFile_ReportRequestFileId",
                        column: x => x.ReportRequestFileId,
                        principalTable: "ReportRequestTemplateFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportRequestsWithFile_ReportSchedules_ReportScheduleId",
                        column: x => x.ReportScheduleId,
                        principalTable: "ReportSchedules",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    ReportUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Districts_ReportUsers_ReportUserId",
                        column: x => x.ReportUserId,
                        principalTable: "ReportUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReportsSurvey",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportUserId = table.Column<int>(type: "int", nullable: false),
                    DateFilled = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsSurvey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportsSurvey_ReportUsers_ReportUserId",
                        column: x => x.ReportUserId,
                        principalTable: "ReportUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportsText",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepsonseString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportUserId = table.Column<int>(type: "int", nullable: false),
                    DateFilled = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsText", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportsText_ReportUsers_ReportUserId",
                        column: x => x.ReportUserId,
                        principalTable: "ReportUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportUserApprovalClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportUserId = table.Column<int>(type: "int", nullable: false),
                    ClaimDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsClaimProcessed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportUserApprovalClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportUserApprovalClaims_ReportUsers_ReportUserId",
                        column: x => x.ReportUserId,
                        principalTable: "ReportUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportsWithFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResponseFileId = table.Column<int>(type: "int", nullable: false),
                    ReportUserId = table.Column<int>(type: "int", nullable: false),
                    DateFilled = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsWithFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportsWithFile_ReportUsers_ReportUserId",
                        column: x => x.ReportUserId,
                        principalTable: "ReportUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportsWithFile_ResponseFile_ResponseFileId",
                        column: x => x.ResponseFileId,
                        principalTable: "ResponseFile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportRequestSurveyOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportRequestSurveyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequestSurveyOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportRequestSurveyOptions_ReportRequestsSurvey_ReportRequestSurveyId",
                        column: x => x.ReportRequestSurveyId,
                        principalTable: "ReportRequestsSurvey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportRequestFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportRequestTextId = table.Column<int>(type: "int", nullable: false),
                    FileUniqueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileOriginalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "AssignmentGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAssigned = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportRequestTextId = table.Column<int>(type: "int", nullable: true),
                    ReportRequestSurveyId = table.Column<int>(type: "int", nullable: true),
                    ReportRequestWithFileId = table.Column<int>(type: "int", nullable: true),
                    IsOverdued = table.Column<bool>(type: "bit", nullable: false),
                    ActualDeadline = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentGroups_ReportRequestsSurvey_ReportRequestSurveyId",
                        column: x => x.ReportRequestSurveyId,
                        principalTable: "ReportRequestsSurvey",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssignmentGroups_ReportRequestsText_ReportRequestTextId",
                        column: x => x.ReportRequestTextId,
                        principalTable: "ReportRequestsText",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssignmentGroups_ReportRequestsWithFile_ReportRequestWithFileId",
                        column: x => x.ReportRequestWithFileId,
                        principalTable: "ReportRequestsWithFile",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "ReportUserSuggestedChanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RelatedDistrictId = table.Column<int>(type: "int", nullable: true),
                    ReportUserApprovalClaimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportUserSuggestedChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportUserSuggestedChanges_Districts_RelatedDistrictId",
                        column: x => x.RelatedDistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportUserSuggestedChanges_ReportUserApprovalClaims_ReportUserApprovalClaimId",
                        column: x => x.ReportUserApprovalClaimId,
                        principalTable: "ReportUserApprovalClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportSurveySelectableOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportSurveyId = table.Column<int>(type: "int", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false),
                    ReportRequestSurveyOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSurveySelectableOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportSurveySelectableOptions_ReportRequestSurveyOptions_ReportRequestSurveyOptionId",
                        column: x => x.ReportRequestSurveyOptionId,
                        principalTable: "ReportRequestSurveyOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportSurveySelectableOptions_ReportsSurvey_ReportSurveyId",
                        column: x => x.ReportSurveyId,
                        principalTable: "ReportsSurvey",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportUserId = table.Column<int>(type: "int", nullable: false),
                    ReportSurveyId = table.Column<int>(type: "int", nullable: true),
                    ReportTextId = table.Column<int>(type: "int", nullable: true),
                    ReportWithFileId = table.Column<int>(type: "int", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ReportAssignmentGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportAssignments_AssignmentGroups_ReportAssignmentGroupId",
                        column: x => x.ReportAssignmentGroupId,
                        principalTable: "AssignmentGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportAssignments_ReportsSurvey_ReportSurveyId",
                        column: x => x.ReportSurveyId,
                        principalTable: "ReportsSurvey",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportAssignments_ReportsText_ReportTextId",
                        column: x => x.ReportTextId,
                        principalTable: "ReportsText",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportAssignments_ReportsWithFile_ReportWithFileId",
                        column: x => x.ReportWithFileId,
                        principalTable: "ReportsWithFile",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportAssignments_ReportUsers_ReportUserId",
                        column: x => x.ReportUserId,
                        principalTable: "ReportUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "RegionName" },
                values: new object[,]
                {
                    { 1, "Брестская область" },
                    { 2, "Гродненская область" },
                    { 3, "Витебская область" },
                    { 4, "Могилевская область" },
                    { 5, "Гомельская область" },
                    { 6, "Минская область" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "DistrictName", "RegionId", "ReportUserId" },
                values: new object[,]
                {
                    { 1, "Березино", 6, null },
                    { 2, "Борисов", 6, null },
                    { 3, "Вилейка", 6, null },
                    { 4, "Воложин", 6, null },
                    { 5, "Дзержинск", 6, null },
                    { 6, "Жодино", 6, null },
                    { 7, "Клецк", 6, null },
                    { 8, "Копыль", 6, null },
                    { 9, "Крупки", 6, null },
                    { 10, "Логойск", 6, null },
                    { 11, "Любань", 6, null },
                    { 12, "Минск", 6, null },
                    { 13, "Молодечно", 6, null },
                    { 14, "Мядель", 6, null },
                    { 15, "Несвиж", 6, null },
                    { 16, "Пуховичи", 6, null },
                    { 17, "Слуцк", 6, null },
                    { 18, "Смолевичи", 6, null },
                    { 19, "Солигорск", 6, null },
                    { 20, "Старые Дороги", 6, null },
                    { 21, "Столбцы", 6, null },
                    { 22, "Узда", 6, null },
                    { 23, "Червень", 6, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGroups_ReportRequestSurveyId",
                table: "AssignmentGroups",
                column: "ReportRequestSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGroups_ReportRequestTextId",
                table: "AssignmentGroups",
                column: "ReportRequestTextId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGroups_ReportRequestWithFileId",
                table: "AssignmentGroups",
                column: "ReportRequestWithFileId");

            migrationBuilder.CreateIndex(
                name: "IX_DistrictReportSchedule_SchedulesId",
                table: "DistrictReportSchedule",
                column: "SchedulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_RegionId",
                table: "Districts",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_ReportUserId",
                table: "Districts",
                column: "ReportUserId",
                unique: true,
                filter: "[ReportUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignments_ReportAssignmentGroupId",
                table: "ReportAssignments",
                column: "ReportAssignmentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignments_ReportSurveyId",
                table: "ReportAssignments",
                column: "ReportSurveyId",
                unique: true,
                filter: "[ReportSurveyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignments_ReportTextId",
                table: "ReportAssignments",
                column: "ReportTextId",
                unique: true,
                filter: "[ReportTextId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignments_ReportUserId",
                table: "ReportAssignments",
                column: "ReportUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAssignments_ReportWithFileId",
                table: "ReportAssignments",
                column: "ReportWithFileId",
                unique: true,
                filter: "[ReportWithFileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestFiles_ReportRequestTextId",
                table: "ReportRequestFiles",
                column: "ReportRequestTextId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestsSurvey_ReportScheduleId",
                table: "ReportRequestsSurvey",
                column: "ReportScheduleId",
                unique: true,
                filter: "[ReportScheduleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestsText_ReportScheduleId",
                table: "ReportRequestsText",
                column: "ReportScheduleId",
                unique: true,
                filter: "[ReportScheduleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestSurveyOptions_ReportRequestSurveyId",
                table: "ReportRequestSurveyOptions",
                column: "ReportRequestSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestsWithFile_ReportRequestFileId",
                table: "ReportRequestsWithFile",
                column: "ReportRequestFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportRequestsWithFile_ReportScheduleId",
                table: "ReportRequestsWithFile",
                column: "ReportScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsSurvey_ReportUserId",
                table: "ReportsSurvey",
                column: "ReportUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsText_ReportUserId",
                table: "ReportsText",
                column: "ReportUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSurveySelectableOptions_ReportRequestSurveyOptionId",
                table: "ReportSurveySelectableOptions",
                column: "ReportRequestSurveyOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportSurveySelectableOptions_ReportSurveyId",
                table: "ReportSurveySelectableOptions",
                column: "ReportSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsWithFile_ReportUserId",
                table: "ReportsWithFile",
                column: "ReportUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsWithFile_ResponseFileId",
                table: "ReportsWithFile",
                column: "ResponseFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportUserApprovalClaims_ReportUserId",
                table: "ReportUserApprovalClaims",
                column: "ReportUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportUserSuggestedChanges_RelatedDistrictId",
                table: "ReportUserSuggestedChanges",
                column: "RelatedDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportUserSuggestedChanges_ReportUserApprovalClaimId",
                table: "ReportUserSuggestedChanges",
                column: "ReportUserApprovalClaimId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlowedUploadFileTypes");

            migrationBuilder.DropTable(
                name: "DistrictReportSchedule");

            migrationBuilder.DropTable(
                name: "ReportAssignments");

            migrationBuilder.DropTable(
                name: "ReportRequestFiles");

            migrationBuilder.DropTable(
                name: "ReportSurveySelectableOptions");

            migrationBuilder.DropTable(
                name: "ReportUserSuggestedChanges");

            migrationBuilder.DropTable(
                name: "AssignmentGroups");

            migrationBuilder.DropTable(
                name: "ReportsText");

            migrationBuilder.DropTable(
                name: "ReportsWithFile");

            migrationBuilder.DropTable(
                name: "ReportRequestSurveyOptions");

            migrationBuilder.DropTable(
                name: "ReportsSurvey");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "ReportUserApprovalClaims");

            migrationBuilder.DropTable(
                name: "ReportRequestsText");

            migrationBuilder.DropTable(
                name: "ReportRequestsWithFile");

            migrationBuilder.DropTable(
                name: "ResponseFile");

            migrationBuilder.DropTable(
                name: "ReportRequestsSurvey");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "ReportUsers");

            migrationBuilder.DropTable(
                name: "ReportRequestTemplateFile");

            migrationBuilder.DropTable(
                name: "ReportSchedules");
        }
    }
}
