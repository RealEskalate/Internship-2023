using BlogApp.Application.Features.Ratings.CQRS.Commands;
using BlogApp.Application.Features.Ratings.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;
[Route("api/Blogs")]
[ApiController]
public class RatingsController : ControllerBase
{
    private readonly IMediator _mediator;
    public RatingsController(IMediator mediator) : base()
    {
        _mediator = mediator;
    }

    [HttpPost("{blogId}/Rate")]
    public async Task<ActionResult<int>> Post(int blogId, [FromBody] RatingDto ratingDto)
    {
        var command = new CreateRatingCommand { BlogId = blogId, RatingDto = ratingDto };
        var repsonse = await _mediator.Send(command);
        return Ok(repsonse);
    }

    [HttpPut("{blogId}/Rate")]
    public async Task<ActionResult<int>> Put(int blogId, [FromBody] RatingDto ratingDto)
    {
        var command = new UpdateRatingCommand { BlogId = blogId, RatingDto = ratingDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
