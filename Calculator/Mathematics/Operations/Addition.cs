using Calculator.Interfaces;

namespace Calculator.Mathematics.Operations
{
    public class Addition : IMathStrategy
    {
        public char Operator => '+';

        public double Calculate(double first, double second)
        {
            return first + second;
        }
    }
}
