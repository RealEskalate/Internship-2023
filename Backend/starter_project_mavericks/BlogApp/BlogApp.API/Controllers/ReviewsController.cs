using System.Net;
using BlogApp.API.Controllers;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.CQRS.Queries;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers;
[Route("api/[Controller]")]
[ApiController]
public class ReviewsController : BaseApiController
{
   
    public ReviewsController(IMediator mediator) : base(mediator)
    {
    
    }

    [HttpGet("blogReviews{blogId}")]
    public async Task<ActionResult<List<ReviewDto>>> GetBlogReviews(int blogId)
    {
        var query = new GetBlogReviewListQuery{BlogId = blogId};
        var response = await _mediator.Send(query);
        return response.Success
            ? getResponse(HttpStatusCode.OK, response)
            : getResponse(HttpStatusCode.BadRequest, response);
    }

    [HttpGet("userReviews{reviewerId}")]
    
    public async Task<ActionResult<List<ReviewDto>>> GetUserReviews(string reviewerId)
    {
        var query = new GetUserReviewListQuery { ReviewerId = reviewerId };
        var response = await _mediator.Send(query);
        return response.Success
            ? getResponse(HttpStatusCode.OK, response)
            : getResponse(HttpStatusCode.BadRequest, response);

    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetReview(int id)
    {
        var query = new GetReviewDetailQuery { Id = id };
        var response = await _mediator.Send(query);
        return response.Success
            ? getResponse(HttpStatusCode.OK, response)
            : getResponse(HttpStatusCode.BadRequest, response);
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<int?>>> Post([FromBody] CreateReviewDto createReviewDto)
    {
        var command = new CreateReviewCommand { CreateReviewDto = createReviewDto };
        var response = await _mediator.Send(command);
        return response.Success
            ? getResponse(HttpStatusCode.Created, response)
            : getResponse(HttpStatusCode.BadRequest, response);
    }

    [HttpPut]
    public async Task<ActionResult<BaseResponse<Unit?>>> Put([FromBody] UpdateReviewDto updateReviewDto)
    {
        var command = new UpdateReviewCommand { UpdateReviewDto = updateReviewDto };
        var response = await _mediator.Send(command);
        return response.Success
            ? getResponse(HttpStatusCode.NoContent, response)
            : getResponse(HttpStatusCode.BadRequest, response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BaseResponse<Unit?>>> Delete(int id)
    {
        var command = new DeleteReviewCommand { Id = id };
        var response = await _mediator.Send(command);
        return response.Success
            ? getResponse(HttpStatusCode.NoContent, response)
            : getResponse(HttpStatusCode.BadRequest, response);
    }
}