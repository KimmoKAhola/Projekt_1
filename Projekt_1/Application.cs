using Autofac;
using Database.DatabaseConfiguration;
using Database.DatabaseSeeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Projekt_1.Container;
using Projekt_1.Interfaces;
using Projekt_1.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1
{
    public class Application(DatabaseContext dbContext) : IApplication
    {
        private readonly DatabaseContext _databaseContext = dbContext;
        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;

            if (!(_databaseContext.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                _databaseContext.Database.Migrate();
            }

            var config = Configuration.Configure();
            SeedData(config);
            using (var scope = config.BeginLifetimeScope())
            {
                var menuService = scope.Resolve<MainMenu>();
                menuService.Run();
            }
        }

        private void SeedData(IContainer config)
        {
            using (var scope = config.BeginLifetimeScope())
            {
                var seeding = scope.Resolve<ShapeSeeding>();
                seeding.SeedData();
            }
        }
    }
}
