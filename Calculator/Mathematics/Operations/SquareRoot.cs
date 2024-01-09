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
        public char Operator { get; set; } = '√';
        public double Execute(double first, double second)
        {
            var exponent = (double)2.0;
            return Math.Round(Math.Pow(first, exponent)); //this is beautiful
        }
    }
}