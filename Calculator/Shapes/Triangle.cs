using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shapes
{
    public class Triangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Name { get; set; } = "Triangle";

        public (double area, double circumference) Calculate()
        {
            return ((Width * Height) / 2, Width * 3);
        }
    }
}