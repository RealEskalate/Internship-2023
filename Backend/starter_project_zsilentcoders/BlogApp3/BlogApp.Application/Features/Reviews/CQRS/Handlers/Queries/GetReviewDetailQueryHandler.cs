using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Exceptions;
using BlogApp.Application.Features._Indices.CQRS.Queries;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Reviews.CQRS.Queries;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers.Queries
{
    public class GetReviewDetailQueryHandler : IRequestHandler<GetReviewDetailQuery, Result<ReviewDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetReviewDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<ReviewDto>> Handle(GetReviewDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new Result<ReviewDto>();
            var review = await _unitOfWork.ReviewRepository.Get(request.Id);
            if (review is null)
            {
                response.Success = false;
                response.Message = "Failed";
            }
            else
            {
                response.Success = true;
                response.Message = "Creation Successful";
                response.Value = _mapper.Map<ReviewDto>(review);
            }
            return response;
        }
    }
}