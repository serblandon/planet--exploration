using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetExploration.Migrations
{
    /// <inheritdoc />
    public partial class Defaultvalue : Migration
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

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Robots_TeamId",
                table: "Robots");

            migrationBuilder.DropIndex(
                name: "IX_Planets_TeamId",
                table: "Planets");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Robots");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Planets");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "En Route",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Robots",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Planets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "En Route");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Planets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HumanCaptainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_HumanCaptains_HumanCaptainId",
                        column: x => x.HumanCaptainId,
                        principalTable: "HumanCaptains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Robots_TeamId",
                table: "Robots",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Planets_TeamId",
                table: "Planets",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_HumanCaptainId",
                table: "Teams",
                column: "HumanCaptainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planets_Teams_TeamId",
                table: "Planets",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Robots_Teams_TeamId",
                table: "Robots",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }
    }
}
