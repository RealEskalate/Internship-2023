using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace CineFlex.Application.Features.Seats.DTO.Validators
{
    public class ISeatDtoValidator : AbstractValidator<ISeatDto>
    {
        public ISeatDtoValidator()
        {
            RuleFor(p => p.SeatNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();


            RuleFor(p => p.IsBookeed)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

        }
    }
}