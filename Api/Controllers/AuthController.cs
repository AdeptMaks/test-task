using Api.Data.Interfaces;
using Api.Domain.Models;
using Api.Domain.Models.DTOs;
using Api.Domain.Models.Entities;
using Api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController(UserService userService) : Controller
{
    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request, [FromServices] HttpContext httpContext)
    {
        var result = await userService.ValidateUserCredentials(request);
        if (result.IsFailure)
        {
            return Unauthorized(result.Errors);
        }
        httpContext.Response.Cookies.Append("AuthToken", result.Data!);

        return Ok("Login successful");
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
    {
        var result = await userService.RegisterUser(request);
        if (result.IsFailure)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Data);
    }

}