using CineFlex.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
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
                return NotFound(result);
            else if (result.Success && result.Value != null)
                return Ok(result);
            else if (result.Success && result.Value == null)
                return NotFound(result);
            else
                return BadRequest(result);
        }

    }
}
