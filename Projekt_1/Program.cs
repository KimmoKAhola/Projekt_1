using Database.DatabaseConfiguration;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Database;
using Calculator.Shapes;
using Calculator.Mathematics.Operations;
using Calculator.Mathematics;
using Calculator.Interfaces;
using Projekt_1.Container;
using Autofac;

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
            var config = Configuration.Configure();
            using (var scope = config.BeginLifetimeScope())
            {
                var test = scope.Resolve<MathContext>();
                using (var ctx = new DatabaseContext())
                {
                    while (true)
                    {
                        Console.Write("Enter a number 1-6: ");
                        var choice = Convert.ToInt32(Console.ReadLine());
                        IMathStrategy? math = test.SetStrategy(choice);

                        var mathCtx = new MathContext(math);

                        var mathResult = mathCtx.Calculate(15, 35);

                        var calculation = new MathCalculation
                        {
                            FirstInput = 15,
                            SecondInput = 35,
                            Answer = mathResult,
                            Operator = math.Operator,
                            Result = new Result
                            {
                                DateCreated = DateTime.Now,
                                ResultType = ResultTypes.MathCalculation.ToString(),
                            }
                        };

                        ctx.Add(calculation);
                        ctx.SaveChanges();
                        Console.WriteLine($"The result is: {mathResult}");

                    }
                }
            }
        }
    }
}
