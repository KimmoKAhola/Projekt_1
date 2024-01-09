using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class AreaCalculation : ICalculation
    {
        public int Id { get; set; }

        public decimal Circumference { get; set; }

        public decimal Area { get; set; }

        public Result Result { get; set; } = null!;
    }
}
