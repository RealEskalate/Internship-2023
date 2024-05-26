using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Application.Features.Seats.DTO.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers
{
    public class GetSeatRequestHandler : IRequestHandler<GetSeatRequest, BaseCommandResponse<SeatDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetSeatRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseCommandResponse<SeatDto>> Handle(GetSeatRequest request, CancellationToken cancellationToken)
        {
            
            var response = new BaseCommandResponse<SeatDto>();
            var seat = await _unitOfWork.SeatRepository.Get(request.Id);

            if (seat == null) {
                throw new NotFoundException(nameof(seat), request.Id);
            }

            response.Success = true;
            response.Message = "Fetch Succesful";
            response.Value = _mapper.Map<SeatDto>(seat);

            return response;



        }
    }
}
