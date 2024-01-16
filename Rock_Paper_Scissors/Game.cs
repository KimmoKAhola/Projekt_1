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

        public void PrintResultsTable()
        {
            if (this == null)
            {
                Console.WriteLine("No result to display.");
                return;
            }
            string playerHeader = "Player's move";
            string computerHeader = "Computer's move";
            string resultHeader = "Result";

            int playerColumnWidth = Math.Max(PlayerMove.ToString().Length, playerHeader.Length);
            int computerColumnWidth = Math.Max(ComputerMove.ToString().Length, computerHeader.Length);
            int resultColumnWidth = Math.Max(Outcome.ToString().Length, resultHeader.Length);

            int totalWidth = playerColumnWidth + computerColumnWidth + resultColumnWidth + 6;

            Console.WriteLine($"{playerHeader.PadRight(playerColumnWidth)} | {computerHeader.PadRight(computerColumnWidth)} | {resultHeader.PadRight(resultColumnWidth)}");
            Console.WriteLine(new string('-', totalWidth));

            Console.Write($"{PlayerMove.ToString().PadRight(playerColumnWidth)} | {ComputerMove.ToString().PadRight(computerColumnWidth)} | ");
            if (Outcome == GameState.Win)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (Outcome == GameState.Loss)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            Console.WriteLine($"{Outcome.ToString().PadRight(resultColumnWidth)}");
            Console.ResetColor();
        }
    }
}