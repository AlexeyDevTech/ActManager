using ActManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ActManager.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Act> Acts { get; set; }
        public ApplicationDbContext()
        {
          //Database.EnsureDeleted();
          Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=actdb.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
