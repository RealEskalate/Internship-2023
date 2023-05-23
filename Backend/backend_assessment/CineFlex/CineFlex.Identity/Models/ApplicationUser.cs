using Microsoft.AspNetCore.Identity;
namespace CineFlex.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int cineUserId { get; set; }
}