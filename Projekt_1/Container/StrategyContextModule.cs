using Autofac;
using Calculations.StrategyContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Container
{
    public class StrategyContextModule : Module
    {
        protected override void Load(ContainerBuilder myBuilder)
        {
            myBuilder.RegisterType<CalculatorContext>().AsSelf().SingleInstance();
            myBuilder.RegisterType<ShapeContext>().AsSelf().SingleInstance();
        }
    }
}
