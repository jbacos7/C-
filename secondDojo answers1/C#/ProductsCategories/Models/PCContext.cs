using Microsoft.EntityFrameworkCore;
using ProductsCategories.Models;

namespace ProductsCategories.Models
{
    public class PCContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public PCContext(DbContextOptions<PCContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CatProd> CatProds { get; set; }


    }
}
