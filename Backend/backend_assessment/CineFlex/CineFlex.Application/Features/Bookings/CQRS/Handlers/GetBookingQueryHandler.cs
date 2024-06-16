using AutoMapper;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Queries;
using CineFlex.Application.Features.Bookings.Dtos;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CineFlex.Domain;

namespace CineFlex.Application.Features.Bookings.CQRS.Handlers
{
    public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BaseCommandResponse<BookingDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public GetBookingQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<BaseCommandResponse<BookingDto>> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            bool exists = await _unitOfWork.BookingRepository.Exists(request.Id);
            if (exists == false)
            {
                var error = new NotFoundException(nameof(Bookings), request.Id);
                return new BaseCommandResponse<BookingDto>
                {
                    Success = false,
                    Message = "Booking Fetch Failed",
                    Errors = new List<string>() { error.Message }
                };

            }
            var Booking = await _unitOfWork.BookingRepository.Get(request.Id);
            return new BaseCommandResponse<BookingDto>
            {
                Success = true,
                Message = "Booking Fetch Success",
                Value = _mapper.Map<BookingDto>(Booking)
            };
        }


    }

}
