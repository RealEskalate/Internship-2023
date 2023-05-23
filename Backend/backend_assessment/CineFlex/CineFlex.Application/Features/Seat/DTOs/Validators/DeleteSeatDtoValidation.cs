using CineFlex.Application.Features.Common;
using FluentValidation;

namespace CineFlex.Application.Features.Seat.DTOs.Validators;

public class DeleteSeatDtoValidator: AbstractValidator<DeleteSeatDto>
{
    public DeleteSeatDtoValidator()
    {
        // Include(new ISeatDtoValidator());
    }
}