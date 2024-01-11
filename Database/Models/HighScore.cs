using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class HighScore
    {
        public int Id { get; set; }
        public byte AverageScore { get; set; } //Is it needed?
        public int NumberOfWins { get; set; }
        public int NumberOfLosses { get; set; }
        public int NumberOfTies { get; set; }
    }
}
