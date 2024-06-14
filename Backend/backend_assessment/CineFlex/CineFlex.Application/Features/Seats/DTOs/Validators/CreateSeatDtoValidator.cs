using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class CreateSeatDtoValidator : AbstractValidator<CreateSeatDto>
    {
        public CreateSeatDtoValidator()
        {
            RuleFor(x => x.SeatNumber).NotEmpty().WithMessage("SeatNumber is required.");
            RuleFor(x => x.RowNumber).NotEmpty().WithMessage("RowNumber is required.");
            RuleFor(x => x.lastBooked)
                .NotEmpty().WithMessage("lastBooked is required.")
                .LessThan(DateTime.Now).WithMessage("lastBooked must be less than DateTime.Now");
        }
    }
}
