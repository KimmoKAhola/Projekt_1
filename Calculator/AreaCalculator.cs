using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class AreaCalculator
    {
        //        1. Rektangel
        //2. Parallellogram
        //3. Triangel
        //4. Romb
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
