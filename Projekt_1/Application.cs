using Autofac;
using Database.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;
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
    public class Application : IApplication
    {
        public void Run()
        {
            Console.OutputEncoding = Encoding.UTF8;
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Migrate();
            }
            var config = Configuration.Configure();
            using (var scope = config.BeginLifetimeScope())
            {
                var menuService = scope.Resolve<MainMenu>();
                menuService.Run();
            }
        }
    }
}
