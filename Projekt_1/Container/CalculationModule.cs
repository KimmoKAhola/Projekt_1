using Autofac;
using Database.Interfaces;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Container
{
    public class CalculationModule : Module
    {
        protected override void Load(ContainerBuilder myBuilder)
        {
            myBuilder.RegisterType<MathCalculation>().As<IEntity>();
            myBuilder.RegisterType<ShapeCalculation>().As<IEntity>();
        }
    }
}
