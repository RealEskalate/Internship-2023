using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class UpdateSeatDtoValidator : AbstractValidator<UpdateSeatDto>
    {
        public UpdateSeatDtoValidator()
        {
            RuleFor(x => x.SeatNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(x => x.RowNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(x => x.lastBooked)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .LessThan(DateTime.Now).WithMessage("{PropertyName} must be less than today's date.");
        }
    }
}
