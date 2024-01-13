﻿using Calculations.Services;
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
    public class CalculatorMenu(MathContext mathContext, MathCalculationService databaseService, MathCalculation calculation) : IMenu
    {
        public MathCalculationService DatabaseService { get; set; } = databaseService;
        public MathCalculation Calculation { get; set; } = calculation;
        public MathContext MathContext { get; set; } = mathContext;

        private readonly Dictionary<int, string> _menuChoices = new()
        {
            {1, "Add" },
            {2, "Read" },
            {3, "Update" },
            {4, "Delete" },
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
                int? choice = UserInputValidation.MenuValidation(_menuChoices, "BAjs1234");
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            var mathCalculation = Bajs();
                            if (mathCalculation != null)
                                DatabaseService.AddCalculation((MathCalculation)mathCalculation);
                            else
                            {
                                PrintMessages.PrintErrorMessage("User chose to exit.");
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
                        DatabaseService.UpdateCalculation(Calculation);
                        break;
                    case 4:
                        DatabaseService.DeleteCalculation(Calculation);
                        break;
                    case null:
                        PrintMessages.PrintNotification("Returning back to the main menu.");
                        PrintMessages.PressAnyKeyToContinue();
                        return;
                    default:
                        PrintMessages.PrintNotification("Returning back to the main menu.");
                        PrintMessages.PressAnyKeyToContinue();
                        return;

                }
                PrintMessages.PressAnyKeyToContinue();
            }
        }
        private ICalculation? Bajs()
        {
            var chosenOperator = MenuChoice.ChooseMathOperator();
            MathContext.SetStrategy(chosenOperator);
            if (MathContext.Strategy != null)
                return CalculationServices.CreateMathCalculation(MathContext);
            else
                return null;
        }
        public int? PromptUser()
        {
            return 1;
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