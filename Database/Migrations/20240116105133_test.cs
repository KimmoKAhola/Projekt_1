using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RockPaperScissors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastUpdated",
                table: "RockPaperScissors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Calculation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastUpdated",
                table: "Calculation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AreaCalculation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateLastUpdated",
                table: "AreaCalculation",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RockPaperScissors");

            migrationBuilder.DropColumn(
                name: "DateLastUpdated",
                table: "RockPaperScissors");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Calculation");

            migrationBuilder.DropColumn(
                name: "DateLastUpdated",
                table: "Calculation");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AreaCalculation");

            migrationBuilder.DropColumn(
                name: "DateLastUpdated",
                table: "AreaCalculation");
        }
    }
}
