using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Result_AreaCalculation_AreaCalculationId",
                table: "Result");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Calculator_CalculatorId",
                table: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Result_AreaCalculationId",
                table: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Result_CalculatorId",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "AreaCalculationId",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "CalculatorId",
                table: "Result");

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Calculator",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "AreaCalculation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calculator_ResultId",
                table: "Calculator",
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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calculator_Result_ResultId",
                table: "Calculator",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaCalculation_Result_ResultId",
                table: "AreaCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_Calculator_Result_ResultId",
                table: "Calculator");

            migrationBuilder.DropIndex(
                name: "IX_Calculator_ResultId",
                table: "Calculator");

            migrationBuilder.DropIndex(
                name: "IX_AreaCalculation_ResultId",
                table: "AreaCalculation");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Calculator");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "AreaCalculation");

            migrationBuilder.AddColumn<int>(
                name: "AreaCalculationId",
                table: "Result",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CalculatorId",
                table: "Result",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Result_AreaCalculationId",
                table: "Result",
                column: "AreaCalculationId");

            migrationBuilder.CreateIndex(
                name: "IX_Result_CalculatorId",
                table: "Result",
                column: "CalculatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Result_AreaCalculation_AreaCalculationId",
                table: "Result",
                column: "AreaCalculationId",
                principalTable: "AreaCalculation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Calculator_CalculatorId",
                table: "Result",
                column: "CalculatorId",
                principalTable: "Calculator",
                principalColumn: "Id");
        }
    }
}
