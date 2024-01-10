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
        MathContext _context;
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
            PrintBanner();
        }


        public void Menuchoice(int choice)
        {
            Console.Write("Enter a number 1-6: ");
            var input = Convert.ToInt32(Console.ReadLine());
            IMathStrategy? math = _context.SetStrategy(input);

            var mathResult = _context.Calculate(15, 35);
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
            _databaseService.AddCalculation(calculation);
        }

        public int PromptUser()
        {
            return 1;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Display();
                var choice = PromptUser();
                Menuchoice(choice);
                PrintMessages.PressAnyKeyToContinue();
            }
        }
        public void PrintBanner()
        {
            string banner = @"***********************************************************************************************
*                                                                                             *
*      ██████╗ █████╗ ██╗      ██████╗██╗   ██╗██╗      █████╗ ████████╗ ██████╗ ██████╗      *
*     ██╔════╝██╔══██╗██║     ██╔════╝██║   ██║██║     ██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗     *
*     ██║     ███████║██║     ██║     ██║   ██║██║     ███████║   ██║   ██║   ██║██████╔╝     *
*     ██║     ██╔══██║██║     ██║     ██║   ██║██║     ██╔══██║   ██║   ██║   ██║██╔══██╗     *
*     ╚██████╗██║  ██║███████╗╚██████╗╚██████╔╝███████╗██║  ██║   ██║   ╚██████╔╝██║  ██║     *
*      ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝     *
*                                                                                             *
***********************************************************************************************";
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(banner);
            Console.ResetColor();
        }
    }
}
