using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Api.Configurations;
using Api.Domain.Interfaces;
using Api.Domain.Models.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services;

public class JwtProvider(IOptions<JwtOptions> jwtOptions) : IJwtProvider
{
    private readonly JwtOptions _config = jwtOptions.Value;
    public string GenerateToken(AppBaseUser user, string role)
    {
        var claims = new[]
        {
            new Claim("userId", user.Id.ToString()),
            new Claim("login", user.Login),
            new Claim("role", role)
        };
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.Key)),
            SecurityAlgorithms.HmacSha256
        );
        var token = new JwtSecurityToken(
            signingCredentials: signingCredentials,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(_config.ExpiresInHours)
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}