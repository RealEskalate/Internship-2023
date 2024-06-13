namespace CineFlex.Application.Features.Posts.DTOs
{
    public class CreatePostDto : IPostDto
    {
        public string Title { get; set; }
		public string Content { get; set; } 
		public int UserId { get; set; } 
    }
}
