using Database.Models;
using Database.Repositories;
using InputValidationLibrary;
using Rock_Paper_Scissors;

namespace Database.Services
{
    public class RPSService(RPSRepository repository)
    {
        private readonly RPSRepository _repository = repository;
        public void AddRockPaperScissorsResult(Game game)
        {
            var rps = CreateRockPaperScissors(game);
            _repository.Add(rps);
            _repository.Save();
        }

        public void ViewAll()
        {
            var allGames = _repository.GetAll();
            PrintResultsTable(allGames);
        }

        public static RockPaperScissors CreateRockPaperScissors(Game game)
        {
            var rps = new RockPaperScissors
            {
                PlayerMove = game.PlayerMove.ToString(),
                ComputerMove = game.ComputerMove.ToString(),
                Outcome = game.Outcome.ToString(),
            };

            return rps;
        }

        public static void PrintResultsTable(IEnumerable<RockPaperScissors> results)
        {
            if (results == null || !results.Any())
            {
                Console.WriteLine("No results to display.");
                return;
            }
            string playerHeader = "Player's move";
            string computerHeader = "Computer's move";
            string resultHeader = "Result";
            string datePlayedHeader = "Date played";


            int playerColumnWidth = Math.Max(results.Max(r => r.PlayerMove.Length), playerHeader.Length);
            int computerColumnWidth = Math.Max(results.Max(r => r.ComputerMove.Length), computerHeader.Length);
            int resultColumnWidth = Math.Max(results.Max(r => r.Outcome.Length), resultHeader.Length);
            int datePlayedColumnWidth = Math.Max(results.Max(r => r.DateCreated.ToString().Length), datePlayedHeader.Length);

            int totalWidth = playerColumnWidth + computerColumnWidth + resultColumnWidth + datePlayedColumnWidth + 9;

            PrintMessages.PrintNotification("A complete list of all played games.\n");
            Console.WriteLine($"{playerHeader.PadRight(playerColumnWidth)} | {computerHeader.PadRight(computerColumnWidth)} | {resultHeader.PadRight(resultColumnWidth)} | {datePlayedHeader.PadRight(datePlayedColumnWidth)}");
            Console.WriteLine(new string('-', totalWidth));

            foreach (var result in results)
            {
                Console.WriteLine($"{result.PlayerMove.PadRight(playerColumnWidth)} | {result.ComputerMove.PadRight(computerColumnWidth)} | {result.Outcome.PadRight(resultColumnWidth)} | {result.DateCreated.ToString().PadRight(datePlayedColumnWidth)}");
            }
            Console.WriteLine();
        }
    }
}