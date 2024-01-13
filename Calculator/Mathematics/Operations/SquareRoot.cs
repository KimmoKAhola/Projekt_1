using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Mathematics.Operations
{
    public class SquareRoot : IMathStrategy
    {
        public char Operator => '√';
        public double Calculate(double first, double second)
        {
            return Math.Pow(first, 1 / second);
        }
    }
}