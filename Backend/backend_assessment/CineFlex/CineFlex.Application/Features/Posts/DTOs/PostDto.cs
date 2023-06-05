using CineFlex.Application.Features.Common;
using CineFlex.Domain;

namespace CineFlex.Application.Features.Posts.DTOs
{
    public class PostDto : BaseDto
    {
        public string Title { get; set; }
		public string Content { get; set; } 
		public int UserId { get; set; } 
    }
}