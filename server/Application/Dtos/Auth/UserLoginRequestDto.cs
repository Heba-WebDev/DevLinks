using System.ComponentModel.DataAnnotations;
namespace Application.Auth.Dtos;

public class UserLoginRequestDto
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
    [RegularExpression(@"^[a-zA-Z\d_-]{8,}$",
    ErrorMessage = "Password can only contain letters, digits, _, and -")]
    public required string Password { get; set; }
}