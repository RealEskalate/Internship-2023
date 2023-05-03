using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Indices.CQRS.Commands;
using BlogApp.Application.Features._Indices.DTOs.Validators;
using BlogApp.Application.Features.Rates.CQRS.Commands;
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
public class Create_RatingCommandHandler : IRequestHandler<Create_RatingCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Create_RatingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<int> Handle(Create_RatingCommand request, CancellationToken cancellationToken)
    {
        var validator = new RatingDtoValidator();
        var validationResult = await validator.ValidateAsync(request.RatingDto);

        if (validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult);
        }
        else
        {
            var rating = _mapper.Map<Rating>(request.RatingDto);
            rating.BlogId = request.BlogId;
            /* rating.raterId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
             *      q => q.Type == CustomClaimTypes.Uid)?.Value;
            **/
            rating = await _unitOfWork.RatingRepository.Add(rating);
            await _unitOfWork.Save();
        }
        int response = 0;
        var ratings = _unitOfWork.RatingRepository.GetByBlog(request.BlogId);
        foreach (var rating in ratings)
        {
            response += rating.Rate;
        }
        if (response != 0) response /= ratings.Count;
        return response;
    }
}
