

using Application.Auth.Dtos;
using Application.Dtos.Auth;
using Application.Dtos.User;

namespace Application.Contracts;
public interface IUser
{
    Task<UserRegisterResponse> UserRegisterAsync(UserRegisterRequestDto dto);
    Task<UserLoginResponse> UserLoginAsync(UserLoginRequestDto dto);
    Task<UserProfileResponse> UserProfileUpdateAsync(UserProfileRequestDto dto, string userId);
}