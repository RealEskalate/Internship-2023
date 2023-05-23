using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.CQRS.Queries;
using CineFlex.Application.Features.Seats.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.CQRS.Handlers;

    public class GetSeatListQueryHandler : IRequestHandler<GetSeatListQuery, List<SeatDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSeatListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<SeatDto>> Handle(GetSeatListQuery request, CancellationToken cancellationToken)
        {
            var seats = await _unitOfWork.SeatRepository.GetAll();
            return _mapper.Map<List<SeatDto>>(seats);
        }
    }

