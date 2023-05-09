namespace BlogApp.Application.Features.Blogs.DTOs
{
    public interface IBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string? CoverImage { get; set; }
        public bool? PublicationStatus { get; set; }  
    }
}