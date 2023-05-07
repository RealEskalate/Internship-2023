using MediatR;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Application.Responses;
using BlogApp.Application.Features.Blogs.DTOs;
using BlogApp.Application.Features.Blogs.CQRS.Commands;
using BlogApp.Application.Features.Blogs.CQRS.Queries;
using BlogApp.API.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogApp.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class BlogsController : BaseApiController
    {
        public BlogsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Nullable<int>>>> Post([FromBody] CreateBlogDTO createBlogDTO)
        {
            var command = new CreateBlogCommand { CreateBlogDTO = createBlogDTO};
            var response = await _mediator.Send(command);

            var status = response.Success ? HttpStatusCode.Created: HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<Nullable<int>>>(status, response);
        }
        [HttpGet]
        public async Task<ActionResult<BaseResponse<IList<BlogListDTO>>>> Get([FromQuery] bool published)
        {
            BaseResponse<IList<BlogListDTO>> blogs;
            blogs = await _mediator.Send(new GetBlogListQuery{ published=published});
            
            var status = blogs.Success ? HttpStatusCode.OK: HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<IList<BlogListDTO>>>(status, blogs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<BlogDTO>>> Get(int id)
        {
            var blog = await _mediator.Send(new GetBlogQuery { Id = id });

            var status = blog.Success ? HttpStatusCode.OK: HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<BlogDTO>>(status, blog);
        }

        [HttpPatch]
        public async Task<ActionResult> Patch([FromBody] UpdateBlogDTO blogDTO)
        {
            var command = new UpdateBlogCommand { UpdateBlogDTO = blogDTO };
            var response = await _mediator.Send(command);

            var status = response.Success ? HttpStatusCode.OK: HttpStatusCode.BadRequest;
            
            return getResponse<BaseResponse<Unit>>(status, response);
        }
        
        [HttpPatch("publish/{id}")]
        public async Task<ActionResult> Patch(int id)
        {
            var command = new PublishBlogCommand { Id = id };
            var response = await _mediator.Send(command);

            var status = response.Success ? HttpStatusCode.OK: HttpStatusCode.BadRequest;
            
            return getResponse<BaseResponse<Unit>>(status, response);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteBlogCommand { Id = id };
            var response = await _mediator.Send(command);

            var status = response.Success ? HttpStatusCode.NoContent: HttpStatusCode.BadRequest;
            return getResponse<BaseResponse<Unit>>(status, response);
        }
    }
}
