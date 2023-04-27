using AutoMapper;
using UserApp.Shared.Domain.Repositories;
using UserApp.UserApp.Authorization.Handlers.Interfaces;
using UserApp.UserApp.Domain.Models;
using UserApp.UserApp.Domain.Repositories;
using UserApp.UserApp.Domain.Services;
using UserApp.UserApp.Domain.Services.Communication;
using UserApp.UserApp.Exceptions;
using UserApp.UserApp.Services.Communication.Responses;

namespace UserApp.UserApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IJwtHandler _jwtHandler;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler jwtHandler)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtHandler = jwtHandler;
    }

    public async Task<User> GetUserById(long userId)
    {
        var existingUser = await _userRepository.FindAsync(userId);
        if (existingUser == null)
            throw new KeyNotFoundException("User does not exist");
        return existingUser;

    }

    public async Task RegisterAsync(RegisterRequest registerRequest)
    {
        //Validate if email was already taken.
        if (_userRepository.ExistByUsername(registerRequest.Username!))
            throw new AppException($"Username '{registerRequest.Username!} was already taken.");
        
        //Map request to User Object
        var user = _mapper.Map<User>(registerRequest);
        
        //Hash Password
        user.HashedPassword = BCrypt.Net.BCrypt.HashPassword(registerRequest.Password);
        
        //Save User
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"Something happened: {e.Message}");
        }
    }
    
    public async Task<AuthReponse> AuthenticateAsync(AuthRequest authRequest)
    {
        var user = await _userRepository.FindByUsernameAsync(authRequest.Username!);
        if (user == null)
        {
            Console.WriteLine("User is null");
        }
        Console.WriteLine($"Password hashed: {user.HashedPassword}");
        if (user == null || !BCrypt.Net.BCrypt.Verify(authRequest.Password, user.HashedPassword))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Username or Password is incorrect.");
        }
        Console.WriteLine($"Request {authRequest.Username}, {authRequest.Password}");
        Console.WriteLine($"Request {user.UserId}, {user.Firstname}");
        Console.WriteLine("Authentication successful. About to generate token");
        // Authentication Successful
        var response = _mapper.Map<User, AuthReponse>(user);
        response.Token = _jwtHandler.GenerateToken(user);
        return response;
    }
}