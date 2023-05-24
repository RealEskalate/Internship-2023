using MBApp.Application.Features.Seats.DTOs.Validators;
using FluentValidation;

namespace MBApp.Application.Features.Seats.DTOs.Validators
{
    public class UpdateSeatDtoValidator : AbstractValidator<UpdateSeatDto>
    {
        public UpdateSeatDtoValidator()
        {
            Include(new ISeatDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");

        }

    }
}