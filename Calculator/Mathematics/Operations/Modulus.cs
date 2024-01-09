using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Mathematics.Operations
{
    public class Modulus : IMathStrategy
    {
        public char Operator { get; set; } = '%';
        public decimal Execute(decimal first, decimal second)
        {
            return Math.Round(decimal.Remainder(first, second), 2);
        }
    }
}
