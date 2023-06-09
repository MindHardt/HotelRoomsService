using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Exceptions.Middleware;

public static class DependencyInjection
{
    public static IServiceCollection AddErrorHandling(this IServiceCollection services)
    {
        return services.AddScoped<ErrorHandlingMiddleware>();
    }
    /// <summary>
    /// Adds more informative status codes for some custom exceptions.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}