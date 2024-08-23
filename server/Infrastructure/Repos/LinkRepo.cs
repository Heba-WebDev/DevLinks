
using Application.Contracts;
using Application.Dtos.Link;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos;

public class LinkRepo : ILink
{
    private readonly AppDbContext _appDbContext;
    public LinkRepo(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<AddLinkResponseDto> AddLinkAsync(AddLinkRequestDto dto)
    {
        var user = await UserExists(dto.UserId);
        if(user == null) return new AddLinkResponseDto(false, "No user found");
        var platform = await PlatformExists(dto.PlatformId);
        if (platform == null) return new AddLinkResponseDto(false, "No platform found");
        var userHasLink = await LinkExists(dto.UserId, dto.PlatformId);
        if (userHasLink == true) return new AddLinkResponseDto(false, "A link for this platform already exists");
        var validUrl = ValidLink(dto.Url, platform);
        if (validUrl == false) return new AddLinkResponseDto(false, "Invalid link");
        await _appDbContext.Links.AddAsync(new Link
        {
            UserId = new Guid(dto.UserId),
            PlatformId = new Guid(dto.PlatformId),
            Url = dto.Url
        });

        return new AddLinkResponseDto(true, "Link successfully added");
    }

    private async Task<User?> UserExists(string id)
    {
        return await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id.ToString() == id);
    }

    private async Task<Platform?> PlatformExists(string id)
    {
        return await _appDbContext.Platforms.FirstOrDefaultAsync(x => x.Id.ToString() == id);
    }

    private async Task<bool> LinkExists(string userId, string platformId)
    {
        // Check if any link exists with the given userId and platformId
        return await _appDbContext.Links.AnyAsync(
            link => link.PlatformId.ToString() == platformId && link.UserId.ToString() == userId
        );
    }

    private static bool ValidLink(string url, Platform platform)
    {
        if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(platform.BaseUrl)) return false;
        Uri baseUri = new(platform.BaseUrl);
        Uri urlUri;

        if (!Uri.TryCreate(url, UriKind.Absolute, out urlUri!))
        {
            return false;
        }

        //  compares the Host properties of both URIs to ensure they are from the same domain
        //  then checks that the path of the url starts with the base path of the platform's URL
        return urlUri.Host.Equals(baseUri.Host, StringComparison.OrdinalIgnoreCase) &&
           urlUri.AbsolutePath.StartsWith(baseUri.AbsolutePath, StringComparison.OrdinalIgnoreCase);
    }
}