namespace Rock_Paper_Scissors
{
    public static class GameLogic
    {
        public static GameState CheckForWin(Move userMove, Move computerMove)
        {
            if (userMove == computerMove)
            {
                return GameState.Tie;
            }
            else if (userMove == Move.Rock && computerMove == Move.Scissors
                || userMove == Move.Scissors && computerMove == Move.Paper
                || userMove == Move.Paper && computerMove == Move.Rock)
            {
                return GameState.Win;
            }
            else
            {
                return GameState.Loss;
            }
        }
    }
}