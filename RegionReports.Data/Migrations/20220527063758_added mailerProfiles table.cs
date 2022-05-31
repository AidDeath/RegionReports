using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegionReports.Data.Migrations
{
    public partial class addedmailerProfilestable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailersProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailServer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailServerPort = table.Column<int>(type: "int", nullable: false),
                    MailerLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailerPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsProfileActive = table.Column<bool>(type: "bit", nullable: false),
                    SendAboutAssignment = table.Column<bool>(type: "bit", nullable: false),
                    SendAboutNearDeadline = table.Column<bool>(type: "bit", nullable: false),
                    SendAboutOverdue = table.Column<bool>(type: "bit", nullable: false),
                    HoursBeforeDailySending = table.Column<int>(type: "int", nullable: true),
                    DaysBeforeWeeklySending = table.Column<int>(type: "int", nullable: true),
                    DaysMonthlySending = table.Column<int>(type: "int", nullable: true),
                    DaysNonScheduledSending = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailersProfiles", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailersProfiles");
        }
    }
}
