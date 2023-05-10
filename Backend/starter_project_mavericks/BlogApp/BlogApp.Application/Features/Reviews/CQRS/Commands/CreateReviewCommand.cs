using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Commands;

public class CreateReviewCommand : IRequest<BaseResponse<int?>>
{
    public CreateReviewDto CreateReviewDto { get; set; }
    
}