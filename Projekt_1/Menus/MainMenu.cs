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
    public class MainMenu(DatabaseService service) : IMenu
    {
        private List<IMenu> _menus =
        [
            new CalculatorMenu(new MathContext(), service, new MathCalculation()),
            new AreaCalculatorMenu(new AreaCalculatorContext(), service, new AreaCalculation()),
            new RockPaperScissorsMenu(),
        ];

        public string MenuName => "Main menu";

        public void Display()
        {
            PrintBanner();
        }


        public void Menuchoice()
        {
            var choice = PromptUser();
            _menus[choice - 1].Run();
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

        public int PromptUser()
        {
            return UserInputValidation.MenuValidation(_menus, "Choose which game to start: ");
        }
        public override string ToString()
        {
            return MenuName;
        }
    }
}
