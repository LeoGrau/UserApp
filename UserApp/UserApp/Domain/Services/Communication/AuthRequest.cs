using System.ComponentModel.DataAnnotations;

namespace UserApp.UserApp.Domain.Services.Communication;

public class AuthRequest
{
    [Required] public string? Username { get; set; }
    [Required] public string? Password { get; set; }
}