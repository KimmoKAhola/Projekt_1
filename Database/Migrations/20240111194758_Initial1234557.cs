using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial1234557 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ComputerMove",
                table: "RockPaperScissors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Outcome",
                table: "RockPaperScissors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PlayerMove",
                table: "RockPaperScissors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "RockPaperScissors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RockPaperScissors_ResultId",
                table: "RockPaperScissors",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_RockPaperScissors_Result_ResultId",
                table: "RockPaperScissors",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RockPaperScissors_Result_ResultId",
                table: "RockPaperScissors");

            migrationBuilder.DropIndex(
                name: "IX_RockPaperScissors_ResultId",
                table: "RockPaperScissors");

            migrationBuilder.DropColumn(
                name: "ComputerMove",
                table: "RockPaperScissors");

            migrationBuilder.DropColumn(
                name: "Outcome",
                table: "RockPaperScissors");

            migrationBuilder.DropColumn(
                name: "PlayerMove",
                table: "RockPaperScissors");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "RockPaperScissors");
        }
    }
}
