using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand, BaseCommandResponse<Unit>>
{
    public Task<BaseCommandResponse<Unit>> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}