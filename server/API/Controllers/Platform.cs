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
    public async Task<IActionResult> CreatePlatform([FromForm] CreatePlatformRequestDto dto)
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

    [Authorize(policy: "AdminOnly")]
    [HttpPatch]
    public async Task<IActionResult> UpdatePlatform([FromQuery] string id, [FromForm] UpdatePlatformRequestDto dto)
    {
        var role = User.FindFirstValue(ClaimTypes.Role);
        if (role != "Admin")
        {
            return Unauthorized("Unauthorized to perform this action");
        }
        var response = await _platformRepo.UpdatePlatformAsync(id, dto);
        return Ok(new
        {
            status = "success",
            message = response.Message
        }
        );
    }

    [Authorize(policy: "UserOrAdmin")]
    [HttpGet]
    public async Task<IActionResult> GetAllPlatforms()
    {
        var response = await _platformRepo.GetAllPlatformsAsync();
        return Ok(new
        {
            status = "success",
            message = response.Message,
            data = response.Platforms
        }
        );
    }

    [Authorize(policy: "UserOrAdmin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAPlatforms(string id)
    {
        var response = await _platformRepo.GetAPlatformAsync(id);
        if (!response.Flag)
        {
            return BadRequest(new
            {
                status = "fail",
                message = response.Message
            });
        }
        return Ok(new
        {
            status = "success",
            message = response.Message,
            data = response.Platform
        }
        );
    }
}