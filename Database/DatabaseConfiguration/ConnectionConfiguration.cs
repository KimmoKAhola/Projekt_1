using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DatabaseConfiguration
{
    public static class ConnectionConfiguration
    {
        public static DbContextOptionsBuilder<DatabaseContext> Build()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();

            var connectionString = GetConnectionString();

            var options = new DbContextOptionsBuilder<DatabaseContext>();

            options.UseSqlServer(connectionString);

            return options;
        }

        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);

            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}
