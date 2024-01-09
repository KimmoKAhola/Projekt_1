using Database.DatabaseConfiguration;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using Database;

namespace Projekt_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DatabaseContext())
            {
                ctx.Database.Migrate();
            }

            //using (var ctx = new DatabaseContext())
            //{
            //    var test = new AreaCalculation
            //    {

            //    };
            //}
        }
    }
}
