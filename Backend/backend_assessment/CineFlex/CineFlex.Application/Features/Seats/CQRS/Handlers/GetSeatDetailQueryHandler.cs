﻿using AutoMapper;
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
    public class GetSeatDetailQueryHandler : IRequestHandler<GetSeatDetailQuery, BaseCommandResponse<SeatDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeatDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<SeatDto>> Handle(GetSeatDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<SeatDto>();
            var Seat = await _unitOfWork.SeatRepository.Get(request.Id);
            response.Success = true;
            response.Message = "Seat retrieval Successful";
            response.Value = _mapper.Map<SeatDto>(Seat);

            return response;
        }
    }
}
