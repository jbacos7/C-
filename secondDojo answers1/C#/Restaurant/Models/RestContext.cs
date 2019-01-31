using Microsoft.EntityFrameworkCore;
using Restaurant.Models;

namespace Restaurant.Models
{
    public class RestContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public RestContext(DbContextOptions<RestContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
