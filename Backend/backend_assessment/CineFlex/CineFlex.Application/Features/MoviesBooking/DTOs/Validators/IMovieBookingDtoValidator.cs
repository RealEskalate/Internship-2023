using FluentValidation;

namespace CineFlex.Application.Features.MoviesBooking.DTOs.Validators;

public class IMovieBookingDtoValidator : AbstractValidator<IMovieBookingDto>
    {
        public IMovieBookingDtoValidator()
        {
            RuleFor(dto => dto.MovieId).GreaterThan(0).WithMessage("MovieId must be greater than 0.");
            RuleFor(dto => dto.CinemaId).GreaterThan(0).WithMessage("CinemaId must be greater than 0.");
            RuleFor(dto => dto.Seats).Must(seats => seats != null && seats.Any()).WithMessage("Seats must not be null or empty.");
            RuleFor(dto => dto.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleFor(dto => dto.BookingDate).Must(BeAValidDate).WithMessage("BookingDate must be a valid date.");
        }

        private bool BeAValidDate(DateTime date)
        {
            // You can add custom date validation logic here if needed
            return date > DateTime.MinValue && date < DateTime.MaxValue;
        }
    }





