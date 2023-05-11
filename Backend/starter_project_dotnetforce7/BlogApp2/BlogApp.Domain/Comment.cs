using BlogApp.Domain.Common;

namespace BlogApp.Domain
{
    public class Comment : BaseDomainEntity
    {
        
        public string Content { get; set; }

        public int UserId { get; set; }

        public int BlogId { get; set; }

    }
}