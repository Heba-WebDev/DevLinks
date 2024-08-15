using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace Application.Dtos.Platform;

public class CreatePlatformRequestDto
{
    [Required(ErrorMessage = "A platform name is requried")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "A platform base url is requried")]
    public required string BaseUrl { get; set; }

    [Required(ErrorMessage = "A platform image url is requried")]
    public IFormFile? Image { get; set; }
}