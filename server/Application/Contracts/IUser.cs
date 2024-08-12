
using Application.Auth.Dtos;

namespace Application.Contracts;
public interface IUser
{
    Task<UserRegisterResponse> UserRegisterAsync(UserRegisterRequestDto dto);
    Task<UserLoginResponse> UserLoginAsync(UserLoginRequestDto dto);
}