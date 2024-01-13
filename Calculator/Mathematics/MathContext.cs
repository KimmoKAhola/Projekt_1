using Calculator.Interfaces;
using Calculator.Mathematics.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Mathematics
{
    public class MathContext
    {
        public IMathStrategy? Strategy { get; private set; } = null;
        public char Operator { get; private set; }
        private static IMathStrategy? CreateStrategy(char choice)
        {
            return choice switch
            {
                '+' => new Addition(),
                '-' => new Subtraction(),
                '*' => new Multiplication(),
                '÷' => new Division(),
                '%' => new Modulus(),
                '√' => new SquareRoot(),
                '➡' => null,
                _ => throw new BajskorvException("Bajskorv!"),
            };
        }

        public void SetStrategy(char choice)
        {
            Strategy = CreateStrategy(choice);
            if (Strategy != null)
                Operator = Strategy.Operator;
        }

        public double ExecuteStrategy(double first, double second)
        {
            return Math.Round(Strategy.Calculate(first, second), 2);
        }
    }
}