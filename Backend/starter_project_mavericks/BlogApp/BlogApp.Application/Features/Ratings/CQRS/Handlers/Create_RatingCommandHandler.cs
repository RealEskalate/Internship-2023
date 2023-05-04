using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Indices.CQRS.Commands;
using BlogApp.Application.Features._Indices.DTOs.Validators;
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
public class Create_RatingCommandHandler : IRequestHandler<Create_RatingCommand, BaseResponse<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Create_RatingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseResponse<int>> Handle(Create_RatingCommand request, CancellationToken cancellationToken)
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
            var rating = _mapper.Map<Rating>(request.RatingDto);
            rating.BlogId = request.BlogId;
            /* rating.raterId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
             *      q => q.Type == CustomClaimTypes.Uid)?.Value;
            **/

            await _unitOfWork.RatingRepository.Add(rating);
            await _unitOfWork.Save();
        }
        var ratings = _unitOfWork.RatingRepository.GetByBlog(request.BlogId);
        response = new BaseResponse<int>()
        {
            Data = CalculateRating(ratings),
            Success = false,
            Message = nameof(ValidationException),
            Errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList()
        };
        
        return response;
    }

    public static int CalculateRating(IReadOnlyList<Rating> ratings)
    {
        int commulativeRating = 0;
        foreach (var rating in ratings)
        {
            commulativeRating += rating.Rate;
        }
        if (commulativeRating != 0) commulativeRating /= ratings.Count;
        return commulativeRating;
    }
}
