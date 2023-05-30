using FluentValidation;

namespace CineFlex.Application.Features.MoviesBooking.DTOs.Validators;

public class UpdateMovieBookingDtoValidator : AbstractValidator<UpdateMovieBookingDto>
    {
        public UpdateMovieBookingDtoValidator()
        {
            Include(new IMovieBookingDtoValidator());

            RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");
        }

    internal Task ValidateAsync(object movieBookingDto)
    {
        throw new NotImplementedException();
    }
}
