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

        protected ActionResult HandleResponse<T>(BaseResponse<T> response)
        {
            if (response == null) return NotFound(response);

            if (response.Success && response.Data != null)
                return Ok(response);
            if (response.Success && response.Data == null)
                return NotFound(response);

            return BadRequest(response);
        }

    }


}