using System.ComponentModel.DataAnnotations;
namespace Core.Entities;

public class Platform: EntityBase
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string BaseUrl { get; set; }
    [Required]
    public required string Image { get; set; }
    [Required]
    public required string Color { get; set; }
    public bool IsSupported { get; set; } = true;
}