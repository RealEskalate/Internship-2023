using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.DTO.Validators;
using CineFlex.Application.Features.Seats.CQRS.Commands;
using CineFlex.Application.Features.Seats.DTO;
using CineFlex.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.DTO;
using CineFlex.Application.Features.Bookings.DTO.Validators;
using CineFlex.Application.Features.Bookings.CQRS.Commands;
using CineFlex.Application.Responses;
using MediatR;


namespace CineFlex.Application.Features.Bookings.CQRS.Handlers
{
    public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, BaseCommandResponse<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<Unit>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse<Unit>();
            var validator = new UpdateBookingDtoValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request.UpdateBookingDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return response;
            }

            var booking = await _unitOfWork.BookingRepository.Get(request.UpdateBookingDto.Id);

            if (booking == null)
            {
                response.Success = true;
                response.Message = "No booking found by this id";
                return response;
            }

            _mapper.Map(request.UpdateBookingDto, booking);

            // Update seat numbers
            if (booking.Seats != null)

            {
                var updatedSeatNumbers = request.UpdateBookingDto.SeatNumbers;
                var oldSeatNumbers = booking.Seats.Select(s => s.SeatNumber).ToList();

                var seatsToBeRemoved = booking.Seats.Where(s => !updatedSeatNumbers.Contains(s.SeatNumber)).ToList();
                var seatsToBeAdded = updatedSeatNumbers.Except(oldSeatNumbers).ToList();

                foreach (var seatToBeRemoved in seatsToBeRemoved)
                {
                    booking.Seats.Remove(seatToBeRemoved);
                    seatToBeRemoved.IsTaken = false;
                }

                foreach (var seatNumberToBeAdded in seatsToBeAdded)
                {
                    var seatToBeAdded = await _unitOfWork.SeatRepository.GetSeatByNumberAsync(seatNumberToBeAdded, booking.CinemaId);

                    if (seatToBeAdded != null && !seatToBeAdded.IsTaken)
                    {
                        booking.Seats.Add(seatToBeAdded);
                        seatToBeAdded.IsTaken = true;
                    }
                }
            }


            await _unitOfWork.BookingRepository.Update(booking);

            if (await _unitOfWork.Save() > 0)
            {
                response.Success = true;
                response.Message = "Successfully Updated";
                response.Value = Unit.Value;
            }
            else
            {
                response.Success = false;
                response.Message = "Update Failed";
            }

            return response;
        }
    }
}
