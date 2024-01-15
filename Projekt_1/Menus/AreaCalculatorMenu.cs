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
                int? choice = UserInputValidation.MenuValidation(_menuChoices, "These are your available options.\n");
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            var areaCalculation = GetStrategy();
                            if (areaCalculation != null)
                                DatabaseService.AddCalculation((AreaCalculation)areaCalculation);
                            else
                            {
                                PrintMessages.PrintErrorMessage("User chose to exit.");
                                break;
                            }
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                        break;
                    case 2:
                        DatabaseService.ReadAllCalculations();
                        break;
                    case 3:
                        int? idToUpdate = PromptUser();
                        if (idToUpdate != null)
                            DatabaseService.UpdateCalculation((int)idToUpdate);
                        else
                        {
                            PrintMessages.PrintErrorMessage("User chose to exit.");
                        }
                        break;
                    case 4:
                        int? idToDelete = PromptUser();
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
            AreaContext.SetStrategy(chosenShape);
            if (AreaContext.Strategy != null)
                return AreaCalculationService.CreateAreaCalculation(AreaContext);
            else
                return null;
        }

        public int? PromptUser()
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
