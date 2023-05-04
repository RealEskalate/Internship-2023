using BlogApp.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class BaseController: ControllerBase
{
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