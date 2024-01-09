using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class AreaCalculation
    {
        public int Id { get; set; }

        public List<Result>? Results { get; set; }
    }
}
