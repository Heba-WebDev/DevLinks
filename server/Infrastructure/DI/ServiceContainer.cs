using System.Text;
using Application.Contracts;
using Infrastructure.Repos;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.DI;

public static class ServiceContainer
{
    public static IServiceCollection InfrastructureService(this IServiceCollection services,
    IConfiguration configuration)
    {
        // db
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Default")));
        // jwt service
        services.AddScoped<JwtService>();
        services.AddAuthentication(options =>
        {
            // updates all defaults to be jwt bearer default
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"]!))
            };
        });
        // cors
        services.AddCors(options =>
        {
            options.AddPolicy(name: "developmentCors", policy =>
        {
            policy.WithOrigins("http://localhost:5173");
            policy.AllowAnyHeader();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
            policy.AllowCredentials();
        });
        });
        // authorization
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
            options.AddPolicy("UserOrAdmin", policy => policy.RequireRole("User", "Admin"));
        });
        services.AddScoped<IUser, UserRepo>();
        services.AddScoped<IPlatform, PlatformRepo>();
        services.AddScoped<IUploadImage, UploadImagesService>();
        services.AddScoped<ILink, LinkRepo>();
        return services;
    }
}