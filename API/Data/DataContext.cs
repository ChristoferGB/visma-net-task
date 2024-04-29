using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                        .HasOne(x => x.Boss)
                        .WithMany(x => x.Employees)
                        .HasForeignKey(x => x.BossId)
                        .IsRequired(false);
        }
    }
}