using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class GetSeatQueryHandler : IRequestHandler<GetSeatQuery, BaseCommandResponse<SeatDto>>
    {


        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetSeatQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseCommandResponse<SeatDto>> Handle(GetSeatQuery request, CancellationToken cancellationToken)
        {
            bool exists = await _unitOfWork.SeatRepository.Exists(request.Id);

            if (exists == false)
            {
                var error = new NotFoundException(nameof(Seat), request.Id);
                return new BaseCommandResponse<SeatDto>
                {
                    Success = false,
                    Message = "Seat Fetch Failed",
                    Errors = new List<string>() { error.Message }
                };

            }
            var seat = await _unitOfWork.SeatRepository.Get(request.Id);
            return new BaseCommandResponse<SeatDto>
            {
                Success = true,
                Message = "Seat Fetch Success",
                Value = _mapper.Map<SeatDto>(seat)
            };
        }
    }
}