using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Mathematics.Operations
{
    public class Subtraction : IMath
    {
        public char Operator => '-';
        public double Calculate(double first, double second)
        {
            return first - second;
        }
    }
}