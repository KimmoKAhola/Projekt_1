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
    public class ShapeCalculatorMenu(ShapeContext shapeContext, ShapeCalculatorService databaseService, ShapeCalculation calculation) : IMenu
    {
        public ShapeCalculatorService DatabaseService { get; set; } = databaseService;
        public ShapeCalculation Calculation { get; set; } = calculation;
        public ShapeContext ShapeContext { get; set; } = shapeContext;

        public string MenuName => "Area Calculator";

        private readonly Dictionary<int, string> _menuChoices = new()
        {
            {1, "Add a new calculation." },
            {2, "View all calculations." },
            {3, "Update a calculation." },
            {4, "Delete a calculation." },
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
                int? choice = UserInputValidation.MenuValidation(_menuChoices, "\nThese are your available options.\n");
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            var areaCalculation = GetStrategy();
                            if (areaCalculation != null)
                                DatabaseService.AddCalculation((ShapeCalculation)areaCalculation);
                            else
                            {
                                PrintMessages.PrintErrorMessage("User chose to exit.");
                                break;
                            }
                            Thread.Sleep(1500);
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
                        PrintMessages.PrintNotification("Returning back to the main menu.");
                        PrintMessages.PressAnyKeyToContinue();
                        return;
                }
                PrintMessages.PressAnyKeyToContinue();
            }
        }

        private ICalculation? GetStrategy()
        {
            string? chosenShape = MenuChoice.ChooseGeometricShape();
            ShapeContext.SetStrategy(chosenShape);
            if (ShapeContext.Strategy != null)
                return ShapeCalculatorService.CreateAreaCalculation(ShapeContext);
            else
                return null;
        }

        public int? PromptUserForId()
        {
            var test = DatabaseService.GetAllCalculations();
            int? userChoice = UserInputValidation.MenuValidation(test, "\nThis is a list of all available calculations that can be updated.\n");
            if (userChoice != null)
            {
                return test[(int)userChoice - 1].Id;
            }
            else
            {
                PrintMessages.PrintErrorMessage("User chose to exit.");
                return null;
            }
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
