using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using API.Middlewares;
using Core.Data;
using Core.Data.Repositories;
using Core.Handlers;
using Core.Mappers;
using Core.Services.DI;
using Microsoft.EntityFrameworkCore;

namespace API;

public class Startup
{
    private readonly IConfiguration _config;
    private readonly IWebHostEnvironment _env;

    public Startup(IConfiguration config, IWebHostEnvironment env)
    {
        _config = config;
        _env = env;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connStr = _config.GetConnectionString("DefaultConnection") 
                      ?? throw new InvalidOperationException("Connection string not found");
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(connStr));

        services.AddEfCoreRepositories<ApplicationContext>();
        services.AddDefaultServices();
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblyContaining<GetAllHotelsHandler>();
        });
        services.AddAutoMapper(options =>
        {
            options.AddMaps(typeof(HotelsMapper));
        });
        services.AddErrorHandling();
        services.AddHttpClient();

        services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddHttpClient();
    }

    public void Configure(IApplicationBuilder app)
    {
        MigrateDatabase(app.ApplicationServices);

		//if (_env.IsDevelopment())
		//{
		app.UseSwagger();
		app.UseSwaggerUI();
		//}

		app.UseHttpsRedirection();

        app.UseErrorHandling();
        
        app.UseRouting();
        
        app.UseAuthorization();

        app.UseEndpoints(e =>
        {
            e.MapControllers();
        });
    }

    private static void MigrateDatabase(IServiceProvider provider)
    {
        using var scope = provider.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
        ctx.Database.Migrate();
    }
}