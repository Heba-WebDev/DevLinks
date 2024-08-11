
using Application.Dtos;

namespace Application.Contracts;
public interface IUser
{
    Task<UserRegisterResponse> UserRegisterAsync(UserRegisterRequestDto dto);
}