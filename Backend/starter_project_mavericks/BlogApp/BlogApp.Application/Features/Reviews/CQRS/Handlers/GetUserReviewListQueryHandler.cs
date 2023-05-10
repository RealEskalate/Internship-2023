﻿using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Queries;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers;

public class GetUserReviewListQueryHandler : IRequestHandler<GetUserReviewListQuery,BaseResponse<List<ReviewDto>>>
{
    public readonly IUnitOfWork _unitOfWork;
    public readonly IMapper _mapper;

    public GetUserReviewListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<List<ReviewDto>>> Handle(GetUserReviewListQuery request,
        CancellationToken cancellationToken)
    {
        var reviews =await _unitOfWork.ReviewRepository.GetReviewsByUserId(request.ReviewerId);
        return reviews == null || !reviews.Any()
            ? new BaseResponse<List<ReviewDto>>()
            {
                Success = false,
                Message = "User has no reviews",
                Errors = new List<string>()
                {
                    $"User with id {request.ReviewerId} not found",
                    $"User with id {request.ReviewerId} has no reviews"
                }

            }
            : new BaseResponse<List<ReviewDto>>()
            {
                Data = _mapper.Map<List<ReviewDto>>(reviews),
                Success = true,
                Message = "User reviews retrieved successfully"
            };
    }

}