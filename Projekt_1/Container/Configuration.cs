using Autofac;
using Calculator.Interfaces;
using Calculator.Mathematics;
using Calculator.Mathematics.Operations;
using Calculator.Shapes;
using Database.DatabaseConfiguration;
using Database.Services;
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

            myBuilder.RegisterType<Addition>().As<IMathStrategy>();
            myBuilder.RegisterType<Subtraction>().As<IMathStrategy>();
            myBuilder.RegisterType<Multiplication>().As<IMathStrategy>();
            myBuilder.RegisterType<Division>().As<IMathStrategy>();
            myBuilder.RegisterType<Modulus>().As<IMathStrategy>();
            myBuilder.RegisterType<SquareRoot>().As<IMathStrategy>();

            myBuilder.RegisterType<MathContext>().AsSelf();



            myBuilder.RegisterType<Parallelogram>().As<IShape>();
            myBuilder.RegisterType<Rectangle>().As<AreaStrategy>();
            myBuilder.RegisterType<Rhomboid>().As<IShape>();
            myBuilder.RegisterType<Triangle>().As<IShape>();

            myBuilder.RegisterType<AreaCalculatorContext>().AsSelf();

            myBuilder.RegisterType<DatabaseContext>().AsSelf();
            myBuilder.RegisterType<DatabaseService>().AsSelf();

            return myBuilder.Build();
        }
    }
}
