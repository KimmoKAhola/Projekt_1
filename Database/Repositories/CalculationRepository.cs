using Database.DatabaseConfiguration;
using Database.Interfaces;
using Database.Models;
using InputValidationLibrary;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories
{
    public class CalculationRepository(DatabaseContext dbContext) : IRepository<MathCalculation>
    {
        private readonly DatabaseContext _dbContext = dbContext;
        public void Add(MathCalculation entity)
        {
            _dbContext.Add(entity);
        }

        public void SoftDelete(int id)
        {
            var entityToDelete = Get(id);
            if (entityToDelete != null)
            {
                entityToDelete.IsDeleted = true;
            }
        }

        public MathCalculation? Get(int id)
        {
            return _dbContext.Calculation.Find(id);
        }

        public IEnumerable<MathCalculation> GetAll()
        {
            return _dbContext.Calculation;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(MathCalculation entity)
        {
            throw new NotImplementedException();
        }
    }
}