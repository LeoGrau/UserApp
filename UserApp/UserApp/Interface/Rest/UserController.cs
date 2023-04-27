using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UserApp.UserApp.Domain.Services;
using UserApp.UserApp.Domain.Services.Communication;

namespace UserApp.UserApp.Interface.Rest;

[ApiController]
[Route("/api/v0/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Testing")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        await _userService.RegisterAsync(registerRequest);
        return Ok(new { message = "Registration successful" });
    }
    
    [HttpPost("/auth")]
    public async Task<IActionResult> Authenticate(AuthRequest authRequest)
    {
        var response = await _userService.AuthenticateAsync(authRequest);
        return Ok(response);
    }
    
}