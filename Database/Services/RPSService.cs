using Database.Models;
using Database.Repositories;
using Rock_Paper_Scissors;

namespace Database.Services
{
    public class RPSService(RPSRepository repository)
    {
        private RPSRepository _repository = repository;
        public void AddRockPaperScissorsHighScore(Models.RockPaperScissors game)
        {
            throw new NotImplementedException();
        }

        public void AddRockPaperScissorsResult(Rock_Paper_Scissors.RockPaperScissors game)
        {
            _repository.Add(game);
        }
    }
}