using Rock_Paper_Scissors;

namespace Database.Interfaces
{
    public interface IDatabaseService<T> where T : class
    {
        void AddCalculation(T calculation);
        void ReadCalculation(int id);
        void ViewAllCalculations();

        List<T> GetAllCalculations();
        void UpdateCalculation(int id);
        void DeleteCalculation(int id);
    }
}