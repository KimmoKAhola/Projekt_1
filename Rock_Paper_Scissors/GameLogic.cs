namespace Rock_Paper_Scissors
{
    public static class GameLogic
    {
        public static string CheckForWin(string userInput, string computerInput)
        {
            if (userInput == computerInput)
            {
                Console.WriteLine($"{GameState.Tie}");
                return GameState.Tie.ToString();
            }
            else if (userInput == Move.Rock.ToString() && computerInput == Move.Scissors.ToString()
                || userInput == Move.Scissors.ToString() && computerInput == Move.Paper.ToString()
                || userInput == Move.Paper.ToString() && computerInput == Move.Rock.ToString())
            {
                Console.WriteLine($"{GameState.Win}");
                return GameState.Win.ToString();
            }
            else
            {
                Console.WriteLine($"{GameState.Loss}");
                return GameState.Loss.ToString();
            }
        }
    }
}