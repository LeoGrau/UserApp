using System.ComponentModel.DataAnnotations;

namespace UserApp.UserApp.Domain.Services.Communication;

public class RegisterRequest
{
    [Required] public string? Username { get; set; }
    [Required] public string? Password { get; set; }
    [Required] public string? Firstname { get; set; }
    [Required] public string? Lastname { get; set; }
}