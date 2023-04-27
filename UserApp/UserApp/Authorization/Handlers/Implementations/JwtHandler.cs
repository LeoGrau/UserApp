using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using UserApp.UserApp.Authorization.Handlers.Interfaces;
using UserApp.UserApp.Authorization.Settings;
using UserApp.UserApp.Domain.Models;

namespace UserApp.UserApp.Authorization.Handlers.Implementations;

public class JwtHandler : IJwtHandler
{
    private readonly AppSettings AppSettings;

    public JwtHandler(IOptions<AppSettings> appSettings)
    {
        AppSettings = appSettings.Value;
    }

    public string GenerateToken(User user)
    {
        // Generate token for a valid period of 7 days and with our Secret
        Console.WriteLine($"{AppSettings.Secret}");
        var secret = AppSettings.Secret;
        var key = Encoding.ASCII.GetBytes(secret!);
        Console.WriteLine($"Key: {key}");
        Console.WriteLine($"{user.UserId.ToString()}");

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Sid, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username!)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public long? ValidateToken(string token)
    {
        if (string.IsNullOrEmpty(token))
            return null;
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AppSettings.Secret!);
        
        // Execute Token Validation Process
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                //Expiration
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(
                claim => claim.Type == ClaimTypes.Sid).Value);
            return userId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}