using CLOUD.Auth;
using Microsoft.EntityFrameworkCore;

namespace CLOUD.DataBase;

// DbContext => reprezentarea bazei de date
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasIndex(u => u.Username).IsUnique();
    }
    public DbSet<User> Users { get; set; }
}
