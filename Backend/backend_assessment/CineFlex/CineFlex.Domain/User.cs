using Microsoft.AspNetCore.Identity;

namespace CineFlex.Domain
{
    public class User : IdentityUser
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
