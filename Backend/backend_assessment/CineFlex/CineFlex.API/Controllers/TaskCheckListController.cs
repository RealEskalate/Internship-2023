using CineFlex.Application.Features.Movies.CQRS.Commands;
using CineFlex.Application.Features.Movies.CQRS.Queries;
using CineFlex.Application.Features.Movies.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CineFlex.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TaskCheckListController : BaseApiController
    {
        private readonly IMediator _mediator;

        public TaskCheckListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskCheckListDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetTaskCheckListListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetTaskCheckListDetailQuery { Id = id }));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTaskCheckListDto createTaskCheckListDto)
        {
            var command = new CreateTaskCheckListCommand { TaskCheckListDto = createTaskCheckListDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateTaskCheckListDto TaskCheckListDto)
        {


            var command = new UpdateTaskCheckListCommand { TaskCheckListDto = TaskCheckListDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTaskCheckListCommand { Id = id };
            return HandleResult(await _mediator.Send(command));
        }
    }
}
