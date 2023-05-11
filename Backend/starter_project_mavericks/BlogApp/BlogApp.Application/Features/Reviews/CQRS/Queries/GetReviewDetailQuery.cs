using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Queries;

public class GetReviewDetailQuery : IRequest<BaseResponse<ReviewDto>>
{
    public int Id { get; set; }
}