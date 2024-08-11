using Application.Contracts;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[Route("/api/v1/auth")]
[ApiController]
public class User : ControllerBase
{
    private readonly IUser _userRepo;
    public User(IUser user)
    {
        this._userRepo = user;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterRequestDto dto)
    {
        var response = await _userRepo.UserRegisterAsync(dto);

        if (!response.Flag)
        {
            return BadRequest(new { message = response.Message });
        }

        return Ok(new { message = response.Message });
    }
}