using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Application.Features.Review.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Command
{
    public class CreateReviewCommand: IRequest<Result<ReviewDto?>>
    {
        public ReviewDto reviewDto { get; set; }
    }
}