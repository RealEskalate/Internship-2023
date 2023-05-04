using MediatR;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Responses;

namespace BlogApp.Application.Features.Blog.CQRS.Requests.Queries;

public class GetBlogDetailsQuery: IRequest<Result<BlogDetailsDto?>>
{
    public int Id { get; set; }
}