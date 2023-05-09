using MediatR;
using BlogApp.Application.Responses;
using BlogApp.Application.Features.Blogs.DTOs;

namespace BlogApp.Application.Features.Blogs.CQRS.Commands
{
    public class CreateBlogCommand: IRequest<BaseResponse<Nullable<int>>>
    {
        public CreateBlogDTO CreateBlogDTO { get; set; }
    
    }
}