using Application.Contracts;
using Application.Auth.Dtos;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services;
using Application.Dtos.User;
using Application.Dtos.Auth;
using Microsoft.Extensions.Configuration;
namespace Infrastructure.Repos;

public class UserRepo : IUser
{
    private readonly AppDbContext _appDbContext;
    private readonly JwtService _jwtService;
    private readonly IEmail _email;
    private readonly IConfiguration _configuration;
    public UserRepo(AppDbContext appDbContext, JwtService jwtService, IEmail email, IConfiguration configuration)
    {
        this._appDbContext = appDbContext;
        this._jwtService = jwtService;
        this._email = email;
        this._configuration = configuration;
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

    public async Task<UserProfileResponse> UserProfileUpdateAsync(Guid userId, UserProfileRequestDto dto)
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
        var userDto = new UserResponse
        {
            Id = user.Id.ToString(),
            Username = user.Username!,
            Email = user.Email!,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Image = user.Image,
            Role = user.Role.ToString(),
        };
        return new UserProfileResponse(true, "Profile successfully updated", userDto);
    }

    public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequestDto dto)
    {
        var user = await this._appDbContext.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
        if (user == null) return new ForgotPasswordResponse(true, "An email with instruction has been sent");
        var url = this.GetResetPasswordUrl(user.Id, user.Role.ToString());
        var message = $"If you've lost your password or wish to reset it, use the link below to get started: {url}";
        var subject = "Reset your password || Devlinks";
        await _email.SendEmailAsync(dto.Email, subject, message);
        return new ForgotPasswordResponse(true, "An email with instruction has been sent");
    }

    private async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
    }

    private async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    private async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
    }

    private string GetResetPasswordUrl(Guid userId, string userRole)
    {
        var token = _jwtService.GenerateToken(userId.ToString(), userRole);
        var baseUrl = _configuration["AppSettings:BaseUrl"];
        return $"{baseUrl}/auth/reset-password?token={token}";
    }
}