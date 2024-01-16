using Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace Database.DatabaseConfiguration
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<AreaCalculation> ShapeCalculator { get; set; }
        public DbSet<MathCalculation> Calculator { get; set; }
        public DbSet<RockPaperScissors> RockPaperScissors { get; set; }
        public DbSet<HighScore> HighScore { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConnectionConfiguration.GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}