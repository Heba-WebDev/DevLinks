using System.ComponentModel.DataAnnotations;
namespace Application.Dtos.Link;
public class AddLinkRequestDto
{
    [Required(ErrorMessage = "A url is requried")]
    public required string Url { get; set; }
    [Required(ErrorMessage = "A platform is requried")]
    public required string PlatformId { get; set; }
}
