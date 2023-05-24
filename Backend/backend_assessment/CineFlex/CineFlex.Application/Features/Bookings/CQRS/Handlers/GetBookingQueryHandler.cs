using AutoMapper;
using CineFlex.Application.Exceptions;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Queries;
using CineFlex.Application.Features.Bookings.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Cinema.CQRS.Handlers
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
            bool exists = await _unitOfWork.CinemaRepository.Exists(request.Id);
            if (exists == false)
            {
                var error = new NotFoundException(nameof(Cinema), request.Id);
                return new BaseCommandResponse<BookingDto>
                {
                    Success = false,
                    Message = "Cinema Fetch Failed",
                    Errors = new List<string>() { error.Message }
                };

            }
            var booking = await _unitOfWork.BookingRepository.Get(request.Id);
            return new BaseCommandResponse<BookingDto>
            {
                Success = true,
                Message = "Cinema Fetch Success",
                Value = _mapper.Map<BookingDto>(booking)
            };
        }
       
       
    }

}
