using Calculator.Interfaces;

namespace Calculator.Math.Operations
{
    public class Addition : IMathStrategy
    {
        public decimal Execute(decimal first, decimal second)
        {
            return first + second;
        }
    }
}
