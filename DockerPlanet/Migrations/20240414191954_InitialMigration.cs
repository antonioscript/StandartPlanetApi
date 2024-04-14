using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DockerPlanet.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mass = table.Column<double>(type: "float", nullable: false),
                    Radius = table.Column<double>(type: "float", nullable: false),
                    Gravity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Planets",
                columns: new[] { "Id", "Gravity", "Mass", "Name", "Radius" },
                values: new object[] { 1, 6371000.0, 5.9720000000000004, "Earth", 100.0 });

            migrationBuilder.InsertData(
                table: "Planets",
                columns: new[] { "Id", "Gravity", "Mass", "Name", "Radius" },
                values: new object[] { 2, 6781000.0, 4.9720000000000004, "Mars", 130.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
