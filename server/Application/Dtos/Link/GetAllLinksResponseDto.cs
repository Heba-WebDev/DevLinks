namespace Application.Dtos.Link;

public class GetAllLinks
{
    public required string Url { get; set; }
    public required string UserId { get; set; }
    public required string PlatformName { get; set; }
}
public record GetAllLinksResponse(bool Flag, string Message, List<GetAllLinks>? Links);
