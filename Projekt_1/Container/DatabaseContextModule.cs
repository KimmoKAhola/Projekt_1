using Autofac;
using Database.DatabaseConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Container
{
    public class DatabaseContextModule : Module
    {
        protected override void Load(ContainerBuilder myBuilder)
        {
            myBuilder.Register(ctx =>
            {
                return ConnectionConfiguration.Build();
            }).As<DbContextOptionsBuilder<DatabaseContext>>().SingleInstance();

            myBuilder.Register(ctx =>
            {
                var optionsBuilder = ctx.Resolve<DbContextOptionsBuilder<DatabaseContext>>();
                return new DatabaseContext(optionsBuilder.Options);
            }).AsSelf().SingleInstance();
        }
    }
}
