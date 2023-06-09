using Microsoft.EntityFrameworkCore;

namespace Core.Data.Repositories.Implementations;

public abstract class EfCoreRepositoryBase<T>
    where T : class
{
    private readonly DbContext _ctx;

    protected EfCoreRepositoryBase(DbContext ctx)
    {
        _ctx = ctx;
    }
    
    /// <summary>
    /// The <see cref="DbSet{TEntity}"/> used for accessing the table.
    /// </summary>
    /// <remarks>В рамках репозитория у вас есть доступ только к сету, т.е. табличке.</remarks>
    protected DbSet<T> Set => _ctx.Set<T>();
    /// <summary>
    /// Saves changes made in this <see cref="EfCoreRepositoryBase{T}"/>.
    /// </summary>
    /// <returns></returns>
    protected Task CommitAsync() => _ctx.SaveChangesAsync();

}