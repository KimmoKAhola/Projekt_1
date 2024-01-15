using Calculations.StrategyContexts;
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
    public class AreaCalculatorMenu(AreaCalculatorContext areaContext, AreaCalculationService databaseService, AreaCalculation calculation) : IMenu
    {
        public AreaCalculationService DatabaseService { get; set; } = databaseService;
        public AreaCalculation Calculation { get; set; } = calculation;
        public AreaCalculatorContext AreaContext { get; set; } = areaContext;

        public string MenuName => "Area Calculator";

        private readonly Dictionary<int, string> _menuChoices = new()
        {
            {1, "Add" },
            {2, "Read" },
            {3, "Update" },
            {4, "Delete" },
        };

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
                int? choice = UserInputValidation.MenuValidation(_menuChoices, "BAJS12345621");
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            var areaCalculation = Bajs();
                            if (areaCalculation != null)
                                DatabaseService.AddCalculation((AreaCalculation)areaCalculation);
                            else
                            {
                                PrintMessages.PrintErrorMessage("User chose to discard.");
                                break;
                            }
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        break;
                    case 2:
                        DatabaseService.ReadAllCalculations(Calculation);
                        break;
                    case 3:
                        DatabaseService.UpdateCalculation(1);
                        break;
                    case 4:
                        DatabaseService.DeleteCalculation(Calculation);
                        break;
                    case null:
                        PrintMessages.PrintNotification("Returning back to the main menu.");
                        PrintMessages.PressAnyKeyToContinue();
                        return;
                }
                PrintMessages.PressAnyKeyToContinue();
            }
        }

        private ICalculation? Bajs()
        {
            string? chosenShape = MenuChoice.ChooseGeometricShape();
            AreaContext.SetStrategy(chosenShape);
            if (AreaContext.Strategy != null)
                return AreaCalculationService.CreateAreaCalculation(AreaContext);
            else
                return null;
        }

        public int? PromptUser()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Menuchoice();
        }
        public void PrintBanner()
        {
            string banner = @"***********************************************************************************************
*                                                                                             *
*                              █████╗ ██████╗ ███████╗ █████╗                                 *
*                             ██╔══██╗██╔══██╗██╔════╝██╔══██╗                                *
*                             ███████║██████╔╝█████╗  ███████║                                *
*                             ██╔══██║██╔══██╗██╔══╝  ██╔══██║                                *
*                             ██║  ██║██║  ██║███████╗██║  ██║                                *
*                             ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝                                *
*                                                                                             *
*      ██████╗ █████╗ ██╗      ██████╗██╗   ██╗██╗      █████╗ ████████╗ ██████╗ ██████╗      *
*     ██╔════╝██╔══██╗██║     ██╔════╝██║   ██║██║     ██╔══██╗╚══██╔══╝██╔═══██╗██╔══██╗     *
*     ██║     ███████║██║     ██║     ██║   ██║██║     ███████║   ██║   ██║   ██║██████╔╝     *
*     ██║     ██╔══██║██║     ██║     ██║   ██║██║     ██╔══██║   ██║   ██║   ██║██╔══██╗     *
*     ╚██████╗██║  ██║███████╗╚██████╗╚██████╔╝███████╗██║  ██║   ██║   ╚██████╔╝██║  ██║     *
*      ╚═════╝╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝     *
*                                                                                             *
***********************************************************************************************";
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(banner);
            Console.ResetColor();
        }
        public override string ToString()
        {
            return MenuName;
        }
    }
}
