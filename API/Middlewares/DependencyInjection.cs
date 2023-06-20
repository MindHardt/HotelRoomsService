namespace API.Middlewares;

public static class DependencyInjection
{
	/// <summary>
	/// Adds infrastructure for <see cref="UseErrorHandling(IApplicationBuilder)"/> middleware.
	/// </summary>
	/// <param name="services"></param>
	/// <returns></returns>
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