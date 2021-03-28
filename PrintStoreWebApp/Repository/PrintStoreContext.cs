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
    }
}