using BlogApp.Application.Features.Comments.CQRS.Commands;
using BlogApp.Application.Features.Comments.CQRS.Queries;
using BlogApp.Application.Features.Comments.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.API.Controllers;

 
[ApiController]
[Route("api/[controller]")]
public class CommentController : ControllerBase
{
    private readonly IMediator _mediator;
    public CommentController(IMediator mediatR)
    {
        _mediator = mediatR;     
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
            var indices = await _mediator.Send(new GetCommentDetailQuery { Id = id });
            return Ok(indices);
        }


    [HttpPost]
      public async Task<ActionResult> Post([FromBody] CreateCommentDto commentDto){
        var response = await _mediator.Send(new CreateCommentCommand{CommentDto = commentDto});
        return Ok(response);   
    }

     [HttpPut]
      public async Task<ActionResult> Put([FromBody] UpdateCommentDto commentDto){

         await _mediator.Send(new UpdateCommentCommand{CommentDto = commentDto});
        return NoContent(); 
    }

     [HttpDelete]
      public async Task<ActionResult> Delete(int id){
         await _mediator.Send(new DeleteCommentCommand{Id = id});
        return NoContent(); 
    }
}

