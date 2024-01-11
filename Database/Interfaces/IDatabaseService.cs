namespace Database.Interfaces
{
    public interface IDatabaseService
    {
        void AddCalculation(ICalculation calculation);
        void ReadCalculation(ICalculation calculation);
        void ReadAllCalculations(ICalculation calculation);
        void UpdateCalculation(ICalculation calculation);
        void DeleteCalculation(ICalculation calculation);

        void AddRockPaperScissorsResult();
        void AddRockPaperScissorsHighScore();
    }
}