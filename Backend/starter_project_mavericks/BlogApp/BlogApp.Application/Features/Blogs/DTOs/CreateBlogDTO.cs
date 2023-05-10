
using BlogApp.Application.Features._Tags.DTOs;
using BlogApp.Application.Features.Common;

namespace BlogApp.Application.Features.Blogs.DTOs
{
    public class CreateBlogDTO: IThumbnailUrlDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        
        public string? ThumbnailImageUrl { get; set; }

        public static implicit operator CreateBlogDTO(Create_TagDto v)
        {
            throw new NotImplementedException();
        }
    }
}