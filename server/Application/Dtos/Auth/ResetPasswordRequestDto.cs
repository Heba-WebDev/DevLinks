using System.ComponentModel.DataAnnotations;
namespace Application.Dtos.Auth;
public class ResetPasswordRequestDto
{
    [Required(ErrorMessage = "A token is required")]
    public required string Token { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    [RegularExpression(@"^[a-zA-Z\d_-]{8,}$",
    ErrorMessage = "Password can only contain letters, digits, _, and -")]
    public required string Password { get; set; }
}
