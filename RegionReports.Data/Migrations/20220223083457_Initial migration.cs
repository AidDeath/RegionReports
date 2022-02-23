﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ReportUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WindowsUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ApproveClaimDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportUsers", x => x.Id);
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
                name: "IX_Districts_RegionId",
                table: "Districts",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_ReportUserId",
                table: "Districts",
                column: "ReportUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "ReportUsers");
        }
    }
}
