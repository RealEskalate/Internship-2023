using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, BaseCommandResponse<int>>
{
    public Task<BaseCommandResponse<int>> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}