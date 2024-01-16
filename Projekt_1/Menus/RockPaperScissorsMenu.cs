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
            {1, "Play a game of Rock, paper, scissors." },
            {2, "View your individual results of previous games." },
            {3, "View your total W/L record." },
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
                int? choice = UserInputValidation.MenuValidation(_menuChoices, "\nThese are your available options.\n");
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        while (true)
                        {
                            RockPaperScissors.RunGame();
                            RockPaperScissors.PrintResultsTable();
                            DatabaseService.AddRockPaperScissorsResult(RockPaperScissors);
                            if (!UserInputValidation.PromptYesOrNo("\nPress y to play again.\nPress anything else to exit: "))
                            {
                                PrintMessages.PrintNotification("User chose to exit.");
                                HighScoreService.UpdateHighScore();
                                break;
                            }
                        }
                        break;
                    case 2:
                        DatabaseService.ViewAll();
                        break;
                    case 3:
                        HighScoreService.ViewHighScore();
                        break;
                    case null:
                        PrintMessages.PrintNotification("Returning back to the main menu.");
                        PrintMessages.PressAnyKeyToContinue();
                        return;
                }
                PrintMessages.PressAnyKeyToContinue();
            }
        }

        public int? PromptUserForId()
        {
            return -999; //Not implemented for this menu
        }

        public void Run()
        {
            Console.Clear();
            Display();
            Menuchoice();
        }
        public void PrintBanner()
        {
            string banner = @"*************************************************************************************
*██████╗  ██████╗  ██████╗██╗  ██╗       ██████╗  █████╗ ██████╗ ███████╗██████╗    *
*██╔══██╗██╔═══██╗██╔════╝██║ ██╔╝       ██╔══██╗██╔══██╗██╔══██╗██╔════╝██╔══██╗   *
*██████╔╝██║   ██║██║     █████╔╝        ██████╔╝███████║██████╔╝█████╗  ██████╔╝   *
*██╔══██╗██║   ██║██║     ██╔═██╗        ██╔═══╝ ██╔══██║██╔═══╝ ██╔══╝  ██╔══██╗   *
*██║  ██║╚██████╔╝╚██████╗██║  ██╗▄█╗    ██║     ██║  ██║██║     ███████╗██║  ██║▄█╗*
*╚═╝  ╚═╝ ╚═════╝  ╚═════╝╚═╝  ╚═╝╚═╝    ╚═╝     ╚═╝  ╚═╝╚═╝     ╚══════╝╚═╝  ╚═╝╚═╝*
*                                                                                   *
*            ███████╗ ██████╗██╗███████╗███████╗ ██████╗ ██████╗ ███████╗           *
*            ██╔════╝██╔════╝██║██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝           *
*            ███████╗██║     ██║███████╗███████╗██║   ██║██████╔╝███████╗           *
*            ╚════██║██║     ██║╚════██║╚════██║██║   ██║██╔══██╗╚════██║           *
*            ███████║╚██████╗██║███████║███████║╚██████╔╝██║  ██║███████║           *
*            ╚══════╝ ╚═════╝╚═╝╚══════╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝           *
*************************************************************************************";
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
