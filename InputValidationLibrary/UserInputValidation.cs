

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
            Console.Write($"Enter a number between 1 and {maximumInput}, or press 'e' to exit to the main menu: ");
            while (true)
            {
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
                        Console.WriteLine($"Please enter a number between 1 and {maximumInput}.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number or 'e' to exit.");
                }
            }
        }

        public static int? ReturnNumberChoice()
        {
            Console.Write($"Enter a positive number, or press 'e' to exit to the main menu: ");
            while (true)
            {
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
                        Console.WriteLine($"Please enter a positive number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number or 'e' to exit.");
                }
            }
        }
        public static double[]? ReturnTwoNumbers(string msg)
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
                    numbers = [first, second];
                    return numbers;
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
                    Console.WriteLine($"{i + 1}. {choices[i]}");
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