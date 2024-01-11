using Autofac;
using Calculator.Interfaces;
using Calculator.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Container
{
    public class ShapeModule : Module
    {
        protected override void Load(ContainerBuilder myBuilder)
        {
            myBuilder.RegisterType<Parallelogram>().As<IShape>();
            myBuilder.RegisterType<Rectangle>().As<IShape>();
            myBuilder.RegisterType<Rhomboid>().As<IShape>();
            myBuilder.RegisterType<Triangle>().As<IShape>();
        }
    }
}
