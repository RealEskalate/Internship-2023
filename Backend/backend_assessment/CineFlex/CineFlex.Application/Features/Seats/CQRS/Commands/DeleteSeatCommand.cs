namespace CineFlex.Application.Features.Seats.CQRS.Commands;

public class DeleteSeatCommand :IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }
 