using Microsoft.EntityFrameworkCore;
using Models;

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
        public DbSet<Store> Stores { get; set; }
        public DbSet<Print> Prints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ManyToManyRelationshipConfiguration(modelBuilder);
        }

        private void ManyToManyRelationshipConfiguration(ModelBuilder modelBuilder)
        {
            //Model config for many to many relation for Inventory
            modelBuilder.Entity<Inventory>()
                .HasKey(t => new { t.StoreId, t.PrintId });

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Store)
                .WithMany(s => s.Inventories)
                .HasForeignKey(i => i.StoreId);

            modelBuilder.Entity<Inventory>()
                .HasOne(i => i.Print)
                .WithMany(p => p.Inventories)
                .HasForeignKey(i => i.PrintId);

            //Model config for many to many relation for Orderline
            modelBuilder.Entity<Orderline>()
                .HasKey(t => new { t.OrderNumId, t.PrintId });

            modelBuilder.Entity<Orderline>()
                .HasOne(ol => ol.Order)
                .WithMany(o => o.Orderlines)
                .HasForeignKey(ol => ol.OrderNumId);

            modelBuilder.Entity<Orderline>()
                .HasOne(ol => ol.Print)
                .WithMany(p => p.Orderlines)
                .HasForeignKey(ol => ol.PrintId);
        }

    }
}