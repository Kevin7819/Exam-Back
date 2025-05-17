using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
  // Represents the Entity Framework Core database context
  public class AppDbContext : DbContext
  {
    // Constructor that passes options to the base DbContext class
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Represents the Courses table in the database
    public DbSet<Course> Courses { get; set; }

    // Represents the Students table in the database
    public DbSet<Student> Students { get; set; }
  }
}
