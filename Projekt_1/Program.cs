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
using Database.Services;
using InputValidationLibrary;

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
            var config = Configuration.Configure();
            using (var scope = config.BeginLifetimeScope())
            {
                var mathContext = scope.Resolve<MathContext>();
                var areaContext = scope.Resolve<AreaCalculatorContext>();
                var databaseService = scope.Resolve<DatabaseService>();

                if (UserInputValidation.PromptYesOrNo("Press y to do math, n to do area: "))
                {
                    using (var ctx = new DatabaseContext())
                    {
                        while (true)
                        {
                            Console.Write("Enter a number 1-6: ");
                            var choice = Convert.ToInt32(Console.ReadLine());
                            IMathStrategy? math = mathContext.SetStrategy(choice);

                            var mathResult = mathContext.Calculate(15, 35);

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

                            databaseService.AddCalculation(calculation);
                            Console.WriteLine($"The result is: {mathResult}");
                        }
                    }
                }
                else
                {
                    using (var ctx = new DatabaseContext())
                    {
                        while (true)
                        {
                            Console.Write("Enter a number 1-4: ");
                            var choice = Convert.ToInt32(Console.ReadLine());
                            IShape shape = areaContext.SetStrategy(choice);

                            var mathResult = areaContext.Calculate(15, 25);

                            var calculation = new AreaCalculation
                            {
                                Area = mathResult.area,
                                Circumference = mathResult.circumference,
                                Result = new Result
                                {
                                    DateCreated = DateTime.Now,
                                    ResultType = ResultTypes.AreaCalculation.ToString(),
                                }
                            };

                            databaseService.AddCalculation(calculation);
                            Console.WriteLine($"The resulting area is: {mathResult}");
                        }
                    }
                }
            }
        }
    }
}
