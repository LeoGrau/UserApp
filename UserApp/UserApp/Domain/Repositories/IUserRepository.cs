using UserApp.Shared.Domain.Repositories;
using UserApp.UserApp.Domain.Models;

namespace UserApp.UserApp.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User, long>
{
    bool ExistByUsername(string email);
    Task<User?> FindByUsernameAsync(string email);
}