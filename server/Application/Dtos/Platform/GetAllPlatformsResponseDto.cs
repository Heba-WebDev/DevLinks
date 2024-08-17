using Core.Entities;

namespace Application.Dtos.Platform;
public record GetAllPlatformsResponse(bool Flag, string Message, List<Core.Entities.Platform> Platforms);