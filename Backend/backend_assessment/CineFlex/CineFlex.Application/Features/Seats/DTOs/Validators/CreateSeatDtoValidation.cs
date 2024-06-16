using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators;

public class CreateSeatDtoValidation : AbstractValidator<CreateSeatDto>
{
    public CreateSeatDtoValidation()
    {
        Include(new ISeatDtoValidation());
    }
}