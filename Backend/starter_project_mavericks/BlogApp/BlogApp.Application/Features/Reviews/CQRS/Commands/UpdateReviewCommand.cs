using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Commands;

public class UpdateReviewCommand : IRequest<BaseResponse<Unit>>
{
    public UpdateReviewDto UpdateReviewDto { get; set; }
}