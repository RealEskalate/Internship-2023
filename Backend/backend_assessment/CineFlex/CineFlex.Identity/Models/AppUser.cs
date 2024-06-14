using Microsoft.AspNetCore.Identity;

namespace CineFlex.Identity.Models;

public class AppUser: IdentityUser
{
    public string FullName { get; set; } = null!;
}