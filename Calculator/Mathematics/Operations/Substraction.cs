using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Mathematics.Operations
{
    public class Substraction : IMathStrategy
    {
        public decimal Execute(decimal first, decimal second)
        {
            return first - second;
        }
    }
}
