using Calculator.Interfaces;
using Calculator.Mathematics;
using Database.Models;
using Database.Services;
using InputValidationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Menus
{
    public class CalculatorMenu
    {
        private MathContext _context;
        DatabaseService _databaseService;
        public CalculatorMenu(MathContext context, DatabaseService databaseService)
        {
            _context = context;
            _databaseService = databaseService;
        }

        public void Display()
        {
            PrintOptions();
            Run();
        }

        public void PrintOptions()
        {
            Console.WriteLine("1. Calculate");
        }

        public void Run()
        {
            Console.Write("Enter 1-6: ");
            var choice = Convert.ToInt32(Console.ReadLine());

            var temp = _context.SetStrategy(choice);
            //_context.SetStrategy(choice);
            Console.Write("Enter first number: ");
            var first = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter second number: ");
            var second = Convert.ToDouble(Console.ReadLine());
            var answer = _context.Calculate(first, second);

            var calculation = new MathCalculation
            {
                FirstInput = first,
                SecondInput = second,
                Answer = answer,
                Operator = temp.Operator,
                Result = new Result
                {
                    DateCreated = DateTime.Now,
                    ResultType = ResultTypes.MathCalculation.ToString(),
                }
            };

            _databaseService.AddCalculation(calculation);
        }
    }
}
