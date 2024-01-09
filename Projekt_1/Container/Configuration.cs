using Autofac;
using Calculator.Interfaces;
using Calculator.Mathematics;
using Calculator.Mathematics.Operations;
using Calculator.Shapes;
using Database.DatabaseConfiguration;
using Database.Services;
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

            MathBuilder(myBuilder);
            ShapeBuilder(myBuilder);
            DatabaseBuilder(myBuilder);
            MenuBuilder(myBuilder);

            return myBuilder.Build();
        }


        private static void MenuBuilder(ContainerBuilder myBuilder)
        {
            myBuilder.RegisterType<CalculatorMenu>().AsSelf();
            myBuilder.RegisterType<MainMenu>().AsSelf();
            myBuilder.RegisterType<AreaCalculatorMenu>().AsSelf();
        }
        private static void DatabaseBuilder(ContainerBuilder myBuilder)
        {
            myBuilder.RegisterType<DatabaseContext>().AsSelf();
            myBuilder.RegisterType<DatabaseService>().AsSelf();
        }

        private static void MathBuilder(ContainerBuilder myBuilder)
        {
            myBuilder.RegisterType<Addition>().As<IMathStrategy>();
            myBuilder.RegisterType<Subtraction>().As<IMathStrategy>();
            myBuilder.RegisterType<Multiplication>().As<IMathStrategy>();
            myBuilder.RegisterType<Division>().As<IMathStrategy>();
            myBuilder.RegisterType<Modulus>().As<IMathStrategy>();
            myBuilder.RegisterType<SquareRoot>().As<IMathStrategy>();

            myBuilder.RegisterType<MathContext>().AsSelf();
        }

        private static void ShapeBuilder(ContainerBuilder myBuilder)
        {
            myBuilder.RegisterType<Parallelogram>().As<IShape>();
            myBuilder.RegisterType<Rectangle>().As<IShape>();
            myBuilder.RegisterType<Rhomboid>().As<IShape>();
            myBuilder.RegisterType<Triangle>().As<IShape>();

            myBuilder.RegisterType<AreaCalculatorContext>().AsSelf();
        }
    }
}
