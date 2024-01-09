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
        public decimal Execute(decimal first, decimal second)
        {
            var bas = Convert.ToDouble(first);
            var exponent = Convert.ToDouble(second);
            return Convert.ToDecimal(Math.Pow(bas, (1 / exponent)));
        }
    }
}
