using Autofac;
using Database.Interfaces;
using Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Container
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CalculatorRepository>().AsSelf();
            builder.RegisterType<ShapeCalculatorRepository>().AsSelf();
            builder.RegisterType<RPSRepository>().AsSelf();
            builder.RegisterType<HighScoreRepository>().AsSelf();
        }
    }
}
