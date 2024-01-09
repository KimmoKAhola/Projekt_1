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
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public decimal CalculateArea(decimal width, decimal height)
        {
            return (width * height) / 2;
        }

        public decimal CalculateCircumference(decimal width, decimal height)
        {
            return 3 * width; //Asume equilaterial triangle
        }
    }
}
