using Autofac;
using Database.DatabaseConfiguration;
using Database.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Container
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder myBuilder)
        {
            myBuilder.RegisterType<DatabaseContext>().AsSelf();
            myBuilder.RegisterType<MathCalculationService>().AsSelf();
            myBuilder.RegisterType<AreaCalculationService>().AsSelf();
            myBuilder.RegisterType<RPSService>().AsSelf();
        }
    }
}
