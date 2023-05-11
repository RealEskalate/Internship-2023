using API.Controllers;
using BlogApp.Application.Features.Reviews.CQRS.Commands;
using BlogApp.Application.Features.Reviews.CQRS.Queries;
using BlogApp.Application.Features.Reviews.DTOs;
using BlogApp.Domain;
using Microsoft.AspNetCore.Mvc; 
using System.Diagnostics;

namespace BlogApp.API.Controllers
{
    public class ReviewController : BaseApiController
    {
        [HttpGet] //api/reviews 
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult(await Mediator.Send(new GetReviewListQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview(int id)
        {
            return HandleResult(await Mediator.Send(new GetReviewDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDto Review)
        {
            return HandleResult(await Mediator.Send(new CreateReviewCommand{ ReviewDto  = Review }));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewDto Review)
        {
            return HandleResult(await Mediator.Send(new UpdateReviewCommand {ReviewDto = Review }));
        }

        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteActvity(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteReviewCommand{ Id = id }));
        }
    }
}
