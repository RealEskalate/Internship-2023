using BlogApp.Domain;
using Microsoft.AspNetCore.Http;

namespace BlogApp.Application.Features.Blogs.DTOs
{
    public interface IBlogDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool? PublicationStatus { get; set; }  
    }
}