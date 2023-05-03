using BlogApp.Application.Features.Ratings.CQRS.Commands;
using BlogApp.Application.Features.Ratings.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BlogsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("{blogId}/rate")]
    public async Task<ActionResult<int>> Post(int blogId, [FromBody] RatingDto ratingDto)
    {
        var command = new Create_RatingCommand { BlogId = blogId, RatingDto = ratingDto };
        var repsonse = await _mediator.Send(command);
        return Ok(repsonse);
    }

    [HttpPut("{blogId}/rate")]
    public async Task<ActionResult> Put(int blogId, [FromBody] RatingDto ratingDto)
    {
        var command = new Update_RatingCommand { BlogId = blogId, RatingDto = ratingDto };
        await _mediator.Send(command);
        return NoContent();
    }
}
