using UserApp.UserApp.Domain.Models;
using UserApp.UserApp.Domain.Services.Communication;
using UserApp.UserApp.Services.Communication.Responses;

namespace UserApp.UserApp.Domain.Services;

public interface IUserService
{
    Task RegisterAsync(RegisterRequest registerRequest);
    Task<AuthReponse> AuthenticateAsync(AuthRequest authRequest);
    Task<User> GetUserById(long userId);
}