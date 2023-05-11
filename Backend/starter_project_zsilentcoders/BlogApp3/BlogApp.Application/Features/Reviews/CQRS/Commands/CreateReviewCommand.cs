using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Command
{
    public class CreateReviewCommand: IRequest<Result<ReviewDto?>>
    {
        public ReviewDto reviewDto { get; set; }
    }
}