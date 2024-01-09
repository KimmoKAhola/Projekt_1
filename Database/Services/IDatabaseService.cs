using Database.Models;

namespace Database.Services
{
    public interface IDatabaseService
    {
        void AddCalculation(ICalculation calculation);
        void ReadCalculation(ICalculation calculation);
        void ReadAllCalculations(ICalculation calculation);
        void UpdateCalculation(ICalculation calculation);
        void DeleteCalculation(ICalculation calculation);
    }
}