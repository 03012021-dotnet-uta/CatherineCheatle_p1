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

            //Customer Seed
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    CustomerFName = "William",
                    CustomerLName = "Shakespeare",
                    CustomerEmail = "wshakespeare",
                    CustomerPasswordHash = new byte[] { 0x00, 0x21, 0x60, 0x1F, 0xA1, 0x07 },
                    CustomerPhone = "555-123-4567",
                    CustomerStreet = "295 Juliet Street",
                    CustomerCity = "Romeo",
                    CustomerState = "ND"
                },
                new Customer
                {
                    CustomerId = 2,
                    CustomerFName = "Jane",
                    CustomerLName = "Collins",
                    CustomerEmail = "ljames",
                    CustomerPasswordHash = new byte[] { 0x00, 0x20, 0x60, 0x1F, 0xA1, 0x07 },
                    CustomerPhone = "555-457-3255",
                    CustomerStreet = "938 Jungle Circle",
                    CustomerCity = "Boise",
                    CustomerState = "ID",
                    CustomerZip = 83705
                }
            );

            //Store Seed
            modelBuilder.Entity<Store>().HasData(
                new Store
                {
                    StoreID = 1,
                    StoreName = "Prints for Days",
                    StoreCity = "Durham",
                    StoreState = "NC",
                    StoreStreet = "123 Main Street",
                    StoreZip = 27704
                },
                new Store
                {
                    StoreID = 2,
                    StoreName = "Pieces of History",
                    StoreCity = "Lincoln",
                    StoreState = "Nebraska",
                    StoreStreet = "1863 Gettysburg Street",
                    StoreZip = 68001
                },
                new Store
                {
                    StoreID = 3,
                    StoreName = "Fantasy and Daydreams",
                    StoreCity = "Colorado Springs",
                    StoreState = "CO",
                    StoreStreet = "2336 Sage Lane",
                    StoreZip = 80951
                }
            );

            modelBuilder.Entity<Print>().HasData(
                new Print
                {
                    PrintID = 1,
                    PrintTitle = "Fantail Wrens",
                    ArtistFName = "McGill Library",
                    PrintPrice = 13.99,
                    PrintDecription = "A print of fantail birds. Look at them, how quaint.",
                    PrintImage = "img/mcgill-library-fantailwrens.jpg"
                },
                new Print
                {
                    PrintID = 2,
                    PrintTitle = "Red Fox",
                    ArtistFName = "McGill Library",
                    PrintPrice = 13.99,
                    PrintDecription = "A print of red fox. Look at him go.",
                    PrintImage = "img/mcgill-library-redfox.jpg"

                },
                new Print
                {
                    PrintID = 3,
                    PrintTitle = "Brown Hawk Owl",
                    ArtistFName = "McGill Library",
                    PrintPrice = 13.99,
                    PrintDecription = "A print of a brown hawk owl in a forest. I wonder what he sees.",
                    PrintImage = "img/mcgill-library-brownhawkowl.jpg"
                },
                new Print
                {
                    PrintID = 4,
                    PrintTitle = "Tarzan's Home",
                    ArtistFName = "Tamara",
                    ArtistLName = "Menzi",
                    PrintPrice = 17.99,
                    PrintDecription = "A print of a place somewhere on a mountain side. Is that tree possibly the home of Tarzan?",
                    PrintImage = "img/tamara-menzi-tarzan.jpg"
                },
                new Print
                {
                    PrintID = 5,
                    PrintTitle = "A Girl With Flowers",
                    ArtistFName = "Maris",
                    PrintPrice = 29.99,
                    PrintDecription = "A print of girl picking flowers. How nice.",
                    PrintImage = "img/maris-agirlwithflowers.jpg"
                },
                new Print
                {
                    PrintID = 6,
                    PrintTitle = "Cheers",
                    ArtistFName = "Jan",
                    ArtistLName = "Rombauer",
                    PrintPrice = 23.99,
                    PrintDecription = "A print of man who appears to be very pleased with his drink...Cheers?",
                    PrintImage = "img/janrombauer-cheers.jpg"
                },
                new Print
                {
                    PrintID = 7,
                    PrintTitle = "Knight Night",
                    ArtistFName = "Yuri_B",
                    PrintPrice = 29.99,
                    PrintDecription = "A painting of knight overlooking the mountains at night.",
                    PrintImage = "img/yuri-b-knightatnight.jpg"
                },
                new Print
                {
                    PrintID = 8,
                    PrintTitle = "White Clouds in Pink and Blue Clouds",
                    ArtistFName = "Eberhard",
                    ArtistLName = "Grossgasteiger",
                    PrintPrice = 13.99,
                    PrintDecription = "A painting of fantial birds. Look at them, how quaint.",
                    PrintImage = "img/eberhard-grossgasteiger-moonpink.jpg"
                }
            );

            //Seed Data for Inventory
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    StoreId = 1,
                    PrintId = 1,
                    PrintQty = 200
                },
                new Inventory
                {
                    StoreId = 1,
                    PrintId = 2,
                    PrintQty = 150
                },
                new Inventory
                {
                    StoreId = 1,
                    PrintId = 3,
                    PrintQty = 100
                },
                new Inventory
                {
                    StoreId = 1,
                    PrintId = 5,
                    PrintQty = 45
                },
                new Inventory
                {
                    StoreId = 1,
                    PrintId = 6,
                    PrintQty = 16
                },
                new Inventory
                {
                    StoreId = 2,
                    PrintId = 1,
                    PrintQty = 34
                },
                new Inventory
                {
                    StoreId = 2,
                    PrintId = 2,
                    PrintQty = 122
                },
                new Inventory
                {
                    StoreId = 2,
                    PrintId = 3,
                    PrintQty = 125
                },
                new Inventory
                {
                    StoreId = 2,
                    PrintId = 4,
                    PrintQty = 12
                },
                new Inventory
                {
                    StoreId = 2,
                    PrintId = 5,
                    PrintQty = 18
                },
                new Inventory
                {
                    StoreId = 2,
                    PrintId = 6,
                    PrintQty = 46
                },
                new Inventory
                {
                    StoreId = 3,
                    PrintId = 4,
                    PrintQty = 24
                },
                new Inventory
                {
                    StoreId = 3,
                    PrintId = 5,
                    PrintQty = 56
                },
                new Inventory
                {
                    StoreId = 3,
                    PrintId = 7,
                    PrintQty = 7
                },
                new Inventory
                {
                    StoreId = 3,
                    PrintId = 8,
                    PrintQty = 49
                }
            );

            //Seed Data for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order{
                    OrdersId = 1,
                    OrderDate = new System.DateTime(2021, 3, 1, 7, 25, 36),
                    OrderDeliveryDate = new System.DateTime(2021, 3, 8, 11, 0, 0),
                    OrderSubtotal = 41.97,
                    OrderTax = 2.94,
                    OrderTotalPrice = 44.91,
                    CustomerId = 1,
                    StoreId = 1
                },
                new Order{
                    OrdersId = 2,
                    OrderDate = new System.DateTime(2021, 3, 15, 19, 10, 2),
                    OrderDeliveryDate = new System.DateTime(2021, 3, 19, 10, 0, 0),
                    OrderSubtotal = 23.99,
                    OrderTax = 1.68,
                    OrderTotalPrice = 25.67,
                    CustomerId = 2,
                    StoreId = 2
                },
                new Order{
                    OrdersId = 3,
                    OrderDate = new System.DateTime(2021, 3, 26, 11, 55, 0),
                    OrderDeliveryDate = new System.DateTime(2021, 4, 2, 11, 0, 0),
                    OrderSubtotal = 61.97,
                    OrderTax = 4.34,
                    OrderTotalPrice = 66.31,
                    CustomerId = 2,
                    StoreId = 3
                },
                new Order{
                    OrdersId = 4,
                    OrderDate = new System.DateTime(2021, 3, 29, 9, 52, 0),
                    OrderDeliveryDate = new System.DateTime(2021, 3, 31, 11, 0, 0),
                    OrderSubtotal = 13.99,
                    OrderTax = .98,
                    OrderTotalPrice = 14.97,
                    CustomerId = 1,
                    StoreId = 3
                }
            );

            //Seed Data for OrderLine
            modelBuilder.Entity<Orderline>().HasData(
                new Orderline{
                    OrderNumId = 1,
                    PrintId = 1,
                    PrintQty = 2
                },
                new Orderline{
                    OrderNumId = 1,
                    PrintId = 2,
                    PrintQty = 1
                },
                new Orderline{
                    OrderNumId = 2,
                    PrintId = 6,
                    PrintQty = 1
                },
                new Orderline{
                    OrderNumId = 3,
                    PrintId = 4,
                    PrintQty = 1
                },
                new Orderline{
                    OrderNumId = 3,
                    PrintId = 7,
                    PrintQty = 1
                },
                new Orderline{
                    OrderNumId = 3,
                    PrintId = 8,
                    PrintQty = 1
                },
                new Orderline{
                    OrderNumId = 4,
                    PrintId = 8,
                    PrintQty = 1
                }
            
            );
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