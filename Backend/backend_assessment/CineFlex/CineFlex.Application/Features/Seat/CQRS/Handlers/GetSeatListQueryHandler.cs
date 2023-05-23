using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Queries;
using CineFlex.Application.Features.Seat.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seat.CQRS.Handlers
{
    public class GetSeatListQueryHandler : IRequestHandler<GetSeatListQuery, BaseCommandResponse<List<SeatDto>>>
    {
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;

        public GetSeatListQueryHandler(ISeatRepository seatRepository, IMapper mapper)
        {
            _seatRepository = seatRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<List<SeatDto>>> Handle(GetSeatListQuery request, CancellationToken cancellationToken)
        {
            var seats = await _seatRepository.GetAll();
            var seatDtos = _mapper.Map<List<SeatDto>>(seats);

            return new BaseCommandResponse<List<SeatDto>>
            {
                Success = true,
                Message = "Seat list retrieved successfully",
                Value = seatDtos
            };
        }
    }
}
