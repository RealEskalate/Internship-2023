using BlogApp.Application.Features.Common;

namespace BlogApp.Application.Features.Comments.DTOs
{
    public class UpdateCommentDto : BaseDto , ICommentDto
    {

        public string Content { get; set; }
        
    }
}