using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace Database.DatabaseConfiguration
{
    public class Database : DbContext
    {
        public Database()
        {

        }

        public Database(DbContextOptions<Database> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=TheSuiteSpot;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");
        }
    }
}
