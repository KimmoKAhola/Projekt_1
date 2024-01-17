using Calculator.Interfaces;

namespace Calculator.Mathematics.Operations
{
    public class Addition : IMath
    {
        public char Operator => '+';

        public double Calculate(double first, double second)
        {
            return first + second;
        }
    }
}
