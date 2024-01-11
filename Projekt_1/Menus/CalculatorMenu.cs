using Calculations.Services;
using Calculator.Interfaces;
using Calculator.Mathematics;
using Database.Interfaces;
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
    public class CalculatorMenu(MathContext mathContext, DatabaseService databaseService, MathCalculation calculation) : IMenu
    {
        public DatabaseService DatabaseService { get; set; } = databaseService;
        public MathCalculation Calculation { get; set; } = calculation;
        public MathContext MathContext { get; set; } = mathContext;

        public string MenuName => "Calculator";

        public void Display()
        {
            PrintBanner();
        }

        public void Menuchoice()
        {
            Console.Write("Enter a number: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    var chosenOperator = MenuChoice.ChooseMathOperator();
                    MathContext.SetStrategy(chosenOperator);
                    ICalculation? mathCalculation = CalculationServices.CreateMathCalculation(MathContext);
                    if (mathCalculation != null)
                        DatabaseService.AddCalculation(mathCalculation);
                    else
                        PrintMessages.PrintErrorMessage("User chose to discard.");
                    break;
                case 2:
                    DatabaseService.ReadAllCalculations(Calculation);
                    break;
                case 3:
                    //Update
                    break;
                case 4:
                    //Delete
                    break;
                case 0:
                    PrintMessages.PrintNotification("Returning back to the main menu.");
                    PrintMessages.PressAnyKeyToContinue();
                    break;
            }
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
                Menuchoice();
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

        public override string ToString()
        {
            return MenuName;
        }
    }
}