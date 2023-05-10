﻿using AutoMapper;
using BlogApp.Application.Contracts.Persistence;
using BlogApp.Application.Features.Reviews.CQRS.Queries;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Handlers;

public class GetBlogReviewListQueryHandler : IRequestHandler<GetBlogReviewListQuery,BaseResponse<List<ReviewDto>>>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetBlogReviewListQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseResponse<List<ReviewDto>>> Handle(GetBlogReviewListQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _unitOfWork.ReviewRepository.GetReviewsByBlogId(request.BlogId);
        return reviews == null || !reviews.Any()?
            new BaseResponse<List<ReviewDto>>()
            {
                Success = false,
                Message = "Blog reviews not found",
                Errors = new List<string>()
                {
                    $"blog with id {request.BlogId} not found ",
                    $"blog with id {request.BlogId} has no reviews"
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