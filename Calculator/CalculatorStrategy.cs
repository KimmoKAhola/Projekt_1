using Calculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public abstract class CalculatorStrategy : IShape
    {
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public abstract decimal CalculateArea();

        public abstract decimal CalculateCircumference();
    }
}
