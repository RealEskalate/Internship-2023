using CineFlex.Application.Features.Cinema.CQRS.Commands;
using CineFlex.Application.Features.Cinema.CQRS.Queries;
using CineFlex.Application.Features.Cinema.DTO;
using CineFlex.Application.Features.Cinema.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    public class TaskController: BaseApiController
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<TaskDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetTaskListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> Get(int id)
        {
             return HandleResult(await _mediator.Send(new GetTaskQuery { Id = id }));
        }
        [HttpPost("CreateCinema")]
        public async Task<ActionResult> Post([FromBody] CreateTaskDto createTaskDto)
        {
            var command = new CreateTaskCommand { TaskDto = createTaskDto };
            return HandleResult(await _mediator.Send(command));
        }
        [HttpPut("UpdateCinema")]
        public async Task<ActionResult> Put([FromBody] UpdateTaskDto updateTaskDto)
        {
            var command = new UpdateTaskCommand { updateTaskDto = updateTaskDto };
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteTaskCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}

