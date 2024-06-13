using FluentValidation;

namespace CineFlex.Application.Features.Seat.DTOs.Validators;

public class CreateSeatDtoValidator : AbstractValidator<CreateSeatDto>
{
    public CreateSeatDtoValidator()
    {
        // Include(new ISeatDtoValidator());
    }


}