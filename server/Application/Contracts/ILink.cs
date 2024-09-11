using Application.Dtos.Link;
namespace Application.Contracts;

public interface ILink
{
    Task<AddLinkResponseDto> AddLinkAsync(Guid userId, AddLinkRequestDto dto);
    Task<UpdateLinkResponse> UpdateLinkAsync(Guid userId, UpdateLinkRequestDto dto);
    Task<GetAllLinksResponse> GetAllLinksAsync(Guid id);
    Task<DeleteLinkResponseDto> DeleteLinkAsync(Guid userId, Guid id);
}
