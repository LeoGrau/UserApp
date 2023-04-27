using UserApp.UserApp.Domain.Models;

namespace UserApp.UserApp.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    string GenerateToken(User user);
    long? ValidateToken(string token); // It will return userId
}