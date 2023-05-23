using AutoMapper;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.Dtos;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Domain;

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
                var error = new NotFoundException(nameof(Seats), request.Id);
                return new BaseCommandResponse<SeatDto>
                {
                    Success = false,
                    Message = "Seat Fetch Failed",
                    Errors = new List<string>() { error.Message }
                };

            }
            var Seat = await _unitOfWork.SeatRepository.Get(request.Id);
            return new BaseCommandResponse<SeatDto>
            {
                Success = true,
                Message = "Seat Fetch Success",
                Value = _mapper.Map<SeatDto>(Seat)
            };
        }


    }

}
