using Application.Dtos.Link;
namespace Application.Contracts;

public interface ILink
{
    Task<AddLinkResponseDto> AddLinkAsync(AddLinkRequestDto dto);
}
