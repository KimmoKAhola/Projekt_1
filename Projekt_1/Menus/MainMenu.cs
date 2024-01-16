using Calculations.StrategyContexts;
using Calculator.Mathematics;
using Calculator.Shapes;
using Database.Interfaces;
using Database.Models;
using Database.Services;
using InputValidationLibrary;
using Projekt_1.Interfaces;
using Rock_Paper_Scissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Menus
{
    public class MainMenu(CalculatorService mathService, ShapeCalculatorService areaService, RPSService rpsService, HighScoreService highScoreService) : IMenu
    {
        private List<IMenu> _menus =
        [
            new CalculatorMenu(new CalculatorContext(), mathService, new MathCalculation()),
            new AreaCalculatorMenu(new ShapeContext(), areaService, new ShapeCalculation()),
            new RockPaperScissorsMenu(rpsService, highScoreService, new Game(new PlayerMoves())),
        ];

        public string MenuName => "Main menu";

        public void Display()
        {
            PrintBanner();
        }


        public void Menuchoice()
        {
            var choice = PromptUserForId();
            if (choice == null)
            {
                Environment.Exit(0);
            }
            _menus[(int)choice - 1].Run();
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
            string banner = @"****************************************************************************
*███╗   ███╗ █████╗ ██╗███╗   ██╗    ███╗   ███╗███████╗███╗   ██╗██╗   ██╗*
*████╗ ████║██╔══██╗██║████╗  ██║    ████╗ ████║██╔════╝████╗  ██║██║   ██║*
*██╔████╔██║███████║██║██╔██╗ ██║    ██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║*
*██║╚██╔╝██║██╔══██║██║██║╚██╗██║    ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║*
*██║ ╚═╝ ██║██║  ██║██║██║ ╚████║    ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝*
*╚═╝     ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝    ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ *
****************************************************************************";
            Console.WriteLine(banner);
        }

        public int? PromptUserForId()
        {
            return UserInputValidation.MenuValidation(_menus, "Choose which game to start: ");
        }
        public override string ToString()
        {
            return MenuName;
        }
    }
}
