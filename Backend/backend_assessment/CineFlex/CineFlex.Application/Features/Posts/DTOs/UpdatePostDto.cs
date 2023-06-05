using CineFlex.Application.Features.Common;

namespace CineFlex.Application.Features.Posts.DTOs
{
    public class UpdatePostDto : BaseDto , IPostDto
    {
        public string Title { get; set; }
		public string Content { get; set; } 
		public int UserId { get; set; } 
        
    }
}