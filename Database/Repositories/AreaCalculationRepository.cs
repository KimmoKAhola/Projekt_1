using Database.DatabaseConfiguration;
using Database.Interfaces;
using Database.Models;
using InputValidationLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class AreaCalculationRepository(DatabaseContext dbContext) : IRepository<AreaCalculation>
    {
        private readonly DatabaseContext _dbContext = dbContext;
        public void Add(AreaCalculation entity)
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

        public AreaCalculation? Get(int id)
        {
            return _dbContext.AreaCalculation.Find(id);
        }

        public IEnumerable<AreaCalculation> GetAll()
        {
            return _dbContext.AreaCalculation;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(AreaCalculation entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
