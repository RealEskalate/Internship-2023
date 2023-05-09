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
public class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, BaseResponse<Nullable<int>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRatingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<BaseResponse<Nullable<int>>> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
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

        var rating = _mapper.Map<Rating>(request.RatingDto);
        rating.BlogId = request.BlogId;
        /* rating.raterId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
         *      q => q.Type == CustomClaimTypes.Uid)?.Value;
        **/

        await _unitOfWork.RatingRepository.Add(rating);
        var databaseResponse = await _unitOfWork.Save();
        if (databaseResponse == 0)
        {
            response = new BaseResponse<Nullable<int>>()
            {
                Success = false,
                Message = "ServerErrorException",
            };
            return response;
        }

        var ratings = _unitOfWork.RatingRepository.GetByBlog(rating.BlogId);
        response = new BaseResponse<Nullable<int>>()
        {
            Data = CalculateRating(ratings),
            Success = true,
            Message = "CreateRatingSuccess"
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
