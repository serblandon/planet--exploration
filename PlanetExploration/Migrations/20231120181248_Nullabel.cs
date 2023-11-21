using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetExploration.Migrations
{
    /// <inheritdoc />
    public partial class Nullabel : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "PlanetId",
                table: "HumanCaptains",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HumanCaptains_Planets_PlanetId",
                table: "HumanCaptains");

            migrationBuilder.DropIndex(
                name: "IX_HumanCaptains_PlanetId",
                table: "HumanCaptains");

            migrationBuilder.AlterColumn<int>(
                name: "PlanetId",
                table: "HumanCaptains",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
