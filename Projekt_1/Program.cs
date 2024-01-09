using Database.DatabaseConfiguration;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Database;
using Calculator.Shapes;
using Calculator.Mathematics.Operations;
using Calculator.Mathematics;
using Calculator.Interfaces;

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
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Migrate();
            }
            IMathStrategy mathStrategy = new Addition();

            var addition = (Addition)mathStrategy;

            var mathCtx = new MathContext(addition);

            Console.WriteLine(mathCtx.Calculate(15, 35));
        }
    }
}
