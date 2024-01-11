using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class RockPaperScissors
    {
        public int Id { get; set; }

        [Required]
        public string PlayerMove { get; set; } = null!;
        [Required]
        public string ComputerMove { get; set; } = null!;

        public string Outcome { get; set; } = null!;

        [Required]
        public Result Result { get; set; } = null!;
    }
}
