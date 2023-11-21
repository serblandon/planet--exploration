﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanetExploration.Migrations
{
    /// <inheritdoc />
    public partial class Nullabel4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Robots_Planets_PlanetId",
                table: "Robots");

            migrationBuilder.AlterColumn<int>(
                name: "PlanetId",
                table: "Robots",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Robots_Planets_PlanetId",
                table: "Robots",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Robots_Planets_PlanetId",
                table: "Robots");

            migrationBuilder.AlterColumn<int>(
                name: "PlanetId",
                table: "Robots",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Robots_Planets_PlanetId",
                table: "Robots",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
