using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class Game(PlayerMoves moves)
    {
        private readonly PlayerMoves _playerMoves = moves;
        public Move PlayerMove { get; set; }
        public Move ComputerMove { get; set; }
        public GameState Outcome { get; set; }

        public Game RunGame()
        {
            PlayerMove = _playerMoves.GetPlayerMove();
            ComputerMove = _playerMoves.GetComputerMove();
            Outcome = GameLogic.CheckForWin(PlayerMove, ComputerMove);
            return this;
        }
    }
}