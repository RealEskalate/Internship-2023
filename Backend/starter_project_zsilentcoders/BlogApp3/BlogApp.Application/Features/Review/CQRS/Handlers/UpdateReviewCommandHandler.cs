using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Indices.CQRS.Commands;
using BlogApp.Application.Features._Indices.DTOs.Validators;
using BlogApp.Application.Features.Review.CQRS.Commands;
using BlogApp.Application.Features.Review.DTOs.Validators;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Handlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateReviewValidator();
            var validationResult = await validator.ValidateAsync(request.reviewDto);

            if (validationResult.IsValid == false) {
                throw new ValidationException(validationResult);
            }
            else
            {
                var review = await _unitOfWork.ReviewRepository.Get(request.reviewDto.Id);
                if (review is null)
                    throw new NotFoundException(nameof(review), request.reviewDto.Id);

                if (request.reviewIsApprovedDto != null)
                {
                    await _unitOfWork.ReviewRepository.ChangeApprovalStatus(review, request.reviewIsApprovedDto.IsApproved);
                }
                else if (request.reviewDto != null)
                {
                    _mapper.Map(request.reviewDto, review);
                    await _unitOfWork.ReviewRepository.Update(review);
                    await _unitOfWork.Save();

                }
                return Unit.Value;
            }
            
        }
    }
}