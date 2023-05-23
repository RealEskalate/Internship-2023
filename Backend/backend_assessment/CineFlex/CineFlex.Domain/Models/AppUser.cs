
using Microsoft.AspNetCore.Identity;


namespace CineFlex.Domain.Models{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set;}
    }
}