using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class GetSeatListQueryHandler : IRequestHandler<GetSeatListQuery, BaseCommandResponse<List<SeatListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeatListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<List<SeatListDto>>> Handle(GetSeatListQuery request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<List<SeatListDto>>();
            var Seats = await _unitOfWork.SeatRepository.GetAll();

            response.Success = true;
            response.Message = "Seats retrieval Successful";
            response.Value = _mapper.Map<List<SeatListDto>>(Seats);

            return response;
        }
    }
}
