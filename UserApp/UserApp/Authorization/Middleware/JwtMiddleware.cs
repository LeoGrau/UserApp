using Microsoft.Extensions.Options;
using UserApp.Shared.Tools;
using UserApp.UserApp.Authorization.Handlers.Interfaces;
using UserApp.UserApp.Authorization.Settings;
using UserApp.UserApp.Domain.Services;

namespace UserApp.UserApp.Authorization.Middleware;

/// <summary>
/// Will intercept all incoming HTTP requests and perform
/// JWT validation and user authorization/authentication
/// based on the token
/// </summary>
public class JwtMiddleware
{
    private readonly AppSettings _appSettings;
    private readonly RequestDelegate _next;

    public JwtMiddleware(IOptions<AppSettings> appSettings, RequestDelegate next)
    {
        _appSettings = appSettings.Value;
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, IUserService userService, IJwtHandler handler)
    {
        var myObject = httpContext.Request.Headers["Authorization"];
        ObjectPrinter.PrintObject(myObject);
        var token = httpContext.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split("").Last();
        var userId = handler.ValidateToken(token!);
        if (userId != null)
        {
            Console.WriteLine("UserId is not null. So that means token is validated");
            httpContext.Items["User"] = await userService.GetUserById(userId.Value);
        }

        await _next(httpContext);
    }
    

}