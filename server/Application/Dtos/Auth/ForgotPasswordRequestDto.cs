using System.ComponentModel.DataAnnotations;
namespace Application.Dtos.Auth;
public class ForgotPasswordRequestDto
{
    [Required(ErrorMessage = "An email is required")]
    public required string Email { get; set;}
}
