using Microsoft.Extensions.DependencyInjection;
using MyAuth.Core.Abstractions;
using MyAuth.Core.UseCases;
using MyAuth.Core.Validation;
using MyAuth.Domain.Commands;

namespace MyAuth.Core
{
    public static class ContainerConfiguration
    {
        public static IServiceCollection AddCore(this IServiceCollection services) {
            services.AddScoped<Ivalidator<LoginCommand>, LoginCommandValidator>();
            services.AddScoped<Ivalidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddScoped<IRequestHandler<bool, RegisterCommand>, RegisterCommandHandler>();
            services.AddScoped<IRequestHandler<string, LoginCommand>, LoginCommandHandler>();
            return services;
        }
    }
}
