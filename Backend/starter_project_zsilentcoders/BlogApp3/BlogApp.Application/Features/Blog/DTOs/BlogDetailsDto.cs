using BlogApp.Application.Features.Blog.DTOs;
namespace BlogApp.Application.Features.Blog.DTOs;

public class BlogDetailsDto
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string? ThumbnailImage { get; set; }

}