using CineFlex.Application.Contracts.Persistence;
using CineFlex.Application.Features.Seats.DTOs;
using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators;

public class UpdateSeatDtoValidator: AbstractValidator<UpdateSeatDto>
{
    public UpdateSeatDtoValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(m => m.Id)
            .MustAsync(async (id, token) => await unitOfWork.SeatRepository.Exists(id)).WithMessage($"Seat not found");
    }
}