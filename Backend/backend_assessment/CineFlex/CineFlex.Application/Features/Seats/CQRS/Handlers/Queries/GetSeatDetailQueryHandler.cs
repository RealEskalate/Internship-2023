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
    public class GetSeatDetailQueryHandler : IRequestHandler<GetSeatDetailQuery, BaseCommandResponse<SeatDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeatDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<BaseCommandResponse<SeatDto>> Handle(GetSeatDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<SeatDto>();
            var seat = await _unitOfWork.SeatRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Movie retrieval Successful";
            response.Value = _mapper.Map<SeatDto>(seat);

            return response;
        }
    }
}
