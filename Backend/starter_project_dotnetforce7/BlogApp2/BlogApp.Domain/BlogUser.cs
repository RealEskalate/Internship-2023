using BlogApp.Domain.Common;

namespace BlogApp.Domain
{
    public class BlogUser : BaseDomainEntity
    {
        public string AppUserId {get; set;}
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        // public ICollection<Blog> Blogs {get; set;}

    }
}