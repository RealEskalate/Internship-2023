namespace CineFlex.Application.Models.Identity;

public class AuthResponse
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}