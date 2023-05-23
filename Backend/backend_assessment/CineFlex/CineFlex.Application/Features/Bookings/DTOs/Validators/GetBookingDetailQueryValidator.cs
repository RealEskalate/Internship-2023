using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Requests.Queries;
using FluentValidation;

namespace CineFlex.Application.Features.Bookings.DTOs.Validators;

public class GetBookingDetailQueryValidator: AbstractValidator<GetBookingDetailQuery>
{
    public GetBookingDetailQueryValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(m => m.Id)
            .MustAsync(async (id, token) => await unitOfWork.BookingRepository.Exists(id)).WithMessage($"Booking not found"); 
        
    }
}