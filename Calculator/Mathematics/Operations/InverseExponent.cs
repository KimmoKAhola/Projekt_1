using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Mathematics.Operations
{
    public class InverseExponent : IMathStrategy
    {
        public char Operator { get; set; } = '√';
        public decimal Execute(decimal first, decimal second)
        {
            var bas = Convert.ToDouble(first);
            var exponent = Convert.ToDouble(second);
            return Math.Round(Convert.ToDecimal(Math.Pow(bas, (1 / exponent))), 2); //this is beautiful
        }
    }
}