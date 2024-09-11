using API.Extensions;
using Application.Contracts;
using Application.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateProfile(string id, UserProfileRequestDto dto)
    {
        var userId = User.GetUserId();
        if (!userId.HasValue)
        {
            return Unauthorized("Invalid indentification");
        }
        var userRole = User.GetUserRole();

        if (userId.ToString() != id && userRole != "Admin")
        {
            return Unauthorized("Unauthorized to perform this action");
        }

        var response = await _userRepo.UserProfileUpdateAsync((Guid)userId, dto);
        if (!response.Flag)
        {
            return BadRequest(new { message = response.Message });
        }
        return Ok(new
        {
            status = "success",
            message = response.Message,
            data = new {
                response.User
            }
        }
        );
    }
}