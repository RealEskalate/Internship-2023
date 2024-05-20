using CineFlex.Application.Features.Posts.CQRS.Commands;
using CineFlex.Application.Features.Posts.CQRS.Queries;
using CineFlex.Application.Features.Posts.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    [ApiController]

    [Route("api/[Controller]")]
    public class PostController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var query = new GetPostDetailQuery { Id = id };
            var response = await Mediator.Send(query);
            return HandleResult(response);
        }
        [HttpGet]
        public async Task<ActionResult<List<PostDto>>> GetPosts()
        {
            var query = new GetPostListQuery();
            var response = await Mediator.Send(query);
            return HandleResult(response);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreatePostDto createPostDto)
        {
            var command = new CreatePostCommand { CreatePostDto = createPostDto };
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }
        [HttpPatch]
        public async Task<ActionResult> Put([FromBody] UpdatePostDto updatePostDto)
        {
            var command = new UpdatePostCommand { UpdatePostDto = updatePostDto };
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            var command = new DeletePostCommand { Id = Id };
            var response = await Mediator.Send(command);
            return HandleResult(response);
        }
    }
}
