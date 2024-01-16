using Database.DatabaseConfiguration;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Rock_Paper_Scissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class HighScoreRepository(DatabaseContext dbContext)
    {
        private readonly DatabaseContext _dbContext = dbContext;
        public void Add(HighScore entity)
        {
            _dbContext.Add(entity);
        }

        public HighScore? Get()
        {
            return _dbContext.HighScore.FirstOrDefault();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
