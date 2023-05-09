using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Indices.DTOs.Validators;
using BlogApp.Application.Features.Review.CQRS.Command;
using BlogApp.Application.Features.Review.DTOs;
using BlogApp.Application.Features.Review.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Handlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateReviewValidator();
            var validationResult = await validator.ValidateAsync(request.reviewDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
             else
                {
                var review = _mapper.Map<_Review>(request.reviewDto);
                review = await _unitOfWork.ReviewRepository.Add(review);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = review.Id;

                // here I will send the email to requist review.ReviewId

            }
            return response;
        }
    }
}