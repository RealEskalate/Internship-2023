using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators;

public class ISeatDtoValidator : AbstractValidator<ISeatDto>
    {
        public ISeatDtoValidator()
        {
            RuleFor(s => s.SeatNumber)
                .GreaterThan(0)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }



