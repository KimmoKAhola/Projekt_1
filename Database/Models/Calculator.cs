using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Calculator
    {
        public int Id { get; set; }
        public List<Result>? Results { get; set; }

        public char Operator { get; set; }

        public decimal Result { get; set; }

        public decimal FirstInput { get; set; }
        public decimal SecondInput { get; set; }
    }
}
