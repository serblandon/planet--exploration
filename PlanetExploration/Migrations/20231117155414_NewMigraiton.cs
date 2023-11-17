using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetExploration.Migrations
{
    /// <inheritdoc />
    public partial class NewMigraiton : Migration
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

            migrationBuilder.CreateIndex(
                name: "IX_Planets_HumanCaptainId",
                table: "Planets",
                column: "HumanCaptainId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_HumanCaptains_HumanCaptainId",
                table: "Planets",
                column: "HumanCaptainId",
                principalTable: "HumanCaptains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "HumanCaptains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HumanCaptains_PlanetId",
                table: "HumanCaptains",
                column: "PlanetId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HumanCaptains_Planets_PlanetId",
                table: "HumanCaptains",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
