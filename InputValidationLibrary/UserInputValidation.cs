

namespace InputValidationLibrary
{
    public static class UserInputValidation
    {
        /// <summary>
        /// Promps the user for y (or no). If y then true, else false.
        /// </summary>
        /// <returns></returns>
        public static bool PromptYesOrNo(string msg)
        {
            Console.Write(msg);
            var input = Console.ReadKey(true);
            return input.KeyChar == 'y' || input.KeyChar == 'Y';
        }
        /// <summary>
        /// Returns a numbered choice between 1 and maximumInput.
        /// Returns -1 if user enters 'e'.
        /// </summary>
        /// <param name="maximumInput"></param>
        /// <returns></returns>
        public static int? ReturnNumberChoice(int maximumInput)
        {
            while (true)
            {
                Console.Write($"Enter a number between 1 and {maximumInput}, or press 'e' to exit: ");
                string? input = Console.ReadLine();
                if (input?.ToLower() == "e")
                {
                    return null;
                }
                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1 && choice <= maximumInput)
                    {
                        return choice;
                    }
                    else
                    {
                        PrintMessages.PrintErrorMessage($"Please enter a number between 1 and {maximumInput}.");
                    }
                }
                else
                {
                    PrintMessages.PrintErrorMessage("Invalid input. Please enter a valid number or 'e' to exit.");
                }
            }
        }

        public static int? ReturnNumberChoice()
        {
            while (true)
            {
                Console.Write($"Enter a positive number, or press 'e' to exit to the main menu: ");
                string? input = Console.ReadLine();
                if (input?.ToLower() == "e")
                {
                    return null;
                }
                if (int.TryParse(input, out int choice))
                {
                    if (choice >= 1)
                    {
                        return choice;
                    }
                    else
                    {
                        PrintMessages.PrintErrorMessage($"Please enter a positive number.");
                    }
                }
                else
                {
                    PrintMessages.PrintErrorMessage("Invalid input. Please enter a valid number or 'e' to exit.");
                }
            }
        }
        public static double[]? ReturnTwoNumbersForShapes(string msg)
        {
            double[] numbers;
            while (true)
            {
                Console.Write(msg);
                string? input = Console.ReadLine();
                if (input?.ToLower() == "e" || input == null)
                {
                    return null;
                }

                string[] userInput = input.Split(' ');
                if (userInput.Length == 2 && double.TryParse(userInput[0], out double first) && first > 0 && double.TryParse(userInput[1], out double second) && second > 0)
                {
                    if (first > 1E100 || second > 1E100)
                    {
                        PrintMessages.PrintErrorMessage($"We do not allow math operations with numbers above {1E100}");
                    }
                    else
                    {
                        numbers = [Math.Round(first, 2), Math.Round(second, 2)];
                        return numbers;
                    }
                }
                else
                {
                    PrintMessages.PrintErrorMessage("Invalid user input.");
                }
            }
        }

        public static double[]? ReturnTwoNumbersForMath(string msg)
        {
            double[] numbers;
            while (true)
            {
                Console.Write(msg);
                string? input = Console.ReadLine();
                if (input?.ToLower() == "e" || input == null)
                {
                    return null;
                }

                string[] userInput = input.Split(' ');
                if (userInput.Length == 2 && double.TryParse(userInput[0], out double first) && double.TryParse(userInput[1], out double second))
                {
                    if (first > 1E100 || second > 1E100)
                    {
                        PrintMessages.PrintErrorMessage($"We do not allow math operations with numbers above {1E100}");
                    }
                    else
                    {
                        numbers = [Math.Round(first, 2), Math.Round(second, 2)];
                        return numbers;
                    }
                }
                else
                {
                    PrintMessages.PrintErrorMessage("Invalid user input.");
                }
            }
        }
        public static int? MenuValidation(Dictionary<int, string> choices, string promptMessage)
        {
            var maxValue = choices.Count;
            foreach (var kvp in choices)
            {
                Console.WriteLine($"{kvp.Key}. {kvp.Value}");
            }

            Console.Write(promptMessage);
            var choice = ReturnNumberChoice(maxValue);
            return choice;
        }
        public static int? MenuValidation<T>(List<T> choices, string promptMessage)
        {
            var maxValue = choices.Count;
            if (choices.Count > 0)
            {
                for (int i = 0; i < choices.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write($"{i + 1}. ");
                    Console.ResetColor();
                    Console.WriteLine($"{choices[i]}");
                }
                Console.Write(promptMessage);
                var choice = ReturnNumberChoice(maxValue);
                return choice;
            }
            else
            {
                PrintMessages.PrintErrorMessage("There are no entities to update.");
                PrintMessages.PressAnyKeyToContinue();
                return null;
            }
        }
    }
}