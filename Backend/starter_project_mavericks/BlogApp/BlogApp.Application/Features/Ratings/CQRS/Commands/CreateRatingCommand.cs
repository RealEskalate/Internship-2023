using BlogApp.Application.Features.Ratings.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Application.Features.Ratings.CQRS.Commands;
public class CreateRatingCommand : IRequest<BaseResponse<Nullable<int>>>
{
    public int BlogId { get; set; }
    public RatingDto RatingDto { get; set; }
}
