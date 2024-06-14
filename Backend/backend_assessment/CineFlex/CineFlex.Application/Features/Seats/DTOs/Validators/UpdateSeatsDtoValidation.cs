using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Application.Features.Seats.DTOs.Validators
{
    public class UpdateSeatsDtoValidator : AbstractValidator<UpdateSeatsDto>
    {
        public UpdateSeatsDtoValidator()
        {
            Include(new ISeatsDtoValidator());

            RuleFor(m => m.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
