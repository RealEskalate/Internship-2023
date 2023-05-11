using BlogApp.Application.Responses;
using MediatR;


namespace BlogApp.Application.Features.Reviews.CQRS.Commands
{
    public class DeleteReviewCommand : IRequest<Result<Unit>>
    {
        public int Id { get; set; }
    }
}
