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
<<<<<<< HEAD
        public int Id { get; set; }
=======
        public int Id  { get; set; }
        public int ReviewerId { get; set; }
>>>>>>> 4c24891 (fix(Samuel.Review): resolve conflict 2)
    }
}