using Microsoft.EntityFrameworkCore;

namespace Core.Data;

/// <remarks>
/// Наш контекст в котором содеражтся все таблички. Они не хранятся как свойства потому что он их понимает
/// исходя из того какие сущности прописаны в энтити конфигах. Инжектить контекст напрямую не стоит, это лишает нас
/// важного уровня абстракции. См папку Repositories
/// </remarks>
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) 
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Чтобы EFCore сам нашел конфигурации из этого проекта
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}