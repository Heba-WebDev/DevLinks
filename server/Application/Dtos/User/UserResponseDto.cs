namespace Application.Dtos.User;
public class UserResponse
{
    public required string Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Image { get; set; }
    public string? Role { get; set; }
}