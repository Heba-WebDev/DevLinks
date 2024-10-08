
using Application.Dtos.Platform;

namespace Application.Contracts;

public interface IPlatform
{
    Task<CreatePlatformResponse> CreatePlatformAsync(CreatePlatformRequestDto dto);
    Task<UpdatePlatformResponse> UpdatePlatformAsync(string id, UpdatePlatformRequestDto dto);
    Task<GetAllPlatformsResponse> GetAllPlatformsAsync(bool? isSupported = null);
    Task<GetAPlatformResponseDto> GetAPlatformAsync(string id);
}