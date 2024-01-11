using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shapes
{
    public class Rhomboid : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Name { get; set; } = "Rhomboid";

        public (double area, double circumference) Calculate(double width, double height)
        {
            return (width * height, width * 4);
        }
    }
}
