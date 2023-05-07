using BlogApp.Application.Features.Common;
using BlogApp.Domain;

namespace BlogApp.Application.Features.Blogs.DTOs
{
    public class UpdateBlogDTO: BaseDto, IThumbnailUrlDTO
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? ThumbnailImageUrl { get; set; }
    }
}