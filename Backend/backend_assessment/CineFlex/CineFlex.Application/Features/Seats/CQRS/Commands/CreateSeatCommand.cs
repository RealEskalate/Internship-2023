namespace CineFlex.Application.Features.Seats.CQRS.Commands;

public class CreateSeatCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreateSeatDto SeatDto { get; set; }
    }
 
