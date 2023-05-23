using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Application.Responses;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class GetSeatListQueryHandler : IRequestHandler<GetSeatListQuery, BaseCommandResponse<List<SeatDto>>>
    {



        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeatListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        public async Task<BaseCommandResponse<List<SeatDto>>> Handle(GetSeatListQuery request, CancellationToken cancellationToken)
        {
            var seat = await _unitOfWork.SeatRepository.GetAll();

            if (seat == null || seat.Count == 0)
            {
                return new BaseCommandResponse<List<SeatDto>>
                {
                    Success = false,
                    Message = "No Seat found."
                };
            }
            else
            {
                return new BaseCommandResponse<List<SeatDto>>
                {
                    Success = true,
                    Value = _mapper.Map<List<SeatDto>>(seat)
                };
            }
        }
    }
}