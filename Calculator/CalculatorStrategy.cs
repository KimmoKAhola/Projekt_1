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
        public decimal CalculateArea()
        {
            throw new NotImplementedException();
        }

        public decimal CalculateCircumference()
        {
            throw new NotImplementedException();
        }
    }
}
