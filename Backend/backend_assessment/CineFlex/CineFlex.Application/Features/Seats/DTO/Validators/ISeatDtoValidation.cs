namespace CineFlex.Application.Features.Seats.DTO.Validators;

 
  public class ISeatDtoValidator : AbstractValidator<ISeatDto>
    {
        public ISeatDtoValidator()
        {
            RuleFor(m => m.SeatNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
