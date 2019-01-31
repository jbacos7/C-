using Microsoft.EntityFrameworkCore;
using WeddingPlanner2.Models;

namespace WeddingPlanner2.Data

{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<Guest> Guests { get; set; }

    }
}
