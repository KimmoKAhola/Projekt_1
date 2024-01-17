using Autofac;
using Calculator.Interfaces;
using Calculator.Mathematics.Operations;
using Calculator.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Container
{
    public class MathModule : Module
    {
        protected override void Load(ContainerBuilder myBuilder)
        {
            myBuilder.RegisterType<Addition>().As<IMath>();
            myBuilder.RegisterType<Subtraction>().As<IMath>();
            myBuilder.RegisterType<Multiplication>().As<IMath>();
            myBuilder.RegisterType<Division>().As<IMath>();
            myBuilder.RegisterType<Modulus>().As<IMath>();
            myBuilder.RegisterType<SquareRoot>().As<IMath>();
        }
    }
}
