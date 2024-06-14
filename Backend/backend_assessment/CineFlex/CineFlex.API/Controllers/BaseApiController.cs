using MediatR;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace CineFlex.API.Controllers
{
    public class BaseApiController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public ActionResult getResponse<T>(HttpStatusCode status, T? payload){

            if(status == HttpStatusCode.Created){
                return Created("", payload);
            }else if(status == HttpStatusCode.BadRequest){
                return BadRequest(payload);
            }else if(status == HttpStatusCode.OK){
                return Ok(payload);
            }else if(status == HttpStatusCode.NotFound){
                return NotFound();
            }
            return NoContent();
        }

    }
}