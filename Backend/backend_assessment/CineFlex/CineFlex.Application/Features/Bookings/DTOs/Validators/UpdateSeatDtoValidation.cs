using CineFlex.Domain;
using FluentValidation;

namespace CineFlex.Application.Features.Bookings.DTOs.Validators
{
    public class UpdateBookingDtoValidator : AbstractValidator<UpdateBookingDto>
    {
        public UpdateBookingDtoValidator()
        {
            RuleFor(p => p.Seats)
           .Must(sts => sts.GetType() == typeof(ICollection<Seat>))
           .WithMessage("{ProperyName} must be Collection");

            RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
