namespace CineFlex.Application.Features.Posts.DTOs
{
    public interface IPostDto
	{
        public string Title { get; set; }
		public string Content { get; set; } 
		public int UserId { get; set; } 
	}
}