﻿using Database.DatabaseConfiguration;
using Database.Interfaces;
using Database.Models;
using InputValidationLibrary;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class CalculatorRepository(DatabaseContext dbContext) : IRepository<MathCalculation>
    {
        private readonly DatabaseContext _dbContext = dbContext;
        public void Add(MathCalculation entity)
        {
            _dbContext.Add(entity);
            Save();
            Console.Clear();
            Console.WriteLine($"Your calculation: {entity.FirstInput} {entity.Operator} {entity.SecondInput} = {entity.Answer}");
            PrintMessages.PrintSuccessMessage("Save to database was successful.");
        }

        public void SoftDelete(int id)
        {
            var entityToDelete = Get(id);
            if (entityToDelete != null)
            {
                entityToDelete.IsDeleted = true;
                entityToDelete.DateLastUpdated = DateTime.Now;
                Save();
            }
        }

        public MathCalculation? Get(int id)
        {
            return _dbContext.Calculator.Find(id);
        }

        public IEnumerable<MathCalculation> GetAll()
        {
            return _dbContext.Calculator.Where(x => !x.IsDeleted);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(MathCalculation entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}