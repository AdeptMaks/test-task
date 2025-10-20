using Api.Data.Interfaces;
using Api.Data.Repositories;

namespace Api.Configurations;

public static class ServiceCollectionExtentions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IURLRepository, URLRepository>();
        return services;
    }
}