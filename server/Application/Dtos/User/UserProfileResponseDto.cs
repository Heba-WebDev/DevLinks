namespace Application.Dtos.User;
public record UserProfileResponse (bool Flag, string Message = null!, UserResponse User = null!);