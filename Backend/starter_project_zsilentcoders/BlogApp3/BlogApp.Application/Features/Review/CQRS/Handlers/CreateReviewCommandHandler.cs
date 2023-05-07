using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Review.CQRS.Command;
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

            var review = _mapper.Map<_Review>(request.reviewDto);

            review = await _unitOfWork.ReviewRepository.Add(review);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = review.Id;

            return response;
        }
    }
}