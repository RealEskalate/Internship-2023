

using CineFlex.Application.Features.Seats.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class ISeatDtoValidator : AbstractValidator<ISeatDto>
    {
        public ISeatDtoValidator()
        {
            RuleFor(p => p.CinemaId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.SeatNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

        }
    }
}
