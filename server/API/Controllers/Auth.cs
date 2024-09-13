using Application.Contracts;
using Application.Auth.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Dtos.Auth;

namespace API.Controllers;
[Route("/api/v1/auth")]
[ApiController]
public class Auth : ControllerBase
{
    private readonly IUser _userRepo;
    public Auth(IUser user)
    {
        this._userRepo = user;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterRequestDto dto)
    {
        var response = await _userRepo.UserRegisterAsync(dto);

        if (!response.Flag)
        {
            return BadRequest(new { message = response.Message });
        }

        return Ok(new
        {
            status = "success",
            message = response.Message
        });
    }


    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginRequestDto dto)
    {
        var response = await _userRepo.UserLoginAsync(dto);

        if (!response.Flag)
        {
            return BadRequest(new { message = response.Message });
        }

        return Ok(new
        {
            status="success",
            message = response.Message,
            data = new { accessToken = response.Token, user = response.User }
        });
    }

    [AllowAnonymous]
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequestDto dto)
    {
        var response = await _userRepo.ForgotPasswordAsync(dto);
        if (!response.Flag)
        {
            return BadRequest(new { message = response.Message });
        }
        return Ok( new {
            status = "success",
            message = response.Message
        });
    }
}