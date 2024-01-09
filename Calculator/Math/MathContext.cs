using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Math
{
    public class MathContext
    {
        private IMathStrategy _strategy;

        public MathContext(IMathStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal Calculate(decimal first, decimal second)
        {
            return _strategy.Execute(first, second);
        }
    }
}
