using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.CQRS.Queries;
using CineFlex.Application.Features.Posts.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    public class PostController: BaseApiController
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<PostDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetPostListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostDto>> Get(int id)
        {
             return HandleResult(await _mediator.Send(new GetPostDetailQuery { Id = id }));
        }
        [HttpPost("CreatePost")]
        public async Task<ActionResult> Post([FromBody] CreatePostDto createPostDto)
        {
            var command = new CreatePostCommand { PostDto = createPostDto };
            return HandleResult(await _mediator.Send(command));
        }
        [HttpPut("UpdatePost")]
        public async Task<ActionResult> Put([FromBody] UpdatePostDto updatePostDto)
        {
            var command = new UpdatePostCommand { updatePostDto = updatePostDto };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePostCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}

