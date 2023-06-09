using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Indices.DTOs.Validators;
using BlogApp.Application.Features.Reviews.CQRS.Command;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Features.Reviews.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers.Commands
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Result<ReviewDto?>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ReviewDto?>> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<ReviewDto?>();

            var validator = new CreateReviewValidator();
            var validationResult = await validator.ValidateAsync(request.reviewDto);

            if (validationResult.IsValid == true)
            {
                var review = _mapper.Map<Review>(request.reviewDto);
                review = await _unitOfWork.ReviewRepository.Add(review);

                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = _mapper.Map<ReviewDto>(review);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            return response;
        }
    }
}