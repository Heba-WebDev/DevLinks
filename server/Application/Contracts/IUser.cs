using Application.Auth.Dtos;
using Application.Dtos.Auth;
using Application.Dtos.User;
namespace Application.Contracts;
public interface IUser
{
    Task<UserRegisterResponse> UserRegisterAsync(UserRegisterRequestDto dto);
    Task<UserLoginResponse> UserLoginAsync(UserLoginRequestDto dto);
    Task<UserProfileResponse> UserProfileUpdateAsync(Guid userId, UserProfileRequestDto dto);
    Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequestDto dto);
    Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequestDto dto);
}
