using Database.DatabaseConfiguration;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Database;
using Calculator;

namespace Projekt_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.EnsureDeleted();
            }
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Migrate();
            }
            for (int i = 0; i < 100; i++)
            {

                using (var ctx = new DatabaseContext())
                {
                    var result = new Result
                    {
                        ResultType = "Area Calculation"
                    };
                    var rectangleCalculation = new AreaCalculation
                    {
                        Area = Rectangle.CalculateArea(5, 10),
                        Circumference = Rectangle.CalculateCircumference(5, 10),
                        Result = result
                    };
                    ctx.Result.Add(result);
                    ctx.Add(rectangleCalculation);
                    ctx.SaveChanges();
                }

                using (var ctx = new DatabaseContext())
                {
                    var result = new Result
                    {
                        ResultType = "Math Calculation",

                    };
                    var firstInput = 15m;
                    var secondInput = 25m;
                    var mathCalculation = new MathCalculation
                    {
                        Operator = '+',
                        FirstInput = firstInput,
                        SecondInput = secondInput,
                        Answer = MathOperations.Addition(firstInput, secondInput),
                        Result = result
                    };
                    ctx.Result.Add(result);
                    ctx.Add(mathCalculation);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
