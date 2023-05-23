
using CineFlex.Application.Features.Auth.CQRS.Commands;
using CineFlex.Application.Features.Auth.CQRS.Queries;
using CineFlex.Application.Models.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace CineFlex.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("login")]
         [AllowAnonymous]
      
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        
        {
            var command  = new LoginCommand { loginRequest = loginRequest};
            var response = await _mediator.Send(command);
            Console.WriteLine(response);
            return Ok(response);
        }

        [HttpPost]
         [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] UserCreationDto userCreation)
        {

            var command = new CreateUserCommand {userCreationDto = userCreation};
            var user = await _mediator.Send(command);
            return Ok(user);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var query = new GetUserQuery { UserId = userId };
            var user = await _mediator.Send(query);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
