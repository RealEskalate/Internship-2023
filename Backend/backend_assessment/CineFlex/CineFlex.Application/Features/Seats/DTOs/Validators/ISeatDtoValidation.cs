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
            RuleFor(m => m.SeatLocation)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
    }
}
