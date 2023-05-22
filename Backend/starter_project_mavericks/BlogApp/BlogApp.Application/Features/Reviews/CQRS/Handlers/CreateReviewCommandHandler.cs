using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
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
                Success = false,
                Message = nameof(ValidationException),
                Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
            };
        Review review = _mapper.Map<Review>(request.CreateReviewDto);
        review = await _unitOfWork.ReviewRepository.Add(review);
        
        if ( await _unitOfWork.Save()==0 ){
            return new BaseResponse<int?>(){
                Success=false,
                Message = "creation failed "
            };
        }

        return new BaseResponse<int?>()
        {
            Data = review.Id,
            Success = true,
            Message = "successfully created",

        };
    }
}