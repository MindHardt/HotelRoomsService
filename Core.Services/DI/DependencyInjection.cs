using Microsoft.Extensions.DependencyInjection;

namespace Core.Services.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddDefaultServices(this IServiceCollection services)
    {
        services.Scan(scan =>
        {
            scan.FromAssemblies(typeof(DependencyInjection).Assembly)
                .AddClasses(c => c.WithAttribute<DefaultServiceAttribute>())
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
        return services;
    }
}