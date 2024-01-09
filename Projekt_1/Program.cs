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

            using (var ctx = new DatabaseContext())
            {
                var rectangleCalculation = new AreaCalculation
                {
                    Area = AreaCalculator.CalculateArea(5, 10),
                    Circumference = AreaCalculator.CalculateCircumference(5, 10),

                };

                var result = new Result
                {

                };
                ctx.Add(rectangleCalculation);
                ctx.SaveChanges();
                result.AreaCalculations.Add(rectangleCalculation);
                ctx.Add(result);
                ctx.SaveChanges();
            }
        }
    }
}
