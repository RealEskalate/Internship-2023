using Microsoft.AspNetCore.Http;

namespace BlogApp.Application.Features.Blogs.DTOs
{
    public class CreateBlogDto : IBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile? File { get; set; }
        public bool? PublicationStatus { get; set; }
    }
}
