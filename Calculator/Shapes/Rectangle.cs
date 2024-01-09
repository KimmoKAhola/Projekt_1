using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shapes
{
    public class Rectangle : AreaStrategy
    {
        public override decimal CalculateArea(decimal width, decimal height)
        {
            return width * height;
        }

        public override decimal CalculateCircumference(decimal width, decimal height)
        {
            return width * 2 + height * 2;
        }
    }
}
