using BlogApp.Application.Responses;

using BlogApp.Application.Features.Blog.DTOs;
using MediatR;

namespace BlogApp.Application.Features.Blog.CQRS.Requests.Commands;

public class CreateBlogCommand: IRequest<BaseCommandResponse>
{
    public CreateBlogDto CreateBlogDto { get; set; }
}