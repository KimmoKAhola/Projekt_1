using Autofac;
using Calculator.Interfaces;
using Calculator.Mathematics;
using Calculator.Mathematics.Operations;
using Calculator.Shapes;
using Database.DatabaseConfiguration;
using Database.Interfaces;
using Database.Models;
using Database.Services;
using Projekt_1.Interfaces;
using Projekt_1.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Container
{
    public class Configuration
    {
        public static IContainer Configure()
        {
            var myBuilder = new ContainerBuilder();

            myBuilder.RegisterModule<DatabaseContextModule>();
            myBuilder.RegisterModule<MenuModule>();
            myBuilder.RegisterModule<ShapeModule>();
            myBuilder.RegisterModule<CalculationModule>();
            myBuilder.RegisterModule<DatabaseModule>();
            myBuilder.RegisterModule<MathModule>();
            myBuilder.RegisterModule<StrategyContextModule>();

            return myBuilder.Build();
        }
    }
}
