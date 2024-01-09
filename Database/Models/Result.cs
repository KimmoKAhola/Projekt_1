using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Result
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public List<AreaCalculation>? AreaCalculations { get; set; } = new List<AreaCalculation>();
        public List<Calculator>? MathCalculations { get; set; } = new List<Calculator>();
    }
}
