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
        public DbSet<Calculator> Calculator { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Projekt_1;Trusted_Connection=True;TrustServerCertificate=true;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Result>()
            //    .HasMany(r => r.AreaCalculations)
            //    .WithOne(ac => ac.Result)
            //    .HasForeignKey(ac => ac.Result);
        }
    }
}
