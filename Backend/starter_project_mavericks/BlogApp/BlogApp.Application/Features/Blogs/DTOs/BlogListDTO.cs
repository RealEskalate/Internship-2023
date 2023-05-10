using BlogApp.Application.Features.Common;
using BlogApp.Domain;

namespace BlogApp.Application.Features.Blogs.DTOs
{
    public class BlogListDTO: BaseDto
    {
        public string Title { get; set; }
        public string ThumbnailImageUrl { get; set; }
        public int Rating { get; set; }
    }
}