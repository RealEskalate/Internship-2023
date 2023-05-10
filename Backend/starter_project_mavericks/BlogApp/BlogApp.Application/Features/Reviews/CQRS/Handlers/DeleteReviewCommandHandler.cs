using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand,BaseResponse<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<Unit>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _unitOfWork.ReviewRepository.GetReviewDetail(request.Id);
        if (review == null)
            return new BaseResponse<Unit>()
            {
                Success = false,
                Message = "deletion failed",
                Errors = new List<string>()
                {
                    $"review with id {request.Id} not found"
                }
            };
        await _unitOfWork.ReviewRepository.Delete(review);
        await _unitOfWork.Save();
        return new BaseResponse<Unit>()
        {
            Success = true,
            Message = "Deletion succeed"
        };
    }
}