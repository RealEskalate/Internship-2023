using BlogApp.Application.Features.Common;

namespace BlogApp.Application.Features.Comments.DTOs
{
    public class CommentDto : BaseDto, ICommentDto
    {
        public string Content { get; set; }

        public int UserId { get; set; }

        public int BlogId { get; set; }
    }
}