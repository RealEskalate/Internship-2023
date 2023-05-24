using AutoMapper;
using MBApp.Application.Contracts.Persistence;
using MBApp.Application.Features.Seats.DTOs;
using MBApp.Application.Features.Seats.CQRS.Queries;
using MBApp.Application.Features.Seats.DTOs;
using MBApp.Application.Responses;
using MBApp.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBApp.Application.Features.Seats.CQRS.Handlers
{
    public class GetSeatDetailQueryHandler : IRequestHandler<GetSeatDetailQuery,Result<SeatDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeatDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<SeatDto>> Handle(GetSeatDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new Result<SeatDto>();
            var seat = await _unitOfWork.SeatRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<SeatDto>(seat);

            return response;
        }
    }
}
