namespace UserApp.UserApp.Services.Communication.Responses;

public class AuthReponse
{
    public long UserId { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Username { get; set; }
    public string? Token { get; set; }
}