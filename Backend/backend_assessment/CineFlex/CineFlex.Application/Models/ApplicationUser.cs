using Microsoft.AspNetCore.Identity;

namespace CineFlex.Application.Models;
public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }

    public string GivenRole { get; set; }
    // Any additional properties you want to include
}
