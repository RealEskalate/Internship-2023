using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Queries;
using CineFlex.Application.Features.Bookings.DTOs;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.CQRS.Handlers
{
    public class GetBookingDetailQueryHandler : IRequestHandler<GetBookingDetailQuery, BaseCommandResponse<BookingDetailDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBookingDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse<BookingDetailDto>> Handle(GetBookingDetailQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<BookingDetailDto>();
            var Booking = await _unitOfWork.BookingRepository.GetBookingDetail(request.Id);
            response.Success = true;
            response.Message = "Booking retrieval Successful";
            response.Value = _mapper.Map<BookingDetailDto>(Booking);

            return response;
        }
    }
}
