﻿using Database.DatabaseConfiguration;
using Database.Models;
using Rock_Paper_Scissors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class RPSRepository(DatabaseContext dbContext)
    {
        private readonly DatabaseContext _dbContext = dbContext;
        public void Add(RockPaperScissors entity)
        {
            _dbContext.Add(entity);
        }

        public IEnumerable<RockPaperScissors> GetAll()
        {
            return _dbContext.RockPaperScissors;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
