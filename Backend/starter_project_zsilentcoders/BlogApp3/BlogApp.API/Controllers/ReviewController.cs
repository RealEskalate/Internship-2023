using BlogApp.Application.Features._Indices.CQRS.Commands;
using BlogApp.Application.Features._Indices.CQRS.Queries;
using BlogApp.Application.Features._Indices.DTOs;
using BlogApp.Application.Features.Review.CQRS.Command;
using BlogApp.Application.Features.Review.CQRS.Commands;
using BlogApp.Application.Features.Review.CQRS.Queries;
using BlogApp.Application.Features.Review.DTOs;
using BlogApp.Application.Responses;
using BlogApp.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{reivewerId}")]
        public async Task<ActionResult<List<_Review>>> GetReviewsByReviewerId(int reivewerId)
        {
            var reviews = await _mediator.Send(new GetReviewListQuery { ReviewerId= reivewerId });
            return Ok(reviews);
        }

        [HttpGet("{reviewId}")]
        public async Task<ActionResult<ReviewDto>> GetReviewById(int reviewId)
        {
            var review = await _mediator.Send(new GetReviewDetailQuery { ReviewerId = reviewId });
            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] ReviewDto createReviewDto)
        {
            var command = new CreateReviewCommand { reviewDto = createReviewDto };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ReviewDto reviewDto)
        {
            var command = new UpdateReviewCommand { reviewDto = reviewDto };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteReviewCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
