﻿using Database.DatabaseConfiguration;
using Database.Models;
using InputValidationLibrary;
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
                PrintMessages.PrintSuccessMessage($"{temp} has been added to the system.");
            }
            else
            {
                var temp = (AreaCalculation)calculation;
                _dbContext.AreaCalculation.Add(temp);
                PrintMessages.PrintSuccessMessage($"{temp} has been added to the system.");
            }
            _dbContext.SaveChanges();
        }

        public void DeleteCalculation(ICalculation calculation)
        {
            throw new NotImplementedException();
        }

        public void ReadAllCalculations(ICalculation calculation)
        {
            List<ICalculation> temp = new List<ICalculation>();
            if (calculation is MathCalculation)
            {
                temp = _dbContext.Calculation.OfType<MathCalculation>().Cast<ICalculation>().ToList();
            }
            else
            {
                temp = _dbContext.AreaCalculation.OfType<AreaCalculation>().Cast<ICalculation>().ToList();
            }
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
            PrintMessages.PressAnyKeyToContinue();
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
