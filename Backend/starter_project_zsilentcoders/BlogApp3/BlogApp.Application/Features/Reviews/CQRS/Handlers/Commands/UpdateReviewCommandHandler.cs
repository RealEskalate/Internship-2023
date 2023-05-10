using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Blog.DTOs;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Features.Reviews.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers.Commands
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
            var response = new Result<ReviewDto>();

            if (request.reviewIsApprovedDto != null)
            {
                var validator = new UpdateIsResolvedValidator(_unitOfWork);
                var validationResult = await validator.ValidateAsync(request.reviewIsApprovedDto);

                if (validationResult.IsValid == true)
                {
                    var review = await _unitOfWork.ReviewRepository.Get(request.reviewIsApprovedDto.Id);
                    await _unitOfWork.ReviewRepository.ChangeApprovalStatus(review, request.reviewIsApprovedDto.IsApproved);
                    if (await _unitOfWork.Save() > 0)
                    {
                        response.Success = true;
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
            else
            {
                var validator = new UpdateReviewValidator(_unitOfWork);
                var validationResult = await validator.ValidateAsync(request.reviewDto);


                if (validationResult.IsValid == true)
                {
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
                        response.Success = true;
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

        }
    }
}