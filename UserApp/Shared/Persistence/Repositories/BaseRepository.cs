using Microsoft.EntityFrameworkCore;
using UserApp.Shared.Domain.Repositories;
using UserApp.Shared.Persistence.Context;

namespace UserApp.Shared.Persistence.Repositories;

public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
{
    protected AppDbContext AppDbContext { get; set; }
    protected readonly DbSet<TEntity> DbSet;

    public BaseRepository(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
        DbSet = appDbContext.Set<TEntity>(); //Find a properly DbSet to do the job.
    }

    public async Task<IEnumerable<TEntity>> ListAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<TEntity> FindAsync(TKey id)
    {
        return (await DbSet.FindAsync(id))!;
    }

    public async Task AddAsync(TEntity newEntityObject)
    {
        await DbSet.AddAsync(newEntityObject);
    }

    public void Update(TEntity updateEntityObject)
    {
        DbSet.Update(updateEntityObject);
    }

    public void Remove(TEntity toDeleteEntityObject)
    {
        DbSet.Remove(toDeleteEntityObject);
    }

    public bool Exist(TKey id)
    {
        if (DbSet.Find(id) == null)
            return true;
        return false;
    }
}