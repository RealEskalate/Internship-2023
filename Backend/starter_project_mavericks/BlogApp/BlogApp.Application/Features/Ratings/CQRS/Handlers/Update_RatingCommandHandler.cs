using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Ratings.CQRS.Commands;
using BlogApp.Application.Features.Ratings.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Ratings.CQRS.Handlers;
public class Update_RatingCommandHandler : IRequestHandler<Update_RatingCommand, BaseResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Update_RatingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<int>> Handle(Update_RatingCommand request, CancellationToken cancellationToken)
    {
        var validator = new RatingDtoValidator();
        var validationResult = await validator.ValidateAsync(request.RatingDto);
        BaseResponse<int> response;
        if (validationResult.IsValid == false)
        {
            response = new BaseResponse<int>()
            {
                Success = false,
                Message = nameof(ValidationException),
                Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
            };
            return response;
        }
        else
        {
            var updatedRating = _mapper.Map<Rating>(request.RatingDto);
            updatedRating.BlogId = request.BlogId;
            updatedRating.RaterId = 0;
            /* updatedRating.RaterId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
             *      q => q.Type == CustomClaimTypes.Uid)?.Value;
            **/
            var existingRating = await _unitOfWork.RatingRepository.GetByBlogAndRater(request.BlogId, updatedRating.RaterId);
            if(existingRating == null)
            {
                var ex = new NotFoundException(nameof(Rating), $"for {request.BlogId} by {updatedRating.RaterId}");
                response = new BaseResponse<int>()
                {
                    Success = false,
                    Message = nameof(NotFoundException),
                    Errors = new List<string> { ex.Message }
                };
                return response;
            }
            updatedRating.Id = existingRating.Id;
            await _unitOfWork.RatingRepository.Update(updatedRating);
            await _unitOfWork.Save();
        }
        var ratings = _unitOfWork.RatingRepository.GetByBlog(request.BlogId);
        response = new BaseResponse<int>()
        {
            Data = Create_RatingCommandHandler.CalculateRating(ratings),
            Success = false,
            Message = nameof(ValidationException),
            Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
        };

        return response;
    }
}
