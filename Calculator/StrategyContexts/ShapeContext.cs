using Calculator.Interfaces;
using Calculator.Mathematics.Operations;
using Calculator.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations.StrategyContexts
{
    public class ShapeContext
    {
        public ShapeContext(IShape? strategy)
        {
            Strategy = strategy;
        }
        public IShape? Strategy { get; private set; }
        public string ShapeName { get; private set; } = string.Empty;
        private static IShape? CreateStrategy(string? choice)
        {
            return choice?.ToLower() switch //'▬', '▲', 'P', '♦'
            {
                "rectangle" => new Rectangle(),
                "parallelogram" => new Parallelogram(),
                "triangle" => new Triangle(),
                "rhomboid" => new Rhomboid(),
                null => null,
                _ => null,
            };
        }

        public void SetStrategy(string? choice)
        {
            Strategy = CreateStrategy(choice);
            if (Strategy != null)
                ShapeName = Strategy.Name;
        }

        public (double area, double circumference) ExecuteStrategy(double width, double height)
        {
            (Strategy.Width, Strategy.Height) = (width, height);
            var (area, circumference) = Strategy.Calculate();
            return (Math.Round(area, 2), Math.Round(circumference, 2));
        }
    }
}
