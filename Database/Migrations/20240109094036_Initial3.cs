using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalculatorId",
                table: "Result",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Calculator",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operator = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstInput = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondInput = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculator", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Result_CalculatorId",
                table: "Result",
                column: "CalculatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Calculator_CalculatorId",
                table: "Result",
                column: "CalculatorId",
                principalTable: "Calculator",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Result_Calculator_CalculatorId",
                table: "Result");

            migrationBuilder.DropTable(
                name: "Calculator");

            migrationBuilder.DropIndex(
                name: "IX_Result_CalculatorId",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "CalculatorId",
                table: "Result");
        }
    }
}
