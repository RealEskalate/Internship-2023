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
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Bookings.CQRS.Handlers
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, BaseCommandResponse<int>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<int>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<int>();
            var validator = new BookingDTOValidator();
            var validationResult = await validator.ValidateAsync(request.BookingDto);
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            // Check if the time slot is available for the specific movieId and cinemaId
            var bookings = await _unitOfWork.BookingRepository.GetAll();
            var isTimeSlotAvailable = bookings.Any(b => b.MovieId == request.BookingDto.MovieId && b.CinemaId == request.BookingDto.CinemaId && b.TimeSlot == request.BookingDto.TimeSlot);
            if (isTimeSlotAvailable)
            {
                response.Success = false;
                response.Message = "Time slot is not available.";
                return response;
            }
            var bookedSeats = bookings.Any(b =>  b.MovieId == request.BookingDto.MovieId && b.CinemaId == request.BookingDto.CinemaId && b.TimeSlot == request.BookingDto.TimeSlot && b.row== request.BookingDto.row && b.col == request.BookingDto.col );
                              
           
            if (bookedSeats)
            {
                response.Success = false;
                response.Message = "Selected seat is not available.";
                return response;
            }

            var booking = _mapper.Map<Booking>(request.BookingDto);
            booking = await _unitOfWork.BookingRepository.Add(booking);

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
