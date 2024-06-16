using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators;

public class ISeatDtoValidation : AbstractValidator<ISeatDto>
{
    public ISeatDtoValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters.")
            .MaximumLength(5).WithMessage("Name must not exceed 5 characters.");
    }
}