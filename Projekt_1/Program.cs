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
                var test = new AreaCalculation
                {
                    Area = AreaCalculator.CalculateArea(5, 10),
                    Circumference = AreaCalculator.CalculateArea(5, 10),

                };

                var result = new Result
                {

                };
                ctx.Add(test);
                ctx.SaveChanges();
                result.AreaCalculations.Add(test);
                ctx.SaveChanges();
            }
        }
    }
}
