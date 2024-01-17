using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface IMath
    {
        public char Operator { get; }
        public double Calculate(double first, double second);
    }
}
