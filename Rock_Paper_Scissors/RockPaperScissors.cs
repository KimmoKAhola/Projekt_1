using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class RockPaperScissors(PlayerMoves moves)
    {
        public Move PlayerMove { get; set; }
        public Move ComputerMove { get; set; }
        public string Outcome { get; set; } = string.Empty;

        public void RunGame()
        {
            PlayerMove = moves.GetPlayerMove();
            ComputerMove = moves.GetComputerMove();
            Outcome = GameLogic.CheckForWin(PlayerMove, ComputerMove).ToString();
        }
    }
}