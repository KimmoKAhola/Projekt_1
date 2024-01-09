using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Rectangle
    {
        public static decimal CalculateArea(decimal width, decimal height)
        {
            return width * height;
        }

        public static decimal CalculateCircumference(decimal width, decimal height)
        {
            return width * 2 + height * 2;
        }
    }
}
