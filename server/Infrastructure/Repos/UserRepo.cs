using Application.Contracts;
using Application.Auth.Dtos;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
using Application.Dtos.User;
using Application.Dtos.Auth;
using Core.Enums;
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
        if (user == null) return new UserLoginResponse(false, null, "Invalid credentials");
        var matchedPassword = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);
        if (!matchedPassword) return new UserLoginResponse(false, null, "Invalid credentials");
        var token = _jwtService.GenerateToken(user.Id.ToString(), user.Role.ToString());
        var userDto = new UserResponse
        {
            Id = user.Id.ToString(),
            Username = user.Username!,
            Email = user.Email!,
            Role = user.Role.ToString()
        };
        return new UserLoginResponse(true, userDto, "User loggedin successfully", token);
    }

    public async Task<UserProfileResponse> UserProfileUpdateAsync(UserProfileRequestDto dto, string userId)
    {
        var user = await GetUserByIdAsync(userId);
        if (user == null) return new UserProfileResponse(false, "Invalid credentials");
        if(!string.IsNullOrWhiteSpace(dto.Email))
        {
            var emailExists = await GetUserByEmailAsync(dto.Email);
            if (emailExists != null && emailExists.Id != user.Id)
            {
                return new UserProfileResponse(false, "Email already in use");
            }
            user.Email = dto.Email;
        }

        if (!string.IsNullOrWhiteSpace(dto.FirstName))
        {
            user.FirstName = dto.FirstName;
        }

        if (!string.IsNullOrWhiteSpace(dto.LastName))
        {
            user.LastName = dto.LastName;
        }

        _appDbContext.Users.Update(user);
        await _appDbContext.SaveChangesAsync();
        return new UserProfileResponse(true, "Profile successfully updated");
    }

    private async Task<User?> GetUserByIdAsync(string userId)
    {
        return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);
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