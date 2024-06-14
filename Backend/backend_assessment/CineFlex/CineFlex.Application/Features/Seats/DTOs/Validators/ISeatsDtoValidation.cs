using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class ISeatsDtoValidator : AbstractValidator<ISeatsDto>
    {
        public ISeatsDtoValidator()
        {
            
            RuleFor(m => m.SeatType)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(25).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            // RuleFor(m => m.ReleaseYear)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MaximumLength(4).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        }
    }
}
