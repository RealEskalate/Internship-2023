using BlogApp.Application.Features.Ratings.CQRS.Commands;
using BlogApp.Application.Features.Ratings.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BlogApp.API.Controllers;
[Route("api/Blogs")]
[ApiController]
public class RatingsController : BaseApiController
{
    private readonly IMediator _mediator;
    public RatingsController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("{blogId}/Rate")]
    public async Task<ActionResult<BaseResponse<Nullable<int>>>> Post(int blogId, [FromBody] RatingDto ratingDto)
    {
        var command = new CreateRatingCommand { BlogId = blogId, RatingDto = ratingDto };
        var response = await _mediator.Send(command);

        var status = response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        return getResponse<BaseResponse<Nullable<int>>> (status, response);
    }

    [HttpPut("{blogId}/Rate")]
    public async Task<ActionResult<BaseResponse<Nullable<int>>>> Put(int blogId, [FromBody] RatingDto ratingDto)
    {
        var command = new UpdateRatingCommand { BlogId = blogId, RatingDto = ratingDto };
        var response = await _mediator.Send(command);

        var status = response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
        return getResponse<BaseResponse<Nullable<int>>>(status, response);
    }
}
