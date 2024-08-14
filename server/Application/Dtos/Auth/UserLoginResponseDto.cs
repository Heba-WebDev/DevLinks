
using Application.Dtos.User;
namespace Application.Dtos.Auth;

public record UserLoginResponse(bool Flag, UserResponse? User, string Message = null!, string Token = null!);