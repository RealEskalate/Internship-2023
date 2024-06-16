using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTO.Validators;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;
public class UpdateSeatCommandHandler : IRequestHandler<UpdateSeatCommand>
{
    private readonly ISeatRepository _seatRepository;
    private readonly IMapper _mapper;

    public UpdateSeatCommandHandler(ISeatRepository seatRepository, IMapper mapper)
    {
        _seatRepository = seatRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSeatCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSeatDtoValidator();
        var validationResult = await validator.ValidateAsync(request.UpdateSeatDto, cancellationToken);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        var seatToUpdate = await _seatRepository.Get(request.UpdateSeatDto.Id);

        if (seatToUpdate == null)
            throw new NotFoundException(nameof(Seat), request.UpdateSeatDto.Id);

        _mapper.Map(request.UpdateSeatDto, seatToUpdate);

        await _seatRepository.Update(seatToUpdate);
        return Unit.Value;
    }
}
