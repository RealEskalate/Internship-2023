using CineFlex.Application.Features.Common;
using FluentValidation;

namespace CineFlex.Application.Features.Seat.DTOs.Validators;

public class DeleteSeatDtoValidator: AbstractValidator<BaseDto>
{
    public DeleteSeatDtoValidator()
    {
        // Include(new ISeatDtoValidator());
    }
}