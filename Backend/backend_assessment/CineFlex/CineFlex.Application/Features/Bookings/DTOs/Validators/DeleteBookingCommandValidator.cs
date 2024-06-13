using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Bookings.CQRS.Requests.Commands;
using CineFlex.Application.Features.Bookings.CQRS.Requests.Queries;
using FluentValidation;

namespace CineFlex.Application.Features.Bookings.DTOs.Validators;

public class DeleteBookingCommandValidator: AbstractValidator<DeleteBookingCommand>
{
    public DeleteBookingCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(m => m.Id)
            .MustAsync(async (id, token) => await unitOfWork.BookingRepository.Exists(id)).WithMessage($"Booking not found"); 
        
    }
}