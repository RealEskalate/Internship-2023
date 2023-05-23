using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Queries;
using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.CQRS.Handlers
{
    public class GetBookingListQueryHandler : IRequestHandler<GetBookingListQuery, BaseCommandResponse<List<BookingDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookingListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<List<BookingDto>>> Handle(GetBookingListQuery request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse<List<BookingDto>>();
            var Bookings = await _unitOfWork.BookingRepository.GetAllWithDetail();

            response.Success = true;
            response.Message = "Bookings retrieval Successful";
            response.Value = _mapper.Map<List<BookingDto>>(Bookings);

            return response;
        }
    }
}
