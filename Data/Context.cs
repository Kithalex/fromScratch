using Microsoft.EntityFrameworkCore;
using RetailStoreAPI.Models;

namespace RetailStoreAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> contents) : base(contents) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
    }
}
