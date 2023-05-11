using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Queries;

public class GetUserReviewListQuery : IRequest<BaseResponse<List<ReviewDto>>>
{
    public string ReviewerId { get; set; }
}