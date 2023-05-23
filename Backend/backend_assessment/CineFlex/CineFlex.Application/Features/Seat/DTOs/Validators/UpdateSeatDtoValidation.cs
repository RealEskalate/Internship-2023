using FluentValidation;

namespace CineFlex.Application.Features.Seat.DTOs.Validators;

public class UpdateSeatDtoValidator: AbstractValidator<UpdateSeatDto>
{
    public UpdateSeatDtoValidator()
    {
        // Include(new ISeatDtoValidator());

        // RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
