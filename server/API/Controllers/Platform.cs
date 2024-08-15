using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Platform;
using Application.Contracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;
[Route("/api/v1/platforms")]
[ApiController]
public class Platform : ControllerBase
{
    private readonly IPlatform _platformRepo;
    public Platform(IPlatform platformRepo)
    {
        this._platformRepo = platformRepo;
    }

    [Authorize(Policy = "AdminOnly")]
    [HttpPost]
    public async Task<IActionResult> CreatePlatform(CreatePlatformRequestDto dto)
    {
        var role = User.FindFirstValue(ClaimTypes.Role);
        if (role != "Admin")
        {
            return Unauthorized("Unauthorized to perform this action");
        }
        var response = await _platformRepo.CreatePlatformAsync(dto);
        return Ok(new
        {
            status = "success",
            message = response.Message
        }
        );
    }
}