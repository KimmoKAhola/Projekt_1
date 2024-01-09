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
        private IMathStrategy _strategy;

        public MathContext(IMathStrategy strategy)
        {
            _strategy = strategy;
        }

        public double Calculate(double first, double second)
        {
            return _strategy.Execute(first, second);
        }

        public IMathStrategy? SetStrategy(int choice)
        {
            switch (choice)
            {
                case 1:
                    _strategy = new Addition();
                    break;
                case 2:
                    _strategy = new Subtraction();
                    break;
                case 3:
                    _strategy = new Multiplication();
                    break;
                case 4:
                    _strategy = new Division();
                    break;
                case 5:
                    _strategy = new Modulus();
                    break;
                case 6:
                    _strategy = new SquareRoot();
                    break;
            }
            return _strategy;
        }
    }
}
