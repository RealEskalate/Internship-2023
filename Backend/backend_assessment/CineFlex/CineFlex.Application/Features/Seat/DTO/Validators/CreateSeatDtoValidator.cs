using CineFlex.Application.Features.Seat.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seat.DTO.Validators
{
    public class CreateSeatDtoValidator : AbstractValidator<CreateSeatDto>
    {
        public CreateSeatDtoValidator()
        {
            Include(new ISeatDtoValidator());

            RuleFor(p => p.SeatNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

        }

    }
}
