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
    public class RockPaperScissorsMenu(RPSService databaseService, RockPaperScissors rockPaperScissors) : IMenu
    {
        public string MenuName => "Rock, Paper, Scissors";

        public RPSService DatabaseService { get; set; } = databaseService;
        public RockPaperScissors RockPaperScissors { get; set; } = rockPaperScissors;
        public void Display()
        {
            PrintBanner();
        }


        public void Menuchoice()
        {
            throw new NotImplementedException();
        }

        public int? PromptUserForId()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.Clear();
            Display();
            RockPaperScissors.RunGame();
            DatabaseService.AddRockPaperScissorsResult(RockPaperScissors);
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
