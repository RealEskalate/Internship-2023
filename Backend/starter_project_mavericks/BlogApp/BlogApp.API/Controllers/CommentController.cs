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
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CommentDto>>> Get()
        {
            var indices = await _mediator.Send(new GetCommentListQuery());
            return Ok(indices);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> Get(int id)
        {
            var indices = await _mediator.Send(new GetCommentByIdQuery { Id = id });
            return Ok(indices);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCommentDto createCommentDto)
        {
            var command = new CreateCommentCommand { CommentDto = createCommentDto };
            var repsonse = await _mediator.Send(command);
            return Ok(repsonse);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(UpdateCommentDto indexDto ,int id)
        {
            var command = new UpdateCommentCommand { Id = id,updateCommentDto = indexDto  };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteCommentCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
