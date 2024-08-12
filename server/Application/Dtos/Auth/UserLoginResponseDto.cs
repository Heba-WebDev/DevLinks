namespace Application.Auth.Dtos;
public record UserLoginResponse(bool Flag, string Message = null!, string token = null!);