using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Core.Entities;

public class Link: EntityBase
{
    [Required]
    public required string Url { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey("UserId")]
    public User? User { get; set; }
    public Guid PlatformId { get; set; }
    [ForeignKey("PlatformId")]
    public Platform? Platform { get; set; }
}
