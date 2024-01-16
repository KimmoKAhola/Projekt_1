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
    public class ShapeCalculatorRepository(DatabaseContext dbContext) : IRepository<ShapeCalculation>
    {
        private readonly DatabaseContext _dbContext = dbContext;
        public void Add(ShapeCalculation entity)
        {
            _dbContext.Add(entity);
        }

        public void SoftDelete(int id)
        {
            var entityToDelete = Get(id);
            if (entityToDelete != null)
            {
                entityToDelete.IsDeleted = true;
                entityToDelete.DateLastUpdated = DateTime.Now;
            }
        }

        public ShapeCalculation? Get(int id)
        {
            return _dbContext.ShapeCalculator.Find(id);
        }

        public IEnumerable<ShapeCalculation> GetAll()
        {
            return _dbContext.ShapeCalculator.Where(x => !x.IsDeleted);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(ShapeCalculation entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
