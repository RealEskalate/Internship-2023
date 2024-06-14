using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seat.CQRS.Queries;
using CineFlex.Application.Features.Seat.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seat.CQRS.Handlers
{
    public class GetSeatQueryHandler : IRequestHandler<GetSeatQuery, BaseCommandResponse<SeatDto>>
    {
        private readonly ISeatRepository _seatRepository;
        private readonly IMapper _mapper;

        public GetSeatQueryHandler(ISeatRepository seatRepository, IMapper mapper)
        {
            _seatRepository = seatRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<SeatDto>> Handle(GetSeatQuery request, CancellationToken cancellationToken)
        {
            var seat = await _seatRepository.Get(request.Id);
            if (seat == null)
            {
                return new BaseCommandResponse<SeatDto>
                {
                    Success = false,
                    Message = "Seat not found"
                };
            }

            var seatDto = _mapper.Map<SeatDto>(seat);

            return new BaseCommandResponse<SeatDto>
            {
                Success = true,
                Message = "Seat retrieved successfully",
                Value = seatDto
            };
        }
    }
}
