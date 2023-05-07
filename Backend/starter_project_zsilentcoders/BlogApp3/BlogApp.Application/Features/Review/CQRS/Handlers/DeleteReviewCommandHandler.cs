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
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Handlers
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteReviewValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.Id);

            if (validationResult.IsValid == false) {
                throw new NotFoundException(nameof(_Review), request.Id);
            }
            else {
                var review = await _unitOfWork.ReviewRepository.Get(request.Id);

                if (review == null)
                    throw new NotFoundException(nameof(review), request.Id);

                await _unitOfWork.ReviewRepository.Delete(review);
                await _unitOfWork.Save();

                return Unit.Value;
            }
        }
    }
}