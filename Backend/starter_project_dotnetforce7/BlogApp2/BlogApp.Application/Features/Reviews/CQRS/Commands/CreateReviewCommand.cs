using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Commands
{
    public class CreateReviewCommand: IRequest<Result<int>>
    {
        public CreateReviewDto ReviewDto { get; set; }
    }
}
