namespace UserApp.UserApp.Domain.Models;

public class User
{
    public long UserId { get; set; }
    public string? Username { get; set; }
    public string? HashedPassword { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
}