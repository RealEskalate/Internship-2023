using CineFlex.Application.Features.CheckList.CQRS.Commands;
using CineFlex.Application.Features.CheckList.CQRS.Queries;
using CineFlex.Application.Features.CheckList.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace CineFlex.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CheckListController : BaseApiController
    {
        private readonly IMediator _mediator;

        public CheckListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CheckListDto>>> Get()
        {
            return HandleResult(await _mediator.Send(new GetCheckListListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return HandleResult(await _mediator.Send(new GetCheckListDetailQuery { Id = id }));

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCheckListDto createCheckList)
        {
            var command = new CreateCheckListCommand { CheckListDto = createCheckList };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCheckListDto checklistDto)
        {


            var command = new UpdateCheckListCommand { CheckListDto = checklistDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCheckListCommand { Id = id };
            return HandleResult(await _mediator.Send(command));
        }
    }
}
