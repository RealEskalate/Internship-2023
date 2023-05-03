using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Ratings.CQRS.Commands;
using BlogApp.Application.Features.Ratings.DTOs.Validators;
using BlogApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Ratings.CQRS.Handlers;
public class Update_RatingCommandHandler : IRequestHandler<Update_RatingCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public Update_RatingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(Update_RatingCommand request, CancellationToken cancellationToken)
    {
        var validator = new RatingDtoValidator();
        var validationResult = await validator.ValidateAsync(request.RatingDto);

        if (validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult);
        }
        else
        {
            var updatedRating = _mapper.Map<Rating>(request.RatingDto);
            updatedRating.BlogId = request.BlogId;
            /*
             * updatedRating.RaterId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(
             *      q => q.Type == CustomClaimTypes.Uid)?.Value;
            **/
            var existingRating = _unitOfWork.RatingRepository.FindByBlogAndRater(request.BlogId, updatedRating.RaterId);
            if(existingRating == null)
            {
                throw new RatingNotFoundException(nameof(Rating), request.BlogId);
            }
            await _unitOfWork.RatingRepository.Update(updatedRating);
            await _unitOfWork.Save();
        }
        return Unit.Value;
    }
}
