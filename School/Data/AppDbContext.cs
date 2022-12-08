using Microsoft.EntityFrameworkCore;

namespace School.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }
}

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
}