using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class UpdateSeatStatusDtoValidator : AbstractValidator<UpdateSeatStatusDto>
    {
        public UpdateSeatStatusDtoValidator()
        {
            RuleFor(p => p.Free)
             .Must((cmpld) => cmpld.GetType() == typeof(bool))
             .WithMessage("{ProperyName} must be boolean");

            RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
