using UserApp.Shared.Domain.Repositories;
using UserApp.Shared.Persistence.Context;

namespace UserApp.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    protected AppDbContext AppDbContext;

    public UnitOfWork(AppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }

    public async Task CompleteAsync()
    {
        await AppDbContext.SaveChangesAsync();
    }
}