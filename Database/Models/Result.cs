using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public enum ResultTypes
    {
        MathCalculation,
        AreaCalculation,
        RockPapperScissors
    };

    public class Result
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        public string ResultType { get; set; } = null!;
    }
}
