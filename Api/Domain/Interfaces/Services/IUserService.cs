using Api.Domain.Models.DTOs;
using Api.Domain.Models.Entities;
using Api.Domain.Models.Utils;

namespace Api.Domain.Interfaces.Services;

public interface IUserService
{
    Task<Response<string>> ValidateUserCredentials(UserLoginRequest request);
    Task<Response<User>> RegisterUser(UserRegisterRequest request);
}
