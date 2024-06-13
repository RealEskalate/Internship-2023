using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.DTOs;
using FluentValidation;

namespace CineFlex.Application.Features.Bookings.DTOs.Validators;


public class CreateBookingDtoValidator: AbstractValidator<CreateBookingDto>
{
    public CreateBookingDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(m => m.Seat)
            .MustAsync(async (id, token) => await unitOfWork.SeatRepository.Exists(id)).WithMessage($"Seat not found"); 
        
        RuleFor(m => m.Seat)
            .MustAsync(async (id, token) => (await unitOfWork.SeatRepository.Get(id)).Taken == false).WithMessage($"Seat Taken");
    }
}