using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class AreaCalculatorContext(CalculatorStrategy strategy)
    {
        private CalculatorStrategy _strategy = strategy;

        public void SetCalculatorStrategy(CalculatorStrategy strategy)
        {
            _strategy = strategy;
        }
    }
}
