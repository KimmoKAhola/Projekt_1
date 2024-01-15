﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    public class PlayerMoves
    {
        public Move GetComputerMove()
        {
            var random = new Random();
            int chosenMove = random.Next(0, 3);

            return (Move)chosenMove;
        }

        public Move GetPlayerMove()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Choose a player move: ");

            Move[] playerMoves = [Move.Rock, Move.Paper, Move.Scissors,];

            return PlayerChoices(playerMoves);
        }

        private static Move PlayerChoices(Move[] playerMoves)
        {
            int currentColumn = 0;
            int yPos = Console.CursorTop;

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
                        Move selectedMove = playerMoves[currentColumn];
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