using CineFlex.Application.Responses;
using MediatR;


namespace CineFlex.Application.Features.Seats.CQRS.Commands
{
    public class DeleteSeatCommand : IRequest<BaseCommandResponse<Unit>>
    {
        public int Id { get; set; }
    }
}
