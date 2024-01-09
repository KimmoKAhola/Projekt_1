using Calculator.Interfaces;

namespace Calculator.Mathematics.Operations
{
    public class Addition : IMathStrategy
    {
        public decimal Execute(decimal first, decimal second)
        {
            return Math.Round(first + second, 2);
        }
    }
}
