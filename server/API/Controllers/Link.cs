using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Dtos.Link;

namespace API.Controllers;

[Route("/api/v1/links")]
[ApiController]
public class Link : ControllerBase
{
    private readonly ILink _linkRepo;
    public Link(ILink linkRepo)
    {
        _linkRepo = linkRepo;
    }

    [Authorize(policy: "UserOrAdmin")]
    [HttpPost]
    public async Task<IActionResult> AddLink(AddLinkRequestDto dto)
    {
        var response = await _linkRepo.AddLinkAsync(dto);
        if (!response.Flag)
        {
            return BadRequest(new { message = response.Message });
        }
        return Ok(new {
            status = "success",
            message = response.Message,
        });
    }

    [Authorize(policy: "UserOrAdmin")]
    [HttpPatch]
    public async Task<IActionResult> UpdateLink([FromBody] UpdateLinkRequestDto dto)
    {
        var response = await _linkRepo.UpdateLinkAsync(dto);
        if (!response.Flag)
        {
            return BadRequest(new { message = response.Message});
        }
        return Ok(new
        {
            status = "success",
            message = response.Message,
            data = new {
                response.Link
            }
        });
    }
}
