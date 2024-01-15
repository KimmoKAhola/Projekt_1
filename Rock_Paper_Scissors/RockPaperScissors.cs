using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class RockPaperScissors
    {
        public string PlayerMove { get; set; } = string.Empty;
        public string ComputerMove { get; set; } = string.Empty;
        public string Outcome { get; set; } = string.Empty;

        public void RunGame()
        {
            PlayerMove = PlayerMoves.GetPlayerMove();
            ComputerMove = PlayerMoves.GetComputerMove().ToString();
            Console.WriteLine(PlayerMove);
            Console.WriteLine(ComputerMove);
            Outcome = GameLogic.CheckForWin(PlayerMove, ComputerMove);
        }
    }
}