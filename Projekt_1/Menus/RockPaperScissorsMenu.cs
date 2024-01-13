using Calculator.Mathematics;
using Database.Services;
using InputValidationLibrary;
using Microsoft.EntityFrameworkCore.Storage;
using Projekt_1.Interfaces;
using Rock_Paper_Scissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Menus
{
    public class RockPaperScissorsMenu(RPSService databaseService) : IMenu
    {
        public string MenuName => "Rock, Paper, Scissors";

        public RPSService DatabaseService { get; set; } = databaseService;
        public void Display()
        {
            PrintBanner();
        }


        public void Menuchoice()
        {
            throw new NotImplementedException();
        }

        public int? PromptUser()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.Clear();
            Display();
            RockPaperScissors game = new RockPaperScissors();
            game.RunGame();
            DatabaseService.AddRockPaperScissorsResult(game);
            //DatabaseService.AddRockPaperScissorsHighScore(game);
            PrintMessages.PressAnyKeyToContinue();
        }
        public void PrintBanner()
        {
            string banner = @" _____                                                              _____ 
( ___ )                                                            ( ___ )
 |   |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|   | 
 |   |             ██████╗  ██████╗  ██████╗██╗  ██╗                |   | 
 |   |             ██╔══██╗██╔═══██╗██╔════╝██║ ██╔╝                |   | 
 |   |             ██████╔╝██║   ██║██║     █████╔╝                 |   | 
 |   |             ██╔══██╗██║   ██║██║     ██╔═██╗                 |   | 
 |   |             ██║  ██║╚██████╔╝╚██████╗██║  ██╗                |   | 
 |   |             ╚═╝  ╚═╝ ╚═════╝  ╚═════╝╚═╝  ╚═╝                |   | 
 |   |                                                              |   | 
 |   |         ██████╗  █████╗ ██████╗ ███████╗██████╗              |   | 
 |   |         ██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗             |   | 
 |   |         ██████╔╝███████║██████╔╝█████╗  ██████╔╝             |   | 
 |   |         ██╔═══╝ ██╔══██║██╔═══╝ ██╔══╝  ██╔══██╗             |   | 
 |   |         ██║     ██║  ██║██║     ███████╗██║  ██║             |   | 
 |   |         ╚═╝     ╚═╝  ╚═╝╚═╝     ╚══════╝╚═╝  ╚═╝             |   | 
 |   |                                                              |   | 
 |   | ███████╗ ██████╗██╗███████╗███████╗ ██████╗ ██████╗ ███████╗ |   | 
 |   | ██╔════╝██╔════╝██║██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝ |   | 
 |   | ███████╗██║     ██║███████╗███████╗██║   ██║██████╔╝███████╗ |   | 
 |   | ╚════██║██║     ██║╚════██║╚════██║██║   ██║██╔══██╗╚════██║ |   | 
 |   | ███████║╚██████╗██║███████║███████║╚██████╔╝██║  ██║███████║ |   | 
 |   | ╚══════╝ ╚═════╝╚═╝╚══════╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝ |   | 
 |___|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|___| 
(_____)                                                            (_____)";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(banner);
            Console.ResetColor();
        }
        public override string ToString()
        {
            return MenuName;
        }
    }
}
