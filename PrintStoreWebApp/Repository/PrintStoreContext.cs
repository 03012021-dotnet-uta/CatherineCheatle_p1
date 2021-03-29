using Microsoft.EntityFrameworkCore;
using Models;
using Models.Abstracts;

namespace Repository
{
    public class PrintStoreContext : DbContext
    {
        public PrintStoreContext(DbContextOptions<PrintStoreContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<Orderline> Orderline { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<AStore> Stores { get; set; }
        public DbSet<APrint> Prints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>()
                .HasKey(c => new { c.StoreId, c.PrintId });
        }

    }
}