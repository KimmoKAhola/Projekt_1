using Calculator.Interfaces;
using Calculator.Mathematics.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shapes
{
    public class AreaCalculatorContext
    {
        private IShape? _strategy;
        public string ShapeName { get; private set; } = string.Empty;

        public AreaCalculatorContext()
        {
            _strategy = null;
        }
        private static IShape CreateStrategy(char choice)
        {
            return choice switch //'▬', '▲', 'P', '♦'
            {
                '▬' => new Rectangle(),
                'P' => new Parallelogram(),
                '▲' => new Triangle(),
                '♦' => new Rhomboid(),
                _ => throw new NotImplementedException(),
            };
        }

        public void SetStrategy(char choice)
        {
            _strategy = CreateStrategy(choice);
            ShapeName = _strategy.Name;
        }

        public (double area, double circumference) ExecuteStrategy(double width, double height)
        {
            return _strategy.Calculate(width, height);
        }
    }
}
