using BlogApp.Application.Features.Blog.DTOs;
using MediatR;

namespace BlogApp.Application.Features.Blog.CQRS.Requests.Commands;

public class DeleteBlogCommand: IRequest<Unit>
{
    public DeleteBlogDto DeleteBlogDto;
}