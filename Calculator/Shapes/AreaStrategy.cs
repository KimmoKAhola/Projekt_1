using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Shapes
{
    public abstract class AreaStrategy : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public abstract double CalculateArea(double width, double height);

        public abstract double CalculateCircumference(double width, double height);
    }
}
