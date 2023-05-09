using System;
using MediatR;
using BlogApp.Application.Responses;
using BlogApp.Application.Features.Blogs.DTOs;

namespace BlogApp.Application.Features.Blogs.CQRS.Commands
{
    public class DeleteBlogCommand: IRequest<BaseResponse<Unit>>
    {
        public int Id { get; set; }
    
    }
}