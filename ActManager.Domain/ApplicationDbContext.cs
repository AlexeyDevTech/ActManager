using ActManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ActManager.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Act> Acts { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAttribute> CustomerAttributes { get; set; }
        public DbSet<FileName> Filenames { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractTemplate> ContractTemplates { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Analytic> Analytics { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }


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
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Act>().Navigation(e => e.Building).AutoInclude();
            //modelBuilder.Entity<Act>().Navigation(e => e.Goals).AutoInclude();
            modelBuilder.Entity<Act>().Navigation(e => e.Files).AutoInclude();

            modelBuilder.Entity<FileName>().Navigation(e => e.Act).AutoInclude();

            modelBuilder.Entity<Building>().Navigation(e => e.AddressInst).AutoInclude();

            modelBuilder.Entity<Goal>().Navigation(e => e.Acts).AutoInclude();
            modelBuilder.Entity<Goal>().Navigation(e => e.Customer).AutoInclude();
            modelBuilder.Entity<Customer>().Navigation(e => e.Attributes).AutoInclude();
        }
        public bool DatabaseOnline() => Database.CanConnect();
    }
}
