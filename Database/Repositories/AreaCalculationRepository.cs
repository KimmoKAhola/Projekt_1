using Database.DatabaseConfiguration;
using Database.Interfaces;
using Database.Models;
using InputValidationLibrary;
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

        public void Delete(int id)
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
            int? choice = PromptUpdate();
            if (choice == null)
            {

            }
            else
            {
                ChangeOption(choice, entity);
            }
        }

        private static void ChangeOption(int? choice, AreaCalculation entity)
        {
            switch (choice - 1)
            {
                case 0:
                    entity.Width = 10;
                    break;
                case 1:
                    entity.Height = 10;
                    break;
                case 2:
                    entity.IsDeleted = true;
                    break;
                case 3:
                    entity.ShapeName = "Test";
                    break;
                case 4:
                    break;
            }
        }

        private static int? PromptUpdate()
        {
            Dictionary<int, string> options = new()
            {
                {1, "Width" },
                {2, "Height" },
                {3, "Delete" },
                {4, "Shape" },
            };
            return UserInputValidation.MenuValidation(options, "Bajs 123456");
        }

    }
}
