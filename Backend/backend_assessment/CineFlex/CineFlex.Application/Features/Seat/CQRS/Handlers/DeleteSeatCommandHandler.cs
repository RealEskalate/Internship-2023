using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;
public class DeleteSeatCommandHandler : IRequestHandler<DeleteSeatCommand>
{
    private readonly ISeatRepository _seatRepository;

    public DeleteSeatCommandHandler(ISeatRepository seatRepository)
    {
        _seatRepository = seatRepository;
    }

    public async Task<Unit> Handle(DeleteSeatCommand request, CancellationToken cancellationToken)
    {
        var seatToDelete = await _seatRepository.Get(request.Id);

        if (seatToDelete == null)
            throw new NotFoundException(nameof(Seat), request.Id);

        await _seatRepository.Delete(seatToDelete);
        return Unit.Value;
    }
}
