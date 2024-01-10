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
    public class MainMenu(MathContext context, DatabaseService service, MathCalculation calculation) : IMenu
    {
        private List<IMenu> _menus = new List<IMenu>()
        {
            new CalculatorMenu(context, service, calculation),
            new AreaCalculatorMenu(context, service),
            new RockPaperScissorsMenu(),
        };
        public void Display()
        {
            PrintBanner();
        }


        public void Menuchoice(int choice)
        {
            _menus[choice - 1].Run();
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Display();
                var choice = PromptUser();
                Menuchoice(choice);
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
    }
}
