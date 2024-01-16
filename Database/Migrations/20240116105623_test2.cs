using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class test2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaCalculation_Result_ResultId",
                table: "AreaCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculation_Result_ResultId",
                table: "Calculation");

            migrationBuilder.DropForeignKey(
                name: "FK_RockPaperScissors_Result_ResultId",
                table: "RockPaperScissors");

            migrationBuilder.DropTable(
                name: "Result");

            migrationBuilder.DropIndex(
                name: "IX_RockPaperScissors_ResultId",
                table: "RockPaperScissors");

            migrationBuilder.DropIndex(
                name: "IX_Calculation_ResultId",
                table: "Calculation");

            migrationBuilder.DropIndex(
                name: "IX_AreaCalculation_ResultId",
                table: "AreaCalculation");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "RockPaperScissors");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Calculation");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "AreaCalculation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "RockPaperScissors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Calculation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "AreaCalculation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Result",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResultType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Result", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RockPaperScissors_ResultId",
                table: "RockPaperScissors",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculation_ResultId",
                table: "Calculation",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaCalculation_ResultId",
                table: "AreaCalculation",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaCalculation_Result_ResultId",
                table: "AreaCalculation",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calculation_Result_ResultId",
                table: "Calculation",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RockPaperScissors_Result_ResultId",
                table: "RockPaperScissors",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
