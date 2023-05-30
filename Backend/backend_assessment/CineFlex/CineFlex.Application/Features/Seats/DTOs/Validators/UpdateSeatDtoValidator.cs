using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators;

public class UpdateSeatDtoValidator : AbstractValidator<UpdateSeatDto>
    {
        public UpdateSeatDtoValidator()
        {
            Include(new ISeatDtoValidator());
            RuleFor(s => s.Id).NotNull().WithMessage("{PropertyName} must be present");

        }
    }
