

using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Blogs.CQRS.Queries
{
    public class GetBlogQuery: IRequest<BaseResponse<BlogDTO>>
    {
        public int Id { get; set; }
    }
}