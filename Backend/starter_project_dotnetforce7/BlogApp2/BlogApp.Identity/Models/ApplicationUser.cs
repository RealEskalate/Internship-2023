using Microsoft.AspNetCore.Identity;

namespace BlogApp.Identity.Models;
public class ApplicationUser : IdentityUser
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public int blogUserId {get; set;}
}