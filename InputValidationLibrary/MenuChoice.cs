
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputValidationLibrary
{
    public static class MenuChoice
    {
        public static char ChooseMathOperator()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Choose an operator:");
            int yPos = Console.CursorTop;
            char[] operators = ['+', '-', '*', '÷', '%', '√', '➡'];

            int currentColumn = 0;

            while (true)
            {
                for (int column = 0; column < operators.GetLength(0); column++)
                {
                    if (column == currentColumn)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($" {operators[column]} ");

                    Console.ResetColor();
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        currentColumn = (currentColumn - 1 + operators.GetLength(0)) % operators.GetLength(0);
                        break;
                    case ConsoleKey.RightArrow:
                        currentColumn = (currentColumn + 1) % operators.GetLength(0);
                        break;
                    case ConsoleKey.Enter:
                        char selectedOperator = operators[currentColumn];
                        Console.WriteLine();
                        Console.CursorVisible = true;
                        return selectedOperator;
                    default:
                        break;
                }
                Console.SetCursorPosition(0, yPos);
            }
        }

        public static string? ChooseGeometricShape()
        {
            Console.CursorVisible = false;
            Console.WriteLine("Choose a geometric shape, or pick 'E' to exit:");
            int yPos = Console.CursorTop;
            char[] operators = ['▬', '▲', 'P', '♦', 'E']; //▰
            string?[] shapes = ["Rectangle", "Triangle", "Parallelogram", "Rhomboid", null];
            int currentColumn = 0;

            while (true)
            {
                for (int column = 0; column < operators.GetLength(0); column++)
                {
                    if (column == currentColumn)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($" {operators[column]} ");

                    Console.ResetColor();
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        currentColumn = (currentColumn - 1 + operators.GetLength(0)) % operators.GetLength(0);
                        break;
                    case ConsoleKey.RightArrow:
                        currentColumn = (currentColumn + 1) % operators.GetLength(0);
                        break;
                    case ConsoleKey.Enter:
                        string? selectedOperator = shapes[currentColumn];
                        Console.WriteLine();
                        Console.CursorVisible = true;
                        return selectedOperator;
                    default:
                        break;
                }
                Console.SetCursorPosition(0, yPos);
            }
        }


    }
}