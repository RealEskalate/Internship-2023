using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Application.Features.Review.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Queries
{
    public class GetReviewDetailQuery: IRequest<Result<ReviewDto>>
    {
        public int Id { get; set; }
        public int ReviewerId { get; set; }
    }
}