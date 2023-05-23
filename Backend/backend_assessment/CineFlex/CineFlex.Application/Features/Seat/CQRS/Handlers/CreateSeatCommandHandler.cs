using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.DTO.Validators;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;
public class CreateSeatCommandHandler : IRequestHandler<CreateSeatCommand, int>
{
    private readonly ISeatRepository _seatRepository;
private readonly IMapper _mapper;
private readonly IHttpContextAccessor _httpContextAccessor;

public CreateSeatCommandHandler(ISeatRepository seatRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
{
    _httpContextAccessor = httpContextAccessor;
    _seatRepository = seatRepository;
    _mapper = mapper;
}

public async Task<int> Handle(CreateSeatCommand request, CancellationToken cancellationToken)
{
    var validator = new CreateSeatDtoValidator();
    var validationResult = await validator.ValidateAsync(request.CreateSeatDto, cancellationToken);

    if (validationResult.Errors.Count > 0)
        throw new ValidationException(validationResult);

        var seat = _mapper.Map<Seat>(request.CreateSeatDto);

    seat = await _seatRepository.Add(seat);

    return seat.Id;
}
}
