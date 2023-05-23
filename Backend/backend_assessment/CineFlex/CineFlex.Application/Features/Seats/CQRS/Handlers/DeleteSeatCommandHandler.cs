using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand, BaseCommandResponse<int>>
{
    public Task<BaseCommandResponse<int>> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}