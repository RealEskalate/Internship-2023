﻿using BlogApp.Application.Features.Common;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Queries;

public class GetUserReviewListQuery : IRequest<BaseResponse<List<ReviewDto>>>
{
    public int ReviewerId { get; set; }
}