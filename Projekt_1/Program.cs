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
using Projekt_1.Menus;
using System.Text;

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
            Console.OutputEncoding = Encoding.UTF8;
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
                var menuService = scope.Resolve<CalculatorMenu>();

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
                            menuService.Display();
                        }
                    }
                }
            }
        }
    }
}
