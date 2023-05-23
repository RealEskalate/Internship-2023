using CineFlex.Application.Responses;
using MediatR;


namespace CineFlex.Application.Features.Bookings.CQRS.Commands
{
    public class DeleteBookingCommand : IRequest<BaseCommandResponse<int>>
    {
        public int Id { get; set; }
    }
}
