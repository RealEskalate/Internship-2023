using BlogApp.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediatr;

        protected IMediator Mediator => _mediatr ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null)
                return NotFound(new Result<int>{ Success=false ,Message="Item not found"});

            if (result.Success && result.Value != null)
                return Ok(result);
            if (result.Success && result.Value == null)
                return NotFound(result);
           

            return BadRequest(result);
        }

    }


}