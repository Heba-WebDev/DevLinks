
using Application.Contracts;
using Application.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers;
[Route("/api/v1/users")]
[ApiController]

public class User : ControllerBase
{
    private readonly IUser _userRepo;

    public User(IUser user)
    {
        this._userRepo = user;
    }

    [Authorize(Policy = "UserOrAdmin")]
    [HttpPost("update-profile")]
    public async Task<IActionResult> UpdateProfile(UserProfileRequestDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userRole = User.FindFirstValue(ClaimTypes.Role);
        if (userId != dto.Id && userRole != "Admin")
        {
            return Unauthorized("Unauthorized to perform this action");
        }

        var response = await _userRepo.UserProfileUpdateAsync(dto, userId!);
        if (!response.Flag)
        {
            return BadRequest(new { message = response.Message });
        }
        return Ok(new
        {
            status = "success",
            message = response.Message
        }
        );
    }
}