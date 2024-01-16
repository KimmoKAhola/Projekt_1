using Database.Models;
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
                Console.WriteLine($"W: {highScore.NumberOfWins} L: {highScore.NumberOfLosses} T: {highScore.NumberOfTies} - W % {highScore.AverageScore:P2}");
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
    }
}