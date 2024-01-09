

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
        /// Let the user choose between two options, one or two.
        /// Return true if 1.
        /// </summary>
        /// <returns></returns>
        public static bool PromptOneOrTwo(string msg)
        {
            Console.Write(msg);
            var input = Console.ReadKey(true);
            return input.KeyChar == '1';
        }

        /// <summary>
        /// Returns a numbered choice between 1 and maximumInput.
        /// Returns -1 if user enters 'e'.
        /// </summary>
        /// <param name="maximumInput"></param>
        /// <returns></returns>
        public static int ReturnNumberChoice(int maximumInput)
        {
            var choice = 0;
            Console.Write($"Enter a number between 1 and {maximumInput}, or press 'e' to exit: ");
            while (true)
            {
                string? input = Console.ReadLine();
                if (input?.ToLower() == "e")
                {
                    return -1;
                }
                if (int.TryParse(input, out choice))
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

        /// <summary>
        /// Asks for a general input string. Will truncate its answer to 30 characters. Business rules.
        /// </summary>
        /// <returns></returns>
        public static string? AskForValidInputString()
        {
            while (true)
            {
                string? value = Console.ReadLine();
                if (value?.ToLower() == "e" || value == null)
                {
                    return null;
                }
                else
                {
                    Console.WriteLine();
                    if (value.Length > 30)
                    {
                        value = value.Substring(0, 30);
                    }
                    return value;
                }
            }
        }
        public static string AskForValidInputString(string prompt)
        {
            string? value = "";
            while (value?.Length <= 0 || value == null)
            {
                Console.Write($"Enter your input for the {prompt}: ");
                value = Console.ReadLine();
                if (!(value?.Length > 0))
                {
                    PrintMessages.PrintErrorMessage("You can not have an empty input.");
                }
            }
            return value;
        }
        public static double? AskForValidNumber(double minimumInput, double maximumInput, string promptMessage)
        {
            double choice;
            while (true)
            {
                Console.WriteLine(promptMessage);
                Console.Write($"Enter a number between {minimumInput} and {maximumInput}, or press 'e' to exit: ");
                string? input = Console.ReadLine();
                if (input?.ToLower() == "e" || input == null)
                {
                    return null;
                }
                if (double.TryParse(input, out choice))
                {
                    if (choice >= minimumInput && choice <= maximumInput)
                    {
                        return choice;
                    }
                    else
                    {
                        PrintMessages.PrintErrorMessage($"Please enter a number between {minimumInput} and {maximumInput}.");
                    }
                }
                else
                {
                    PrintMessages.PrintErrorMessage("Invalid input.");
                }
            }
        }
        public static int MenuValidation(Dictionary<int, string> choices, string promptMessage)
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
        public static int MenuValidation<T>(List<T> choices, string promptMessage)
        {
            var maxValue = choices.Count;
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {choices[i]}");
            }
            Console.Write(promptMessage);
            var choice = ReturnNumberChoice(maxValue);
            return choice;
        }
    }
}