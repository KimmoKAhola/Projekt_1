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
    public class RockPaperScissorsMenu(RPSService databaseService, HighScoreService highScoreService, Game rockPaperScissors) : IMenu
    {
        public string MenuName => "Rock, Paper, Scissors";

        public RPSService DatabaseService { get; set; } = databaseService;
        public HighScoreService HighScoreService { get; set; } = highScoreService;
        public Game RockPaperScissors { get; set; } = rockPaperScissors;

        private readonly Dictionary<int, string> _menuChoices = new()
        {
            {1, "Play" },
            {2, "Read" },
            {3, "View Highscore" },
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
                            Console.Clear();
                            if (UserInputValidation.PromptYesOrNo("Press y to play a game, anything else to exit: "))
                            {
                                RockPaperScissors.RunGame();
                                DatabaseService.AddRockPaperScissorsResult(RockPaperScissors);
                            }
                            else
                            {
                                PrintMessages.PrintNotification("User chose to exit.");
                                HighScoreService.UpdateHighScore();
                                break;
                            }
                        }
                        break;
                    case 2:
                        DatabaseService.ReadAll();
                        break;
                    case 3:
                        HighScoreService.ViewHighScore();
                        break;
                    default:
                        return;
                }
                PrintMessages.PressAnyKeyToContinue();
            }
        }

        public int? PromptUserForId()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.Clear();
            Display();
            Menuchoice();
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
