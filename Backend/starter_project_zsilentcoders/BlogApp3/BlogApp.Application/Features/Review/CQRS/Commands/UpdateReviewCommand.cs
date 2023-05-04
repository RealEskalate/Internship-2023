using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Application.Features.Review.DTOs;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Commands
{
    public class UpdateReviewCommand: IRequest
    {
        public ReviewDto reviewDto { get; set; }
    }
}