using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Features.Reviews.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand,BaseResponse<int?>>

{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReviewCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<int?>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateReviewDtoValidator();
        var validationResult = await validator.ValidateAsync(request.CreateReviewDto);
        if (validationResult.IsValid == false)
            return new BaseResponse<int?>()
            {
                Data = null,
                Success = false,
                Message = "Creation failed",
                Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
            };
        var review = _mapper.Map<Review>(request.CreateReviewDto);
        review = await _unitOfWork.ReviewRepository.Add(review);
        await _unitOfWork.Save();
        return new BaseResponse<int?>()
        {
            Data = review.Id,
            Success = true,
            Message = "successfully created",

        };
    }
}