using BlogApp.Domain.Common;

namespace BlogApp.Domain.Models.Identity
{
    public class User
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public IList<string> Roles { get; set; }
    }
}