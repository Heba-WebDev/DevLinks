using Application.Contracts;
using Application.Dtos;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repos;

public class UserRepo : IUser
{
    private readonly AppDbContext _appDbContext;
    public UserRepo(AppDbContext appDbContext)
    {
        this._appDbContext = appDbContext;
    }
    public async Task<UserRegisterResponse> UserRegisterAsync(UserRegisterRequestDto dto)
    {
        var emailExists = await GetUserByEmailAsync(dto.Email);
        if (emailExists != null) return new UserRegisterResponse(false, "Email already exists");
        var usernameExists = await GetUserByUsernameAsync(dto.Username);
        if (usernameExists != null) return new UserRegisterResponse(false, "Username already exists");
        _appDbContext.Users.Add(new User()
        {
            Email = dto.Email,
            Username = dto.Username,
            Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        });
        await _appDbContext.SaveChangesAsync();
        return new UserRegisterResponse(true, "User successfully registered");
    }

    private async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    private async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
    }
}