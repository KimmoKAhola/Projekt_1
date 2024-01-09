namespace Calculator
{
    public class MathOperations
    {
        public static decimal Addition(decimal first, decimal second)
        {
            return first + second;
        }

        public static decimal Subtraction(decimal first, decimal second)
        {
            return first - second;
        }

        public static decimal Multiplication(decimal first, decimal second)
        {
            return first * second;
        }

        public static decimal Division(decimal first, decimal second)
        {
            return first / second;
        }

        public static double SquareRoot(double first)
        {
            return Math.Sqrt(first);
        }

        public static decimal Modulus(decimal first, decimal second)
        {
            return Decimal.Remainder(first, second);
        }
    }
}
