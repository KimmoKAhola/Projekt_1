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

        public double CalculateArea(double width, double height)
        {
            return (width * height) / 2;
        }

        public double CalculateCircumference(double width, double height)
        {
            return 3 * width; //Asume equilaterial triangle
        }
    }
}