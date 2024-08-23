using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace  Infrastructure.Data.Seed;

public static class AppSeedData
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Email = "john@example.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Pass123456"),
                Username = "john23",
                FirstName = "John",
                LastName = "Doe",
                Role = Core.Enums.Role.User
            },
            new User
            {
                Id = new Guid("22222222-2222-2222-2222-222222222222"),
                Email = "susi@example.com",
                Password = BCrypt.Net.BCrypt.HashPassword("Pass123456"),
                Username = "susi11",
                FirstName = "Susi",
                LastName = "Jr",
                Role = Core.Enums.Role.Admin
            }
        );

        modelBuilder.Entity<Platform>().HasData(
            new Platform
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
                Name = "Youtube",
                BaseUrl = "https://www.youtube.com",
                Image = "/images/platforms/youtube.svg",
                Color = "#EE3939",
            },
            new Platform
            {
                Id = new Guid("22222222-2222-2222-2222-222222222222"),
                Name = "Linkedin",
                BaseUrl = "http://linkedin.com",
                Image = "/images/platforms/linkedin.svg",
                Color = "#2D68FF",
            },
            new Platform
            {
                Id = new Guid("33333333-3333-3333-3333-333333333333"),
                Name = "Github",
                BaseUrl = "https://github.com",
                Image = "/images/platforms/github.svg",
                Color = "#1A1A1A",
            }
        );

        modelBuilder.Entity<Link>().HasData(
            new Link
            {
                Id = Guid.NewGuid(),
                UserId = new Guid("22222222-2222-2222-2222-222222222222"),
                PlatformId = new Guid("33333333-3333-3333-3333-333333333333"),  // Github
                Url = "https://github.com/Heba-WebDev"
            }
        );
    }
}
