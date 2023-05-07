using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Blogs.CQRS.Queries
{
    public class GetBlogListQuery: IRequest<BaseResponse<IList<BlogListDTO>>>
    {
        public bool published { get; set; }
    }
}