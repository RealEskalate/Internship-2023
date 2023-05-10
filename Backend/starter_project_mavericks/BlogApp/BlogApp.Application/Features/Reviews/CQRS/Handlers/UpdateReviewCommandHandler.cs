using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Indices.DTOs.Validators;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Features.Reviews.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers;

public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, BaseResponse<Unit>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReviewCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<BaseResponse<Unit>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateReviewValidator();
        var validationResult = await validator.ValidateAsync(request.UpdateReviewDto);
        if (validationResult.IsValid == false)
        {
            return new BaseResponse<Unit>()
            {
                Success = false,
                Message =nameof(ValidationException),
                Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
            };
        }
        var review = await _unitOfWork.ReviewRepository.GetReviewDetail(request.UpdateReviewDto.Id);
        
        if (review == null){
            var error = new NotFoundException(nameof(review),request.UpdateReviewDto.Id);
            return new BaseResponse<Unit>()
            {
                Success = false,
                Message = "update failed",
                Errors = new List<string>()
                {
                    $"{error}"
                }
            };}

        _mapper.Map(request.UpdateReviewDto, review);

        await _unitOfWork.ReviewRepository.Update(review);

        if (await _unitOfWork.Save()==0){
            return new BaseResponse<Unit>(){
                Success= false,
                Message = "data base update failed",

            };
        }
        return new BaseResponse<Unit>()
        {
            Success = true,
            Message = "update succeed",

        };

    }
}