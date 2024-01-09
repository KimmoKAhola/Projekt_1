using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Interfaces
{
    public interface IMathStrategy
    {
        public char Operator { get; set; }
        public decimal Execute(decimal first, decimal second);
    }
}
