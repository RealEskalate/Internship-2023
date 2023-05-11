using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Queries;

public class GetBlogReviewListQuery : IRequest<BaseResponse<List<ReviewDto>>>
{
    public int BlogId { get; set; }
}