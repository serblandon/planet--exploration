using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetExploration.Migrations
{
    /// <inheritdoc />
    public partial class NofkRobot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Robots_Planets_PlanetId",
                table: "Robots");

            migrationBuilder.DropIndex(
                name: "IX_Robots_PlanetId",
                table: "Robots");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "Robots");

            migrationBuilder.CreateTable(
                name: "PlanetRobot",
                columns: table => new
                {
                    PlanetId = table.Column<int>(type: "int", nullable: false),
                    RobotsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanetRobot", x => new { x.PlanetId, x.RobotsId });
                    table.ForeignKey(
                        name: "FK_PlanetRobot_Planets_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanetRobot_Robots_RobotsId",
                        column: x => x.RobotsId,
                        principalTable: "Robots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanetRobot_RobotsId",
                table: "PlanetRobot",
                column: "RobotsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanetRobot");

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "Robots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Robots_PlanetId",
                table: "Robots",
                column: "PlanetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Robots_Planets_PlanetId",
                table: "Robots",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id");
        }
    }
}
