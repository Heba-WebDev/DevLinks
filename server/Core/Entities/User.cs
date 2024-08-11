using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Core.Enums;
namespace Core.Entities;

public class User: EntityBase {
    [Required]
    public string? Username { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [AllowNull]
    public string FirstName { get; set; }
    [AllowNull]
    public string LastName { get; set; }
    [Required]
    public required string Password { get; set; }
    [AllowNull]
    public string Image { get; set; }

    public Role Role { get; set; } = Role.User;
}