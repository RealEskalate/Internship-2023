namespace CineFlex.Application.Models.Identity;

public class User
{
    public int Id { get; set; }
    public string AppUserId { get; set; }
    public string Username { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public IList<string> Roles { get; set; }
}