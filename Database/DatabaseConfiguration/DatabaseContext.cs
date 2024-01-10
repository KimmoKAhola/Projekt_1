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

        public DbSet<Result> Result { get; set; }
        public DbSet<AreaCalculation> AreaCalculation { get; set; }
        public DbSet<MathCalculation> Calculation { get; set; }

        public DbSet<RockPaperScissors> RockPaperScissors { get; set; }
        public DbSet<HighScore> HighScore { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConnectionConfiguration.GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
