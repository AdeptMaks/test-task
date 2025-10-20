using Api.Domain.Models.Entities;

namespace Api.Domain.Interfaces;

public interface IJwtProvider
{
    string GenerateToken(AppBaseUser user, string userLogin);
}