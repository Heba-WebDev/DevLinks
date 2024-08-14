using System.ComponentModel.DataAnnotations;
namespace Application.Dtos.User;
public class UserProfileRequestDto
{
    [Required(ErrorMessage = "a user id is required")]
    public required string Id { get; set; }
    [StringLength(20, ErrorMessage = "First name cannot exceed 20 characters")]
    public string? FirstName { get; set; }

    [StringLength(20, ErrorMessage = "Last name cannot exceed 20 characters")]
    public string? LastName { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address format")]
    public string? Email { get; set; }
}