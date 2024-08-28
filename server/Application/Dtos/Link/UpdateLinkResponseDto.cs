namespace Application.Dtos.Link;
public class UpdateLinkResponseDto
{
    public required string Url {get; set;}
    public required string UserId {get; set;}
    public required string PlatformName { get; set; }
}
public record UpdateLinkResponse(bool Flag, string Message, UpdateLinkResponseDto? Link);
