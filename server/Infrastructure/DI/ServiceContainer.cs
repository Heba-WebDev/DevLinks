using System.ComponentModel.Design;
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
        services.AddScoped<IUser, UserRepo>();
        return services;
    }
}