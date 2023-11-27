using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetExploration.Migrations
{
    /// <inheritdoc />
    public partial class Nofk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HumanCaptains_Planets_PlanetId",
                table: "HumanCaptains");

            migrationBuilder.DropIndex(
                name: "IX_HumanCaptains_PlanetId",
                table: "HumanCaptains");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "HumanCaptains");

            migrationBuilder.AddColumn<int>(
                name: "HumanCaptainId",
                table: "Planets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planets_HumanCaptainId",
                table: "Planets",
                column: "HumanCaptainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_HumanCaptains_HumanCaptainId",
                table: "Planets",
                column: "HumanCaptainId",
                principalTable: "HumanCaptains",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_HumanCaptains_HumanCaptainId",
                table: "Planets");

            migrationBuilder.DropIndex(
                name: "IX_Planets_HumanCaptainId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "HumanCaptainId",
                table: "Planets");

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "HumanCaptains",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HumanCaptains_PlanetId",
                table: "HumanCaptains",
                column: "PlanetId",
                unique: true,
                filter: "[PlanetId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_HumanCaptains_Planets_PlanetId",
                table: "HumanCaptains",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id");
        }
    }
}
