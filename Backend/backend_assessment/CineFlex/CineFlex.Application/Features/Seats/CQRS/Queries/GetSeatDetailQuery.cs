namespace CineFlex.Application.Features.Seats.CQRS.Queries;

public class GetSeatDetailQuery : IRequest<BaseCommandResponse<SeatDto>>
    {
        public int Id { get; set; }
    }
 
