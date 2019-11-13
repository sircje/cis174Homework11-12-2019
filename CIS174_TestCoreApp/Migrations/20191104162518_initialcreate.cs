using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CIS174_TestCoreApp.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    AchievementsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FamousPeopleId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    doa = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.AchievementsId);
                });

            migrationBuilder.CreateTable(
                name: "FamousPeoples",
                columns: table => new
                {
                    firstName = table.Column<string>(nullable: false),
                    FamousPeopleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    lastName = table.Column<string>(nullable: false),
                    birthDate = table.Column<string>(nullable: false),
                    city = table.Column<string>(nullable: false),
                    state = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamousPeoples", x => x.FamousPeopleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "FamousPeoples");
        }
    }
}
