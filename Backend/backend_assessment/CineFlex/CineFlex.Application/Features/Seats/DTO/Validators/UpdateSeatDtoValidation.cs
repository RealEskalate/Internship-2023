namespace CineFlex.Application.Features.Seats.DTO.Validators;


public class UpdateSeatDtoValidator : AbstractValidator<SeatMovieDto>
    {
        public UpdateSeatDtoValidator()
        {
            Include(new ISeatDtoValidator());

            RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }

