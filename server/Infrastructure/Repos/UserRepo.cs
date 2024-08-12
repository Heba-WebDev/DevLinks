using Application.Contracts;
using Application.Auth.Dtos;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
namespace Infrastructure.Repos;

public class UserRepo : IUser
{
    private readonly AppDbContext _appDbContext;
    private readonly JwtService _jwtService;
    public UserRepo(AppDbContext appDbContext, JwtService jwtService)
    {
        this._appDbContext = appDbContext;
        this._jwtService = jwtService;
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

    public async Task<UserLoginResponse> UserLoginAsync(UserLoginRequestDto dto)
    {
        var user = await GetUserByEmailAsync(dto.Email);
        if (user == null) return new UserLoginResponse(false, "Invalid credentials");
        var matchedPassword = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
        if (!matchedPassword) return new UserLoginResponse(false, "Invalid credentials");
        var token = _jwtService.GenerateToken(user.Id.ToString(), user.Role.ToString());
        return new UserLoginResponse(true, "User loggedin successfully", token);
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