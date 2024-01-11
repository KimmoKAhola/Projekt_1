using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shapes
{
    public class Parallelogram : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Name { get; set; } = "Parallelogram";

        public (double area, double circumference) Calculate(double width, double height)
        {
            return (width * height, (2 * width + 2 * height));
        }
    }
}