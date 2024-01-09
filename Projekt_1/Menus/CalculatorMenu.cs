using Calculator.Interfaces;
using Calculator.Mathematics;
using Database.Models;
using Database.Services;
using InputValidationLibrary;
using Projekt_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Menus
{
    public class CalculatorMenu : IMenu
    {
        private MathContext _context;
        DatabaseService _databaseService;
        ICalculation _calculation;
        public CalculatorMenu(MathContext context, DatabaseService databaseService, MathCalculation calculation)
        {
            _context = context;
            _databaseService = databaseService;
            _calculation = calculation;
        }

        public void Display()
        {
            PrintOptions();
            Run();
        }

        public void PrintOptions()
        {
            Console.WriteLine("1. Calculate");
            Console.WriteLine("2. Read all");
            Console.WriteLine("1. _----");
            Console.WriteLine("1. ------");
            Console.WriteLine("1. ------");
        }

        public void Run()
        {
            //Console.Write("Enter 1-6: ");
            //var choice = Convert.ToInt32(Console.ReadLine());

            //var temp = _context.SetStrategy(choice);
            ////_context.SetStrategy(choice);
            //Console.Write("Enter first number: ");
            //var first = Convert.ToDouble(Console.ReadLine());
            //Console.Write("Enter second number: ");
            //var second = Convert.ToDouble(Console.ReadLine());
            //var answer = _context.Calculate(first, second);

            //var calculation = new MathCalculation
            //{
            //    FirstInput = first,
            //    SecondInput = second,
            //    Answer = answer,
            //    Operator = temp.Operator,
            //    Result = new Result
            //    {
            //        DateCreated = DateTime.Now,
            //        ResultType = ResultTypes.MathCalculation.ToString(),
            //    }
            //};

            //_databaseService.AddCalculation(calculation);

            _databaseService.ReadAllCalculations(_calculation);
        }
    }


}
