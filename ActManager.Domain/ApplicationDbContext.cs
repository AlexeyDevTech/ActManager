using ActManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ActManager.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Act> Acts { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<FileName> Filenames { get; set; }



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
            modelBuilder.Entity<Act>().Navigation(e => e.Building).AutoInclude();
            modelBuilder.Entity<Act>().Navigation(e => e.Goals).AutoInclude();
            modelBuilder.Entity<Act>().Navigation(e => e.Files).AutoInclude();

            modelBuilder.Entity<FileName>().Navigation(e => e.Act).AutoInclude();

            modelBuilder.Entity<Building>().Navigation(e => e.AddressInst).AutoInclude();

            modelBuilder.Entity<Goal>().Navigation(e => e.Acts).AutoInclude();


            


            
        }
        public bool DatabaseOnline() => Database.CanConnect();
    }
}
