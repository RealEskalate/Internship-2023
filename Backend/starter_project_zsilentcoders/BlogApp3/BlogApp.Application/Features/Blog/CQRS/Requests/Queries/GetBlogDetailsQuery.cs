using MediatR;
using BlogApp.Application.Features.Blog.DTOs;

namespace BlogApp.Application.Features.Blog.CQRS.Requests.Queries;

public class GetBlogDetailsQuery: IRequest<BlogDetailsDto?>
{
    public int Id { get; set; }
}