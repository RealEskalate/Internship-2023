using BlogApp.Application.Features.Common;

namespace BlogApp.Application.Features.Comments.DTOs;


public class CommentDto : BaseDto
{
    public int CommenterId { get; set; }
    public string Content { get; set; }
    public int BlogId { get; set; }
}
