using Database.Models;
using Database.Repositories;
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

        public void ReadAll()
        {
            foreach (var item in _repository.GetAll())
            {
                var info = $"{item.Id} - P: {item.PlayerMove} C: {item.ComputerMove} - R: {item.Outcome}";
                Console.WriteLine(info);
            }
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
    }
}