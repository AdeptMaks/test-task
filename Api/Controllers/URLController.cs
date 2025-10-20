
using Api.Domain.Interfaces.Services;
using Api.Domain.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class URLController(IURLService urlService) : ControllerBase
{
    [Authorize]
    [HttpPost("shorten")]
    public async Task<IActionResult> ShortenURL([FromBody] URLCreateRequest request)
    {
        var userId = User.FindFirst("userId")?.Value;
        if (userId == null)
        {
            return Unauthorized("User ID not found in token.");
        }
        var shortUrl = await urlService.ShortenURLAsync(request, userId);
        return Ok();
    }
    [Authorize]
    [HttpGet("urls")]
    public async Task<IActionResult> GetAllURLs()
    {
        var userId = User.FindFirst("userId")?.Value;
        if (userId == null)
        {
            return Unauthorized("User ID not found in token.");
        }
        var response = await urlService.GetAllURLsAsync(userId);
        if (!response.IsSuccess)
        {
            return BadRequest(response.Errors);
        }
        var urls = response.Data;
        return Ok(urls);
    }



}