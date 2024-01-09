using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Mathematics.Operations
{
    public class Subtraction : IMathStrategy
    {
        public char Operator { get; set; } = '-';
        public double Execute(double first, double second)
        {
            return Math.Round(first - second, 2);
        }
    }
}
