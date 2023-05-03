using BlogApp.Domain.Common;

namespace BlogApp.Domain.Models.Identity
{
    public enum UserRole
    {
        ADMIN,
        USER
    }
    public class User : BaseDomainEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
