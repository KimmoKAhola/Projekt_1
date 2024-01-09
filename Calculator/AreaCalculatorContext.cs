using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class AreaCalculatorContext(CalculatorStrategy strategy)
    {
        private IShape _shapeStrategy = strategy;

        public void SetCalculatorStrategy(CalculatorStrategy strategy)
        {
            _shapeStrategy = strategy;
        }
    }
}
