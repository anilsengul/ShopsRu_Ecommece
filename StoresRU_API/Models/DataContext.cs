using Microsoft.EntityFrameworkCore;

namespace StoresRU_API.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Basket> Basket { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
