namespace CineFlex.API.Controllers;


[Route("api/[Controller]")]
[ApiController]
public class SeatController : BaseApiController
{
    private readonly IMediator _mediator;

    public SeatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<SeatDto>>> Get()
    {
        return HandleResult(await _mediator.Send(new GetSeatListQuery()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return HandleResult(await _mediator.Send(new GetSeatDetailQuery { Id = id }));

    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSeatDto createSeat)
    {
        var command = new CreateSeatCommand { SeatDto = createSeat };
        return HandleResult(await _mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateSeatDto seatDto)
    {


        var command = new UpdateMovieCommand { SeatDto = seatDto };
        return HandleResult(await _mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteSeatCommand { Id = id };
        return HandleResult(await _mediator.Send(command));
    }
}
