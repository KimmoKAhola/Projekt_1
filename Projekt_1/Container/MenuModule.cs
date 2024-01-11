using Autofac;
using Projekt_1.Interfaces;
using Projekt_1.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_1.Container
{
    public class MenuModule : Module
    {
        protected override void Load(ContainerBuilder myBuilder)
        {
            myBuilder.RegisterType<MainMenu>().AsSelf();
            myBuilder.RegisterType<CalculatorMenu>().As<IMenu>();
            myBuilder.RegisterType<AreaCalculatorMenu>().As<IMenu>();
        }
    }
}
