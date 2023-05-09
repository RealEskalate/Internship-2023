using System.Net;
using BlogApp.API.Controllers;
using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.CQRS.Queries;
using BlogApp.Application.Features.Comments.DTOs;
using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CommentController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<List<CommentDto>>>> Get()
        {
            var comments = await _mediator.Send(new GetCommentListQuery());
            var status = comments.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<List<CommentDto>>>(status, comments);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<CommentDto>>> Get(int id)
        {
            var comment = await _mediator.Send(new GetCommentByIdQuery { Id = id });
            var status = comment.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<CommentDto>>(status, comment);

        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Nullable<int>>>> Post([FromBody] CreateCommentDto createCommentDto)
        {
            var command = new CreateCommentCommand { CommentDto = createCommentDto };
            var response = await _mediator.Send(command);
            var status = response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<Nullable<int>>>(status, response);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(UpdateCommentDto indexDto, int id)
        {
            var command = new UpdateCommentCommand { Id = id, updateCommentDto = indexDto };
            var response = await _mediator.Send(command);
            var status = response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest;

            return getResponse<BaseResponse<Unit>>(status, response);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCommentCommand { Id = id };
            var response = await _mediator.Send(command);
            var status = response.Success ? HttpStatusCode.NoContent : HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<Unit>>(status, response);

        }
    }
}
