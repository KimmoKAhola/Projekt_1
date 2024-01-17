using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Mathematics.Operations
{
    public class Division : IMath
    {
        public char Operator => '÷';
        public double Calculate(double first, double second)
        {
            if (second != 0.0)
                return first / second;
            else return double.NaN;
        }
    }
}
