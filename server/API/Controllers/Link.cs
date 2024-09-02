using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Dtos.Link;
using System.Security.Claims;

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

    [Authorize(policy: "UserOrAdmin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAllLinks(Guid id)
    {
        var response = await _linkRepo.GetAllLinksAsync(id);
        if (!response.Flag)
        {
            return BadRequest(new { message = response.Message });
        }
        return Ok(new
        {
            status = "success",
            message = response.Message,
            data = new
            {
                response.Links
            }
        });
    }

    [Authorize(policy: "UserOrAdmin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLink(Guid id)
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
        if(userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out Guid userId))
        {
            return Unauthorized("Invalid indentification");
        }
        var response = await _linkRepo.DeleteLinkAsync(userId, id);
        if (!response.Flag)
        {
            return BadRequest(new { message = response.Message });
        }
        return NoContent();
    }
}
