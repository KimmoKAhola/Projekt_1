using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface IShape
    {
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal CalculateArea();
        public decimal CalculateCircumference();
    }
}
