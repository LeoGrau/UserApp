using Microsoft.EntityFrameworkCore;
using UserApp.Shared.Persistence.Context;
using UserApp.Shared.Persistence.Repositories;
using UserApp.UserApp.Domain.Models;
using UserApp.UserApp.Domain.Repositories;
using UserApp.UserApp.Domain.Services;

namespace UserApp.UserApp.Repositories;

public class UserRepository : BaseRepository<User, long>, IUserRepository
{
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public bool ExistByUsername(string username)
    {
        return AppDbContext.Users.Any(user => user.Username == username);
    }

    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await AppDbContext.Users.FirstOrDefaultAsync(user => user.Username == username);
    }
}