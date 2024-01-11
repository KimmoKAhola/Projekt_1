using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shapes
{
    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Name { get; set; } = "Rectangle";

        public (double area, double circumference) Calculate(double width, double height)
        {
            return (width * height, (width * 2 + height * 2));
        }
    }
}
