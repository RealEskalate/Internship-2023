using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Commands;
using CineFlex.Application.Features.Bookings.DTO.Validators;
using CineFlex.Application.Responses;
using CineFlex.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace CineFlex.Application.Features.Bookings.CQRS.Handlers
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserAccessor _userAccessor;

        public CreateBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserAccessor userAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new CreateBookingDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.BookingDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var currentUser = await _userAccessor.GetCurrentUser();
            if (currentUser == null)
            {
                response.Success = false;
                response.Message = "User not found";
                return response;
            }

            var booking = _mapper.Map<Booking>(request.BookingDto);
            booking.AppUser = currentUser;
            booking.Seats = new List<SeatEntity>();

            foreach (var seatNumber in request.BookingDto.SeatNumbers)
            {
                var seat = await _unitOfWork.SeatRepository.GetSeatByNumberAsync(seatNumber, booking.CinemaId);

                if (seat == null || seat.IsTaken)
                {
                    response.Success = false;
                    response.Message = "Seat number is not available";
                    return response;
                }

                seat.IsTaken = true;
                booking.Seats.Add(seat);
            }

            await _unitOfWork.BookingRepository.Add(booking);

            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "Creation Successful";
                response.Value = booking.Id;
            }
            else
            {
                response.Success = false;
                response.Message = "Creation Failed";
            }

            return response;
        }
    }
}
