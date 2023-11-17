using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetExploration.Migrations
{
    /// <inheritdoc />
    public partial class Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planets_Teams_TeamId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Robots_Teams_TeamId",
                table: "Robots");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Robots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "Robots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Planets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HumanCaptainId",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanetId",
                table: "HumanCaptains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Robots_PlanetId",
                table: "Robots",
                column: "PlanetId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_Teams_TeamId",
                table: "Planets",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Robots_Planets_PlanetId",
                table: "Robots",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Robots_Teams_TeamId",
                table: "Robots",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HumanCaptains_Planets_PlanetId",
                table: "HumanCaptains");

            migrationBuilder.DropForeignKey(
                name: "FK_Planets_Teams_TeamId",
                table: "Planets");

            migrationBuilder.DropForeignKey(
                name: "FK_Robots_Planets_PlanetId",
                table: "Robots");

            migrationBuilder.DropForeignKey(
                name: "FK_Robots_Teams_TeamId",
                table: "Robots");

            migrationBuilder.DropIndex(
                name: "IX_Robots_PlanetId",
                table: "Robots");

            migrationBuilder.DropIndex(
                name: "IX_HumanCaptains_PlanetId",
                table: "HumanCaptains");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "Robots");

            migrationBuilder.DropColumn(
                name: "HumanCaptainId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "PlanetId",
                table: "HumanCaptains");

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Robots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "Planets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_Teams_TeamId",
                table: "Planets",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Robots_Teams_TeamId",
                table: "Robots",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
