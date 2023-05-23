using FluentValidation;

namespace CineFlex.Application.Features.Seat.DTOs.Validators
{
    public class ISeatDtoValidator : AbstractValidator<ISeatDto>
    {
        public ISeatDtoValidator()
        {
            RuleFor(dto => dto.Row)
                .NotEmpty().WithMessage("Row is required.")
                .GreaterThan(0).WithMessage("Row must be greater than 0.");

            RuleFor(dto => dto.Number)
                .NotEmpty().WithMessage("Number is required.")
                .GreaterThan(0).WithMessage("Number must be greater than 0.");

            RuleFor(dto => dto.Level)
                .NotNull().WithMessage("Level is required.");

        }
    }
}
