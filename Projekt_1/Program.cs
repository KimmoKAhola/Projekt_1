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
            //using (var ctx = new DatabaseContext())
            //{
            //    ctx.Database.EnsureDeleted();
            //}
            //using (var ctx = new DatabaseContext())
            //{
            //    ctx.Database.Migrate();
            //}

            using (var ctx = new DatabaseContext())
            {
                var result = new Result();
                var rectangleCalculation = new AreaCalculation
                {
                    Area = AreaCalculator.CalculateArea(5, 10),
                    Circumference = AreaCalculator.CalculateCircumference(5, 10),
                    Result = result
                };
                ctx.Result.Add(result);
                ctx.Add(rectangleCalculation);
                ctx.SaveChanges();
            }

            using (var ctx = new DatabaseContext())
            {
                var ac = ctx.AreaCalculation.ToList();
                var r = ctx.Result.ToList();

                Console.ReadKey();
            }
        }
    }
}
