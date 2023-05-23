using Microsoft.AspNetCore.Identity;

namespace CineFlex.Domain
{
    public class User : IdentityUser  
    {
        public string FullName { get; set; }

        public Seat? Seat { get; set; }

        
    }
}