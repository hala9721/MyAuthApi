using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAuth.Core.Abstractions;
using MyAuth.Domain;
using MyAuth.Infrastructure.Database;
using MyAuth.Infrastructure.Entities;
using MyAuth.Infrastructure.Repositories;
using MyAuth.Infrastructure.Security;

namespace MyAuth.Infrastructure;

public static class ContainerConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TokenOptions>(configuration.GetSection("Authentication:Schemes:Bearer"));
        services.AddDbContext<UserContext>(o => o.UseInMemoryDatabase("AuthDb"));
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserQueriesRepository, UserQueriesRepository>();
        services.AddScoped<IUserCommandsRepository, UserCommandsRepository>();
        return services;
    }

    public static async Task SeedDefaultUsersAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<UserContext>();
        if (!await context.Users.AnyAsync())
        {
            context.Users.Add(new UserEntity
            {
                Username = "admin",
                Email = "admin@local",
                Password = PasswordHasher.Hash("admin"),
                Role = AuthRoles.Admin,
            });
            await context.SaveChangesAsync();
        }
    }
}