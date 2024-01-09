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
            //using (var ctx = new DatabaseContext())
            //{
            //    ctx.Database.Migrate();
            //}
            using (var ctx = new DatabaseContext())
            {
                while (true)
                {
                    IMathStrategy math = SetStrategy();

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

        public static IMathStrategy? SetStrategy()
        {
            Console.Write("Enter 1-6: ");
            var input = Convert.ToInt32(Console.ReadLine());
            IMathStrategy? mathStrategy = null;
            switch (input)
            {
                case 1:
                    mathStrategy = new Addition();
                    break;
                case 2:
                    mathStrategy = new Subtraction();
                    break;
                case 3:
                    mathStrategy = new Multiplication();
                    break;
                case 4:
                    mathStrategy = new Division();
                    break;
                case 5:
                    mathStrategy = new Modulus();
                    break;
                case 6:
                    mathStrategy = new SquareRoot();
                    break;
            }

            return mathStrategy;
        }
    }
}
