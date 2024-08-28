using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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
    [JsonIgnore]
    ICollection<Link> Links { get; set; } = new List<Link>();
}
