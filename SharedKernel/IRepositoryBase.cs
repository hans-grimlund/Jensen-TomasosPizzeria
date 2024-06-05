namespace SharedKernel;

public interface IRepositoryBase<TEntity> where TEntity : EntityBase
{
    ValueTask<TEntity?> Get(int id);
    Task<List<TEntity>> GetAll();

    Task Add(TEntity entity);
    Task AddRange(IEnumerable<TEntity> entities);

    Task Remove(TEntity entity);
    Task RemoveRange(IEnumerable<TEntity> entities);
}