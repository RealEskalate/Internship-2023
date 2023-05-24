using MBApp.Application.Features.Seats.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBApp.Application.Features.Seats.DTOs.Validators
{
    public class CreateSeatDtoValidator : AbstractValidator<CreateSeatDto>
    {
        public CreateSeatDtoValidator()
        {
            Include(new ISeatDtoValidator());

            RuleFor(p => p.CinemaId)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");
        }
    }

}