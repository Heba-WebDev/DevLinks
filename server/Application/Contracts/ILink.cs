using Application.Dtos.Link;
namespace Application.Contracts;

public interface ILink
{
    Task<AddLinkResponseDto> AddLinkAsync(AddLinkRequestDto dto);
    Task<UpdateLinkResponse> UpdateLinkAsync(UpdateLinkRequestDto dto);
    Task<GetAllLinksResponse> GetAllLinksAsync(Guid id);
}
