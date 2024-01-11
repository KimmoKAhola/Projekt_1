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
            myBuilder.RegisterType<Addition>().As<IMathStrategy>();
            myBuilder.RegisterType<Subtraction>().As<IMathStrategy>();
            myBuilder.RegisterType<Multiplication>().As<IMathStrategy>();
            myBuilder.RegisterType<Division>().As<IMathStrategy>();
            myBuilder.RegisterType<Modulus>().As<IMathStrategy>();
            myBuilder.RegisterType<SquareRoot>().As<IMathStrategy>();
        }
    }
}
