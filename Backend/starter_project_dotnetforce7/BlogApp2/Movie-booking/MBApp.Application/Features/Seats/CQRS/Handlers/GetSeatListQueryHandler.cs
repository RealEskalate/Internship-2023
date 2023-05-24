using AutoMapper;
using MBApp.Application.Contracts.Persistence;
using MBApp.Application.Features.Seats.DTOs;
using MBApp.Application.Features.Seats.CQRS.Queries;
using MBApp.Application.Features.Seats.DTOs;
using MBApp.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBApp.Application.Features.Seats.CQRS.Handlers
{
    public class GetSeatsListQueryHandler : IRequestHandler<GetSeatsListQuery, Result<List<SeatDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeatListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<SeatDto>>> Handle(GetSeatListQuery request, CancellationToken cancellationToken)
        {

            var response = new Result<List<SeatDto>>();
            var seats = await _unitOfWork.SeatRepository.GetAll();
       
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<List<SeatDto>>(seats);

            return response;
        }
    }
}
