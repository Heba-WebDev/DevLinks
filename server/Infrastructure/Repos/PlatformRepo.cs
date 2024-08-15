using Application.Contracts;
using Application.Dtos.Platform;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repos;

public class PlatformRepo : IPlatform
{
    private readonly AppDbContext _appDbContext;
    private readonly IUploadImage _uploadImageService;
    public PlatformRepo(AppDbContext appDbContext, IUploadImage uploadImageService)
    {
        this._appDbContext = appDbContext;
        this._uploadImageService = uploadImageService;
    }
    public async Task<CreatePlatformResponse> CreatePlatformAsync(CreatePlatformRequestDto dto)
    {
        var nameExists = await PlatformNameExists(dto.Name);
        if (nameExists != null) return new CreatePlatformResponse(false, "This platform name already exists");
        var baseUrlExists = await PlatformUrlExists(dto.BaseUrl);
        if (baseUrlExists != null) return new CreatePlatformResponse(false, "This platform url already exists");
        var imageUrl = _uploadImageService.SavePlatformImage(dto.Image!, dto.Name);
        _appDbContext.Platforms.Add(new Platform()
        {
            Name = dto.Name,
            BaseUrl = dto.BaseUrl,
            Image = imageUrl,
            IsSupported = true,
        });
        await _appDbContext.SaveChangesAsync();
        return new CreatePlatformResponse(true, "Platform successfully created");
    }

    private async Task<Platform?> PlatformNameExists(string name)
    {
        return await _appDbContext.Platforms.FirstOrDefaultAsync(x => x.Name == name);
    }
    private async Task<Platform?> PlatformUrlExists(string baseUrl)
    {
        return await _appDbContext.Platforms.FirstOrDefaultAsync(x => x.BaseUrl == baseUrl);
    }

}