using Database.Models;

namespace Database.Services
{
    public interface IDatabaseService
    {
        void AddCalculation(MathCalculation calculation);
        void ReadCalculation(MathCalculation calculation;
        void ReadAllCalculations(MathCalculation calculation);
        void UpdateCalculation(MathCalculation calculation);
        void DeleteCalculation(MathCalculation calculation);
    }
}