using FluentValidation;

namespace CineFlex.Application.Features.MoviesBooking.DTOs.Validators;

public class CreateMovieBookingDtoValidator : AbstractValidator<CreateMovieBookingDto>
    {
        public CreateMovieBookingDtoValidator()
        {
           // Include(new IMovieBookingDtoValidator());

        }
}
