using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;

namespace BlogApp.Application.Features.Reviews.CQRS.Commands
{
    public class UpdateReviewCommand: IRequest<Result<ReviewDto>>
    {
        public int Id { get; set; }
        public ReviewDto reviewDto { get; set; }
        public ReviewIsApprovedDto? reviewIsApprovedDto { get; set; }
    }
}