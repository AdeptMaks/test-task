using Api.Data.Interfaces;
using Api.Domain.Interfaces.Services;
using Api.Domain.Models.DTOs;
using Api.Domain.Models.Utils;
using Api.Domain.Models.Entities;
using Api.Data.Entities;
using AutoMapper;

namespace Api.Services;

public class UserService(
    IUserRepository userRepository,
    IMapper mapper,
    JwtProvider jwtProvider,
    ILogger<UserService> logger) : IUserService
{
    public async Task<Response<string>> ValidateUserCredentials(UserLoginRequest request)
    {
        var errors = new Dictionary<string, string[]>();
        var user = await userRepository.GetByLogin(request.Login);
        if (user == null || user.Password != request.Password)
        {
            logger.LogWarning("Invalid login attempt for user {Login}", request.Login);
            errors.Add("Authentication", ["Invalid login or password."]);
            return Response<string>.Failure(errors);
        }
        var role = string.Empty;
        if (user is UserEntity)
        {
            role = "User";
        }
        else if (user is AdminEntity)
        {
            role = "Admin";
        }
        else
        {
            logger.LogError("Unknown user type for user {Login}", request.Login);
            errors.Add("Authentication", ["Unknown user type."]);
            return Response<string>.Failure(errors);
        }
        var baseUser = mapper.Map<AppBaseUser>(user);
        var token = jwtProvider.GenerateToken(baseUser, role);
        return Response<string>.Success(token);
    }

    public async Task<Response<User>> RegisterUser(UserRegisterRequest request)
    {
        var errors = new Dictionary<string, string[]>();
        var existingUser = await userRepository.GetByLogin(request.Login);
        if (existingUser != null)
        {
            logger.LogWarning("Registration attempt with existing login {Login}", request.Login);
            errors.Add("Registration", ["Login already exists."]);
            return Response<User>.Failure(errors);
        }
        var newUser = new UserEntity
        {
            Id = Guid.NewGuid(),
            Login = request.Login,
            Password = request.Password
        };

        await userRepository.Add(newUser);
        logger.LogInformation("User {Login} registered successfully", request.Login);
        var userResponse = mapper.Map<User>(newUser);
        return Response<User>.Success(userResponse);
    }

}