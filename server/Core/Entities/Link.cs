using System.ComponentModel.DataAnnotations;
namespace Core.Entities;

public class Link: EntityBase
{
    [Required]
    public required string Url { get; set; }
    public Guid UserId { get; set; }
    public Guid PlatformId { get; set; }
}