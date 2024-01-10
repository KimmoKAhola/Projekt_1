using Database.DatabaseConfiguration;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Database;
using Calculator.Shapes;
using Calculator.Mathematics.Operations;
using Calculator.Mathematics;
using Calculator.Interfaces;
using Projekt_1.Container;
using Autofac;
using Database.Services;
using InputValidationLibrary;
using Projekt_1.Menus;
using System.Text;

namespace Projekt_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            app.Run();
        }
    }
}