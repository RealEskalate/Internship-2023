using API.Controllers;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Features.Rates.CQRS.Commands;
using BlogApp.Application.Features.Rates.CQRS.Queries;
using BlogApp.Application.Features.Rates.DTOs;
using BlogApp.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogApp.API.Controllers
{
    public class CommentController : BaseApiController
    {
        [HttpGet] //api/rates
        public async Task<IActionResult> GetActivities()
        {
            return HandleResult(await Mediator.Send(new GetCommentListQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            return HandleResult(await Mediator.Send(new GetCommentDetailQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto comment)
        {
            return HandleResult(await Mediator.Send(new CreateCommentCommand { CommentDto = comment }));
        }


        [HttpPut]
        public async Task<IActionResult> UpdateRate(UpdateCommentDto Comment)
        {
            return HandleResult(await Mediator.Send(new UpdateCommentCommand { CommentDto = Comment }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActvity(int id)
        {
            return HandleResult(await Mediator.Send(new DeleteCommentCommand { Id = id }));
        }
    }
}
