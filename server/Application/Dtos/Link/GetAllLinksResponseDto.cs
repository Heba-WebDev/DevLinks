namespace Application.Dtos.Link;

public class GetAllLinks
{
    public required string Id { get; set; }
    public required string Url { get; set; }
    public required string PlatformName { get; set; }
    public required string PlatformId { get; set; }
}
public record GetAllLinksResponse(bool Flag, string Message, List<GetAllLinks>? Links);
