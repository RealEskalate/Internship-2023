using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Movies.DTOs;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers.Queries
{
    public class GetSeatListQueryHandler : IRequestHandler<GetSeatListQuery, BaseCommandResponse<List<SeatDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetSeatListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseCommandResponse<List<SeatDto>>> Handle(GetSeatListQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<List<SeatDto>>();
            var seats = await _unitOfWork.SeatRepository.GetAll();

            response.Success = true;
            response.Message = "Movies retrieval Successful";
            response.Value = _mapper.Map<List<SeatDto>>(seats);

            return response;
        }
    }
}
