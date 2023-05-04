namespace BlogApp.Application.Features.Blog.DTOs;

public class CreateBlogDto
{
    public string Title { get; set; }
    public string? ThumbnailImage { get; set; }
    public string Content { get; set; }
    public bool Publish { get; set; }   
}