using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class ISeatDtoValidation: AbstractValidator<ISeatDto>
    {
        public ISeatDtoValidation()
        {
            RuleFor(m => m.DateTime)
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.UtcNow).WithMessage("{PropertyName} is should greater than the current time.");
        }
    }
}
