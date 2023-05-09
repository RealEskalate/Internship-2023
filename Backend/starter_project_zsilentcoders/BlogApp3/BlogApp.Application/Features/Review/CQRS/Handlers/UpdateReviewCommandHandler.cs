using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Review.CQRS.Commands;
using BlogApp.Application.Features.Review.DTOs;
using BlogApp.Application.Features.Review.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Handlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Result<ReviewDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ReviewDto>> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
<<<<<<< HEAD
            var response = new Result<ReviewDto>();
            
            if (request.reviewIsApprovedDto != null)
            {
                var validator = new UpdateIsResolvedValidator();
                var validationResult = await validator.ValidateAsync(request.reviewIsApprovedDto);

                if (validationResult.IsValid == true)
                {
                    var review = await _unitOfWork.ReviewRepository.Get(request.reviewIsApprovedDto.Id);
                    if (review is null)
                    {
                        response.Success = false;
                        response.Message = "Updation Failed";
                        response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                        return response;
                    }
                    await _unitOfWork.ReviewRepository.ChangeApprovalStatus(review, request.reviewIsApprovedDto.IsApproved);
                    if (await _unitOfWork.Save() > 0)
                    {
                        response.Message = "Updation Successful!";
                        response.Value = _mapper.Map<ReviewDto>(review);
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Updation Failed";
                        response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Updation Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                }

                
            }
            else if (request.reviewDto != null)
            {
                var validator = new UpdateReviewValidator();
                var validationResult = await validator.ValidateAsync(request.reviewDto);
               

                if (validationResult.IsValid == true) { 
                    var review = await _unitOfWork.ReviewRepository.Get(request.reviewDto.Id);
                    if (review is null)
                    {
                        response.Success = false;
                        response.Message = "Updation Failed";
                        response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                        return response;
                    }
                    _mapper.Map(request.reviewDto, review);
                    await _unitOfWork.ReviewRepository.Update(review);
                    if (await _unitOfWork.Save() > 0)
                    {
                        response.Message = "Updation Successful!";
                        response.Value = _mapper.Map<ReviewDto>(review);
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Updation Failed";
                        response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Updation Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                }

                
            }
            return response;
            
=======

            var review = await _unitOfWork.ReviewRepository.Get(request.Id);
            if (review is null)
                throw new NotFoundException(nameof(review), request.reviewDto.Id);

            if (request.reviewIsApprovedDto != null) {
                await _unitOfWork.ReviewRepository.ChangeApprovalStatus(review, request.reviewIsApprovedDto.IsApproved);
            }
            else if (request.reviewDto != null)
            {
                _mapper.Map(request.reviewDto, review);
                await _unitOfWork.ReviewRepository.Update(review);
                await _unitOfWork.Save();
                
            }
            return Unit.Value;
>>>>>>> 4c24891 (fix(Samuel.Review): resolve conflict 2)
        }
    }
}