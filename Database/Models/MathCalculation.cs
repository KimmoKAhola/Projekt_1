using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class MathCalculation
    {
        public int Id { get; set; }
        public char Operator { get; set; }

        public decimal Answer { get; set; }

        public decimal FirstInput { get; set; }
        public decimal SecondInput { get; set; }

        [Required]
        public Result Result { get; set; } = null!;
    }
}
