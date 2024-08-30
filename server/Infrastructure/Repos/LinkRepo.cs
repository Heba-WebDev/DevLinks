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
        var query = from user in _appDbContext.Users
                    join platform in _appDbContext.Platforms on new Guid(dto.PlatformId) equals platform.Id
                    where user.Id == new Guid(dto.UserId)
                    select new { User = user, Platform = platform };

        var result = await query.FirstOrDefaultAsync();
        if (result == null)
        {
            return new AddLinkResponseDto(false, "User or platform not found");
        }
        var userHasLink = await _appDbContext.Links.AnyAsync(
            link => link.PlatformId.ToString() == dto.PlatformId && link.UserId.ToString() == dto.UserId
        );
        if (userHasLink == true) return new AddLinkResponseDto(false, "A link for this platform already exists");
        var validUrl = ValidLink(dto.Url, result.Platform);
        if (validUrl == false) return new AddLinkResponseDto(false, "Invalid link");
        await _appDbContext.Links.AddAsync(new Link
        {
            UserId = new Guid(dto.UserId),
            PlatformId = new Guid(dto.PlatformId),
            Url = dto.Url
        });
        await _appDbContext.SaveChangesAsync();
        return new AddLinkResponseDto(true, "Link successfully added");
    }

    public async Task<UpdateLinkResponse> UpdateLinkAsync(UpdateLinkRequestDto dto)
    {
        var link = await _appDbContext.Links
        .Include(x => x.User)
        .Include(x => x.Platform)
        .FirstOrDefaultAsync(x => x.UserId.ToString() == dto.UserId && x.PlatformId.ToString() == dto.PlatformId);

        if(link == null) return new UpdateLinkResponse(false, "No link found", null);
        if(link.User == null) return new UpdateLinkResponse(false, "No user found", null);
        if (link.Platform == null) return new UpdateLinkResponse(false, "No platform found", null);

        var validUrl = ValidLink(dto.Url, link.Platform);
        if(validUrl == false) return new UpdateLinkResponse(false, "Invalid link", null);
        link.Url = dto.Url;
        await _appDbContext.SaveChangesAsync();
        var response = new UpdateLinkResponseDto
        {
            Url = link.Url,
            UserId = link.User.Id.ToString(),
            PlatformName = link.Platform.Name
        };
        return new UpdateLinkResponse(true, "Link successfully updated", response);
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
