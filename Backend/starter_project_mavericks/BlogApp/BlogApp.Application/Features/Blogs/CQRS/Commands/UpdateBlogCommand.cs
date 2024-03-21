using MediatR;
using BlogApp.Application.Responses;
using BlogApp.Application.Features.Blogs.DTOs;

namespace BlogApp.Application.Features.Blogs.CQRS.Commands
{
    public class UpdateBlogCommand: IRequest<BaseResponse<Unit>>
    {
        public UpdateBlogDTO UpdateBlogDTO { get; set; }
    
    }
}