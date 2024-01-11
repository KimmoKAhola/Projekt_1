using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public enum Move
    {
        Rock,
        Paper,
        Scissors
    }

    public enum GameState
    {
        Win,
        Loss,
        Tie
    }
    public class Game
    {
        public Game()
        {

        }

        public string PlayerMove { get; set; }
        public string ComputerMove { get; set; }
        public string Outcome { get; set; }

        public void RunGame()
        {
            PlayerMove = GetPlayerMove();
            ComputerMove = Computer.GetComputerMove().ToString();
            Console.WriteLine(PlayerMove);
            Console.WriteLine(ComputerMove);
            Outcome = GameLogic.CheckForWin(PlayerMove, ComputerMove);
        }

        public static string GetPlayerMove()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Choose a player move: ");
            int yPos = Console.CursorTop;

            string[] playerMoves = [$"{Move.Rock}", $"{Move.Paper}", $"{Move.Scissors}",];

            int currentColumn = 0;

            while (true)
            {
                for (int column = 0; column < playerMoves.Length; column++)
                {
                    if (column == currentColumn)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($"{playerMoves[column]} ");

                    Console.ResetColor();

                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        currentColumn = (currentColumn - 1 + playerMoves.GetLength(0)) % playerMoves.GetLength(0);
                        break;
                    case ConsoleKey.RightArrow:
                        currentColumn = (currentColumn + 1) % playerMoves.GetLength(0);
                        break;
                    case ConsoleKey.Enter:
                        string selectedMove = playerMoves[currentColumn];
                        Console.WriteLine();
                        Console.CursorVisible = true;
                        return selectedMove;
                    default:
                        break;
                }
                Console.SetCursorPosition(0, yPos);
            }
        }
    }
}
