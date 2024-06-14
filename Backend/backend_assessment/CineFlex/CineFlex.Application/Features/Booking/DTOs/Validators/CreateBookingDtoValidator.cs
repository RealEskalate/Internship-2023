using CineFlex.Application.Contracts.Persistence;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Booking.DTOs.Validators
{
    public class CreateBookingDtoValidator : AbstractValidator<CreateBookingDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateBookingDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(b => b.MovieId)
             .NotEmpty().WithMessage("{PropertyName} is required.")
             .NotNull()
             .MustAsync(MovieMustExist);

            RuleFor(b => b.SeatIds)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(SeatMustExist);

            RuleFor(b => b.CinemaId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(CinemaMustExist);

            RuleFor(b => b.SeatIds)
                .Must(seats => seats.Count() > 0).WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(b => b.SeatIds)
                .Must(seats => seats.Count() <= 10).WithMessage("{PropertyName} must be less than or equal to 10.")
                .NotNull();

            RuleFor(b => b.SeatIds)
                .Must(seats => seats.Count() == seats.Distinct().Count()).WithMessage("{PropertyName} must be unique.")
                .NotNull();


            // check if there is no booking for the same seat in the same movie
            RuleFor(b => b.SeatIds)
                .MustAsync(SeatMustBeAvailable).WithMessage("{PropertyName} is not available.")
                .NotNull();

            // all seats should be from the same cinema
            RuleFor(b => b.SeatIds)
                .MustAsync(SeatsMustBeFromSameCinema).WithMessage("{PropertyName} must be from the same cinema.")
                .NotNull();


        }
        private async Task<bool> MovieMustExist(int id, CancellationToken arg2)
        {
            var movie = await _unitOfWork.MovieRepository.Get(id);
            return movie != null;
        }

        private async Task<bool> CinemaMustExist(int id, CancellationToken arg2)
        {
            var cinema = await _unitOfWork.MovieRepository.Get(id);
            return cinema != null;
        }

        private async Task<bool> SeatMustExist(List<int> ids, CancellationToken arg2)
        {
            var seats = await _unitOfWork.SeatRepository.GetAll();
            var seatIds = seats.Select(s => s.Id).ToList();
            return ids.All(id => seatIds.Contains(id));
        }

        private async Task<bool> SeatMustBeAvailable(List<int> ids, CancellationToken arg2)
        {
            var bookings = await _unitOfWork.BookingRepository.GetAll();
            var seatIds = bookings.SelectMany(b => b.SeatIds).ToList();
            return ids.All(id => !seatIds.Contains(id));
        }

        private async Task<bool> SeatsMustBeFromSameCinema(List<int> ids, CancellationToken arg2)
        {
            var seats = await _unitOfWork.SeatRepository.GetAll();
            var seatIds = seats.Select(s => s.Id).ToList();
            var bookings = await _unitOfWork.BookingRepository.GetAll();
            var seatIdsInBookings = bookings.SelectMany(b => b.SeatIds).ToList();
            var allSeatIds = seatIds.Concat(seatIdsInBookings).ToList();
            var seatsInCinema = seats.Where(s => s.Cinema.Id == ids[0]).Select(s => s.Id).ToList();
            return ids.All(id => seatsInCinema.Contains(id));
        }


    }
}
