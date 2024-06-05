using Microsoft.EntityFrameworkCore;

namespace SharedKernel;

public class RepositoryBase<TEntity>(DbContext context) : IRepositoryBase<TEntity>
    where TEntity : EntityBase
{
    protected readonly DbContext Context = context;

    public ValueTask<TEntity?> Get(int id)
    {
        return Context.Set<TEntity>().FindAsync(id);
    }

    public Task<List<TEntity>> GetAll()
    {
        return Context.Set<TEntity>().ToListAsync();
    }

    public async Task Add(TEntity entity)
    {
        await Context.Set<TEntity>().AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task AddRange(IEnumerable<TEntity> entities)
    {
        await Context.Set<TEntity>().AddRangeAsync(entities);
        await Context.SaveChangesAsync();
    }

    public async Task Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        await Context.SaveChangesAsync();
    }

    public async Task RemoveRange(IEnumerable<TEntity> entities)
    {
        Context.Set<TEntity>().RemoveRange(entities);
        await Context.SaveChangesAsync();
    }
}