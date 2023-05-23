using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Common;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;
public class GetSeatDetailQueryHandler : IRequestHandler<GetSeatDetailQuery, SeatDto>
{
    private readonly ISeatRepository _seatRepository;
    private readonly IMapper _mapper;

    public GetSeatDetailQueryHandler(ISeatRepository seatRepository, IMapper mapper)
    {
        _seatRepository = seatRepository;
        _mapper = mapper;
    }

    public async Task<SeatDto> Handle(GetSeatDetailQuery request, CancellationToken cancellationToken)
    {
        var seat = await _seatRepository.Get(request.Id);

        if (seat == null)
            throw new NotFoundException(nameof(Seat), request.Id);

        return _mapper.Map<SeatDto>(seat);
    }
}
