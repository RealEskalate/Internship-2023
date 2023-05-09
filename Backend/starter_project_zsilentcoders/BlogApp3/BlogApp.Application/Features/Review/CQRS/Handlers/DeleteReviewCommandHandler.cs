using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Indices.CQRS.Commands;
using BlogApp.Application.Features.Review.CQRS.Commands;
using BlogApp.Application.Features.Review.DTOs.Validators;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Handlers
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Result<Unit>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();
            var validator = new DeleteReviewValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.Id);

            if (validationResult.IsValid == true) {
                var review = await _unitOfWork.ReviewRepository.Get(request.Id);

                if (review == null)
                    throw new NotFoundException(nameof(review), request.Id);

                await _unitOfWork.ReviewRepository.Delete(review);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Message = "Deletion Successful!";
                    response.Value = new Unit();
                }
                else
                {
                    response.Success = false;
                    response.Message = "Deletion Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                }


            }
            else {
                response.Success = false;
                response.Message = "Deletion Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            return response;
        }
    }
}