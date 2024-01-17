using Calculations.StrategyContexts;
using Calculator.Interfaces;
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
    public class CalculatorMenu(CalculatorContext mathContext, CalculatorService databaseService, MathCalculation calculation) : IMenu
    {
        public CalculatorService DatabaseService { get; set; } = databaseService;
        public MathCalculation Calculation { get; set; } = calculation;
        public CalculatorContext MathContext { get; set; } = mathContext;

        private readonly Dictionary<int, string> _menuChoices = new()
        {
            {1, "Add a new calculation." },
            {2, "View all calculations." },
            {3, "Update a calculation." },
            {4, "Delete a calculation." },
        };

        public string MenuName => "Calculator";

        public void Display()
        {
            PrintBanner();
        }

        public void Menuchoice()
        {
            while (true)
            {
                Console.Clear();
                Display();
                int? choice = UserInputValidation.MenuValidation(_menuChoices, "\nThese are your available options.\n");
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            var mathCalculation = GetStrategy();
                            if (mathCalculation != null)
                            {
                                DatabaseService.AddCalculation((MathCalculation)mathCalculation);
                                LoadingBar();
                            }
                            else
                            {
                                PrintMessages.PrintErrorMessage("User chose to exit.");
                                break;
                            }
                            Console.Clear();
                        }
                        break;
                    case 2:
                        DatabaseService.ViewAllCalculations();
                        break;
                    case 3:
                        int? idToUpdate = PromptUserForId();
                        if (idToUpdate != null)
                        {
                            Console.Clear();
                            DatabaseService.UpdateCalculation((int)idToUpdate);
                        }
                        break;
                    case 4:
                        int? idToDelete = PromptUserForId();
                        if (idToDelete != null)
                            DatabaseService.DeleteCalculation((int)idToDelete);
                        break;
                    case null:
                        Display();
                        PrintMessages.PrintNotification("Returning back to the main menu.");
                        PrintMessages.PressAnyKeyToContinue();
                        return;
                }
                PrintMessages.PressAnyKeyToContinue();
            }
        }
        private IEntity? GetStrategy()
        {
            var chosenOperator = MenuChoice.ChooseMathOperator();
            MathContext.SetStrategy(chosenOperator);
            if (MathContext.Strategy != null)
                return CalculatorService.CreateMathCalculation(MathContext);
            else
                return null;
        }

        private static void LoadingBar()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("-");
                Thread.Sleep(250);
            }
        }
        public int? PromptUserForId()
        {
            var test = DatabaseService.GetAllCalculations();
            int? userChoice = UserInputValidation.MenuValidation(test, "");
            if (userChoice != null)
            {
                return test[(int)userChoice - 1].Id;
            }
            return null;
        }
        public void Run()
        {
            Menuchoice();
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