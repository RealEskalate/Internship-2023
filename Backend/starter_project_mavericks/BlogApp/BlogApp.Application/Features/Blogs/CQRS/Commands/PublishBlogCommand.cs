using System;
using MediatR;
using BlogApp.Application.Responses;

namespace BlogApp.Application.Features.Blogs.CQRS.Commands
{
    public class PublishBlogCommand: IRequest<BaseResponse<Unit>>
    {
        public int Id { get; set; }
    
    }
}