using CineFlex.Application.Features.Seat.DTO;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seat.CQRS.Queries
{
    public class GetSeatQuery : IRequest<BaseCommandResponse<SeatDto>>
    {
        public int Id { get; set; }
    }
}
