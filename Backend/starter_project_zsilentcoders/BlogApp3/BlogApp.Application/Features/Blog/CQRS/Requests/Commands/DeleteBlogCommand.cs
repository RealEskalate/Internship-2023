using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Blog.CQRS.Requests.Commands;

public class DeleteBlogCommand: IRequest<Result<Unit>>
{
    public DeleteBlogDto DeleteBlogDto;
}