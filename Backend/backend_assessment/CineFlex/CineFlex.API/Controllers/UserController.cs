// using CineFlex.Application.Features.Users.CQRS.Commands;
// using CineFlex.Application.Features.Users.CQRS.Queries;
// using CineFlex.Application.Features.Users.DTOs;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// namespace CineFlex.API.Controllers
// {
//     [Route("api/[Controller]")]
//     [ApiController]
//     public class UserController : BaseApiController
//     {
//         private readonly IMediator _mediator;

//         public UserController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         [HttpGet]
//         public async Task<ActionResult<List<_UserDto>>> Get()
//         {
//             return HandleResult(await _mediator.Send(new Get_UserListQuery()));
//         }

//         [HttpGet("{id}")]
//         public async Task<IActionResult> Get(int id)
//         {
//             return HandleResult(await _mediator.Send(new Get_UserDetailQuery { Id = id }));

//         }

//         [HttpPost]
//         public async Task<IActionResult> Post([FromBody] Create_UserDto create_User)
//         {
//             var command = new Create_UserCommand { _UserDto = create_User };
//             return HandleResult(await _mediator.Send(command));
//         }

//         [HttpPut]
//         public async Task<IActionResult> Put([FromBody] Update_UserDto userDto)
//         {


//             var command = new Update_UserCommand { _UserDto = userDto };
//             return HandleResult(await _mediator.Send(command));
//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> Delete(int id)
//         {
//             var command = new Delete_UserCommand { Id = id };
//             return HandleResult(await _mediator.Send(command));
//         }
//     }
// }
