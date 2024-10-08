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
    public async Task<AddLinkResponseDto> AddLinkAsync(Guid userId, AddLinkRequestDto dto)
    {
        var query = from user in _appDbContext.Users
                    join platform in _appDbContext.Platforms on new Guid(dto.PlatformId) equals platform.Id
                    where user.Id == userId
                    select new { User = user, Platform = platform };

        var result = await query.FirstOrDefaultAsync();
        if (result == null)
        {
            return new AddLinkResponseDto(false, "User or platform not found");
        }
        var userHasLink = await _appDbContext.Links.AnyAsync(
            link => link.PlatformId.ToString() == dto.PlatformId && link.UserId == userId
        );
        if (userHasLink == true) return new AddLinkResponseDto(false, "A link for this platform already exists");
        var validUrl = ValidLink(dto.Url, result.Platform);
        if (validUrl == false) return new AddLinkResponseDto(false, "Invalid link");
        await _appDbContext.Links.AddAsync(new Link
        {
            UserId = userId,
            PlatformId = new Guid(dto.PlatformId),
            Url = dto.Url
        });
        await _appDbContext.SaveChangesAsync();
        return new AddLinkResponseDto(true, "Link successfully added");
    }

    public async Task<UpdateLinkResponse> UpdateLinkAsync(Guid userId, UpdateLinkRequestDto dto)
    {
        var link = await _appDbContext.Links
        .Include(x => x.User)
        .Include(x => x.Platform)
        .FirstOrDefaultAsync(x => x.UserId == userId && x.PlatformId.ToString() == dto.PlatformId);

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

    public async Task<GetAllLinksResponse> GetAllLinksAsync(Guid id)
    {
        var query = from user in _appDbContext.Users
                    where user.Id == id
                    select new {
                        User = user,
                        Links = _appDbContext.Links
                        .Where(x => x.UserId == id)
                        .Include(x => x.Platform)
                        .Select(x => new GetAllLinks{
                            Id = x.Id.ToString(),
                            Url = x.Url,
                            PlatformName = x.Platform!.Name,
                            PlatformId = x.PlatformId.ToString()
                        })
                        .ToList()
                    };
        var result = await query.FirstOrDefaultAsync();
        if (result == null)
        {
            return new GetAllLinksResponse(false, "User not found", null);
        }
        return new GetAllLinksResponse(true, "Links successfully fetched", result.Links);
    }

    public async Task<DeleteLinkResponseDto> DeleteLinkAsync(Guid userId, Guid linkId)
    {
        var link = await _appDbContext.Links
            .FirstOrDefaultAsync(x => x.Id == linkId && x.UserId == userId);
        if (link == null) return new DeleteLinkResponseDto(false, "No link found");
        _appDbContext.Links.Remove(link);
        await _appDbContext.SaveChangesAsync();
        return new DeleteLinkResponseDto(true, "Link deleted succssfully");
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
