using CineFlex.Application.Features.Seat.DTO;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seat.CQRS.Commands
{
    public class CreateSeatCommand : IRequest<BaseCommandResponse<int>>
    {
        public CreateSeatDto SeatDto { get; set; }
    }
}
