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
    public class GetSeatsListQueryHandler : IRequestHandler<GetSeatsListQuery, BaseCommandResponse<List<SeatsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeatsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<List<SeatsDto>>> Handle(GetSeatsListQuery request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<List<SeatsDto>>();
            var seats = await _unitOfWork.SeatsRepository.GetAll();

            response.Success = true;
            response.Message = "seats retrieval Successful";
            response.Value = _mapper.Map<List<SeatsDto>>(seats);

            return response;
        }
    }
}
