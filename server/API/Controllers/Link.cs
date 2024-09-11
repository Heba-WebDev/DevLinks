using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Dtos.Link;
using API.Extensions;

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
        var userId = User.GetUserId();
        if (!userId.HasValue)
        {
            return Unauthorized("Invalid indentification");
        }
        var response = await _linkRepo.AddLinkAsync((Guid)userId, dto);
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
        var userId = User.GetUserId();
        if (!userId.HasValue)
        {
            return Unauthorized("Invalid indentification");
        }
        var response = await _linkRepo.UpdateLinkAsync((Guid) userId, dto);
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
    [HttpGet]
    public async Task<IActionResult> GetAllLinks()
    {
        var userId = User.GetUserId();
        if (!userId.HasValue)
        {
            return Unauthorized("Invalid indentification");
        }
        var response = await _linkRepo.GetAllLinksAsync((Guid)userId);
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
        var userId = User.GetUserId();
        if(!userId.HasValue)
        {
            return Unauthorized("Invalid indentification");
        }
        var response = await _linkRepo.DeleteLinkAsync((Guid)userId, id);
        if (!response.Flag)
        {
            return BadRequest(new { message = response.Message });
        }
        return NoContent();
    }
}
