using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shapes
{
    public class AreaCalculatorContext
    {
        private IShape _shapeStrategy;

        public AreaCalculatorContext(IShape strategy)
        {
            _shapeStrategy = strategy;
        }
    }
}
