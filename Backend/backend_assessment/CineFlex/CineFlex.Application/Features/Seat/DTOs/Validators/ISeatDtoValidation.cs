using FluentValidation;

namespace CineFlex.Application.Features.Seat.DTOs.Validators;

public class ISeatDtoValidator : AbstractValidator<ISeatDto>
{
    public ISeatDtoValidator()
    {
        RuleFor(m => m.SeatNumber)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(25).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        RuleFor(m => m.SeatType)
           .NotEmpty().WithMessage("{PropertyName} is required.")
           .NotNull();
        
        RuleFor(m => m.Availability)
                   .NotEmpty().WithMessage("{PropertyName} is required.")
                   .NotNull();
                  
    }
}