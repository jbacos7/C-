using Microsoft.EntityFrameworkCore;
using LoginRegistration.Models;

namespace LoginRegistration.Models
{
    public class LRContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public LRContext(DbContextOptions<LRContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
