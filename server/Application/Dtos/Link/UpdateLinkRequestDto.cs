using System.ComponentModel.DataAnnotations;
namespace Application.Dtos.Link;
public class UpdateLinkRequestDto
{
    [Required(ErrorMessage = "A url is requried")]
    public required string Url { get; set; }
    [Required(ErrorMessage = "A platform is requried")]
    public required string PlatformId { get; set; }
    [Required(ErrorMessage = "A user id is requried")]
    public required string UserId { get; set; }
}