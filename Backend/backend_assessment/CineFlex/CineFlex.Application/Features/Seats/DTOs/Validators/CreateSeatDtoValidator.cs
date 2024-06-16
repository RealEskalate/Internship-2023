using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTOs.Validators;

public class CreateSeatDtoValidator : AbstractValidator<CreateSeatDto>
    {
        public CreateSeatDtoValidator()
        {
            Include(new ISeatDtoValidator());
        }
    }