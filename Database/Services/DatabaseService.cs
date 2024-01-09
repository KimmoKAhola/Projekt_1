using Database.DatabaseConfiguration;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Services
{
    public class DatabaseService : IDatabaseService
    {
        private DatabaseContext _dbContext;

        public DatabaseService()
        {
            _dbContext = new DatabaseContext();
        }

        public void AddCalculation(ICalculation calculation)
        {
            if (calculation is MathCalculation)
            {
                var temp = (MathCalculation)calculation;
                _dbContext.Calculation.Add(temp);
            }
            else
            {
                var temp = (AreaCalculation)calculation;
                _dbContext.AreaCalculation.Add(temp);
            }
            _dbContext.SaveChanges();
        }

        public void DeleteCalculation(ICalculation calculation)
        {
            throw new NotImplementedException();
        }

        public void ReadAllCalculations(ICalculation calculation)
        {
            throw new NotImplementedException();
        }

        public void ReadCalculation(ICalculation calculation)
        {
            throw new NotImplementedException();
        }

        public void UpdateCalculation(ICalculation calculation)
        {
            throw new NotImplementedException();
        }
    }
}
