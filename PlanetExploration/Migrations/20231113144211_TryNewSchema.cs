using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetExploration.Migrations
{
    /// <inheritdoc />
    public partial class TryNewSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HumanCaptains_Teams_TeamId",
                table: "HumanCaptains");

            migrationBuilder.DropIndex(
                name: "IX_HumanCaptains_TeamId",
                table: "HumanCaptains");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "HumanCaptains");

            migrationBuilder.AddColumn<int>(
                name: "HumanCaptainId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_HumanCaptainId",
                table: "Teams",
                column: "HumanCaptainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_HumanCaptains_HumanCaptainId",
                table: "Teams",
                column: "HumanCaptainId",
                principalTable: "HumanCaptains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_HumanCaptains_HumanCaptainId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_HumanCaptainId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "HumanCaptainId",
                table: "Teams");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "HumanCaptains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HumanCaptains_TeamId",
                table: "HumanCaptains",
                column: "TeamId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HumanCaptains_Teams_TeamId",
                table: "HumanCaptains",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
