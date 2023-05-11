using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Reviews.CQRS.Queries
{
    public class GetReviewDetailQuery : IRequest<Result<ReviewDto>>
    {
        public int Id { get; set; }
    }
}
