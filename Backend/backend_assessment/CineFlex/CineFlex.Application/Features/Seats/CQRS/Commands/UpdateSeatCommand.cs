namespace CineFlex.Application.Features.Seats.CQRS.Commands;

public class UpdateSeatCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public UpdateSeatDto SeatDto { get; set; }

    }
 
