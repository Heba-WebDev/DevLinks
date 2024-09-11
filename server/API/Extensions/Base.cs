using System.Security.Claims;
namespace API.Extensions;

public static class ClaimsPricipalExtension
{
    public static Guid? GetUserId(this ClaimsPrincipal user)
    {
        var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userIdString, out Guid userId) ? userId : (Guid?)null;
    }

    public static string? GetUserRole(this ClaimsPrincipal user)
    {
        return user.FindFirstValue(ClaimTypes.Role);
    }
}
