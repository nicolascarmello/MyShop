using MyShop.Core.Model;
using System.Data.Entity;

namespace MyShop.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }  
        public DbSet<ProductCategory> ProductCategories { get; set; }  
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
    }
}
