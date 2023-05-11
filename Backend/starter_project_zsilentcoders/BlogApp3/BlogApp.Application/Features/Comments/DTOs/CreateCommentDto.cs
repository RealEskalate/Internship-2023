using BlogApp.Application.Features.Common;
using  BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Common;
namespace BlogApp.Application.Features.Comments.DTOs;

public class CreateCommentDto : ICommentDto
{
    public int CommenterId { get; set; }
    public string Content { get; set; }
    public int BlogId { get; set; }
}
