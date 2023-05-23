using Microsoft.AspNetCore.Identity;
namespace CineFlex.Domain
{
    public class AppUser : IdentityUser
    {
        public AppRole Role{ get; set; }
    }
    public enum AppRole
    {
        User,
        Admin
    }
}