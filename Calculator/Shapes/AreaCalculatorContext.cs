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
        private IShape _strategy;

        public AreaCalculatorContext(IShape strategy)
        {
            _strategy = strategy;
        }

        public (double area, double circumference) Calculate(double first, double second)
        {
            double area = _strategy.CalculateArea(first, second);
            double circumference = _strategy.CalculateCircumference(first, second);

            return (area, circumference);
        }

        public IShape SetStrategy(int choice)
        {
            switch (choice)
            {
                case 1:
                    _strategy = new Rectangle();
                    break;
                case 2:
                    _strategy = new Parallelogram();
                    break;
                case 3:
                    _strategy = new Triangle();
                    break;
                case 4:
                    _strategy = new Rhomboid();
                    break;
            }
            return _strategy;
        }


    }
}
