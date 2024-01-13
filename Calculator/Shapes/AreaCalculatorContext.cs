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
        public IShape? Strategy { get; private set; } = null;
        public string ShapeName { get; private set; } = string.Empty;
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
            Strategy = CreateStrategy(choice);
            ShapeName = Strategy.Name;
        }

        public (double area, double circumference) ExecuteStrategy(double width, double height)
        {
            var (area, circumference) = Strategy.Calculate(width, height);
            return (Math.Round(area, 2), Math.Round(circumference, 2));
        }
    }
}
