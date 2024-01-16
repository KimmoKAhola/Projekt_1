using Database.Interfaces;
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
        public double AverageScore { get; set; }
        public int NumberOfWins { get; set; }
        public int NumberOfLosses { get; set; }
        public int NumberOfTies { get; set; }
    }
}
