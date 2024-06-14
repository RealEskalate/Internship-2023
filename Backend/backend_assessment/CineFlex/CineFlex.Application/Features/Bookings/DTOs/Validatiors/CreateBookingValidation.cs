using FluentValidation;

using CineFlex.Application.Features.Bookings.DTO;
using CineFlex.Domain.Common;
namespace CineFlex.Application.Features.Bookings.DTO.Validators;
public class BookingDTOValidator : AbstractValidator<CreateBookingDTO>
{
    public BookingDTOValidator()
    {
        RuleFor(dto => dto.MovieId).NotEmpty().WithMessage("Movie ID is required.");
        RuleFor(dto => dto.CinemaId).NotEmpty().WithMessage("Cinema ID is required.");
        RuleFor(dto => dto.UserId).NotEmpty().WithMessage("User ID is required.");
        RuleFor(dto => dto.Seats).NotEmpty().WithMessage("Seats details are required.");
        RuleFor(dto => dto.TimeSlot).NotEmpty().WithMessage("TimeSlot details are required.").Must(BeAValidTimeSlot).WithMessage("Invalid time slot.");
    }

    private bool BeAValidTimeSlot(TimeSlot timeSlot)
    {
        return Enum.IsDefined(typeof(TimeSlot), timeSlot);
    }
}
