using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace Application.Dtos.Platform;
public class UpdatePlatformRequestDto
{
    public string? Name { get; set; }
    public string? BaseUrl { get; set; }
    public IFormFile? Image { get; set; }
    public string? Color { get; set; }
    public bool? IsSupported { get; set; }
}