using Microsoft.AspNetCore.Identity;

namespace BlogApp.Identity.Models;
public class ApplicationUser : IdentityUser
{
    public int Id {get; set;}
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Username { get; set; }
}