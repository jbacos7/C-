using Microsoft.EntityFrameworkCore;
using TheWall.Models;


namespace TheWall.Data
{
  public class DataContext : DbContext
  {
    // base() calls the parent class' constructor passing the "options" parameter along
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Comment> Comments { get; set; }
  }
}