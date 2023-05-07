using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Application.Features.Review.DTOs;
using MediatR;

namespace BlogApp.Application.Features.Review.CQRS.Queries
{
    public class GetReviewListQuery: IRequest<List<ReviewDto>>
    {
        
    }
}