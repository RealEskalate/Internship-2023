using Microsoft.AspNetCore.Identity;

namespace CineFlex.Identity.Models;

public class CineFlexUser : IdentityUser
{
    public string FullName { get; set; }
}
