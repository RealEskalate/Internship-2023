using BlogApp.Domain.Common;
namespace BlogApp.Domain;

public class Comment : BaseDomainEntity
{
    public int CommenterId { get; set; }
    public string Content { get; set; }
    public int BlogId { get; set; }
}

