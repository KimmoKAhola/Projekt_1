using Database.DatabaseConfiguration;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public class DatabaseService
    {
        private DatabaseContext _dbContext;

        public DatabaseService()
        {
            _dbContext = new DatabaseContext();
        }

        public void AddMathCalculation(MathCalculation calculation)
        {
            _dbContext.Calculation.Add(calculation);
            _dbContext.SaveChanges();
        }
    }
}
