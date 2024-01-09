using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class AreaCalculation : ICalculation
    {
        public int Id { get; set; }

        public double Circumference { get; set; }

        public double Area { get; set; }

        [Required]
        public Result Result { get; set; } = null!;
    }
}
