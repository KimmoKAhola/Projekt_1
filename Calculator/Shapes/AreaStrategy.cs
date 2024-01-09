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
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public abstract decimal CalculateArea(decimal width, decimal height);

        public abstract decimal CalculateCircumference(decimal width, decimal height);
    }
}
