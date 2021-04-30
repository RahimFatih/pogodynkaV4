using Microsoft.EntityFrameworkCore.Migrations;

namespace pogodynkaV4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    weatherDescription = table.Column<string>(type: "TEXT", nullable: true),
                    mainWeatherTemp = table.Column<float>(type: "REAL", nullable: false),
                    visibility = table.Column<float>(type: "REAL", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    uploadTime = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");
        }
    }
}
