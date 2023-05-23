using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class GetSeatsDetailQueryHandler : IRequestHandler<GetSeatsDetailQuery, BaseCommandResponse<SeatsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeatsDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<SeatsDto>> Handle(GetSeatsDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<SeatsDto>();
            var seat = await _unitOfWork.SeatsRepository.Get(request.Id);
            response.Success = true;
            response.Message = "seats retrieval Successful";
            response.Value = _mapper.Map<SeatsDto>(seat);

            return response;
        }
    }
}
