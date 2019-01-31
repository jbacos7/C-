using Microsoft.EntityFrameworkCore;
using CExam.Models;


namespace CExam.Data
{
  public class DataContext : DbContext
  {
    // base() calls the parent class' constructor passing the "options" parameter along
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Act> Acts { get; set; }
    public DbSet<Join> Joins { get; set; }
  }
}
