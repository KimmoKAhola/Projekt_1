using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculator_Result_ResultId",
                table: "Calculator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calculator",
                table: "Calculator");

            migrationBuilder.RenameTable(
                name: "Calculator",
                newName: "Calculation");

            migrationBuilder.RenameIndex(
                name: "IX_Calculator_ResultId",
                table: "Calculation",
                newName: "IX_Calculation_ResultId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calculation",
                table: "Calculation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculation_Result_ResultId",
                table: "Calculation",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calculation_Result_ResultId",
                table: "Calculation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calculation",
                table: "Calculation");

            migrationBuilder.RenameTable(
                name: "Calculation",
                newName: "Calculator");

            migrationBuilder.RenameIndex(
                name: "IX_Calculation_ResultId",
                table: "Calculator",
                newName: "IX_Calculator_ResultId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calculator",
                table: "Calculator",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculator_Result_ResultId",
                table: "Calculator",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
