using Microsoft.AspNetCore.Identity;

namespace CineFlex.Domain
{
    public class AppUser: IdentityUser
    {
        public string FullName { get; set; }
    }
}