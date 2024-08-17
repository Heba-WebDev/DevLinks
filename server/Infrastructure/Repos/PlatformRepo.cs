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

    public async Task<GetAllPlatformsResponse> GetAllPlatformsAsync(bool? isSupported)
    {
        // allows modifications before executing the query against the db
        var query = _appDbContext.Platforms.AsQueryable();
        if (isSupported.HasValue)
        {
            query = query.Where(platform => platform.IsSupported == isSupported.Value);
        }
        var platforms = await query.ToListAsync(); // now the query is exectued
        return new GetAllPlatformsResponse(true, "Platforms retrieved successfully", platforms);
    }

    public async Task<UpdatePlatformResponse> UpdatePlatformAsync(string id, UpdatePlatformRequestDto dto)
    {
        var platform = await PlatformByIdExists(id);
        if (platform == null) return new UpdatePlatformResponse(false, "No platform found");
        if (!string.IsNullOrWhiteSpace(dto.Name))
        {
            var nameExists = await PlatformNameExists(dto.Name);
            if (nameExists != null && nameExists.Id != platform.Id)
                return new UpdatePlatformResponse(false, "This platform name already exists");
            platform.Name = dto.Name;
        }
        if (!string.IsNullOrWhiteSpace(dto.BaseUrl))
        {
            var baseUrlExists = await PlatformUrlExists(dto.BaseUrl);
            if (baseUrlExists != null && baseUrlExists.Id != platform.Id)
                return new UpdatePlatformResponse(false, "This platform url already exists");
            platform.BaseUrl = dto.BaseUrl;
        }
        if(dto.IsSupported.HasValue)
        {
            platform.IsSupported = dto.IsSupported.Value;
        }
        if (dto.Image != null)
        {
            var imageUrl = _uploadImageService.SavePlatformImage(dto.Image, platform.Name);
            platform.Image = imageUrl;
        }
        _appDbContext.Platforms.Update(platform);
        await _appDbContext.SaveChangesAsync();
        return new UpdatePlatformResponse(true, "Platform updated successfully");
    }

    private async Task<Platform?> PlatformByIdExists(string id)
    {
        return await _appDbContext.Platforms.FirstOrDefaultAsync(x => x.Id.ToString() == id);
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
