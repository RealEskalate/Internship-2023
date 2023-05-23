using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class ISeatDtoValidator : AbstractValidator<ISeatDto>
    {
        public ISeatDtoValidator()
        {
            RuleFor(m => m.SeatNo)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}.");

            RuleFor(p => p.Free)
                .Must((cmpld) => cmpld.GetType() == typeof(bool))
                .WithMessage("{ProperyName} must be boolean");

        }
    }
}
