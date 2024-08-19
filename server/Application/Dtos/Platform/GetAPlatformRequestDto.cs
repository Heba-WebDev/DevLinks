using System.ComponentModel.DataAnnotations;
namespace Application.Dtos.Platform;

public class GetAPlatformRequestDto
{
    [Required(ErrorMessage = "A platform id is requried")]
    public required Guid Id { get; set; }
}
