using Calculations.Services;
using Calculator.Interfaces;
using Calculator.Mathematics;
using Calculator.Shapes;
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
                    var chosenShape = MenuChoice.ChooseGeometricShape();
                    AreaContext.SetStrategy(chosenShape);
                    ICalculation? areaCalculation = CalculationServices.CreateAreaCalculation(AreaContext);
                    if (areaCalculation != null)
                        DatabaseService.AddCalculation((AreaCalculation)areaCalculation);
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
                    DatabaseService.DeleteCalculation(Calculation);
                    break;
                case 0:

                    break;
            }
            PrintMessages.PressAnyKeyToContinue();
        }

        public int? PromptUser()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Display();
                Menuchoice();
            }
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
