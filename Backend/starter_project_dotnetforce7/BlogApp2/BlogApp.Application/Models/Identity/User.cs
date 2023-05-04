using BlogApp.Domain.Common;

namespace BlogApp.Domain.Models.Identity
{
    public enum UserRole
    {
        ADMIN,
        USER
    }
    public class User
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
