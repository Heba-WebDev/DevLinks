using Core.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Link> Links { get; set; }
    public DbSet<Platform> Platforms { get; set; }
}