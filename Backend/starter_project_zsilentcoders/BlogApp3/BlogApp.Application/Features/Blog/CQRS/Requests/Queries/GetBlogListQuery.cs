using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Blog.CQRS.Requests.Queries;

public class GetBlogListQuery : IRequest<Result<List<BlogListDto>>>
{
}