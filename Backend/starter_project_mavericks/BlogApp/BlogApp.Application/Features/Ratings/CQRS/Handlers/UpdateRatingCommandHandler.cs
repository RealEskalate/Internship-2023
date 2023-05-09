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
public class UpdateRatingCommandHandler : IRequestHandler<UpdateRatingCommand, BaseResponse<Nullable<int>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateRatingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<Nullable<int>>> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
    {
        var validator = new RatingDtoValidator();
        var validationResult = await validator.ValidateAsync(request.RatingDto);
        BaseResponse<Nullable<int>> response;
        if (validationResult.IsValid == false)
        {
            response = new BaseResponse<Nullable<int>>()
            {
                Success = false,
                Message = nameof(ValidationException),
                Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
            };
            return response;
        }

        var updatedRating = _mapper.Map<Rating>(request.RatingDto);
        updatedRating.BlogId = request.BlogId;
        updatedRating.RaterId = 0;
        /* updatedRating.RaterId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
         *      q => q.Type == CustomClaimTypes.Uid)?.Value;
        **/
        var existingRating = await _unitOfWork.RatingRepository.GetByBlogAndRater(updatedRating.BlogId, updatedRating.RaterId);
        if(existingRating == null)
        {
            var ex = new NotFoundException(nameof(Rating), $"for {updatedRating.BlogId} by {updatedRating.RaterId}");
            response = new BaseResponse<Nullable<int>>()
            {
                Success = false,
                Message = nameof(NotFoundException),
                Errors = new List<string> { ex.Message }
            };
            return response;
        }
        updatedRating.Id = existingRating.Id;
        await _unitOfWork.RatingRepository.Update(updatedRating);
        var databaseResponse = await _unitOfWork.Save();
        if(databaseResponse == 0)
        {
            response = new BaseResponse<Nullable<int>>()
            {
                Success = false,
                Message = "ServerErrorException",
            };
            return response;
        }
        
        var ratings = _unitOfWork.RatingRepository.GetByBlog(existingRating.BlogId);
        response = new BaseResponse<Nullable<int>>()
        {
            Data = CreateRatingCommandHandler.CalculateRating(ratings),
            Success = true,
            Message = "UpdateRatingSuccess"
        };

        return response;
    }
}
