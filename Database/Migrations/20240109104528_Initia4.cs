using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Initia4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Calculator",
                newName: "Answer");

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Calculator",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Calculator_ResultId",
                table: "Calculator",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculator_Result_ResultId",
                table: "Calculator",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculator_Result_ResultId",
                table: "Calculator");

            migrationBuilder.DropIndex(
                name: "IX_Calculator_ResultId",
                table: "Calculator");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Calculator");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Calculator",
                newName: "Result");
        }
    }
}
