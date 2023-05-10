using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Queries;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers;

public class GetReviewDetailQueryHandler : IRequestHandler<GetReviewDetailQuery,BaseResponse<ReviewDto>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetReviewDetailQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<ReviewDto>> Handle(GetReviewDetailQuery request, CancellationToken cancellationToken)
    {
        var review = await _unitOfWork.ReviewRepository.GetReviewDetail(request.Id);
        return review == null
            ? new BaseResponse<ReviewDto>()
            {
                Success = true,
                Message = "review not found",
                Errors = new List<string>()
                {
                    $"review with id {request.Id} not found"
                }
            }
            : new BaseResponse<ReviewDto>()
            {
                Data = _mapper.Map<ReviewDto>(review),
                Success = true,
                Message = "review successfully retrieved"
            };
    }

}