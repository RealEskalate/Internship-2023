using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Common;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;
public class GetSeatListQueryHandler : IRequestHandler<GetSeatListQuery, List<SeatDto>>
{
    private readonly ISeatRepository _seatRepository;
    private readonly IMapper _mapper;

    public GetSeatListQueryHandler(ISeatRepository seatRepository, IMapper mapper)
    {
        _seatRepository = seatRepository;
        _mapper = mapper;
    }

    public async Task<List<SeatDto>> Handle(GetSeatListQuery request, CancellationToken cancellationToken)
    {
        var seats = await _seatRepository.GetAll();

        return _mapper.Map<List<SeatDto>>(seats);
    }
}