﻿using Database.Models;
using Database.Repositories;
using InputValidationLibrary;
using Microsoft.Identity.Client;
using Rock_Paper_Scissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public class HighScoreService(HighScoreRepository highScoreRepository, RPSRepository rpsRepository)
    {
        private readonly HighScoreRepository _highScoreRepository = highScoreRepository;
        private readonly RPSRepository _rpsRepository = rpsRepository;
        public void UpdateHighScore()
        {
            HighScore? currentScore = GetCurrentHighScore();
            var newHighScore = CalculateHighScore(currentScore);
            if (currentScore == null)
            {
                _highScoreRepository.Add(newHighScore);
            }
            _highScoreRepository.Save();
        }

        public HighScore? GetCurrentHighScore()
        {
            return _highScoreRepository.Get();
        }

        public void ViewHighScore()
        {
            var highScore = GetCurrentHighScore();
            if (highScore != null)
            {
                PrintHighScoreTable(highScore);
            }
            else
            {
                PrintMessages.PrintErrorMessage("No high score is available.");
            }
        }

        private HighScore CalculateHighScore(HighScore? highScore)

        {
            var allGames = _rpsRepository.GetAll().ToList();

            if (highScore != null)
            {
                highScore.NumberOfWins = allGames.Count(x => x.Outcome == GameState.Win.ToString());
                highScore.NumberOfLosses = allGames.Count(x => x.Outcome == GameState.Loss.ToString());
                highScore.NumberOfTies = allGames.Count(x => x.Outcome == GameState.Tie.ToString());
                highScore.AverageScore = CalculateAverageScore(allGames);
                highScore.DateLastUpdated = DateTime.Now;
                return highScore;
            }
            else
            {
                return new HighScore
                {
                    NumberOfWins = allGames.Count(x => x.Outcome == GameState.Win.ToString()),
                    NumberOfLosses = allGames.Count(x => x.Outcome == GameState.Loss.ToString()),
                    NumberOfTies = allGames.Count(x => x.Outcome == GameState.Tie.ToString()),
                    AverageScore = CalculateAverageScore(allGames),
                    DateCreated = DateTime.Now,
                };
            }
        }

        private static double CalculateAverageScore(List<RockPaperScissors> allGames)
        {
            double numberOfWins = allGames.Count(x => x.Outcome == GameState.Win.ToString());
            double numberOfGames = allGames.Count;
            return Math.Round(numberOfWins / numberOfGames, 5);
        }

        private static void PrintHighScoreTable(HighScore highScore)
        {
            string playerHeader = "Number of wins";
            string computerHeader = "Number of losses";
            string resultHeader = "Number of ties";
            string winLossHeader = "Win/loss percentage";

            int winsColumnWidth = Math.Max(highScore.NumberOfWins.ToString().Length, playerHeader.Length);
            int lossColumnWidth = Math.Max(highScore.NumberOfLosses.ToString().Length, computerHeader.Length);
            int tiesColumnWidth = Math.Max(highScore.NumberOfTies.ToString().Length, resultHeader.Length);
            int winLossColumnWidth = Math.Max(highScore.AverageScore.ToString().Length, winLossHeader.Length);

            int totalWidth = winsColumnWidth + lossColumnWidth + tiesColumnWidth + winLossColumnWidth + 6;
            string banner = @"
██╗  ██╗██╗ ██████╗ ██╗  ██╗    ███████╗ ██████╗ ██████╗ ██████╗ ███████╗
██║  ██║██║██╔════╝ ██║  ██║    ██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝
███████║██║██║  ███╗███████║    ███████╗██║     ██║   ██║██████╔╝█████╗  
██╔══██║██║██║   ██║██╔══██║    ╚════██║██║     ██║   ██║██╔══██╗██╔══╝  
██║  ██║██║╚██████╔╝██║  ██║    ███████║╚██████╗╚██████╔╝██║  ██║███████╗
╚═╝  ╚═╝╚═╝ ╚═════╝ ╚═╝  ╚═╝    ╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝";
            Console.WriteLine(banner + "\n");
            Console.WriteLine($"{playerHeader.PadRight(winsColumnWidth)} | {computerHeader.PadRight(lossColumnWidth)} | {resultHeader.PadRight(tiesColumnWidth)} | {winLossHeader.PadRight(winLossColumnWidth)}");
            Console.WriteLine(new string('-', totalWidth));
            string avg = $"{highScore.AverageScore:P2}";
            Console.WriteLine($"{highScore.NumberOfWins.ToString().PadRight(winsColumnWidth)} | {highScore.NumberOfLosses.ToString().PadRight(lossColumnWidth)} | {highScore.NumberOfTies.ToString().PadRight(tiesColumnWidth)} | {avg.PadRight(winLossColumnWidth)}\n");
        }
    }
}