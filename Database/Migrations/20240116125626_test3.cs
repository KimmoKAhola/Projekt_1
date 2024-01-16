using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Calculation",
                table: "Calculation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaCalculation",
                table: "AreaCalculation");

            migrationBuilder.RenameTable(
                name: "Calculation",
                newName: "Calculator");

            migrationBuilder.RenameTable(
                name: "AreaCalculation",
                newName: "ShapeCalculator");

            migrationBuilder.AlterColumn<double>(
                name: "AverageScore",
                table: "HighScore",
                type: "float",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calculator",
                table: "Calculator",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShapeCalculator",
                table: "ShapeCalculator",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShapeCalculator",
                table: "ShapeCalculator");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Calculator",
                table: "Calculator");

            migrationBuilder.RenameTable(
                name: "ShapeCalculator",
                newName: "AreaCalculation");

            migrationBuilder.RenameTable(
                name: "Calculator",
                newName: "Calculation");

            migrationBuilder.AlterColumn<byte>(
                name: "AverageScore",
                table: "HighScore",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaCalculation",
                table: "AreaCalculation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Calculation",
                table: "Calculation",
                column: "Id");
        }
    }
}
