using Calculator.Mathematics;
using Database.Services;
using Projekt_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Menus
{
    public class AreaCalculatorMenu : IMenu
    {
        private MathContext _context;
        DatabaseService _databaseService;
        public AreaCalculatorMenu(MathContext context, DatabaseService databaseService)
        {
            _context = context;
            _databaseService = databaseService;
        }
        public void Display()
        {
            PrintBanner();
        }


        public void Menuchoice(int choice)
        {
            throw new NotImplementedException();
        }

        public int PromptUser()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.Clear();
            Display();
            Console.ReadKey();
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
    }
}
