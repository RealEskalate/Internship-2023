using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features.Review.CQRS.Queries;
using BlogApp.Application.Features.Review.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Handlers
{
    public class GetReviewListQueryHandler : IRequestHandler<GetReviewListQuery, Result<List<ReviewDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReviewListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<ReviewDto>>> Handle(GetReviewListQuery request, CancellationToken cancellationToken)
        {
            var review = await _unitOfWork.ReviewRepository.GetAllByReviewerId(request.ReviewerId);
            var response = new Result<List<ReviewDto>>();
            if (review == null || review.Count == 0)
            {
                response.Success = false;
                response.Message = "Creation Failed";
            }
            else
            {
                response.Success = true;
                response.Message = "Creation Successful";
                response.Value = _mapper.Map<List<ReviewDto>>(review);
            }
            return response;
        }
    }
}