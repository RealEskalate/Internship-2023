using MBApp.Application.Responses;
using MediatR;


namespace MBApp.Application.Features.Seats.CQRS.Commands
{
    public class DeleteSeatCommand : IRequest<Result<Unit>>
    {
        public int Id { get; set; }
    }
}
