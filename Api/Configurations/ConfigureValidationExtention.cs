using Api.Domain.Models.DTOs;
using Api.Validation;
using Api.Validation.UrlDTOs;
using Api.Validation.UserDTOs;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Api.Configurations;

public static class ConfigureValidationExtention
{
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssembly(typeof(UserRegisterRequestValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UserLoginRequestValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(URLCreateRequestValidator).Assembly);
        return services;
    }
}