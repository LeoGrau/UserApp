namespace UserApp.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity, TKey>
{
    Task<IEnumerable<TEntity>> ListAllAsync();
    Task<TEntity> FindAsync(TKey id);
    Task AddAsync(TEntity newEntityObject);
    void Update(TEntity updateEntityObject);
    void Remove(TEntity toDeleteEntityObject);
    bool Exist(TKey id);
}