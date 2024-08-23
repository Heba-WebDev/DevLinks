using Core.Entities;
using Infrastructure.Data.Seed;
using Microsoft.EntityFrameworkCore;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Link> Links { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AppSeedData.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}
